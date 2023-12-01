using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace NHNT.Constants
{
    public class AppSettingConfig
    {
        public static string Secret { get; }
        public static byte[] SecretByte { get; }
        public static string Audience { get; }
        public static string Issuer { get; }
        public static double TokenExpiredTime { get; }
        public static double RefreshTokenExpiredTime { get; }
        public static string Algorithms { get; } = SecurityAlgorithms.HmacSha256;

        static AppSettingConfig()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Secret = config.GetValue<string>("AppSettings:Secret", "ow0zffmU3WqsPhzKJAXrQ2PexENkdMlX");
            SecretByte = Encoding.UTF8.GetBytes(Secret);
            Audience = config.GetValue<string>("AppSettings:Audience", "*");
            Issuer = config.GetValue<string>("AppSettings:Issuer", "*");
            TokenExpiredTime = config.GetValue<Double>("AppSettings:TokenExpiredTime", 3600000);
            RefreshTokenExpiredTime = config.GetValue<Double>("AppSettings:RefreshTokenExpiredTime", 2592000000);
        }
    }
}