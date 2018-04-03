using System;
using System.Threading;

class Program
{
    public static void Main()
    {
        Thread aThread = new Thread(new ParameterizedThreadStart(MyThreadStart));
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} create thread {aThread.ManagedThreadId}.");
        aThread.Start("Hello, World!");
        aThread.Join();
        Console.WriteLine($"Press RETURN to exit thread {Thread.CurrentThread.ManagedThreadId}...");
        Console.ReadLine();
    }
    private static void MyThreadStart(object obj)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is running: {obj}");
    }
}
