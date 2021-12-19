using System;

namespace Decorator
{
    class Pizza
    {
        public virtual string MakePizza() => "Тесто + ";
    }

    class Cheese : Pizza
    {
        Pizza pizza;
        public Cheese(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public override string MakePizza()
        {
            return pizza.MakePizza() + " Сыр + ";
        }
    }
    class ChickenPizza : Pizza
    {
        Pizza pizza;
        public ChickenPizza(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public override string MakePizza()
        {
            return pizza.MakePizza() + " Пицца с курицей + ";
        }
    }
    class FishPizza : Pizza
    {
        Pizza pizza;
        public FishPizza(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public override string MakePizza()
        {
            return pizza.MakePizza() + " Пица с рыбой + ";
        }
    }
    class MeatPizza : Pizza
    {
        Pizza pizza;
        public MeatPizza(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public override string MakePizza()
        {
            return pizza.MakePizza() + " Пица с мясом + ";
        }
    }
    class Olives : Pizza
    {
        readonly Pizza pizza;
        public Olives(Pizza pizza)
        {
            this.pizza = pizza; 
        }
        public override string MakePizza()
        {
            return pizza.MakePizza() + " Оливки + ";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pizza chickenPizza = new ChickenPizza(new Pizza());
            Console.WriteLine(chickenPizza.MakePizza());

            var chickenCheesePizza = new Cheese(new ChickenPizza(new Pizza()));
            Console.WriteLine(chickenCheesePizza.MakePizza());

            var chickenOlivesCheesePizza = new Olives(new Cheese(new ChickenPizza(new Pizza())));
            Console.WriteLine(chickenOlivesCheesePizza.MakePizza());
        }
    }
}
