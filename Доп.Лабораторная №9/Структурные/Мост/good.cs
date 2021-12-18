using System;

namespace Factory
{
    class Color
    {
        protected string color;
        protected Color(string color) => this.color = color;
        public override string ToString() => color;
    }
    class GreenColor : Color { public GreenColor() : base("Зелёный") { } }
    class RedColor : Color { public RedColor() : base("Красный") { } }
    class YellowColor : Color { public YellowColor() : base("Жёлтый") { } }
    abstract class Weapon
    {
        protected Color color;
        protected Weapon(Color color) => this.color = color;
        public abstract void Attack();
    }
    class DragonSword : Weapon
    {
        private int Damage { get; set; }
        public DragonSword(Color color, int damage) : base(color)
        {
            Damage = damage;
        }

        public override void Attack()
        {
            Console.WriteLine(String.Format("{0} урона. Цвет оружия: {1}", Damage, color));
        }
    }
    class SpikedShield : Weapon
    {
        private int Damage { get; set; }
        public int Defence { get; set; }

        public SpikedShield(Color color, int damage, int defence) : base(color)
        {
            Damage = damage;
            Defence = defence;
        }
        public override void Attack()
        {
            Console.WriteLine(string.Format("{0} защиты, {1} атаки. Цвет: {2}", Damage, Defence, color));
        }
    }
    class MagicStick : Weapon
    {
        public int Magic { get; set; }

        public MagicStick(Color color, int side) : base(color)
        {
            Magic = side;
        }
        public override void Attack()
        {
            Console.WriteLine(String.Format("{0} урона. Цвет: {1}", Magic, color));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SpikedShield shield = new SpikedShield(new RedColor(), 5, 10);
            shield.Attack();
            Console.ReadKey();
        }
    }
}
