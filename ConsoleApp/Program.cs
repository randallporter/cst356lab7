using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;
using System.Net;
using System.Net.Http.Formatting;

namespace ConsoleApp
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(){
            RunAsync().Wait();
        }

        static async Task RunAsync(){
            client.BaseAddress = new Uri("http://localhost:56344/api/Event");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.ReadLine();
        }

        static async Task<Event> GetProductAsync(string path)
        {
            Event anEvent = null;
            HttpResponseMessage response = await client.GetAsync(path);

            var formatters = new List<MediaTypeFormatter>() {
                new JsonMediaTypeFormatter(),
                new XmlMediaTypeFormatter()
            };

            if (response.IsSuccessStatusCode)
            {
                //anEvent = await response.Content.ReadAsAsync<IEnumerable<Event>>(formatters);
                anEvent = await response.Content.ReadAsAsync<Event>();
            }
            return anEvent;
        }
    }
}
