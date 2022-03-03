using System;
using System.IO;

namespace OS
{
    class Menu
    {
        private static void Choice()
        {
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|Выберете пункт:                          |");
            Console.WriteLine("|1.Информация о дисках и файловой системе |");
            Console.WriteLine("|2.Работа с файлом                        |");
            Console.WriteLine("|3.Работа с форматом JSON                 |");
            Console.WriteLine("|4.Работа с форматом XML                  |");
            Console.WriteLine("|5.Работа с ZIP архивом                   |");
            Console.WriteLine("|6.Выход                                  |");
            Console.WriteLine("-----------------------------------------|");

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Choice();
                string choice = Console.ReadLine();


                Console.Clear();
                switch (choice)
                {
                    case "1":
                        FILE2.Start();
                        break;
                    case "2":
                        FILE1.Start();
                        break;
                    case "3":
                        JSON.Start();
                        break;
                    case "4":
                        XML.Start();
                        break;
                    case "5":
                        ZIP.Start();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неизвестное значение");
                        break;

                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
