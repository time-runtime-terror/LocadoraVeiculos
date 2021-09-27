using Serilog;
using Serilog.Events;

namespace LocadoraVeiculos.Infra.Logging
{
    public static class SerilogInit
    {
        public static void ConfigurarLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("info.log",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Debug)
                .WriteTo.File("error.log",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Warning)
                .WriteTo.Seq("http://20.195.229.236:5341",
                    restrictedToMinimumLevel: LogEventLevel.Error)
                .CreateLogger();
        }
    }
}
