using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Fisioterapia.Importador
{
    public class Program
    {
        private static IConfiguration _iconfiguration;

        public static void Main(string[] args)
        {
            GetAppSettingsFile();
        }

        public static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }
    }
}
