using System;

namespace Decorator
{
    class Pizza
    {
        public virtual string Make() => "Тесто + ";
    }

    class Cheese : Pizza
    {
        Pizza pizza;
        public Cheese(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public override string Make()
        {
            return pizza.Make() + " Сыр + ";
        }
    }
    class Chicken : Pizza
    {
        Pizza pizza;
        public Chicken(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public override string Make()
        {
            return pizza.Make() + " Курица + ";
        }
    }
    class Fish : Pizza
    {
        Pizza pizza;
        public Fish(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public override string Make()
        {
            return pizza.Make() + " Рыба + ";
        }
    }
    class Meat : Pizza
    {
        Pizza pizza;
        public Meat(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public override string Make()
        {
            return pizza.Make() + " Мясо + ";
        }
    }
    class Olives : Pizza
    {
        readonly Pizza pizza;
        public Olives(Pizza pizza)
        {
            this.pizza = pizza; 
        }
        public override string Make()
        {
            return pizza.Make() + " Оливки + ";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var chickenCheesePizza = new Cheese(new Chicken(new Pizza()));
            Console.WriteLine(chickenCheesePizza.Make());

            var chickenOlivesCheesePizza = new Olives(new Cheese(new Chicken(new Pizza())));
            Console.WriteLine(chickenOlivesCheesePizza.Make());
        }
    }
}
