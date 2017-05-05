using System;
using IdentityModel.Client;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace IdentityTest.Client
{
    public static class Runner
    {
        public static void RunWithClientToken(string controller, string action)
        {
            Console.Clear();

            Console.Write("Enter Client Name: ");
            var client = Console.ReadLine();
            Console.Write("Enter Client Secret: ");
            var secret = Console.ReadLine();
            Console.Write("Enter Scope requesting: ");
            var scope = Console.ReadLine();


            Console.Clear();
            Console.Write("Results for Getting Token: \n\n\n");
            var token = Token.GetToken(client, secret, scope);
            Console.Write("\n\n-------------------------------------------------------------------- \n\n\n");


            Console.Write("Results for Calling API: \n\n\n");
            Client.CallApi(token, controller, action);
            Console.Write("\n\n-------------------------------------------------------------------- \n\n\n");
        }

        public static void RunWithoutToken(string controller, string action)
        {
            Console.Clear();

            Console.Write("Results for Calling API: \n\n\n");
            Client.CallApiNoToken(controller, action);
            Console.Write("\n\n-------------------------------------------------------------------- \n\n\n");
        }

        public static void RunWithUserToken(string controller, string action)
        {
            Console.Clear();

            Console.Write("Enter Client Name: ");
            var client = Console.ReadLine();
            Console.Write("Enter Client Secret: ");
            var secret = Console.ReadLine();
            Console.Write("Enter Scope requesting: ");
            var scope = Console.ReadLine();



            Console.Write("Enter UserName: ");
            var user = Console.ReadLine();



            Console.Write("Enter Password: ");
            var pswd = Console.ReadLine();


            Console.Clear();
            Console.Write("Results for Getting Token: \n\n\n");
            var token = Token.GetTokenWithCred(client, secret, scope, user, pswd);
            Console.Write("\n\n-------------------------------------------------------------------- \n\n\n");


            Console.Write("Results for Calling API: \n\n\n");
            Client.CallApi(token, controller, action);
            Console.Write("\n\n-------------------------------------------------------------------- \n\n\n");
        }


    }
}
