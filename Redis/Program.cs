using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Redis
{


    public class Program
    {
        public static void Main(string[] args)
        {
            string redisConnectionString = "redis-14441.c11.us-east-1-3.ec2.cloud.redislabs.com:14441";
            Redis redisExample = new Redis(redisConnectionString);

            // Veri ekleme
            redisExample.VeriEkle("key1", "value1");
            redisExample.VeriEkle("key2", "value2");

            // Veri getirme
            string value1 = redisExample.VeriGetir("key1");
            string value2 = redisExample.VeriGetir("key2");
            string value3 = redisExample.VeriGetir("key3");

            // Veri silme
            redisExample.VeriSil("key1");
            redisExample.VeriSil("key2");
            redisExample.VeriSil("key3");
        }
    }

}
