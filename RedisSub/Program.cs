using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StackExchange.Redis;
using System.Threading;

namespace RedisSub
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("10.64.68.127");
            ISubscriber sub = redis.GetSubscriber();


            sub.Subscribe("messages", (channel, message) =>
            {
                Console.WriteLine((string)message);
            });

            while (true)
            {
                Console.WriteLine(" input \"exit\" to exit ");
                Console.Write(" > ");
                var message = Console.ReadLine();
                if (message.Equals("exit"))
                {
                    Console.WriteLine("exit ... ");
                    break;
                }
                Thread.Sleep(1000);
            }

        }
    }
}
