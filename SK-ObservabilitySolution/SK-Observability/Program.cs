#pragma warning disable SKEXP0050

using Microsoft.SemanticKernel;
using SK_Observability.Settings;
using SK_Observability.Plugins;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Resources;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;


namespace SK_Observability
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Write("Observability Proof");
            // Telemetry setup code goes here
            var resourceBuilder = ResourceBuilder
             .CreateDefault()
             .AddService("TelemetryConsoleQuickstart");

            // Enable model diagnostics with sensitive data.
            AppContext.SetSwitch("Microsoft.SemanticKernel.Experimental.GenAI.EnableOTelDiagnosticsSensitive", true);

            using var traceProvider = Sdk.CreateTracerProviderBuilder()
                .SetResourceBuilder(resourceBuilder)
                .AddSource("Microsoft.SemanticKernel*")
                .AddConsoleExporter()
                .Build();

            //using var meterProvider = Sdk.CreateMeterProviderBuilder()
            //    .SetResourceBuilder(resourceBuilder)
            //    .AddMeter("Microsoft.SemanticKernel*")
            //    .AddConsoleExporter()
            //    .Build();

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                // Add OpenTelemetry as a logging provider
                builder.AddOpenTelemetry(options =>
                {
                    options.SetResourceBuilder(resourceBuilder);
                    options.AddConsoleExporter();
                    // Format log messages. This is default to false.
                    options.IncludeFormattedMessage = true;
                    options.IncludeScopes = true;
                });
                builder.SetMinimumLevel(LogLevel.Information);
            });

            var builder = Kernel.CreateBuilder();
            

            builder.AddAzureOpenAIChatCompletion(
                AzureOpenAiSettings.Deployment_GPT4o,
                AzureOpenAiSettings.Endpoint,
                AzureOpenAiSettings.ApiKey,
                AzureOpenAiSettings.Model_GPT4o);

            var kernel = builder.Build();

           
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

            // Add a plugin (the LightsPlugin class is defined below)
            kernel.Plugins.AddFromType<LightsPlugin>("Lights");

            // Enable planning
            OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(),                 
                
            };

            // Create a history store the conversation
            var history = new ChatHistory();
            history.AddUserMessage("First: Are the lights on?");

            // Get the response from the AI
            var result = await chatCompletionService.GetChatMessageContentAsync(
               history,
               executionSettings: openAIPromptExecutionSettings,
               kernel: kernel
               );

            // Print the results
            Write("Assistant > " + result);

            // Add the message from the agent to the chat history
            history.AddAssistantMessage(result.ToString());

            history.AddUserMessage("Turn on the Porch");

            // Get the response from the AI
            result = await chatCompletionService.GetChatMessageContentAsync(
               history,
               executionSettings: openAIPromptExecutionSettings,
               kernel: kernel);
            history.AddAssistantMessage(result.ToString());

            history.AddUserMessage("Last: Are the lights on?");

            // Get the response from the AI
            result = await chatCompletionService.GetChatMessageContentAsync(
               history,
               executionSettings: openAIPromptExecutionSettings,
               kernel: kernel);

            // Print the results
            Write("Assistant > " + result);

            Write("Press any key to end");
            Console.ReadKey();
        }
        private static void Write(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

       
    }
}
