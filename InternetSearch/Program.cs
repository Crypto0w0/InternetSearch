using System.Net;
using System.Net.Sockets;
using System.Text;

class InternetSearch
{
    static async Task Main()
    {
        try
        {
            Console.WriteLine("Enter the request: ");
            string req = Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {
                string url1 = $"http://google.com/search?q={req}";
                string url2 = $"http://yahoo.com/search?q={req}";
                string url3 = $"http://firefox.com/search?q={req}";

                HttpResponseMessage res1 = await client.GetAsync(url1);
                string rbody1 = await res1.Content.ReadAsStringAsync();
                HttpResponseMessage res2 = await client.GetAsync(url2);
                string rbody2 = await res2.Content.ReadAsStringAsync();
                HttpResponseMessage res3 = await client.GetAsync(url3);
                string rbody3 = await res3.Content.ReadAsStringAsync();
                Console.WriteLine("Google: " + rbody1);
                Console.WriteLine("Yahoo: " + rbody2);
                Console.WriteLine("Firefox: " + rbody3);
            }
        }
        catch (WebException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}