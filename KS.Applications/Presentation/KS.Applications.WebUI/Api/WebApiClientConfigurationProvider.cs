namespace KS.Applications.WebUI.Api
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;

    public static class WebApiClientConfigurationProvider
    {
        private static readonly IConfigurationRoot s_configRoot = ConfigureSettings();

        public static Lazy<WebApiClientConfiguration> ClientConfiguration { get; } =
            new Lazy<WebApiClientConfiguration>(() =>
            {
                var config = s_configRoot.GetSection("ClientConfiguration").Get<WebApiClientConfiguration>();

                return config;
            });

        private static IConfigurationRoot ConfigureSettings()
        {
            // NOTE: Partho: IHostingEnvironment is not available hence not adding $"appsettings.{env.EnvironmentName}.json"
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(typeof(WebApiClientConfigurationProvider).Assembly.Location))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile("appsettings.localdev.json", optional: true)
                .AddEnvironmentVariables();

            return configBuilder.Build();
        }
    }
}
