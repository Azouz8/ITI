//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Lab
//{
//    internal class Q4
//    {
//        static void Main(string[] args)
//        {
//            float budget = float.Parse(Console.ReadLine());
//            float bagVolume = float.Parse(Console.ReadLine());
//            int people = int.Parse(Console.ReadLine());
//            int nPresents = int.Parse(Console.ReadLine());
//            float[] presentVolume = new float[nPresents];
//            float[] presentPrice = new float[nPresents];
//            for (int i = 0; i < nPresents; i++)
//            {
//                Console.Write("Enter Present Volume No. " + i + 1);
//                presentVolume[i] = float.Parse(Console.ReadLine());
//                Console.Write("Enter Present Price No. " + i + 1);
//                presentPrice[i] = float.Parse(Console.ReadLine());
//            }
//            PresentList(budget, bagVolume, people, nPresents, presentVolume, presentPrice);

//        }
//        public static float PresentList(float budget, float bagVolume, int people, int
//                                        nPresents, float[] presentVolume, float[] presentPrice)
//        {
//            int noOfPresToBuy = (nPresents / people) * people;
//            for (int i = 0; i < nPresents; i++)
//            {
//                for (int j = i + 1; j < nPresents; j++)
//                {
//                    if (presentPrice[j] < presentPrice[i])
//                    {
//                        float temp = presentPrice[i];
//                        presentPrice[i] = presentPrice[j];
//                        presentPrice[j] = temp;
//                        float temp2 = presentVolume[i];
//                        presentVolume[i] = presentVolume[j];
//                        presentVolume[j] = temp2;
//                    }
//                }
//            }
//            //for (int i = 0; i < nPresents; i++)
//            //{
//            //    Console.WriteLine("PresentVolume of " + i + " : " + presentVolume[i] + " -- PresentPrice of " + i + " : " + presentPrice[i]);
//            //}
//            bool flag = true;
//            int shiftIndex = 1;
//            while (flag)
//            {
//                float tempPrice = 0, tempVol = 0;
//                for (int i = 0; i < noOfPresToBuy; i++)
//                {
//                    //Console.WriteLine("PresentPrisdsadce of  : " + noOfPresToBuy);
//                    //Console.WriteLine("PresentPrice of  : " + presentPrice[^(i + shiftIndex)]);
//                    //Console.WriteLine("PresentVolume of : " + presentVolume[^(i + shiftIndex)]);
//                    tempPrice += presentPrice[^(i + shiftIndex)];
//                    tempVol += presentVolume[^(i + shiftIndex)];
//                }
//                if (tempVol <= bagVolume && tempPrice <= budget)
//                {
//                    Console.WriteLine("TOTAL Price  : " + tempPrice);
//                    Console.WriteLine("TOTAL Volume : " + tempVol);
//                    flag = false;
//                }
//                else if (shiftIndex + noOfPresToBuy > nPresents)
//                {
//                    noOfPresToBuy /= 2;
//                }
//                else
//                {
//                    shiftIndex++;
//                }
//            }
//            return 1;
//        }

//    }

//}
