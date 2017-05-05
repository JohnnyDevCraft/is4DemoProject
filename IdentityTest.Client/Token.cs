using System;
using IdentityModel.Client;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace IdentityTest.Client
{
    public static class Token
    {
        public static string GetToken(string client, string secret, string scope)
        {

            var discoTask = DiscoveryClient.GetAsync(Program.AccessApi);
            var disco = discoTask.Result;

            var tokenClient = new TokenClient(disco.TokenEndpoint, client, secret);
            var tokenResponseTask = tokenClient.RequestClientCredentialsAsync(scope);
            var tokenResponse = tokenResponseTask.Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return string.Empty;
            }

            Console.WriteLine(tokenResponse.Json);

            return tokenResponse.AccessToken;
        }

        public static string GetTokenWithCred(string client, string secret, string scope, string user, string password)
        {

            var discoTask = DiscoveryClient.GetAsync(Program.AccessApi);
            var disco = discoTask.Result;

            var tokenClient = new TokenClient(disco.TokenEndpoint, client, secret);
            var tokenResponseTask = tokenClient.RequestResourceOwnerPasswordAsync(user, password, scope);
            var tokenResponse = tokenResponseTask.Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return string.Empty;
            }

            Console.WriteLine(tokenResponse.Json);

            return tokenResponse.AccessToken;

        }
    }
}
