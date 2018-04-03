using System;
using System.Threading;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Main thread starting...");
        Thread aThread1 = new Thread(new ParameterizedThreadStart(WorkThread));
        Thread aThread2 = new Thread(new ParameterizedThreadStart(WorkThread));
        aThread1.Start(new ActionDelegate(Tick));
        aThread2.Start(new ActionDelegate(Tock));
        aThread1.Join();
        aThread2.Join();
        Console.WriteLine("Main thread finished, press RETURN to exit...");
        Console.ReadLine();
    }
    private delegate void ActionDelegate();
    private static void WorkThread(object aAction)
    {
        for (int i = 0; i < 5; i++)
        {
            (aAction as ActionDelegate)();
        }
    }
    private static void Tick()
    {
        Console.WriteLine("Tick"); Thread.Sleep(100);
    }
    private static void Tock()
    {
        Console.WriteLine("Tock"); Thread.Sleep(100);
    }
}

