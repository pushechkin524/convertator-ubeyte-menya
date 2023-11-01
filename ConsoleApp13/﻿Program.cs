namespace Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------\r\n" +
                              "Добро пожаловать в текстовый конвертер\r\n" +
                              "--------------------------------------\r\n");
            Console.WriteLine("Введите путь до файла" +
                              "--------------------------------------\r\n");
            FileReader.ReadFile(Console.ReadLine());
        }
    }
}