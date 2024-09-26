using Microsoft.Extensions.Logging;

namespace Loginproyectvet
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Services.AddSingleton<LocalDbService>();
            builder.Services.AddTransient<CitasProgramadas>();
            builder.Services.AddTransient<Expedientes>();
            builder.Services.AddTransient<Hospitalizacion>();
            builder.Services.AddTransient<Donacion>();
            builder.Services.AddTransient<ListaDonar>();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
