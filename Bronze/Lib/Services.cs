using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Bronze.Lib
{
    public static class Services
    {
        public static MemoryCache Cache;
        public static IConfigurationRoot Config;
        static Services()
        {
            ConfigurationBuilder root = new();
            if(!File.Exists("config.toml"))
            {
                Console.WriteLine("[WARN] config.toml not found, supplying default config (NO API KEYS)");
            }
            else {
                root.AddTomlFile("config.toml");
            }
            Cache = new(new MemoryCacheOptions(){});
            Config = root.Build();
        }
    }
}