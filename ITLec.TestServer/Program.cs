using AwesomeServer;
using AwesomeServer.Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
namespace ITLec.TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseAwesomeServer(o => o.FolderPath = @"C:\DeleteME\TestServer\ServerFolder")
                .UseStartup<Startup>()
                .Build();
    }
}
