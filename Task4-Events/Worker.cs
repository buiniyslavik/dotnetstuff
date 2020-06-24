using System;
using System.Collections.Generic;
using System.Text;

namespace Task4_Events
{
    public class Person
    {
        public string Name
        {
            get;
        }
        public Person(string name)
        {
            Name = name;
        }

        public delegate void PersonCameEventHandler(Person person, DateTime time);
        public event PersonCameEventHandler OnCame;
        public void GoToOffice()
        {
            OnCame?.Invoke(this, DateTime.Now);
        }

        public delegate void PersonLeaveEventHandler(Person person);
        public event PersonLeaveEventHandler Onleave;
        public void GoHome()
        {
            Onleave?.Invoke(this);
        }

        public void SayHello(string person, DateTime time)
        {

            var morning = TimeSpan.Parse("09:00");
            var day = TimeSpan.Parse("12:00");
            var evening = TimeSpan.Parse("17:00");
            string toSay = string.Empty;
            //если оба операнда дадут true
            if (time.TimeOfDay > morning && time.TimeOfDay < day)
            {
                toSay = "Доброе утро";
            }
            if (time.TimeOfDay > day && time.TimeOfDay < evening)
            {
                toSay = "Добрый день";
            }
            if (time.TimeOfDay >= evening)
            {
                toSay = "Добрый вечер";
            }
            Console.WriteLine("{0}, {1} ,сказал - {2}", toSay, person, this.Name);
        }

        public void SayBye(string person)
        {
            Console.WriteLine("До свидания, {0}, - сказал {1}", person, this.Name);
        }

    }
    public delegate void SayHello(string person, DateTime time);
    public delegate void SayBye(string name);


    public class Office
    {
        private SayHello hello;
        private SayBye bye;
        public Office(List<Person> persons)
        {
            foreach (var N in persons)
            {
                N.OnCame += Came;
                N.Onleave += Leave;
            }
        }

        private void Came(Person men, DateTime time)
        {
            Console.WriteLine($"[ На работу пришел {men.Name}]");
            hello?.Invoke(men.Name, time);
            hello += men.SayHello;
            bye += men.SayBye;
        }

        private void Leave(Person men)
        {
            Console.WriteLine($"[{men.Name} ушел домой]");
            hello -= men.SayHello;
            bye -= men.SayBye;
            bye?.Invoke(men.Name);
        }
    }
}
