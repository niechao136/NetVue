using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetVue.Controllers
{
    public class BaseController : Controller
    {
        private static readonly HttpClient client = httpClient();

        private static HttpClient httpClient()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            };
            HttpClient httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.Timeout = TimeSpan.FromSeconds(60);
            return httpClient;
        }

        protected static string callAPI(string url, string method, string type, string body)
        {
            try
            {
                HttpContent httpContent = new StringContent(body);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue(type);
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage
                {
                    Method = new HttpMethod(method),
                    Content = httpContent,
                    RequestUri = new Uri(url)
                };
                Task<HttpResponseMessage> task = client.SendAsync(httpRequestMessage);
                task.Wait();
                HttpResponseMessage response = task.Result;
                Task<string> read = response.Content.ReadAsStringAsync();
                read.Wait();
                return read.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }
        }
    }
}