#include <iostream>
#include <vector>
#include <list>
#include <functional>
#include <algorithm>
#include <queue>
#include <climits>
using namespace std;

template <class VertexType>
class Graph
{
    int verticesNo;
    VertexType vertices[5];
    int edges[5][5];
    bool isMarked[5];

public:
    explicit Graph() : verticesNo(0)
    {
        clearGraph();
    }
    void clearGraph()
    {
        verticesNo = 0;
        for (int i = 0; i < 5; i++)
        {
            isMarked[i] = false;
            for (int j = 0; j < 5; j++)
            {
                edges[i][j] = 0;
            }
        }
    }
    bool isEmpty()
    {
        return verticesNo == 0;
    }
    bool isFull()
    {
        return verticesNo == 5;
    }
    void addVertex(const VertexType &vertex)
    {
        if (isFull())
            return;
        vertices[verticesNo++] = vertex;
    }
    int getVertexIndex(const VertexType &vertex)
    {
        for (int i = 0; i < verticesNo; i++)
        {
            if (vertices[i] == vertex)
            {
                return i;
            }
        }
        return -1;
    }
    void addEdge(const VertexType &fromV, const VertexType &toV, int weight)
    {
        int fromVIndex = getVertexIndex(fromV);
        int toVIndex = getVertexIndex(toV);
        if (fromVIndex == -1 || toVIndex == -1)
            return;
        edges[fromVIndex][toVIndex] = weight;
    }

    int getPathWeight(const VertexType &fromVertex, const VertexType &toVertex)
    {
        int startNode = getVertexIndex(fromVertex);
        int targetNode = getVertexIndex(toVertex);

        if (startNode == -1 || targetNode == -1)
            return -1;
        if (startNode == targetNode)
            return 0;

        vector<int> minWeightToNode(verticesNo, INT_MAX);

        priority_queue<pair<int, int>, vector<pair<int, int>>, greater<pair<int, int>>> discoveryQueue;

        minWeightToNode[startNode] = 0;
        discoveryQueue.push({0, startNode});

        while (!discoveryQueue.empty())
        {
            int currentPathWeight = discoveryQueue.top().first;
            int currentNodeIdx = discoveryQueue.top().second;
            discoveryQueue.pop();

            if (currentPathWeight > minWeightToNode[currentNodeIdx])
                continue;

            if (currentNodeIdx == targetNode)
                return minWeightToNode[targetNode];

            for (int neighborIdx = 0; neighborIdx < verticesNo; neighborIdx++)
            {
                int edgeWeight = edges[currentNodeIdx][neighborIdx];

                if (edgeWeight != 0)
                {
                    int newCalculatedWeight = minWeightToNode[currentNodeIdx] + edgeWeight;

                    if (newCalculatedWeight < minWeightToNode[neighborIdx])
                    {
                        minWeightToNode[neighborIdx] = newCalculatedWeight;
                        discoveryQueue.push({newCalculatedWeight, neighborIdx});
                    }
                }
            }
        }

        return (minWeightToNode[targetNode] == INT_MAX) ? -1 : minWeightToNode[targetNode];
    }

    void getAdjacentVertices(const VertexType &vertex, queue<VertexType> &adjVQ)
    {
        int vertexIndex = getVertexIndex(vertex);
        if (vertexIndex == -1)
            return;
        for (int i = 0; i < verticesNo; i++)
        {
            if (edges[vertexIndex][i] != 0)
            {
                adjVQ.push(vertices[i]);
            }
        }
    }
    void clearAllMarks()
    {
        for (int i = 0; i < 5; i++)
        {
            isMarked[i] = false;
        }
    }
    void markVertex(VertexType &vertex)
    {
        int vertexIndex = getVertexIndex(vertex);
        if (vertexIndex == -1)
            return;
        isMarked[vertexIndex] = true;
    }
    bool isVertexMarked(VertexType vertex)
    {
        int vertexIndex = getVertexIndex(vertex);
        if (vertexIndex == -1)
            return false;

        return isMarked[vertexIndex];
    }
    void bfs(const VertexType &startVertex)
    {
        int startIdx = getVertexIndex(startVertex);
        if (startIdx == -1)
            return;

        clearAllMarks();
        queue<int> traversalQueue;

        isMarked[startIdx] = true;
        traversalQueue.push(startIdx);

        cout << "BFS Traversal: ";

        while (!traversalQueue.empty())
        {
            int currentIdx = traversalQueue.front();
            traversalQueue.pop();

            cout << vertices[currentIdx] << " ";

            for (int neighborIdx = 0; neighborIdx < verticesNo; neighborIdx++)
            {
                if (edges[currentIdx][neighborIdx] != 0 && !isMarked[neighborIdx])
                {
                    isMarked[neighborIdx] = true;
                    traversalQueue.push(neighborIdx);
                }
            }
        }
        cout << endl;
    }
};

int main()
{
    Graph<string> travelMap;

    travelMap.addVertex("Cairo");
    travelMap.addVertex("Alexandria");
    travelMap.addVertex("Giza");
    travelMap.addVertex("Suez");
    travelMap.addVertex("Aswan");

    travelMap.addEdge("Cairo", "Alexandria", 220);
    travelMap.addEdge("Cairo", "Giza", 20);
    travelMap.addEdge("Giza", "Suez", 130);
    travelMap.addEdge("Alexandria", "Aswan", 1000);
    travelMap.addEdge("Suez", "Aswan", 800);

    travelMap.bfs("Cairo");

    cout << "Weight Cairo -> Giza: " << travelMap.getPathWeight("Cairo", "Giza") << endl;

    int totalWeight = travelMap.getPathWeight("Cairo", "Aswan");
    cout << "Shortest Weight Cairo -> Aswan: " << totalWeight << endl;
}