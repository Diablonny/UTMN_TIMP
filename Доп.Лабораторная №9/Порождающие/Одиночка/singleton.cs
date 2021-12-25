using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    class Singleton
    {
        public int Value { get; set; }
        private Singleton() { Value = 1212; }

        static Lazy<Singleton> uniqueInstance
            = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance => uniqueInstance.Value;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = Singleton.Instance;
            var item2 = Singleton.Instance;

            item1.Value = 13;

            Console.WriteLine($"item1.GetHashCode() {item1.GetHashCode()}  {item1.Value}");
            Console.WriteLine($"item2.GetHashCode() {item2.GetHashCode()}  {item2.Value}");
            //item1.GetHashCode() 58225482  13
            //item2.GetHashCode() 58225482  13
        }
    }
}
