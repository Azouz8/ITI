#include "SimpleGraphics.h"
#include <iostream>
using namespace std;

class Point
{
    int x{}, y{};

public:
    Point(int a, int b) : x(a), y(b) {}
    int getX()
    {
        return x;
    }
    int getY()
    {
        return y;
    }
};

class Circle
{
    Point center;
    int radius;

public:
    Circle(int x, int y, int r) : center(x, y), radius(r) {}
    void draw()
    {
        drawCircle(center.getX(), center.getY(), radius);
    }
};

class Rectangle
{
    Point upLeft, lowRight;

public:
    Rectangle(int x1, int y1, int x2, int y2) : upLeft(x1, y1), lowRight(x2, y2) {}
    void draw()
    {
        drawRect(upLeft.getX(), upLeft.getY(), lowRight.getX(), lowRight.getY());
    }
};
class Line
{
    Point start, end;

public:
    Line(int x1, int y1, int x2, int y2) : start(x1, y1), end(x2, y2) {}
    void draw()
    {
        drawLine(start.getX(), start.getY(), end.getX(), end.getY());
    }
};
class Triangle
{
    Point a, b, c;

public:
    Triangle(int x1, int y1, int x2, int y2, int x3, int y3) : a(x1, y1), b(x2, y2), c(x3, y3) {}
    void draw()
    {
        drawTriangle(a.getX(), a.getY(), b.getX(), b.getY(), c.getX(), c.getY());
    }
};
class Ellipse
{
    Point a, b;
    int r;

public:
    Ellipse(int x1, int y1, int x2, int y2, int r) : a(x1, y1), b(x2, y2), r(r)
    {
    }
    void draw()
    {
        // cout << "x1:" << a.getX() << " y1:" << a.getY() << " x2:" << b.getX() << " y2:" << b.getY() << " r:" << r << endl;
        drawEllipse(a.getX(), a.getY(), b.getX(), b.getY(), r);
    }
};
class Picture
{
    Circle **circles;
    Rectangle **rectangles;
    Line **lines;
    Triangle **triangles;
    Ellipse **ellipses;
    int circleCount, rectangleCount, lineCount, triangleCount, ellipseCount;

public:
    Picture(Circle **c, int cCount, Rectangle **r, int rCount, Line **l, int lCount, Triangle **t, int tCount, Ellipse **e, int eCount)
        : circles(c), circleCount(cCount), rectangles(r), rectangleCount(rCount), lines(l), lineCount(lCount), triangles(t), triangleCount(tCount), ellipses(e), ellipseCount(eCount)
    {
    }
    void draw()
    {
        for (int i = 0; i < circleCount; i++)
        {
            circles[i]->draw();
        }
        for (int i = 0; i < rectangleCount; i++)
        {
            rectangles[i]->draw();
        }
        for (int i = 0; i < lineCount; i++)
        {
            lines[i]->draw();
        }
        for (int i = 0; i < triangleCount; i++)
        {
            triangles[i]->draw();
        }
        for (int i = 0; i < ellipseCount; i++)
        {
            ellipses[i]->draw();
        }
    }
};
int main()
{
    int circleNo, rectNo, lineNo, triNo;
    cout << "Enter number of circles: ";
    cin >> circleNo;
    Circle *circles[circleNo];
    if (circleNo > 0)
    {

        for (int i = 0; i < circleNo; i++)
        {
            int x, y, r;
            cout << "Enter circle " << i + 1 << " (x y r): ";
            cin >> x >> y >> r;
            circles[i] = new Circle(x, y, r);
        }
    }
    cout << "Enter number of rectangles: ";
    cin >> rectNo;
    Rectangle *rectangles[rectNo];
    if (rectNo > 0)
    {
        for (int i = 0; i < rectNo; i++)
        {
            int x1, y1, x2, y2;
            cout << "Enter rectangle " << i + 1 << " (x1 y1 x2 y2): ";
            cin >> x1 >> y1 >> x2 >> y2;
            rectangles[i] = new Rectangle(x1, y1, x2, y2);
        }
    }
    cout << "Enter number of lines: ";
    cin >> lineNo;
    Line *lines[lineNo];
    if (lineNo > 0)
    {
        for (int i = 0; i < lineNo; i++)
        {
            int x1, y1, x2, y2;
            cout << "Enter line " << i + 1 << " (x1 y1 x2 y2): ";
            cin >> x1 >> y1 >> x2 >> y2;
            lines[i] = new Line(x1, y1, x2, y2);
        }
    }
    cout << "Enter number of triangles: ";
    cin >> triNo;
    Triangle *triangles[triNo];
    if (triNo > 0)
    {
        for (int i = 0; i < triNo; i++)
        {
            int x1, y1, x2, y2, x3, y3;
            cout << "Enter triangle " << i + 1 << " (x1 y1 x2 y2 x3 y3): ";
            cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3;
            triangles[i] = new Triangle(x1, y1, x2, y2, x3, y3);
        }
    }
    cout << "Enter number of ellipses: ";
    int ellipseNo;
    cin >> ellipseNo;
    Ellipse *ellipses[ellipseNo];
    if (ellipseNo > 0)
    {
        for (int i = 0; i < ellipseNo; i++)
        {
            int x1, y1, x2, y2, r;
            cout << "Enter ellipse " << i + 1 << " (x1 y1 x2 y2 r): ";
            cin >> x1 >> y1 >> x2 >> y2 >> r;
            ellipses[i] = new Ellipse(x1, y1, x2, y2, r);
        }
    }

    initScreen(); // initialize ASCII screen
    // Student Code Below
    Picture pic(circles, circleNo, rectangles, rectNo, lines, lineNo, triangles, triNo, ellipses, ellipseNo);
    pic.draw();
    // Show screen
    renderScreen();
    int x;
    cin >> x;
}