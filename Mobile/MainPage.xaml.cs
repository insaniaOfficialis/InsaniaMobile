using Authorization = Mobile.Pages.Base.Authorization;

namespace Mobile;

/// <summary>
/// Логика главной страницы
/// </summary>
public partial class MainPage : ContentPage
{
    /// <summary>
    /// Логика главной страницы
    /// </summary>
    public MainPage()
    {
        //Инициализируем компоненты
        InitializeComponent();

        ToAuthorization(null, null);
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