using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Lab
{
    internal class Q3
    {
        static void Main(string[] args)
        {
            //CASE 1
            int count = 0;
            int num = 1;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (num < 99999999)
            {
                string s = num.ToString();
                count += s.Count('1');
                num++;
            }
            stopwatch.Stop();
            Console.WriteLine("Count = " + count);
            Console.WriteLine("Time Elapsed = " + stopwatch.Elapsed);
            stopwatch.Reset();

            //CASE 2
            int count2 = 0;
            int num2;

            stopwatch.Start();
            for (int i = 0; i < 99999999; i++)
            {
                num2 = i;
                while (num2 > 0)
                {
                    int digit = num2 % 10;
                    if (digit == 1)
                    {
                        count2++;
                    }
                    num2 /= 10;
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Count = " + count2);
            Console.WriteLine("Time Elapsed = " + stopwatch.Elapsed);
            stopwatch.Reset();
            //CASE 3
            int noOfDigits = 8;
            stopwatch.Start();
            double noOfOccurencesPerDigit = Math.Pow(10, 8 - 1);
            double noOfTotalOccurences = noOfOccurencesPerDigit * noOfDigits;
            stopwatch.Stop();
            Console.WriteLine("Count = " + noOfTotalOccurences);
            Console.WriteLine("Time Elapsed = " + stopwatch.Elapsed);
        }
    }
}
