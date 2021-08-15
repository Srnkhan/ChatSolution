using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChatCore.Configuration
{
    public class ConfigurationManager
    {
        public readonly IConfigurationRoot root;
        private static ConfigurationManager _configurationManager;
        public static ConfigurationManager GetInstance()
        {
            return _configurationManager ?? new ConfigurationManager();
        }
        public ConfigurationManager()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = string.Empty;
            path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            root = configurationBuilder.Build();
        }
        public string GetConnectionString()
        {
            string connectionString = "";
#if DEBUG
            connectionString = root.GetSection("MsSqlConnectionDebug").GetSection("DataConnection").Value;
#endif
#if Release
            connectionString = root.GetSection("MsSqlConnectionRelease").GetSection("DataConnection").Value;
#endif
#if DebugMySql
            connectionString = root.GetSection("MySqlConnectionDebug").GetSection("DataConnection").Value;
#endif
#if ReleaseMySql
            connectionString = root.GetSection("MySqlConnectionRelease").GetSection("DataConnection").Value;
#endif
            return connectionString;
        }
        public string GetRedisConnectionString()
        {
            string connectionString = "";
#if DEBUG || DebugMySql
            connectionString = root.GetSection("RedisConnectionDebug").GetSection("DataConnection").Value;
#endif
#if Release || ReleaseMySql
            connectionString = root.GetSection("RedisConnectionRelease").GetSection("DataConnection").Value;
#endif
            return connectionString;
        }
        public int GetRedisConnectionExpireTime()
        {
            var connectionString = root.GetSection("Configuration").GetSection("RedisCacheExpire").Value;

            return Convert.ToInt32(connectionString);
        }
    }
}

