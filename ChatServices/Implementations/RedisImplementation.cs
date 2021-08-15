using ChatCore.Configuration;
using ChatServices.Abstractions;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatServices.Implementations
{
    public class RedisImplementation : IRedisService
    {
        public T PopKey<T>(string key) where T : new()
        
        {
            try
            {
                using (RedisClient client = new RedisClient())
                {
                    return client.Get<T>(key);
                }

            }
            catch (Exception ex)
            {
                return new T();                
            }
        }

        public bool SetKey<T>(string key, T value)
        {
            try
            {
                using (RedisClient client = new RedisClient())
                {
                    var cachedata = client.As<T>();
                    cachedata.SetValue(key, value , TimeSpan.FromMinutes(ConfigurationManager.GetInstance().GetRedisConnectionExpireTime()));                     
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
