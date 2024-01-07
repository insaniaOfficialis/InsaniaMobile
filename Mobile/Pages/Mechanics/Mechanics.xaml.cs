using Mobile.Pages.Base.Menu;

namespace Mobile.Pages.Mechanics;

/// <summary>
/// ����� �������� �������
/// </summary>
public partial class Mechanics : ContentPage
{
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
        }
    }

    /// <summary>
    /// ����� ������� ������ �����
    /// </summary>
    /// <returns></returns>
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}