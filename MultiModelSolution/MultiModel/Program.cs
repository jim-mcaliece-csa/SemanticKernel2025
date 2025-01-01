#pragma warning disable SKEXP0050

using Microsoft.SemanticKernel;
using MultiModel.Settings;

namespace MultiModel
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Multi-Model Demo");
            try
            {

                // Display all Azure Settings to the console.
                Console.WriteLine($"Endpoint: {Settings.AzureOpenAiSettings.Endpoint}");
                Console.WriteLine($"ApiKey: {Settings.AzureOpenAiSettings.ApiKey}");
                Console.WriteLine($"DeploymentNameGPT4o: {Settings.AzureOpenAiSettings.DeploymentNameGPT4o}");
                Console.WriteLine($"ModelNameGPT4o: {Settings.AzureOpenAiSettings.ModelNameGPT4o}");
                Console.WriteLine($"DeploymentNameGP35Turbo: {Settings.AzureOpenAiSettings.DeploymentNameGPT35Turbo}");
                Console.WriteLine($"ModelNameGP35Turbo: {Settings.AzureOpenAiSettings.ModelNameGPT35Turbo}");
                Console.WriteLine("Press any key to exit.");

                // Build the Kernel
                var builder = Kernel.CreateBuilder();
                builder.AddAzureOpenAIChatCompletion(
                    AzureOpenAiSettings.DeploymentNameGPT4o,
                    AzureOpenAiSettings.Endpoint,
                    AzureOpenAiSettings.ApiKey,
                    AzureOpenAiSettings.ModelNameGPT4o);
                builder.AddAzureOpenAIChatCompletion(
                    AzureOpenAiSettings.DeploymentNameGPT35Turbo,
                    AzureOpenAiSettings.Endpoint,
                    AzureOpenAiSettings.ApiKey,
                    AzureOpenAiSettings.ModelNameGPT35Turbo);
                var kernel = builder.Build();

                // Create a Prompt
                var prompt = "Did Monty Python sing a song about lumberjacks?";

                // Create KernelArguments, one for each model
                KernelArguments kernelArguments = new()
                {
                    ExecutionSettings = new Dictionary<string, PromptExecutionSettings>
                {
                    { AzureOpenAiSettings.ModelNameGPT35Turbo, new() }
                }
                };

                var response = await kernel.InvokePromptAsync(prompt, kernelArguments);
                Console.WriteLine($"Response from GPT-3.5-Turbo: {response}");

                kernelArguments = new()
                {
                    ExecutionSettings = new Dictionary<string, PromptExecutionSettings>
                {
                    { AzureOpenAiSettings.ModelNameGPT35Turbo, new() }
                }
                };

                response = await kernel.InvokePromptAsync(prompt, kernelArguments);
                Console.WriteLine($"Response from GPT-4o: {response}");



                Console.ReadLine();

            }
            catch (Exception ex)
            {
                // Write the exception to the console.
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
