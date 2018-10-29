using System;

namespace PatternsExamples.Creational.AbstractFactory
{
    abstract class Weapon
    {
        public abstract void Hit();
    }

    abstract class Movement
    {
        public abstract void Move();
    }

    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }

    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем мечом");
        }
    }

    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }

    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }

    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();

        public abstract Weapon CreateWeapon();
    }

    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }

    class WarriorFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }

    class Hero
    {
        private Weapon _weapon;
        private Movement _movement;

        public Hero(HeroFactory factory)
        {
            _weapon = factory.CreateWeapon();
            _movement = factory.CreateMovement();
        }

        public void Run()
        {
            _movement.Move();
        }

        public void Hit()
        {
            _weapon.Hit();
        }
    }

    class Usage
    {
        public void Run()
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();

            Hero warrior = new Hero(new WarriorFactory());
            warrior.Hit();
            warrior.Run();

            Console.ReadLine();
        }
    }
}
