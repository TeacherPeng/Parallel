using System;
using System.Net;
using System.Threading.Tasks;

namespace CSAsync04
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main start...");
            var t1 = DownloadAsync("https://www.cnblogs.com");
            var t2 = DownloadAsync("https://www.cnblogs.com");
            Console.WriteLine($"Called.");
            Console.WriteLine($"Download1 length is {(await t1).Length}");
            Console.WriteLine($"Download2 length is {(await t2).Length}");
            Console.WriteLine("Press RETURN to exit...");
            Console.ReadLine();
        }
        static async Task<string> DownloadAsync(string aUrl)
        {
            Console.WriteLine($"Start download...");
            WebClient aWebClient = new WebClient();
            string aResult = await aWebClient.DownloadStringTaskAsync(aUrl);
            Console.WriteLine($"Downloaded.");
            return aResult;
        }
    }
}
