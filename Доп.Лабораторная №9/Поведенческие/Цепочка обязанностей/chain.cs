using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    //Уровень приоритета звонка или же кому адресуется звонок
    enum Responsibility
    {
        AutoAnswer = 1,
        HelpCenter = 2,
        Master = 3
    }
    //Кто на каком уровне ответственен
    abstract class Participant
    {
        public abstract void Conversation(string message, Responsibility level);
    }
    class AutoAnswer : Participant
    {
        readonly Responsibility priority;
        public AutoAnswer(Responsibility priority)
        {
            this.priority = priority;
        }
        public Participant Next { get; set; }

        public override void Conversation(string message, Responsibility level)
        {
            Console.WriteLine("Вы обратились на авто-ответчик");

            if (level <= priority)
            {
                Console.WriteLine(message);
            }
            else if (Next != null)
            {
                Next.Conversation(message, level);
            }
        }
    }
    class HelpCenter : Participant
    {
        readonly Responsibility priority;
        public HelpCenter(Responsibility priority)
        {
            this.priority = priority;
        }
        public Participant Next { get; set; }

        public override void Conversation(string message, Responsibility level)
        {
            Console.WriteLine("Вы обратились в служебный центр");
            if (level <= priority)
            {
                Console.WriteLine(message);
            }
            else if (Next != null)
            {
                Next.Conversation(message, level);
            }
        }
    }
    class Master : Participant
    {
        readonly Responsibility priority;
        public Master(Responsibility priority)
        {
            this.priority = priority;
        }
        public Participant Next { get; set; }

        public override void Conversation(string message, Responsibility level)
        {
            Console.WriteLine("Вы обратились к мастеру");

            if (level <= priority)
            {
                Console.WriteLine(message);
            }
            else if (Next != null)
            {
                Next.Conversation(message, level);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AutoAnswer robot = new AutoAnswer(Responsibility.AutoAnswer);
            Master injener = new Master(Responsibility.Master);
            HelpCenter marija = new HelpCenter(Responsibility.HelpCenter);

            robot.Next = marija;
            marija.Next = injener;

            robot.Conversation("Алло", Responsibility.HelpCenter);
            Console.WriteLine("\n");
            robot.Conversation("Переключите на мастера", Responsibility.Master);
            Console.WriteLine("\n");
            robot.Conversation("Переключите на робота", Responsibility.AutoAnswer);
        }
    }
}

