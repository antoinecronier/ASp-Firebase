using Google.Apis.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirebaseClassLibrary.Services
{
    public class FirebaseServiceInterceptor : IHttpExecuteInterceptor
    {
        private Action<HttpRequestMessage> onIntercept;

        public FirebaseServiceInterceptor(Action<HttpRequestMessage> onIntercept)
        {
            this.onIntercept = onIntercept;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            onIntercept.Invoke(request);
            return new Task(() => { });
        }
    }
}
