using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    internal class MyClass
    {
        Thread thread;
        AutoResetEvent resetEvent;
        bool stop;


        public MyClass()
        {
            resetEvent = new AutoResetEvent(false);
            thread = new Thread(Run);
            thread.Start();

            string input;
            while((input = Console.ReadLine()) != "exit")
            {
                if(input == "think")
                {
                    resetEvent.Set();    
                }
                Console.WriteLine($"You said: {input}"); 
           }
               
            stop = true;
            thread.Abort();
        }
        
        void Run()
        {
            while (!stop)
            {
                resetEvent.WaitOne();
                Console.WriteLine("Thinking...");
                for (int i = 0; i < 1000000000; i++)
                {
                    i++;
                    i--;
                }
                Console.WriteLine("Wow, that was hard...");
            }
        }
    }
}
