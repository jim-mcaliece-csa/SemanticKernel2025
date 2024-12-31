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
        public static string Deployment_GPT4o => Configuration["AzureOpenAI:DeploymentName-GPT4o"];
        public static string Model_GPT4o => Configuration["AzureOpenAI:ModelName-GPT4o"];
        public static string Deployment_GPT35Turbo => Configuration["AzureOpenAI:DeploymentName-GPT35Turbo"];
        public static string Model_GPT35Turbo => Configuration["AzureOpenAI:ModelName-GPT35Turbo"];
    }
}
