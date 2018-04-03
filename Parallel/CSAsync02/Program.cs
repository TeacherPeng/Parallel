using System;
using System.Threading.Tasks;

namespace CSAsync02
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main is running...");
            await MyTask();
            Console.WriteLine("Main is finished, press RETURN to exit...");
            Console.ReadLine();
        }
        static async Task MyTask()
        {
            Console.WriteLine("MyTask is running...");
            await Task.Delay(2000);
            Console.WriteLine("MyTask is finished.");
        }
    }
}
