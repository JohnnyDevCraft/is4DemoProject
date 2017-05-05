using System;
using IdentityModel.Client;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace IdentityTest.Client
{
    class Program
    {
        public static string ApiRoot { get; set; }
        public static string AccessApi { get; set; }

        static void Main(string[] args)
        {
            try
            {
                var exit = false;

                Console.Clear();
                SetRootApi();
                SetAccessApiPort();


                while (!exit)
                {

                    Runtest(ref exit);

                }

                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Exception Thrown of type {ex.GetType().Name}: ");
                Console.WriteLine($"Message: {ex.Message}\n\n\n");
                Console.WriteLine(ex.StackTrace);

                Console.ReadKey();

            }

        }


        static void SetAccessApiPort()
        {

            bool accept = false;

            while (!accept)
            {
                Console.Clear();
                Console.Write("Enter Identity Server Port: ");
                int port = 0;
                var portstr = Console.ReadLine();
                if (int.TryParse(portstr, out port))
                {
                    AccessApi = $"http://localhost:{port}";
                    accept = true;
                }
                else
                {
                    Console.WriteLine("Invalid Port Not Assigned.");
                }
            }



        }


        public static void Runtest(ref bool exit)
        {
            Console.Clear();

            Console.Write("Use token for Call? Y or N: ");
            var useTokenResp = Console.ReadKey();
            var useToken = new List<char> { 'Y', 'y' }.Contains(useTokenResp.KeyChar);

            Console.Clear();
            Console.Write("Target Controller: ");
            var controller = Console.ReadLine();

            Console.Write("Target Action: ");
            var action = Console.ReadLine();


            if (useToken)
            {

                Console.Write("Use user credetials? Y or N: ");
                var userTokenResp = Console.ReadKey();
                var userToken = new List<char> { 'Y', 'y' }.Contains(useTokenResp.KeyChar);

                if (userToken)
                {
                    Runner.RunWithUserToken(controller, action);

                }
                else
                {
                    Runner.RunWithClientToken(controller, action);
                }

            }
            else
            {
                Runner.RunWithoutToken(controller, action);

            }


            Console.Write("Would you like to run another test? Y or N: ");
            exit = new List<char> { 'N', 'n' }.Contains(Console.ReadKey().KeyChar);
        }


        static void SetRootApi()
        {
            var accept = false;

            while (!accept)
            {
                Console.Clear();
                Console.Write("Enter Root Api Server Name: ");
                var apiRootName = Console.ReadLine();
                Console.Write("Enter Root Api Server Port: ");
                var apiRootPortstring = Console.ReadLine();

                if (int.TryParse(apiRootPortstring, out int port))
                {
                    ApiRoot = $"http://{apiRootName}:{port}";
                    accept = true;
                }
                else
                {
                    Console.WriteLine("Invalid Port Not Assigned.");
                }
            }
        }






    }
}
