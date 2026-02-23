using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal class Point(int X, int Y, int Z)
    {
        public int X { get; } = X;
        public int Y { get; } = Y;
        public int Z { get; } = Z;

        public Point(int x, int y) : this(x, y, 0) { }
        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Point other)
            {
                return X == other.X &&
                       Y == other.Y &&
                       Z == other.Z;
            }
            return false;
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }
        public static void sortPoints(ref Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (points[i].X == points[j].X)
                    {
                        if (points[i].Y > points[j].Y)
                        {
                            Point temp = points[i];
                            points[i] = points[j];
                            points[j] = temp;
                        }
                    }
                    else if (points[i].X > points[j].X)
                    {
                        Point temp = points[i];
                        points[i] = points[j];
                        points[j] = temp;
                    }
                }
            }
        }
    }
}
