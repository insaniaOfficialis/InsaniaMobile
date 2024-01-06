using Mobile.Services.General.CheckConnection;
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
    /// Сервис проверки соединения
    /// </summary>
    private readonly ICheckConnection? _checkConnection;

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

		//Получаем сервисы
		_authorization = App.Services?.GetService<IAuthorization>();
        _checkConnection = App.Services?.GetService<ICheckConnection>();
    }

    /// <summary>
    /// Событие загрузки окна
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        //Если есть сервис проверки соединения
        if (_checkConnection != null)
        {
            try
            {
                //Запускаем колесо загрузки
                Load.IsRunning = true;
                Content.IsVisible = false;

                //Если проверка соединения прошла, переходим на главную
                if (await _checkConnection.Handler(true))
                    ToMain(sender, e);
                else
                    //Возвращаем видимость элементов
                    Content.IsVisible = true;
            }
            catch (Exception ex)
            {
                //Устанавливаем текст ошибки
                Error.Text = ex.Message;
            }
            finally
            {
                //Останавливаем колесо загрузки
                Load.IsRunning = false;
            }
        }
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
    /// Метод перехода на главную страницу
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void ToMain(object? sender, EventArgs? e)
    {
        await Navigation.PushModalAsync(new Main());
    }

    /// <summary>
    /// Метод нажатия кнопки назад
    /// </summary>
    /// <returns></returns>
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}