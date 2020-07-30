using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using FirebaseClassLibrary.Entities;
using Google.Apis.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace FirebaseWebApplication.Services
{
    public class FirebaseService
    {
        private static readonly Lazy<FirebaseService> lazy =
            new Lazy<FirebaseService>(() => new FirebaseService());

        /// <summary>
        /// FirebaseService singleton access.
        /// </summary>
        public static FirebaseService Instance { get { return lazy.Value; } }

        private FirebaseService()
        {
            db = FirebaseApp.DefaultInstance;
            msg = FirebaseMessaging.DefaultInstance;
            msg.SubscribeToTopicAsync(new List<String>() { db.Options.ServiceAccountId },"test");

            client = db.Options.HttpClientFactory.CreateHttpClient(new Google.Apis.Http.CreateHttpClientArgs());
            client.MessageHandler.AddExecuteInterceptor(new Test());//.ExecuteInterceptors.Add(new IHttpExecuteInterceptor() { });
        }

        public class Test : IHttpExecuteInterceptor
        {
            public Test()
            {

            }

            public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var content = request.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return new Task(() => { });
            }
        }

        private FirebaseApp db;
        private FirebaseMessaging msg;
        private ConfigurableHttpClient client;

        public void Send(string info)
        {
            var res = client.PostAsJsonAsync("https://asp-firebase-adf1a.firebaseio.com/testheuuuu", new Role() { Id = 0, Name = "test" });
            
            
            Console.WriteLine(res);
        }
    }
}