using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Cleaner;

public class Program
{
    private static void Main(string[] args)
    {
        IHost host = CreateHost();

        CleanerMain cleanerMain = ActivatorUtilities.CreateInstance<CleanerMain>(host.Services);
        cleanerMain.RunCleaner(args);

        if (args.Length == 0)
        {
            var versionString = Assembly.GetEntryAssembly()?
                                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.ToString();
            Console.WriteLine($"cleaner v{versionString}\n\n");

            Console.WriteLine("Options:\r\n  path|-path|--path         A required parameter. Write the path to the folder after this params");

            return;
        }

        //Add Validations here

        if (StaticMethods.IsPathParameterPrensent(args))
        {
            Console.WriteLine("Missing:\r\n  path|-path|--path         A required parameter. Write the path to the folder after this parameter");
        }
    }

    private static IHost CreateHost() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                //Add DI here 
            })
            .Build();

}