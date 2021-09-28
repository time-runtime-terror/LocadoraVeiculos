using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;

namespace LocadoraVeiculos.Infra.Logging
{
    public static class LocadoraLog
    {
        private static LoggingLevelSwitch LevelSwitch { get; set; } = new LoggingLevelSwitch();

        static LocadoraLog()
        {
            LevelSwitch.MinimumLevel = LogEventLevel.Information;
        }

        public static void CriarLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(LevelSwitch)
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
                    apiKey: "7vhi2xy0pSo6lsVGHzi2",
                    controlLevelSwitch: LevelSwitch)
                .CreateLogger();
        }

        public static void ConfigurarNivel(LogEventLevel nivel)
        {
            LevelSwitch.MinimumLevel = nivel;
        }
    }
}
