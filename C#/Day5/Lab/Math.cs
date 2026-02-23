using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal class Math
    {
        public static int add(int x, int y)
        {
            return x + y;
        }
        public static int subtract(int x, int y)
        {
            return x - y;
        }
        public static int divide(int x, int y)
        {
            return y == 0 ? 0 : x / y;
        }
        public static int multiply(int x, int y)
        {
            return x * y;
        }
    }
}
