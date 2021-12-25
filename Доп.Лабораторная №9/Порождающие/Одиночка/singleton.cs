using System;

namespace ConsoleApp8
{
    class Singleton
    {
        public int Value { get; set; }
        private Singleton() { Value = 1212; } //скрытый конструктор

        static Lazy<Singleton> uniqueInstance
            = new Lazy<Singleton>(() => new Singleton()); //статическое поле экземляра этого класса

        public static Singleton Instance => uniqueInstance.Value; //открываем поле пользователю
    }
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = Singleton.Instance;
            var item2 = Singleton.Instance;

            item1.Value = 13;

            Console.WriteLine($"{item1.GetHashCode()}  {item1.Value}");
            Console.WriteLine($"{item2.GetHashCode()}  {item2.Value}");
            //58225482  13
            //58225482  13
        }
    }
}
