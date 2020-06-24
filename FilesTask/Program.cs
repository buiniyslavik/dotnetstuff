using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilesTask
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string p in new List<String>{"K1", "K2", "All" })
            {
                if (Directory.Exists(p))
                    Directory.Delete(p, true);
            }

            string txt1 = "Иванов Иван Иванович, 2000 года рождения, место жительства г. Рязань";
            string txt2 = "Петров Сергей Федорович, 2002 года рождения, место жительства г. Бежицк";
            Directory.CreateDirectory("K1");
            Directory.CreateDirectory("K2");
            using (StreamWriter sw = File.CreateText("K1/t1.txt"))
            {
                sw.WriteLine(txt1);
            }
            using (StreamWriter sw = File.CreateText("K1/t2.txt"))
            {
                sw.WriteLine(txt2);
            }
            using(StreamWriter s1 = File.CreateText("K2/t3.txt"))
            {
                foreach(string s in File.ReadAllLines("K1/t1.txt"))
                    s1.WriteLine(s);
                foreach (string s in File.ReadAllLines("K1/t2.txt"))
                    s1.WriteLine(s);
            }

            foreach (string p in new List<String> { "K1/t1.txt", "K1/t2.txt" , "K2/t3.txt" })
            {
                var f = new FileInfo(p);
                Console.WriteLine($"Filename: {f.Name}\n" +
                    $"Directory: {f.DirectoryName}\n" +
                    $"Size: {f.Length} bytes\n" +
                    $"----------------------\n");
            }
            Console.ReadKey();

            File.Move("K1/t2.txt", "K2/t2.txt");
            File.Copy("K1/t1.txt", "K2/t1.txt");

            if (Directory.Exists("All"))
                Directory.Delete("All", true);

            Directory.Move("K2", "All");
            Directory.Delete("K1", true);

            foreach(string p in Directory.EnumerateFiles("All/"))
            {
                var f = new FileInfo(p);
                Console.WriteLine($"Filename: {f.Name}\n" +
                    $"Directory: {f.DirectoryName}\n" +
                    $"Size: {f.Length} bytes\n\n");
            }
            Console.ReadKey();
        }
    }
}
