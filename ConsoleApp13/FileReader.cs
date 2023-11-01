using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.ConsoleKey;

namespace Converter
{
    internal static class FileReader
    {
        private static string fileExtension;
        public static void ReadFile(string? pathFile)
        {
            if (string.IsNullOrWhiteSpace(pathFile))
            {
                Console.WriteLine("ВВЕДИТЕ ПУТЬ ДО ФАЙЛА");
                ReadFile(Console.ReadLine());
            }
            if (!File.Exists(pathFile))
            {
                Console.WriteLine("Такого файла не существует");
                return;
            }
            fileExtension = Path.GetExtension(pathFile);
            if (fileExtension == ".txt")
            {
                ReaderTxt(pathFile);
            }
            else if (fileExtension == ".json")
            {
                ReaderJson(pathFile);
            }
            else if (fileExtension == ".xml")
            {
                ReaderXml(pathFile);
            }
            else
            {
                Console.WriteLine("Файл не имеет необходимого расширения");
            }
        }
        private static void ReaderTxt(string pathFile)
        {
            Car car = new Car();
            using StreamReader sr = new StreamReader(pathFile);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                switch (line)
                {
                    case "Марка":
                        car.Make = sr.ReadLine();
                        break;
                    case "Модель":
                        car.Model = sr.ReadLine();
                        break;
                    case "Год выпуска":
                        int.TryParse(sr.ReadLine(), out car.Year);
                        break;
                }
            }
            KeyReader(car);
        }


        private static void ReaderJson(string pathFile)
        {
            Car car = JsonConvert.DeserializeObject<Car>(pathFile);
            KeyReader(car);
        }

        private static void ReaderXml(string pathFile)
        {
            Car car;
            XmlSerializer xml = new XmlSerializer(typeof(Car));
            using FileStream fs = new FileStream(pathFile, FileMode.Open);
            car = (Car)xml.Deserialize(fs);
            KeyReader(car);
        }
        private static void KeyReader(Car car)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(car.ToString());
                ConsoleKey imputKey = Console.ReadKey().Key;
                if (imputKey == F1)
                {
                    Console.WriteLine("Введите путь куда сохранить");
                    FileSaver.Save(Console.ReadLine(), car);
                    break;
                }
                else if (imputKey == Escape)
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}