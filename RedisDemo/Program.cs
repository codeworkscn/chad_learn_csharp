using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StackExchange.Redis;


/************************************
 
ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("contoso5.redis.cache.windows.net,abortConnect=false,ssl=true,password=...");
SSL PORT: 6380
PRIMARY:  Yk7JAxMUhbSaXQz0uWsTO7ev8O08x1vfLAlshcu6k4U=
SECONDARY:xlESarDvGfH9DIKjWKVPySUL6jijYw9rlQG768Ufpa0=

*************************************/

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("10.64.68.127");
            IDatabase db = redis.GetDatabase();
            string value = "abcdefg";
            db.StringSet("mykey", value);
            Console.WriteLine(db.StringGet("mykey")); // writes: "abcdefg"

            Console.ReadKey();
        }
    }
}
