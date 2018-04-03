using System;
using System.Net;
using System.Threading.Tasks;

namespace CSAsync03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main start...");
            Task<string> t1 = DownloadAsync("https://www.cnblogs.com");
            Task<string> t2 = DownloadAsync("https://www.cnblogs.com");
            Console.WriteLine($"Called.");
            Console.WriteLine($"Download1 length is {t1.Result.Length}");
            Console.WriteLine($"Download2 length is {t2.Result.Length}");
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
