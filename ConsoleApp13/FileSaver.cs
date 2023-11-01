using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Converter
{
    internal static class FileSaver
    {
        public static void Save(string path, Car car)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("ВВЕДИТЕ ПУТЬ!!!");
                Save(Console.ReadLine(), car);
            }
            else
            {
                FullSave(path, car);
            }
        }

        private static void FullSave(string path, Car car)
        {
            if (!File.Exists(path))
            {
                FileStream fileStream = File.Create(path);
                fileStream.Dispose();
            }
            string fileExtension = Path.GetExtension(path);
            switch (fileExtension)
            {
                case ".txt":
                    File.WriteAllText(path, car.ToString());
                    break;
                case ".json":
                    string json = JsonConvert.SerializeObject(car);
                    File.WriteAllText(path, json);
                    break;
                case ".xml":
                    XmlSerializer xml = new XmlSerializer(typeof(Car));
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, car);
                    }
                    break;
            }
        }
    }
}