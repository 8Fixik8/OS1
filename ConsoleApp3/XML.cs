using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace OS
{
    class XML
    {
        public static void Start()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D://user.xml");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            XmlElement userElem = xDoc.CreateElement("user");
            // создаем атрибут name
            XmlAttribute nameAttr = xDoc.CreateAttribute("name");
            // создаем элементы company и age
            XmlElement companyElem = xDoc.CreateElement("company");
            XmlElement ageElem = xDoc.CreateElement("age");
            // создаем текстовые значения для элементов и атрибута
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите компанию: ");
            string company = Console.ReadLine();
            Console.WriteLine("Введите возраст: ");
            string age = Console.ReadLine();
            XmlText nameText = xDoc.CreateTextNode(name);
            XmlText companyText = xDoc.CreateTextNode(company);
            XmlText ageText = xDoc.CreateTextNode(age);

            //добавляем узлы
            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);
            userElem.Attributes.Append(nameAttr);
            userElem.AppendChild(companyElem);
            userElem.AppendChild(ageElem);
            xRoot.AppendChild(userElem);
            xDoc.Save("D://user.xml");

            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // если узел - company
                    if (childnode.Name == "company")
                    {
                        Console.WriteLine($"Компания: {childnode.InnerText}");
                    }
                    // если узел age
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine($"Возраст: {childnode.InnerText}");
                    }
                }
                Console.WriteLine();
            }
            string path = @"D://user.xml";
            FileInfo file = new FileInfo(path);
            Console.WriteLine("Удалить файл?(1 - Да, 2 - Нет)\n");
            bool answer = true;
            while (answer)
            {
                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        file.Delete();
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