using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StackExchange.Redis;

namespace RedisPub
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("10.64.68.127");
            ISubscriber sub = redis.GetSubscriber();

            sub.Publish("messages","Redis Pub Start...");


            while(true)
            {
                Console.Write(" > ");
                var message = Console.ReadLine();
                if (message.Equals("exit")) {
                    Console.WriteLine("exit ... ");                   
                    break;
                }
                sub.Publish("messages",message);
            }
            
            sub.Publish("messages","Redis Pub Stop.");
        }
    }
}
