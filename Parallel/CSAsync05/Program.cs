using System;
using System.Threading.Tasks;

namespace CSAsync05
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main is running....");
            var aWork = MyWorkAsync(10000); // 异步调用，不等待调用的结束
            await MyWorkAsync(20000);       // 异步调用，并等待调用的结束
            var y = MyFuncAsync(0.1);       // 异步调用，不等待结果的返回
            Console.WriteLine($"y = {await y}");  // 等待之前调用的结果
            Console.WriteLine("Press RETURN to exit...");
            Console.ReadLine();
        }
        static async Task MyWorkAsync(int n)
        {
            Console.WriteLine($"MyWorkAsync({n}) is called...");
            await Task.Run(() =>
            {
                string s = "";
                for (int i = 0; i < n; i++) s += i.ToString();  // 用字符串拼接来模拟一段耗时操作
            });
            Console.WriteLine($"MyWorkAsync({n}) is over.");
        }
        static async Task<double> MyFuncAsync(double x)
        {
            return await Task.Run<double>(() => x * x * x);
        }
    }
}
