using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServerSideBlazor.App.Services
{
    public abstract class RetryPollyService
    {
        private readonly HttpStatusCode[] httpStatusCodesWorthRetrying = {
            HttpStatusCode.RequestTimeout,      // 408
            HttpStatusCode.InternalServerError, // 500
            HttpStatusCode.BadGateway,          // 502
            HttpStatusCode.ServiceUnavailable,  // 503
            HttpStatusCode.GatewayTimeout       // 504
        };
        public async Task<HttpResponseMessage> GetRetry(string url, string jsontype = "application/json", int retryCount = 3, int retryWaitsec = 2)
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(configApiUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(jsontype));
            Task<HttpResponseMessage> response;

            try
            {
                var policyRetry = Policy
                    .HandleResult<HttpResponseMessage>(r => httpStatusCodesWorthRetrying.Contains(r.StatusCode))
                    .WaitAndRetryAsync(retryCount, i => TimeSpan.FromSeconds(retryWaitsec), (resultPolly, timeSpan, countRetried, context) =>
                     {
                         System.Console.WriteLine($"Request failed with {resultPolly.Result.StatusCode}");
                     });
                    response = policyRetry.ExecuteAsync(async () =>
                    {
                        return await httpClient.GetAsync(url);
                    });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Request failed with {ex.Message}");
                response = null;
            }

            return response.Result;
        }
    }
}
