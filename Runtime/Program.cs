using System;
using Database;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace Runtime
{
    class Program
    {
        private static bool isService;
        public static IConfiguration Configuration { get; }
         = new ConfigurationBuilder()
            .SetBasePath(BasePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        public static string BasePath
        {
            get
            {
                var assembly = typeof(Program).Assembly;
                var assemblyPath = Path.GetDirectoryName(assembly.Location);
                return assemblyPath.Contains(@"\bin\") ? Directory.GetCurrentDirectory() : assemblyPath;
            }
        }

        public static string LogPath
        {
            get
            {
                return Path.Combine(BasePath, "Logs");
            }
        }

        public static async Task Main(string[] args)
        {
            isService = !(Debugger.IsAttached || args.Contains("--console"));
            var outputTemplate = "{Timestamp:dd-MM-yyyy HH:mm:ss.fff zz} [{Level:u3}] ({SourceContext}) {Message:lj}{NewLine}{Exception}";
        }
    }
}
