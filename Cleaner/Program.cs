using Cleaner.Helpers;
using System.Reflection;

namespace Cleaner;

public class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            var versionString = Assembly.GetEntryAssembly()?
                                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.ToString();
            Console.WriteLine($"cleaner v{versionString}\n\n");

            Console.WriteLine("Options:\r\n  -path|--path         A required parameter. Write the path to the folder after this params");

            return;
        }

        //Add Validations here 

        if (StaticMethods.IsPathParameterPrensent(args))
        {
            Console.WriteLine("Missing:\r\n  -path|--path         A required parameter. Write the path to the folder after this parameter");
        }

        CleanerMain cleaner = new();
        cleaner.RunCleaner(args);
    }
}