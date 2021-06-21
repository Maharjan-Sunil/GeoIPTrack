using System;

namespace GeoIPTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            //tells which key is pressed
            ConsoleKeyInfo key =  Console.ReadKey();
            Console.WriteLine("\n you press {0}", key.Key);

            Console.Write("Enter Name: ");
            //reads the input stream and returns string
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            //reads char and return ascii value
            Console.Write("Enter Read: ");
            int ascii = Console.Read();
            Console.WriteLine("\n ascii of pressed key {0}", ascii);

            Console.Clear();

            IpTrackWebService.IpTrack webServiceObj = new IpTrackWebService.IpTrack();
            var data = webServiceObj.Join(name, age);
            Console.WriteLine(data);

            //to hold screen until enter press
            Console.ReadLine();

        }
    }
}
