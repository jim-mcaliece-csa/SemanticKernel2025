using Microsoft.Extensions.Configuration;
namespace MultiModel.Settings
{
    public static class AzureOpenAiSettings
    {
        public static IConfigurationRoot Configuration { get; set; }

        static AzureOpenAiSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public static string Endpoint => Configuration["AzureOpenAI:Endpoint"];
        public static string ApiKey => Configuration["AzureOpenAI:ApiKey"];
        public static string DeploymentNameGPT4o => Configuration["AzureOpenAI:DeploymentNameGPT4o"];
        public static string ModelNameGPT4o => Configuration["AzureOpenAI:ModelNameGPT4o"];
        public static string DeploymentNameGPT35Turbo => Configuration["AzureOpenAI:DeploymentNameGPT35Turbo"];
        public static string ModelNameGPT35Turbo => Configuration["AzureOpenAI:ModelNameGPT35Turbo"];
    }
}
