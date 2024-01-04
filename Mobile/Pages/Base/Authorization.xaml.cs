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
	/// Конструктор страницы авторизации
	/// </summary>
	public Authorization()
	{
		//Инициализируем компоненты
		InitializeComponent();

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
			//Обнуляем текст ошибки
			Error.Text = null;

			//Вызываем метод авторизации
			var result = await _authorization?.Handler(Login.Text, Password.Text)!;
		}
		catch(Exception ex)
        {
            //Устанавливаем текст ошибки
            Error.Text = ex.Message;
        }
    }
}