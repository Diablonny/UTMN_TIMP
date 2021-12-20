using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    class Employee
    {
        private readonly IRepository repo;

        //проверка данных в репозитории
        private int GetOrCreate(string characteristic)
        {
            int index = repo.Read(characteristic);
            if (index == -1) //если данных нет, создать сотрудника
            {
                repo.Create(characteristic);
                return repo.Read(characteristic, true);
            }
            return index;
        }
        public Employee(string fullInfo, IRepository repository) // 
        {
            repo = repository; //репозиторий для хранения данных
            characteristics = fullInfo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(GetOrCreate)
                                   .ToArray();
        }
        private readonly int[] characteristics; //индексы записей в репозитории
        //собираем строку, характеризующее сотрудника
        public override string ToString() => String.Join(" ", characteristics.Select(e => repo.Read(e)));
    }
    interface IRepository
    {
        void Create(string value);
        int Read(string value, bool last = false);
        string Read(int index);
    }
    class Repository : IRepository
    {
        public static List<string> data;
        static Repository() => data = new List<string>();
        public void Create(string value) => data.Add(value);
        public int Read(string value, bool last) =>
            last ? data.LastIndexOf(value) : data.IndexOf(value);
        public string Read(int index) => data[index];
    }

    class Program
    {
        static void Main(string[] args)
        {
            var db = new Repository();

            var programmer1 = new Employee("Сергей Программист", db);
            var programmer2 = new Employee("Маша Программист", db);
            var teacher1 = new Employee("Артем Учитель", db);
            var builder1 = new Employee("Сергей Строитель", db);

            Console.WriteLine(programmer1);
            Console.WriteLine(programmer2);
            Console.WriteLine(teacher1);
            Console.WriteLine(builder1);

            Console.WriteLine("_____________________");
            Console.WriteLine(String.Join("\n", Repository.data));
        }
    }
}
