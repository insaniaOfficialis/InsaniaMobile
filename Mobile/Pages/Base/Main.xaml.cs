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
            //Устанаваливаем верхнее меню
            TopMenuMobile topMenu = new(true);
            GridContent.Add(topMenu, 0, 0);

            //Устанавливаем нижнее меню
            BottomMenuMobile bottomMenu = new("main");
            GridContent.Add(bottomMenu, 0, 2);
        }

        //Если пк
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            //Устанавливаем меню
            MenuDesktop menu = new("main");
            GridContent.Add(menu);
            menu.SetValue(Grid.RowSpanProperty, 3);
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