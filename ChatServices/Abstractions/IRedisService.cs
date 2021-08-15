using System;
using System.Collections.Generic;
using System.Text;

namespace ChatServices.Abstractions
{
    public interface IRedisService
    {
        public T PopKey<T>(string key) where T : new();
        public bool SetKey<T>(string key, T value);
    }
}
