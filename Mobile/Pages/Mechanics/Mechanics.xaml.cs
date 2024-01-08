using Mobile.Pages.Base.Menu;
using System.Collections.ObjectModel;

namespace Mobile.Pages.Mechanics;

/// <summary>
/// ����� �������� �������
/// </summary>
public partial class Mechanics : ContentPage
{
    private readonly ObservableCollection<Section> _sections;

    /// <summary>
    /// ����������� ������ �������� �������
    /// </summary>
    public Mechanics()
    {
        //�������������� ����������
        InitializeComponent();

        //���� ��������� ����������
        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            //�������������� ������� ����
            StackLayout topMenuContent = new()
            {
                VerticalOptions = LayoutOptions.Start
            };
            TopMenuMobile topMenu = new(true);
            topMenuContent.Children.Add(topMenu);
            Page.Add(topMenuContent, 0, 0);

            //������������� ������ ����
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

        //���� ��
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            //������������� ����
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
            new("system.png", "���������", "����������\n�����������", background),
            new("general.png", "�����", "�����������\n��������������", background),
            new("politic.png", "��������", "��������������\n�����������", background),
            new("sociology.png", "����������", "�������������� c\n���������", background),
        ];
        Sections.ItemsSource = _sections;
    }

    /// <summary>
    /// ����� ������� ������ �����
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