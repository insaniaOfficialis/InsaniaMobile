using Services.Identification.Authorization;

namespace Mobile.Pages.Base;

/// <summary>
/// Страница авторизация
/// </summary>
public partial class Authorization : ContentPage
{
	/// <summary>
	/// Сервис авторизации
	/// </summary>
	private readonly IAuthorization? _authorization;

	/// <summary>
	/// Константная ширина элементов для пк
	/// </summary>
	private const int WidhtElementDesktop = 360;

    /// <summary>
    /// Конструктор страницы авторизации
    /// </summary>
    public Authorization()
	{
		//Инициализируем компоненты
		InitializeComponent();

		//Устанавливаем отступы
		if (DeviceInfo.Idiom == DeviceIdiom.Phone)
			Padding = new Thickness(15, 0, 15, 0);
		else
		{
			if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
			{
				Login.WidthRequest = WidhtElementDesktop;
				LoginLine.WidthRequest = WidhtElementDesktop;
				Password.WidthRequest = WidhtElementDesktop;
				PasswordLine.WidthRequest = WidhtElementDesktop;
				Authorize.WidthRequest = WidhtElementDesktop;
			}
		}

		//Получаем сервис авторизации
		_authorization = App.Services?.GetService<IAuthorization>();
    }

	/// <summary>
	/// Событие нажатия на кнопку авторизации
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private async void Authorize_Clicked(object sender, EventArgs e)
    {
		try
		{
            //Запускаем колесо загрузки
            Content.IsVisible = false;
            Load.IsRunning = true;

            //Убираем клавитауру
            Login.IsEnabled = false;
            Login.IsEnabled = true;
            Password.IsEnabled = false;
            Password.IsEnabled = true;

            //Обнуляем текст ошибки
            Error.Text = null;

			//Вызываем метод авторизации
			var result = await _authorization?.Handler(Login.Text, Password.Text)!;

			//Если получили токен, переходим на главную страницу
			if(!string.IsNullOrEmpty(result.Token))
				ToMain(sender, e);
		}
		catch(Exception ex)
        {
            //Возвращаем видимость элементов
            Content.IsVisible = true;

            //Устанавливаем текст ошибки
            Error.Text = ex.Message;
        }
		finally
		{
            //Остакнавливаем колесо загрузки
            Load.IsRunning = false;
        }
    }

    /// <summary>
    /// Метод перехода на страницу авторизации
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void ToMain(object? sender, EventArgs? e)
    {
		await Navigation.PushModalAsync(new Main());
    }
}