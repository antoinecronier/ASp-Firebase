using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Streaming;
using FirebaseAdmin;
using FirebaseClassLibrary.Entities;
using FirebaseClassLibrary.Extensions;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FirebaseClassLibrary.Services
{
    public class RealtimeDatabaseService
    {

        private static readonly Lazy<RealtimeDatabaseService> lazy =
            new Lazy<RealtimeDatabaseService>(() => new RealtimeDatabaseService());

        /// <summary>
        /// RealtimeDatabase singleton access.
        /// </summary>
        public static RealtimeDatabaseService Instance { get { return lazy.Value; } }

        private RealtimeDatabaseService()
        {
            realtimeDb = new FirebaseClient("https://asp-firebase-adf1a.firebaseio.com/");
        }

        private FirebaseClient realtimeDb;

        public async void LogApiAction(string controller, FirebaseItem item)
        {
            var logs = await realtimeDb
              .Child("log")
              .Child(controller)
              .PostAsync(item.ToJson());
        }

        public async void UpdateApiAction(FirebaseItem item)
        {
            await realtimeDb
              .Child("log")
              .Child("resume")
              .PutAsync(item.ToJson());
        }

        public Task<IReadOnlyCollection<FirebaseObject<T>>> GetApiDatas<T>(string controller) where T : FirebaseItem
        {
            return realtimeDb.Child("log").Child(controller).OnceAsync<T>();
        }

        public void AttachHandler<T>(string controller, Action<FirebaseEvent<T>> onItemUpdate, Action onComplet) where T : FirebaseItem
        {
            realtimeDb.Child("log").Child(controller).AsObservable<T>().Subscribe(onItemUpdate, onComplet);
        }
    }
}