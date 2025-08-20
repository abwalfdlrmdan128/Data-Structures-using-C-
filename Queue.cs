using System;
using System.Collections.Generic;
using System.Text;

namespace queue
{
    class Program
    {
        static void Main(string[] args)
        {
            queue q = new queue();
            q.enqueue(5);
            q.enqueue(1);
            q.enqueue(8);
            Console.WriteLine(q.front());
            
            q.dequeue();
            q.dequeue();
            q.dequeue();
            q.dequeue();



            Console.Read();
        }
    }
    class queue
    {
        int[] qu = new int[20];
        int last = -1;
        
        public bool isempty()
        {
            if (last == -1) { return true; }
            else { return false; }

        }
        public bool isfull()
        {
            if (last == 19) { return true; }
            else { return false; }

        }
        public void enqueue(int d)
        {
            if (isfull())
            {
                Console.WriteLine("error");
            }
            else
            {
                last++;
                qu[last] = d;
            }
        }
        public void dequeue()
        {
            if (isempty()) { Console.WriteLine("error"); }
            else
            {
                Console.WriteLine( qu[0]);
                for (int i = 1; i <= last; i++)
                {
                    qu[i - 1] = qu[i];
                }
                last--;
                
            }
        }
        public int front()
        {
            return qu[0];
        }
        public int size()
        {
            return last+1;
        }
    }
}
