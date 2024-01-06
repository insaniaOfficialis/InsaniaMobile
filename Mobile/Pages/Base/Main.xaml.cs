using Mobile.Pages.Base.Menu;

namespace Mobile.Pages.Base;

/// <summary>
/// Класс главной страницы
/// </summary>
public partial class Main : ContentPage
{
	/// <summary>
	/// Конструктор главной страницы
	/// </summary>
	public Main()
    {
        //Инициализируем компоненты
        InitializeComponent();

        //Если мобильное устройство
		if(DeviceInfo.Idiom == DeviceIdiom.Phone)
		{
            //Устанавливаем нижнее меню
			StackLayout bottomMenuContent = new()
			{
				VerticalOptions = LayoutOptions.End
			};
            BottomMenuMobile bottomMenu = new("main");
            bottomMenuContent.Children.Add(bottomMenu);
            Page.Children.Add(bottomMenu);

            //Устанаваливаем верхнее меню
            StackLayout topMenuContent = new()
            {
                VerticalOptions = LayoutOptions.Start
            };
            TopMenuMobile topMenu = new(true);
            topMenuContent.Children.Add(topMenu);
            Page.Children.Add(topMenuContent);
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