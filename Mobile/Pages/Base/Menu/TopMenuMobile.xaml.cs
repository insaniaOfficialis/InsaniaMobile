namespace Mobile.Pages.Base.Menu;

/// <summary>
/// Класс верхнего меню
/// </summary>
public partial class TopMenuMobile : ContentView
{
    /// <summary>
    /// Пустой класса верхнего меню
    /// </summary>
    public TopMenuMobile()
    {
        //Инициализируем компоненты
        InitializeComponent();

        //Jтключаем признак выпадающего меню
        Bar.IsVisible = false;
    }

    /// <summary>
    /// Конструктор класса верхнего меню с параметром
    /// </summary>
    /// <param name="useBar"></param>
    public TopMenuMobile(bool useBar)
    {
        //Инициализируем компоненты
        InitializeComponent();

        //Включаем или отключаем признак выпадающего меню
        Bar.IsVisible = useBar;
    }

    /// <summary>
    /// Событие нажатия на кнопку уведомлений
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Notification_Clicked(object sender, EventArgs e)
    {
        //Если получилось найти из ресурса цвет кнопки, выставляем цвет
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //Устанавливаем свойство кнопки уведомлений
            Notification.Background = (RadialGradientBrush)color;

            //Устанавливаем свойство кнопки меню
            Bar.Background = null;
            Bar.BackgroundColor = Colors.Transparent;
        }
    }

    /// <summary>
    /// Событие нажатия на кнопку выпадающего меню
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bar_Clicked(object sender, EventArgs e)
    {
        //Если получилось найти из ресурса цвет кнопки, выставляем цвет
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //Устанавливаем свойство кнопки уведомлений
            Notification.Background = null;
            Notification.BackgroundColor = Colors.Transparent;

            //Устанавливаем свойство кнопки меню
            Bar.Background = (RadialGradientBrush)color;
        }

        //Удаляем токен
        SecureStorage.Default.Remove("token");

        //Переходим на страницу авторизации
        ToAuthorization(sender, e);
    }

    /// <summary>
    /// Метод перехода на страницу авторизации
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void ToAuthorization(object? sender, EventArgs? e)
    {
        await Navigation.PushModalAsync(new Authorization());
    }
}