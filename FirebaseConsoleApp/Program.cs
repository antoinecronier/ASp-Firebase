using Firebase.Database.Streaming;
using FirebaseClassLibrary.Configurations;
using FirebaseClassLibrary.Entities;
using FirebaseClassLibrary.Extensions;
using FirebaseClassLibrary.Services;
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
            SetupFirebase();
            //ListFirebaseDatas();
            //CallApi();

            Console.ReadKey();
        }

        private async static void ListFirebaseDatas()
        {
            var datas = await RealtimeDatabaseService.Instance.GetApiDatas<FirebaseLog>("User");
            foreach (var item in datas)
            {
                Console.WriteLine(item.Object.ToJson());
            }
        }

        private static void CallApi()
        {
            var api = RestService.For<WebApiWebService>("http://localhost:52950/");
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
        }

        private static void SetupFirebase()
        {
            //Firebase
            FirebaseConfiguration.Load();

            FirebaseService.Instance.AttachHandler(new FirebaseServiceInterceptor((e) => 
            {
                Console.WriteLine(e.Content.ReadAsStringAsync());
            }));

            // Realtime database
            Action<FirebaseEvent<FirebaseLog>> onChange = (e) =>
            {
                Console.WriteLine(e.Object.ToJson());
            };

            Action onComplet = () => {
                Console.WriteLine("Complet");
            };

            RealtimeDatabaseService.Instance.AttachHandler<FirebaseLog>("User", onChange, onComplet);
        }
    }
}
