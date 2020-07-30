using FirebaseConsoleApp.WebServices;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = RestService.For<WebApiWebService>("http://localhost:60520/");
            foreach (var item in api.Users().Result)
            {
                Console.WriteLine(item.Id);
            }

            foreach (var item in api.Users("Cars").Result)
            {
                Console.WriteLine(item.Id);
                foreach (var car in item.Cars)
                {
                    Console.WriteLine("\t" + car.Id);
                }
            }

            Console.ReadKey();
        }
    }
}
