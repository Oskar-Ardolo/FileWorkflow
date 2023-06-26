using FileWorkflow.Console;
using FileWorkflow.Library;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.CommandLine;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("FileWorkflow.Console Application");

        var configOption = new Option<FileInfo>(
            name: "--config",
            description: "Configuration file. If no value provided, default appsettings path will be selected");
        configOption.AddAlias("--c");
        configOption.SetDefaultValue(new FileInfo("appsettings.json"));
       
        rootCommand.AddOption(configOption);

        rootCommand.SetHandler((configFilePath) =>
        {
            CommandOptionsWrapper wrapper = new CommandOptionsWrapper
            {
                ConfigFilePath = configFilePath
            };

            _ = ConfigureApplicationAsync(wrapper);
        }, configOption);

        return await rootCommand.InvokeAsync(args);
    }

    static Task ConfigureApplicationAsync(CommandOptionsWrapper options)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        var configBuilder = new ConfigurationBuilder()
        .AddJsonFile(options.ConfigFilePath.FullName);

        var configuration = configBuilder.Build();
        builder.Services.Configure<FileWorkflowApplication>(configuration.GetSection("FileWorkflowApplication"));

        builder.Services.ConfigureWorkflowService();

        builder.Services.AddScoped<WorkflowProcessing>();

        using IHost host = builder.Build();
        StartApplication(host.Services);
        return Task.CompletedTask;
    }

    static void StartApplication(IServiceProvider provider)
    {
        WorkflowProcessing _app = provider.GetService<WorkflowProcessing>();
        _app.Start();
    }
}