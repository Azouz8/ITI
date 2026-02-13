//namespace Lab
//{
//    internal class Q1
//    {
//        static void Main(string[] args)
//        {
//            int size;
//            size = int.Parse(Console.ReadLine());
//            int[] arr;
//            arr = new int[size];
//            for (int i = 0; i < size; i++)
//            {
//                arr[i] = int.Parse(Console.ReadLine());
//            }
//            int maxDis = 0;
//            for (int i = 0; i < size; i++)
//            {
//                for (int j = i + 1; j < size; j++)
//                {
//                    if (arr[i] == arr[j] && (j - i - 1) > maxDis)
//                    {
//                        maxDis = j - i - 1;
//                    }
//                }
//            }
//            Console.WriteLine($"The max Distance is {maxDis}");
//        }
//    }
//}
