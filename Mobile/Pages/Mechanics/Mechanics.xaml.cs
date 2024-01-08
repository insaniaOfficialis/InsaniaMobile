using Mobile.Pages.Base.Menu;
using System.Collections.ObjectModel;

namespace Mobile.Pages.Mechanics;

/// <summary>
/// Класс страницы механик
/// </summary>
public partial class Mechanics : ContentPage
{
    private readonly ObservableCollection<Section> _sections;

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

            Sections.ItemsLayout = new GridItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                HorizontalItemSpacing = 10,
                VerticalItemSpacing = 10,
                Span = 2
            };
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

            Sections.ItemsLayout = new GridItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                HorizontalItemSpacing = 10,
                VerticalItemSpacing = 10,
                Span = 4
            };
        }

        Application.Current!.Resources.TryGetValue("SecondaryBackground", out var color);
        Color background = (Color)color;
        _sections =
        [
            new("system.png", "Системное", "Управление\nприложением", background),
            new("general.png", "Общее", "Общеигровое\nвзаимодействие", background),
            new("politic.png", "Политика", "Взаимодействие\nорганизаций", background),
            new("sociology.png", "Социология", "Взаимодействие c\nобществом", background),
        ];
        Sections.ItemsSource = _sections;
    }

    /// <summary>
    /// Метод нажатия кнопки назад
    /// </summary>
    /// <returns></returns>
    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private class Section(string file, string title, string description, Color color)
    {
        public string File { get; private set; } = file;

        public string Title { get; private set; } = title;

        public string Description { get; private set; } = description;

        public Color Color { get; set; } = color;
    }

    private void Sections_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Application.Current!.Resources.TryGetValue("PrimaryBackground", out var color);
        Color background = (Color)color;

        if (e.CurrentSelection.FirstOrDefault() is Section current)
        {
            var element = _sections.First(x => x.Title == current.Title);
            Section section = new(element.File, element.Title, element.Description, background);
            var index = _sections.IndexOf(element);
            _sections[index] = section;
        }

        Application.Current!.Resources.TryGetValue("SecondaryBackground", out color);
        background = (Color)color;

        if (e.PreviousSelection.FirstOrDefault() is Section previous)
        {
            var element = _sections.First(x => x.Title == previous.Title);
            Section section = new(element.File, element.Title, element.Description, background);
            var index = _sections.IndexOf(element);
            _sections[index] = section;
        }
    }
}