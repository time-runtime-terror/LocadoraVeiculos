using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace LocadoraVeiculos.Infra.Logging
{
    public static class SerilogInit
    {
        public static void ConfigurarLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .WriteTo.File("info.log",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Debug)
                .WriteTo.File("error.log",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Warning)
                .WriteTo.Seq("http://20.195.229.236:5341",
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();
        }
    }
}
