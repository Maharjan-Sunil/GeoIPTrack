using GeoIPTrack.API;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace GeoIPTrack
{
    class Program
    {
        private static string rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string filePath = Path.Combine(rootPath.Remove(rootPath.IndexOf("\\bin\\Debug")),
                                                      @"File\Common\Shipment.txt");

        private static string ShipAWB = "";

        static void Main(string[] args)
        {
            //StoreShipment();
            CreateShipment();
        }

        private static void StoreShipment()
        {
            Console.WriteLine("StoreShipment Web Method");
            Reply reply = new Reply();

            string shipmentJsonString = File.ReadAllText(filePath);
            Shipment shipmentRequest = JsonConvert.DeserializeObject<Shipment>(shipmentJsonString);

            API_Service apiWebService = new API_Service();
            reply = apiWebService.StoreShipment(shipmentRequest);

            ReplyResult(reply);
        }

        private static void CreateShipment()
        {
            Console.WriteLine("Create Shipment Web Method");
            Reply reply = new Reply();

            string shipmentJsonString = File.ReadAllText(filePath);
            Shipment shipmentRequest = JsonConvert.DeserializeObject<Shipment>(shipmentJsonString);

            API_Service apiWebService = new API_Service();
            reply = apiWebService.CreateShipment(shipmentRequest);

            ShipAWB = reply.MainAWB;
            ReplyResult(reply);

        }

        public static void ReplyResult(Reply reply)
        {
            if (reply != null)
            {
                foreach (var error in reply.Status.ErrorList)
                {
                    Console.WriteLine(error.SystemErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("exception!");
            }
        }

    }
}

    //tells which key is pressed
    //    ConsoleKeyInfo key =  Console.ReadKey();
    //            Console.WriteLine("\n you press {0}", key.Key);

//            Console.Write("Enter Name: ");
//            //reads the input stream and returns string
//            string name = Console.ReadLine();
//            Console.Write("Enter Age: ");
//            int age = Convert.ToInt32(Console.ReadLine());

//            //reads char and return ascii value
//            Console.Write("Enter Read: ");
//            int ascii = Console.Read();
//            Console.WriteLine("\n ascii of pressed key {0}", ascii);

//            Console.Clear();

//            IpTrackWebService.IpTrack webServiceObj = new IpTrackWebService.IpTrack();
//            var data = webServiceObj.Join(name, age);
//            Console.WriteLine(data);

//            RegisterModel model = new RegisterModel();
//            model.Username = "Sunil";
//            string output = webServiceObj.TestMethodWithParam(model);
//            Console.WriteLine(output);

//            //to hold screen until enter press
//            Console.ReadLine();
//        }
//    }
//}
