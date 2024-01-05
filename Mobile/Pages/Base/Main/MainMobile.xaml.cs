using Mobile.Pages.Base.Menu;

namespace Mobile.Pages.Base.Main;

/// <summary>
/// Класс главной страницы
/// </summary>
public partial class MainMobile : ContentPage
{
	/// <summary>
	/// Конструктор главной страницы
	/// </summary>
	public MainMobile()
	{
		//Инициализируем компоненты
		InitializeComponent();

        //Устанавливаем меню
        MenuMobile menu = new("main")
        {
            VerticalOptions = LayoutOptions.End
        };

        Menu.Children.Add(menu);
	}
}