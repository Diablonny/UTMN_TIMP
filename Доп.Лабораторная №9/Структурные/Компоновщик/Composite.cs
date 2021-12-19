using System;
using System.Collections.Generic;

namespace Composite
{
    interface IEMail
    {
        string Name { get; set; } //Получатель
        string Theme { get; set; } //Тема Письма
        void Send();
    }
    class EMail : IEMail
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public void Send() => Console.WriteLine($"Тема письма \"{Theme}\" \n Отправлено \"{Name}\"");
    }
    class Group : IEMail
    {
        public string Name { get; set; }
        public string Theme { get; set; }

        private List<IEMail> eMails = new List<IEMail>(); //Коллекция писем IEmail
        public Group(params IEMail[] es) => Append(es);
        public void Append(params IEMail[] es) //Добавление нужного количества писем
        {
            foreach (var item in es) eMails.Add(item);
        }
        public void Send() //Отправление конкретному пользователю
        {
            foreach (var item in eMails) item.Send();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Отправление отдельным получателям
            EMail a = new EMail() { Name = "Кирилл Пономарев", Theme = "Лабораторная №9" };
            a.Send();
            EMail b = new EMail() { Name = "Студенты", Theme = "Расписание" };
            b.Send(); 
            EMail c = new EMail() { Name = "Тех.Поддержка", Theme = "Проблемы с доступом" };
            c.Send(); 
            EMail d = new EMail() { Name = "Компания N ", Theme = "Собеседование" };
            d.Send(); 

            //Отправление по группам
            Console.WriteLine("\n Отправляем письма Тюмгу \n");
            Group tymgu = new Group(a, b);
            tymgu.Send();
            
            Console.WriteLine("\n Отправляем письма Всем \n");

            //Группа в группе
            Group gmail = new Group(tymgu, c, d);
            gmail.Send();
        }
    }
}
