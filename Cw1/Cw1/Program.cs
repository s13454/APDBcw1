using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Cw1
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync("https://www.pja.edu.pl");

            if(result.IsSuccessStatusCode)
            {
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z0-9]+@+[a-z0-9]+\\.[a-z]+",
                    RegexOptions.IgnoreCase);

                MatchCollection matches = regex.Matches(html);
                foreach (var m in matches)
                {
                    Console.WriteLine(m);
                }
            }


            Console.WriteLine("Koniec");

        }
    }
}
