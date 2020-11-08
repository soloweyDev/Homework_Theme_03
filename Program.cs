using System;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main()
        {
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш

            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!

            Console.WriteLine("Добрый день, игроки!");

            Console.Write("Игрок 1 введите ваше имя: ");
            string nameGamer1 = Console.ReadLine();

            Console.Write("Игрок 2 введите ваше имя: ");
            string nameGamer2 = Console.ReadLine();

            while (true)
            {
                Random random = new Random();
                int randomNumber = random.Next(12, 121);

                bool gamerFirst = false;
                do
                {
                    gamerFirst = !gamerFirst;

                    randomNumber = gamerFirst ? Turn(nameGamer1, randomNumber) : Turn(nameGamer2, randomNumber);

                }
                while (randomNumber != 0);

                string name = gamerFirst ? nameGamer1 : nameGamer2;
                Console.WriteLine($"{name} победил!");

                Console.WriteLine();
                Console.Write($"Хотите сыграть еще раз? (y - да, иначе нет): ");
                string ch = Console.ReadLine();
                if (ch != "y")
                {
                    break;
                }
            }

            Console.ReadKey();
        }

        static int Turn(string name, int number)
        {
            int userTry = 0;
            Console.WriteLine($"Число : {number}");
            Console.WriteLine($"Игрок {name} ходит.");

            while (true)
            {
                try
                {
                    Console.Write("Введите число от 1 до 4: ");
                    userTry = Convert.ToInt32(Console.ReadLine());
                    if (userTry > 0 && userTry < 5)
                    {
                        break;
                    }
                }
                catch {}
                
                Console.WriteLine("Ошибка ввода! Число должно быть от 1 до 4.");
            }

            return number - userTry;
        }
    }
}
