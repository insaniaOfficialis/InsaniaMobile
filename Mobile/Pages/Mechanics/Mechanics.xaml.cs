using Mobile.Pages.Base.Menu;

namespace Mobile.Pages.Mechanics;

/// <summary>
/// Класс страницы механик
/// </summary>
public partial class Mechanics : ContentPage
{
	/// <summary>
	/// Конструктор класса страницы механик
	/// </summary>
	public Mechanics()
	{
		//Инициализируем компоненты
		InitializeComponent();

        //Если мобильное устройство
        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            //Устанаваливаем верхнее меню
            StackLayout topMenuContent = new()
            {
                VerticalOptions = LayoutOptions.Start
            };
            TopMenuMobile topMenu = new(true);
            topMenuContent.Children.Add(topMenu);
            Page.Add(topMenuContent, 0, 0);

            //Устанавливаем нижнее меню
            StackLayout bottomMenuContent = new()
            {
                VerticalOptions = LayoutOptions.End
            };
            BottomMenuMobile bottomMenu = new("mechanics");
            bottomMenuContent.Children.Add(bottomMenu);
            Page.Add(bottomMenu, 0, 2);
        }

        //Если пк
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            //Устанавливаем меню
            MenuDesktop menu = new("")
            {
                Padding = new Thickness(0, 10, 0, 0)
            };
            Content.Children.Add(menu);
        }
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