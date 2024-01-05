using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.Identification.Authorization;
using System.Reflection;

namespace Mobile;

/// <summary>
/// Запускаем класс программы
/// </summary>
public static class MauiProgram
{
    /// <summary>
    /// Метод создания приложения
    /// </summary>
    /// <returns></returns>
    public static MauiApp? CreateMauiApp()
    {
        try
        {
            //Убираем подчёркивания у полей ввода
            Microsoft.Maui.Handlers.EntryHandler.Mapper
                .AppendToMapping("Borderless", (handler, view) =>
                {
#if ANDROID
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList
                .ValueOf(Android.Graphics.Color.Transparent);
#elif WINDOWS
            handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
#endif
                });

            //Формируем приложение
            var builder = MauiApp.CreateBuilder();

            //Устанавливаем конфигурацию
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("Mobile.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream!)
                .Build();
            builder.Configuration.AddConfiguration(config);

            //Устанавливаем шрифты
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Ofont_ru_Optimus.ttf", "Ofont_ru_Optimus");
                    fonts.AddFont("Georgia.ttf", "Georgia");
                });

#if DEBUG
            //Добавляем логироваение
            builder.Logging.AddDebug();
#endif

            //Добавляем сервисы
            builder.Services.AddScoped<IAuthorization, Authorization>(); //авторизация

            //Строим приложение
            return builder.Build();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
