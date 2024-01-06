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
        try
        {
            //Инициализируем компоненты
            InitializeComponent();

            //Получаем коллекцию сервисов
            Services = services;

            //Устанавливаем основную страницу
            MainPage = new AppShell();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        window.MinimumHeight = Height;
        window.MinimumWidth = Width;
        return window;
    }
}