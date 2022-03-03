using System;
using System.IO;

namespace OS
{
    class FILE1
    {
        public static void Start()
        { 
            // создаем каталог для файла
            string path = "D:\\SomeDir";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                Console.WriteLine("Введите строку для записи в файл:");
                string text = Console.ReadLine();

                // запись в файл
                using (FileStream fstream = new FileStream($"{path}/note", FileMode.OpenOrCreate))
                {
                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    // запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                    Console.WriteLine("Текст записан в файл");
                }

                // чтение из файла
                using (FileStream fstream = File.OpenRead($"{path}/note"))
                {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    string textFromFile = System.Text.Encoding.Default.GetString(array);
                    Console.WriteLine($"Текст из файла: {textFromFile}");
                }

                string path1 = $"{path}/note";
                FileInfo note = new FileInfo(path1);
                Console.WriteLine("\nУдалить файл?(1 - Да, 2 - Нет)\n");
                bool answer = true;
                while (answer)
                {
                    string a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            note.Delete();
                            dirInfo.Delete();
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
            else
                Console.WriteLine("Файл уже существует");
        }
    }
}