using System;
using IdentityModel.Client;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace IdentityTest.Client
{
    public static class Client
    {
        public static void CallApi(string token, string controller, string action)
        {
            // call api
            var client = new HttpClient();
            client.SetBearerToken(token);

            var responseTask = string.IsNullOrWhiteSpace(controller) ? client.GetAsync($"{Program.ApiRoot}/{action}")
                                     : string.IsNullOrWhiteSpace(action) ? client.GetAsync($"{Program.ApiRoot}/{controller}") :
                                     client.GetAsync($"{Program.ApiRoot}/{controller}/{action}");
            var response = responseTask.Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var contentTask = response.Content.ReadAsStringAsync();
                var content = contentTask.Result;
                Console.WriteLine(JArray.Parse(content));
            }
        }

        public static void CallApiNoToken(string controller, string action)
        {
            // call api
            var client = new HttpClient();

            var responseTask = string.IsNullOrWhiteSpace(controller) ? client.GetAsync($"{Program.ApiRoot}/{action}")
                                     : string.IsNullOrWhiteSpace(action) ? client.GetAsync($"{Program.ApiRoot}/{controller}") :
                                     client.GetAsync($"{Program.ApiRoot}/{controller}/{action}");
            var response = responseTask.Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var contentTask = response.Content.ReadAsStringAsync();
                var content = contentTask.Result;
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
