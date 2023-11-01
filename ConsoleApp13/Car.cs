using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class Car
    {
        public string Make;
        public string Model;
        public int Year;

        public Car()
        {

        }
        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public override string ToString()
        {
            return "Модель\r\n" +
                   $"{Make}\r\n" +
                   "Марка\r\n" +
                   $"{Model}\r\n" +
                   "Год выпуска\r\n" +
                   $"{Year}";
        }
    }
}