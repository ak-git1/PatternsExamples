using System;
using System.Collections.Generic;

namespace PatternsExamples.Behavioral.Memento
{
    // Originator
    class Hero
    {
        private int _patrons = 10;
        private int _lives = 5;

        public void Shoot()
        {
            if (_patrons > 0)
            {
                _patrons--;
                Console.WriteLine("Производим выстрел. Осталось {0} патронов", _patrons);
            }
            else
                Console.WriteLine("Патронов больше нет");
        }

        public HeroMemento SaveState()
        {
            Console.WriteLine("Сохранение игры. Параметры: {0} патронов, {1} жизней", _patrons, _lives);
            return new HeroMemento(_patrons, _lives);
        }

        public void RestoreState(HeroMemento memento)
        {
            _patrons = memento.Patrons;
            _lives = memento.Lives;
            Console.WriteLine("Восстановление игры. Параметры: {0} патронов, {1} жизней", _patrons, _lives);
        }
    }

    // Memento
    class HeroMemento
    {
        public int Patrons { get; }

        public int Lives { get; }

        public HeroMemento(int patrons, int lives)
        {
            Patrons = patrons;
            Lives = lives;
        }
    }

    // Caretaker
    class GameHistory
    {
        public Stack<HeroMemento> History { get; }

        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
