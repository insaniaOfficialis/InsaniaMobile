using Mobile.Models.Pages.Mechanics;
using Mobile.Pages.Base.Menu;
using System.Collections.ObjectModel;

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
            TopMenuMobile topMenu = new(true);
            GridContent.Add(topMenu, 0, 0);

            //Устанавливаем меню механик
            MenuMechanics menuMechanics = new();
            GridContent.Add(menuMechanics, 0, 1);

            //Устанавливаем нижнее меню
            BottomMenuMobile bottomMenu = new("mechanics");
            GridContent.Add(bottomMenu, 0, 2);
        }

        //Если пк
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            //Устанавливаем меню
            MenuDesktop menu = new("mechanics");
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