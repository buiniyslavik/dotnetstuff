using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task4_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var workers = new List<Person>
            {
                new Person("Андреев"),
                new Person("Иванов"),
                new Person("Колосов"),
                new Person("Петров"),
                new Person("Сидоров")
            };


            Office office = new Office(workers);
            foreach (Person p in workers)
            {
                p.GoToOffice();
                Thread.Sleep(1000);
            }
            workers[2].GoHome();
            workers[2].GoToOffice();

            foreach (Person p in workers)
            {
                p.GoHome();
                Thread.Sleep(1000);
            }
            Thread.Sleep(10000);
        }
}
}
