using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    public class Redis
    {

        private readonly ConnectionMultiplexer _redis;

        public bool IsNullOrEmpty { get; private set; }

        public Redis(string redisConnectionString)
        {
            _redis = ConnectionMultiplexer.Connect(redisConnectionString);
        }

        public void VeriEkle(string key, string value)
        {
            IDatabase db = _redis.GetDatabase();
            db.StringSet(key, value);
            Console.WriteLine("Veri eklendi: Key = {0}, Value = {1}", key, value);
        }

        public void VeriSil(string key)
        {
            IDatabase db = _redis.GetDatabase();
            bool silindiMi = db.KeyDelete(key);

            if (silindiMi)
            {
                Console.WriteLine("Veri silindi: Key = {0}", key);
            }
            else
            {
                Console.WriteLine("Veri bulunamadı: Key = {0}", key);
            }
        }

        public string VeriGetir(string key)
        {
            IDatabase db = _redis.GetDatabase();
            string value = db.StringGet(key);

            if (!string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Veri getirildi: Key = {0}, Value = {1}", key, value);
                return value;
            }
            else
            {
                Console.WriteLine("Veri bulunamadı: Key = {0}", key);
                return null;
            }
        }
    }
}
