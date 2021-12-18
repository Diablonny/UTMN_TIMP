using System;

namespace Factory
{
    interface ISword
    {
        void Attack();
    }
    interface IGun
    {
        void Shoot();
    }
    class MeleeWeapon : ISword
    {
        public void Attack()
        {
            Console.WriteLine("Игрок совершил удар мечом!");
        }
    }
    class Guns : IGun
    {
        public void Shoot()
        {
            Console.WriteLine("Игрок выстрелил из ружья!");
        }
    }
    class Adapter : ISword
    {
        Guns gun;
        public Adapter(Guns c)
        {
            gun = c;
        }

        public void Attack()
        {
            gun.Shoot();
        }
    }
    class Player
    {
        public void Damage(ISword sword)
        {
            sword.Attack();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            MeleeWeapon sword = new MeleeWeapon();
            player.Damage(sword);
            Guns gun = new Guns();
            ISword gunn = new Adapter(gun);
            player.Damage(gunn);

            Console.ReadKey();
        }
    }
}
