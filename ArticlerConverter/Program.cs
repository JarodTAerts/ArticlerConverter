// See https://aka.ms/new-console-template for more information

namespace ArticlerConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EPubConverter.ConvertUrlToEPub("https://www.reuters.com/world/europe/chernobyl-power-plant-captured-by-russian-forces-ukrainian-official-2022-02-24/").GetAwaiter().GetResult();
            Console.WriteLine("Done.");
        }
    }
}