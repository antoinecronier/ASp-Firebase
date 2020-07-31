using Firebase.Auth;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using FirebaseClassLibrary.Entities;
using FirebaseClassLibrary.Extensions;
using Google.Apis.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace FirebaseClassLibrary.Services
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
            firebase = FirebaseApp.DefaultInstance;

            msg = FirebaseMessaging.DefaultInstance;
            msg.SubscribeToTopicAsync(new List<String>() { firebase.Options.ServiceAccountId },"test");

            client = firebase.Options.HttpClientFactory.CreateHttpClient(new Google.Apis.Http.CreateHttpClientArgs());
        }

        private FirebaseApp firebase;
        private FirebaseMessaging msg;
        private ConfigurableHttpClient client;

        public void SendFirebase(ApiItem item)
        {
            var res = client.PostAsync("https://asp-firebase-adf1a.firebaseio.com/", new StringContent(
               item.ToJson(), Encoding.UTF8, "application/json"));
            
            
            Console.WriteLine(res);
        }

        public void SendFcm(ApiItem item)
        {
            var data = new Dictionary<string, string>();
            data.Add("item", item.ToJson());

            var res = msg.SendAsync(new Message() { Topic = "test", Data = data });
            Console.WriteLine(res);
        }

        public void AttachHandler(IHttpExecuteInterceptor interceptor)
        {
            client.MessageHandler.AddExecuteInterceptor(interceptor);
        }
    }
}