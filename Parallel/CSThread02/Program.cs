using System;
using System.Threading;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Main thread starting...");
        Thread aThread1 = new Thread(new ThreadStart(MyThread));
        aThread1.Name = "Thread1";
        Thread aThread2 = new Thread(new ThreadStart(MyThread));
        aThread2.Name = "Thread2";
        Thread aThread3 = new Thread(new ThreadStart(MyThread));
        aThread3.Name = "Thread3";
        aThread1.Start();
        aThread2.Start();
        aThread3.Start();
        while (aThread1.IsAlive && aThread2.IsAlive && aThread3.IsAlive)
        {
            Console.Write(".");
            Thread.Sleep(100);
        }
        Console.WriteLine("Main thread finished, press RETURN to exit...");
        Console.ReadLine();
    }
    private static void MyThread()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} starting...");
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(500);
            Console.WriteLine($"In {Thread.CurrentThread.Name}, Count is {i}");
        }
        Console.WriteLine($"{Thread.CurrentThread.Name} terminating.");
    }
}
