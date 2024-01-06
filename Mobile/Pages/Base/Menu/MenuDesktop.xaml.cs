namespace Mobile.Pages.Base.Menu;

/// <summary>
/// Класс меню для пк
/// </summary>
public partial class MenuDesktop : ContentView
{
    /// <summary>
    /// Конструктор класса меню для ПК
    /// </summary>
    /// <param name="page"></param>
    public MenuDesktop(string? page)
	{
		//Инициализируем компоненты
		InitializeComponent();

        //Устанавливаем выбранный элеменрт по-умолчанию
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style))
        {
            if (page == "main")
            {
                Main.Style = (Style)style;
                Main.ImageSource = ImageSource.FromFile("castle_clicked.png");
            }
            if (page == "message")
            {
                Message.Style = (Style)style;
                Message.ImageSource = ImageSource.FromFile("crow_clicked.png");
            }
            if (page == "mechanics")
            {
                Mechanics.Style = (Style)style;
                Mechanics.ImageSource = ImageSource.FromFile("dice_clicked.png");
            }
            if (page == "information")
            {
                Information.Style = (Style)style;
                Information.ImageSource = ImageSource.FromFile("book_clicked.png");
            }
        }
    }

    /// <summary>
    /// Событие нажатия на кнопку главного меню
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Main_Clicked(object sender, EventArgs e)
    {
        //Если получилось найти из ресурса стиль кнопки, выставляем его
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style)
            && Application.Current!.Resources.TryGetValue("ButtonSecondary", out var styleDefault))
        {
            //Устанавливаем свойство кнопки главного меню
            Main.Style = (Style)style;
            Main.ImageSource = ImageSource.FromFile("castle_clicked.png");

            //Устанавливаем свойство кнопки сообщений
            Message.Style = (Style)styleDefault;
            Message.ImageSource = ImageSource.FromFile("crow.png");

            //Устанавливаем свойство кнопки рассчётов
            Mechanics.Style = (Style)styleDefault;
            Mechanics.ImageSource = ImageSource.FromFile("dice.png");

            //Устанавливаем свойство кнопки информации
            Information.Style = (Style)styleDefault;
            Information.ImageSource = ImageSource.FromFile("book.png");
        }
    }

    /// <summary>
    /// Событие нажатия на кнопку сообщений
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Message_Clicked(object sender, EventArgs e)
    {
        //Если получилось найти из ресурса стиль кнопки, выставляем его
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style)
            && Application.Current!.Resources.TryGetValue("ButtonSecondary", out var styleDefault))
        {
            //Устанавливаем свойство кнопки главного меню
            Main.Style = (Style)styleDefault;
            Main.ImageSource = ImageSource.FromFile("castle.png");

            //Устанавливаем свойство кнопки сообщений
            Message.Style = (Style)style;
            Message.ImageSource = ImageSource.FromFile("crow_clicked.png");

            //Устанавливаем свойство кнопки рассчётов
            Mechanics.Style = (Style)styleDefault;
            Mechanics.ImageSource = ImageSource.FromFile("dice.png");

            //Устанавливаем свойство кнопки информации
            Information.Style = (Style)styleDefault;
            Information.ImageSource = ImageSource.FromFile("book.png");
        }
    }

    /// <summary>
    /// Событие нажатия на кнопку рассчётов
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Mechanics_Clicked(object sender, EventArgs e)
    {
        //Если получилось найти из ресурса стиль кнопки, выставляем его
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style)
            && Application.Current!.Resources.TryGetValue("ButtonSecondary", out var styleDefault))
        {
            //Устанавливаем свойство кнопки главного меню
            Main.Style = (Style)styleDefault;
            Main.ImageSource = ImageSource.FromFile("castle.png");

            //Устанавливаем свойство кнопки сообщений
            Message.Style = (Style)styleDefault;
            Message.ImageSource = ImageSource.FromFile("crow.png");

            //Устанавливаем свойство кнопки рассчётов
            Mechanics.Style = (Style)style;
            Mechanics.ImageSource = ImageSource.FromFile("dice_clicked.png");

            //Устанавливаем свойство кнопки информации
            Information.Style = (Style)styleDefault;
            Information.ImageSource = ImageSource.FromFile("book.png");
        }
    }

    /// <summary>
    /// Событие нажатия на кнопку информации
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Information_Clicked(object sender, EventArgs e)
    {
        //Если получилось найти из ресурса стиль кнопки, выставляем его
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style)
            && Application.Current!.Resources.TryGetValue("ButtonSecondary", out var styleDefault))
        {
            //Устанавливаем свойство кнопки главного меню
            Main.Style = (Style)styleDefault;
            Main.ImageSource = ImageSource.FromFile("castle.png");

            //Устанавливаем свойство кнопки сообщений
            Message.Style = (Style)styleDefault;
            Message.ImageSource = ImageSource.FromFile("crow.png");

            //Устанавливаем свойство кнопки рассчётов
            Mechanics.Style = (Style)styleDefault;
            Mechanics.ImageSource = ImageSource.FromFile("dice.png");

            //Устанавливаем свойство кнопки информации
            Information.Style = (Style)style;
            Information.ImageSource = ImageSource.FromFile("book_clicked.png");
        }
    }

    /// <summary>
    /// Событие нажатия на кнопку выхода
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Out_Clicked(object sender, EventArgs e)
    {
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