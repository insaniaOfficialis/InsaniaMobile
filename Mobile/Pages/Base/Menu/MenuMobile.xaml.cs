namespace Mobile.Pages.Base.Menu;

/// <summary>
/// Класс меню мобильного устройства
/// </summary>
public partial class MenuMobile : ContentView
{
	/// <summary>
	/// Конструктор меню мобильного устройства
	/// </summary>
	public MenuMobile(string page)
	{
		//Инициализируем компоненты
		InitializeComponent();

        //Устанавливаем выбранный элеменрт по-умолчанию
        if(Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            if (page == "main")
            {
                Main.Background = (RadialGradientBrush)color;
                Main.ImageSource = ImageSource.FromFile("castle_clicked.svg");
            }
            if (page == "message")
            {
                Message.Background = (RadialGradientBrush)color;
                Message.ImageSource = ImageSource.FromFile("crow_clicked.svg");
            }
            if (page == "mechanics")
            {
                Mechanics.Background = (RadialGradientBrush)color;
                Mechanics.ImageSource = ImageSource.FromFile("dice_clicked.svg");
            }
            if (page == "information")
            {
                Information.Background = (RadialGradientBrush)color;
                Information.ImageSource = ImageSource.FromFile("book_clicked.svg");
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
		//Если получилось найти из ресурса цвет кнопки, выставляем цвет
		if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //Устанавливаем свойство кнопки главного меню
            Main.Background = (RadialGradientBrush)color;
            Main.ImageSource = ImageSource.FromFile("castle_clicked.svg");

            //Устанавливаем свойство кнопки сообщений
            Message.Background = null;
            Message.BackgroundColor = Colors.Transparent;
            Message.ImageSource = ImageSource.FromFile("crow.svg");

            //Устанавливаем свойство кнопки рассчётов
            Mechanics.Background = null;
            Mechanics.BackgroundColor = Colors.Transparent;
            Mechanics.ImageSource = ImageSource.FromFile("dice.svg");

            //Устанавливаем свойство кнопки информации
            Information.Background = null;
            Information.BackgroundColor = Colors.Transparent;
            Information.ImageSource = ImageSource.FromFile("book.svg");
        }
    }

    /// <summary>
    /// Событие нажатия на кнопку сообщений
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Message_Clicked(object sender, EventArgs e)
    {
        //Если получилось найти из ресурса цвет кнопки, выставляем цвет
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //Устанавливаем свойство кнопки главного меню
            Main.Background = null;
            Main.BackgroundColor = Colors.Transparent;
            Main.ImageSource = ImageSource.FromFile("castle.svg");

            //Устанавливаем свойство кнопки сообщений
            Message.Background = (RadialGradientBrush)color;
            Message.ImageSource = ImageSource.FromFile("crow_clicked.svg");

            //Устанавливаем свойство кнопки рассчётов
            Mechanics.Background = null;
            Mechanics.BackgroundColor = Colors.Transparent;
            Mechanics.ImageSource = ImageSource.FromFile("dice.svg");

            //Устанавливаем свойство кнопки информации
            Information.Background = null;
            Information.BackgroundColor = Colors.Transparent;
            Information.ImageSource = ImageSource.FromFile("book.svg");
        }
    }

    /// <summary>
    /// Событие нажатия на кнопку рассчётов
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Mechanics_Clicked(object sender, EventArgs e)
    {
        //Если получилось найти из ресурса цвет кнопки, выставляем цвет
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //Устанавливаем свойство кнопки главного меню
            Main.Background = null;
            Main.BackgroundColor = Colors.Transparent;
            Main.ImageSource = ImageSource.FromFile("castle.svg");

            //Устанавливаем свойство кнопки сообщений
            Message.Background = null;
            Message.BackgroundColor = Colors.Transparent;
            Message.ImageSource = ImageSource.FromFile("crow.svg");

            //Устанавливаем свойство кнопки рассчётов
            Mechanics.Background = (RadialGradientBrush)color;
            Mechanics.ImageSource = ImageSource.FromFile("dice_clicked.svg");

            //Устанавливаем свойство кнопки информации
            Information.Background = null;
            Information.BackgroundColor = Colors.Transparent;
            Information.ImageSource = ImageSource.FromFile("book.svg");
        }
    }

    /// <summary>
    /// Событие нажатия на кнопку информации
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Information_Clicked(object sender, EventArgs e)
    {
        //Если получилось найти из ресурса цвет кнопки, выставляем цвет
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //Устанавливаем свойство кнопки главного меню
            Main.Background = null;
            Main.BackgroundColor = Colors.Transparent;
            Main.ImageSource = ImageSource.FromFile("castle.svg");

            //Устанавливаем свойство кнопки сообщений
            Message.Background = null;
            Message.BackgroundColor = Colors.Transparent;
            Message.ImageSource = ImageSource.FromFile("crow.svg");

            //Устанавливаем свойство кнопки рассчётов
            Mechanics.Background = null;
            Mechanics.BackgroundColor = Colors.Transparent;
            Mechanics.ImageSource = ImageSource.FromFile("dice.svg");

            //Устанавливаем свойство кнопки информации
            Information.Background = (RadialGradientBrush)color;
            Information.ImageSource = ImageSource.FromFile("book_clicked.svg");
        }
    }
}