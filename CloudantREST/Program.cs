using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace CloudantREST
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://mikeamm.cloudant.com/pouchrecords");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest(Method.GET);

            // easily add HTTP Headers
            request.AddHeader("Content-Type", "application/json");

            //unfinite loop until esc key is pressed
            Console.WriteLine("Press ESC to stop");
            do
             {

                    IRestResponse syncresponse = client.Execute(request);
                Console.WriteLine(syncresponse);

                // easy async support
                client.ExecuteAsync(request, response => {
                    Console.WriteLine(response.Content);
                });
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}
