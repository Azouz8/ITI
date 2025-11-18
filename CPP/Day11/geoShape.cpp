#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;
class GeoShape
{
protected:
    float dim1, dim2;

public:
    GeoShape() = default;
    GeoShape(float d) : dim1(d), dim2(d) {}
    GeoShape(float d1, float d2) : dim1(d1), dim2(d2) {}
    float getDim1()
    {
        return dim1;
    }
    float getDim2()
    {
        return dim2;
    }
    virtual float calcArea() = 0;
    virtual float calcPerimeter() = 0;
    virtual void printDims() = 0;
    virtual void getShapeName() = 0;
};

class Rect : public GeoShape
{
public:
    Rect(float w, float h) : GeoShape(w, h) {}
    void getShapeName() override
    {
        cout << "Rectangle" << endl;
    }
    float calcArea() override
    {
        return dim1 * dim2;
    }
    float calcPerimeter() override
    {
        return 2 * (dim1 + dim2);
    }
    void printDims() override
    {
        cout << "Width: " << dim1 << endl;
        cout << "Height: " << dim2 << endl;
    }
    Rect operator=(const Rect &r)
    {
        dim1 = r.dim1;
        dim2 = r.dim2;
    }
};
class Square : public GeoShape
{
public:
    Square(float side) : GeoShape(side) {}
    void getShapeName() override
    {
        cout << "Square" << endl;
    }
    float calcArea() override
    {
        return dim1 * dim2;
    }
    float calcPerimeter() override
    {
        return 4 * dim1;
    }
    void printDims() override
    {
        cout << "Side: " << dim1 << endl;
    }
    Square operator=(const Square &s)
    {
        dim1 = s.dim1;
        dim2 = s.dim2;
    }
};
class Triangle : public GeoShape
{
    float side1, side2;

public:
    Triangle(float base, float height, float side1, float side2)
        : GeoShape(base, height), side1(side1), side2(side2) {}
    void getShapeName() override
    {
        cout << "Triangle" << endl;
    }
    float calcArea() override
    {
        return 0.5 * dim1 * dim2;
    }
    float calcPerimeter() override
    {
        return dim1 + side1 + side2;
    }
    void printDims() override
    {
        cout << "Base: " << dim1 << endl;
        cout << "Height: " << dim2 << endl;
        cout << "Side 1: " << side1 << endl;
        cout << "Side 2: " << side2 << endl;
    }
    Triangle operator=(const Triangle &t)
    {
        dim1 = t.dim1;
        dim2 = t.dim2;
        side1 = t.side1;
        side2 = t.side2;
    }
};
class Circle : public GeoShape
{
public:
    Circle(float radius)
        : GeoShape(radius) {}
    void getShapeName() override
    {
        cout << "Circle" << endl;
    }
    float calcArea() override
    {
        return 3.14 * dim1 * dim2;
    }
    float calcPerimeter() override
    {
        return 2 * 3.14 * dim1;
    }
    void printDims() override
    {
        cout << "Radius: " << dim1 << endl;
    }
    Circle operator=(const Circle &c)
    {
        dim1 = c.dim1;
    }
};
class Cube : public Square
{

public:
    Cube(float side) : Square(side) {}
    void getShapeName() override
    {
        cout << "Cube" << endl;
    }
    float calcArea() override
    {
        return 6 * (Square::calcArea());
    }
    float calcPerimeter() override
    {
        return 6 * (Square::calcPerimeter());
    }
    Cube operator=(const Cube &c)
    {
        Square::operator=(c);
    }
};

bool compare(GeoShape *sh1, GeoShape *sh2)
{
    return sh1->calcArea() > sh2->calcArea();
}

int main()
{
    vector<GeoShape *> shapes;
    shapes.push_back(new Rect(4, 5));
    shapes.push_back(new Square(6));
    shapes.push_back(new Triangle(3, 4, 5, 6));
    shapes.push_back(new Circle(7));
    shapes.push_back(new Cube(2));
    sort(shapes.begin(), shapes.end(), compare);
    for (auto shape : shapes)
    {
        shape->getShapeName();
        shape->printDims();
        cout << "Area: " << shape->calcArea() << endl;
        cout << "Perimeter: " << shape->calcPerimeter() << endl;
        cout << "------------------------" << endl;
    }
}