using Microsoft.Extensions.Configuration;

namespace SK_Observability.Settings
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
        public static string DeploymentName => Configuration["AzureOpenAI:DeploymentName"];
        public static string ModelName => Configuration["AzureOpenAI:ModelName"];
    }
}
