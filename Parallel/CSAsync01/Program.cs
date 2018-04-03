using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAsync01
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        static async Task MyTask()
        {
            Console.WriteLine("MyTask is running...");
            await Task.Delay(2000);
            Console.WriteLine("MyTask is finished.");
        }
    }
}
