using System;
using System.IO;
using System.Text.Json;

namespace OS
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class JSON
    {
        public static void Start()
        {
            var Person = new Person
            {
                Name = "Tom",
                Age = 35
            };
            string fileName = @"D:\note.json";
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Person, options);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine(jsonString);

            string path = @"D:\note.json";
            FileInfo fileInf = new FileInfo(path);
            Console.WriteLine("\nУдалить файл?(1 - Да, 2 - Нет)\n");
            bool answer = true;
            while (answer)
            {
                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        fileInf.Delete();
                        Console.WriteLine("Файл удален");
                        answer = false;
                        break;
                    case "2":
                        Console.WriteLine("Файл сохранен");
                        answer = false;
                        break;
                }
            }
        }
    }
}