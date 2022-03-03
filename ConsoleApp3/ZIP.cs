using System;
using System.IO;
using System.IO.Compression;

namespace OS
{
    class ZIP
    {
        public static void Start()
        {
            string sourceFile = "D://book.txt";
            string compressedFile = "D://test.zip";
            string targetFile = "D://book_new.txt";


            Compress(sourceFile, compressedFile);
            Decompress(compressedFile, targetFile);

            string path = @"D://book_new.txt";
            string path1 = "D://test.zip";
            FileInfo fileInf = new FileInfo(path);
            FileInfo fileInf1 = new FileInfo(path1);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
            }
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
            Console.WriteLine("\nУдалить архив?(1 - Да, 2 - Нет)\n");
            bool answer1 = true;
            while (answer1)
            {
                string b = Console.ReadLine();
                switch (b)
                {
                    case "1":
                        fileInf1.Delete();
                        Console.WriteLine("Архив удален");
                        answer1 = false;
                        break;
                    case "2":
                        Console.WriteLine("Архив сохранен");
                        answer1 = false;
                        break;
                }
            }
            static void Compress(string sourceFile, string compressedFile)
            {
                // поток для чтения исходного файла
                using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
                {
                    // поток для записи сжатого файла
                    using (FileStream targetStream = File.Create(compressedFile))
                    {
                        // поток архивации
                        using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                        {
                            sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                            Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                        }
                    }
                }
            }

            static void Decompress(string compressedFile, string targetFile)
            {
                // поток для чтения из сжатого файла
                using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
                {
                    // поток для записи восстановленного файла
                    using (FileStream targetStream = File.Create(targetFile))
                    {
                        // поток разархивации
                        using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(targetStream);
                            Console.WriteLine("Восстановлен файл: {0}", targetFile);
                        }
                    }
                }
            }
        }
    }
}