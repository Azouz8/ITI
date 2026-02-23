namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int x, y, z;

            //Console.Write($"Enter X of P1: ");
            //x = int.Parse(Console.ReadLine());
            //Console.Write($"Enter Y of P1: ");
            //y = int.Parse(Console.ReadLine());
            //Console.Write($"Enter Z of P1: ");
            //z = int.Parse(Console.ReadLine());
            //Point p1 = new Point(x, y, z);
            //Console.Write($"Enter X of P2: ");
            //x = int.Parse(Console.ReadLine());
            //Console.Write($"Enter Y of P2: ");
            //y = int.Parse(Console.ReadLine());
            //Console.Write($"Enter Z of P2: ");
            //z = int.Parse(Console.ReadLine());
            //Point p2 = new Point(x, y, z);

            //Console.WriteLine(p1.ToString());
            //Console.WriteLine(p2.ToString());
            //Console.WriteLine(p1 == p2);

            //Point[] points = { new Point(3, 2, 3), new Point(2, 5, 4), new Point(2, 3, 6) };
            //Point.sortPoints(ref points);
            //for (int i = 0; i < points.Length; i++)
            //{
            //    Console.WriteLine(points[i].ToString());
            //}
            //Console.WriteLine("------ Math ------");
            //Console.WriteLine(Math.add(2, 5));
            //Console.WriteLine(Math.subtract(2, 5));

            //Console.WriteLine(Math.multiply(2, 5));

            //Console.WriteLine(Math.divide(2, 5));

            //Console.WriteLine("------ NIC ------");
            //NIC nic = new NIC("Lenovo", "AA:BB:CC:DD", Type.ethernet);
            //Console.WriteLine(nic.ToString());

            Console.WriteLine("------ Duration ------");
            Duration D1 = new(1, 2, 55);
            Console.WriteLine(D1.ToString());
            Duration D2 = new(7823);
            Console.WriteLine(D2.ToString());
            Duration D3 = D1 + D2;
            Console.WriteLine(D3.ToString());
            D3 = 666 + D3;
            Console.WriteLine(D3.ToString());
            D3 = ++D1;
            Console.WriteLine(D3.ToString());
            D3 = --D2;
            Console.WriteLine(D3.ToString());
            if (D1 > D2)
            {
                Console.WriteLine("D1 is bigger");
            }
            if (D1 <= D2)
            {
                Console.WriteLine("D2 is bigger");
            }
            if (D1)
            {
                Console.WriteLine("D1 is not Zero");
            }

        }
    }
}
