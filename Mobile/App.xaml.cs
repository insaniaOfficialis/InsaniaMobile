using Services.Identification.Authorization;

namespace Mobile;

/// <summary>
/// Основной класс приложения
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Ширина
    /// </summary>
    private const int Width = 1200;

    /// <summary>
    /// Высота
    /// </summary>
    private const int Height = 750;

    /// <summary>
    /// Коллекция сервисов
    /// </summary>
#pragma warning disable CA2211 // Поля, не являющиеся константами, не должны быть видимыми
    public static IServiceProvider? Services;
#pragma warning restore CA2211 // Поля, не являющиеся константами, не должны быть видимыми

    /// <summary>
    /// Конструктор основного класса приложения
    /// </summary>
    public App(IServiceProvider services)
    {
        //Инициализируем компоненты
        InitializeComponent();

        //Получаем коллекцию сервисов
        Services = services;

        //Устанавливаем основную страницу
        MainPage = new AppShell();
    }

    /// <summary>
    /// Переопределеяем метод создания окна
    /// </summary>
    /// <param name="activationState"></param>
    /// <returns></returns>
    protected override Window CreateWindow(IActivationState activationState)
    {
        //Задаём окно
        var window = base.CreateWindow(activationState);

        //Устанавливаем высоту и ширину
        window.Width = Width;
        window.Height = Height;

        //Возвращаем окно
        return window;
    }
}