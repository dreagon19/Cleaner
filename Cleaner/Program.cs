using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cleaner;

public class Program
{
    private static void Main(string[] args)
    {


        IHost host = CreateHost();

        CleanerMain cleanerMain = ActivatorUtilities.CreateInstance<CleanerMain>(host.Services);
        cleanerMain.RunCleaner(args);

        #region For Testing
        //Console.WriteLine("Enter path");
        //var input = Console.ReadLine();
        //cleanerMain.RunCleaner(new []{input});
        #endregion
    }

    private static IHost CreateHost() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                //Add DI here 
            })
            .Build();

}