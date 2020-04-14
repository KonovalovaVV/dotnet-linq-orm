using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infrastructure.AppSettings
{
    public class AppSettingsProvider
    {
        public readonly AppSettings Settings;
        private const string FileName = "AppSettings.json";
        private const string SectionName = "Settings";
        private static readonly Lazy<AppSettingsProvider> Instance =
            new Lazy<AppSettingsProvider>(() => new AppSettingsProvider());

        private AppSettingsProvider()
        {
            Settings = GetSettings();
        }

        private AppSettings GetSettings()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(FileName, optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            AppSettings appSettings = configuration.GetSection(SectionName).Get<AppSettings>();
            return appSettings;
        }

        public static AppSettingsProvider GetInstance()
        {
            return Instance.Value;
        }
    }
}
