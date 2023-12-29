using Microsoft.Extensions.Logging;

namespace Mobile;

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
                fonts.AddFont("Ofont_ru_Optimus.ttf", "Ofont_ru_Optimus");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
