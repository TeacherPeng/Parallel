using System;
using System.Threading;
using System.Collections;

namespace CSThread07
{
    class MonitorSample
    {
        const int MAX_LOOP_TIME = 1000;
        Queue m_Queue;

        public MonitorSample()
        {
            m_Queue = new Queue();
        }
        public void FirstThread()
        {
            lock (m_Queue)
            {
                for (int i = 0; i < MAX_LOOP_TIME; i++)
                {
                    //Wait, if the queue is busy.
                    Monitor.Wait(m_Queue);
                    //Push one element.
                    m_Queue.Enqueue(i);
                    //Release the waiting thread.
                    Monitor.Pulse(m_Queue);
                }
            }
        }
        public void SecondThread()
        {
            lock (m_Queue)
            {
                //Release the waiting thread.
                Monitor.Pulse(m_Queue);
                //Wait in the loop, while the queue is busy.
                //Exit on the time-out when the first thread stops. 
                while (Monitor.Wait(m_Queue, 1000))
                {
                    //Pop the first element.
                    int counter = (int)m_Queue.Dequeue();
                    //Print the first element.
                    Console.WriteLine(counter.ToString());
                    //Release the waiting thread.
                    Monitor.Pulse(m_Queue);
                }
            }
        }
        //Return the number of queue elements.
        public int GetQueueCount()
        {
            return m_Queue.Count;
        }

        static void Main(string[] args)
        {
            //Create the MonitorSample object.
            MonitorSample test = new MonitorSample();
            //Create the first thread.
            Thread tFirst = new Thread(new ThreadStart(test.FirstThread));
            //Create the second thread.
            Thread tSecond = new Thread(new ThreadStart(test.SecondThread));
            //Start threads.
            tFirst.Start();
            tSecond.Start();
            //wait to the end of the two threads
            tFirst.Join();
            tSecond.Join();
            //Print the number of queue elements.
            Console.WriteLine("Queue Count = " + test.GetQueueCount().ToString());
        }
    }
}

