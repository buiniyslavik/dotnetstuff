using System;

namespace Task2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = new DynamicArray<int>();
            a.Add(111);
            //Console.WriteLine(a[0]);
            int[] arr = new int[7] { 1111111, 111111, 11111, 1111, 111, 11, 1 };
            a.AddRange(arr);
            //for (int i = 0; i < a.Capacity; i++)
            //    Console.Write(a[i] + " ");
            //a.Remove(1);
            //Console.WriteLine();
            //for (int i = 0; i < a.Capacity; i++)
            //    Console.Write(a[i] + " ");
            //a.Insert(1, 1);
            //Console.WriteLine();

            a.Sort((t1, t2) =>
            {
                string s1 = t1.ToString();
                string s2 = t2.ToString();
                if (s1.Length == s2.Length)
                    return 0;
                else if (s1.Length > s2.Length)
                    return 1;
                else
                    return -1;
            });
            for (int i = 0; i < a.Capacity; i++)
                Console.Write(a[i] + " ");
            a.FilterD((o) => o > 4);
            Console.WriteLine();
            for (int i = 0; i < a.Capacity; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
            ///////////////////////////////////////////////////////////////////////////
            var d = new DynamicArray<double>();
            double[] arrD = new double[7] { 8.1, 4.9, 6.05, 1.2, 14.4, 7.542, 0.22 };
            d.AddRange(arrD);
            for (int i = 0; i < d.Capacity; i++)
                Console.Write(d[i] + " ");
            Console.WriteLine();
            d.Sort(DynamicArray<double>.Comparator);
            for (int i = 0; i < d.Capacity; i++)
                Console.Write(d[i] + " ");
            d.Filter((o) => o > 4.2);
            Console.WriteLine();
            for (int i = 0; i < d.Capacity; i++)
                Console.Write(d[i] + " ");
        }
    }
}