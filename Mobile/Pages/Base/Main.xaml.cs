using Mobile.Pages.Base.Menu;

namespace Mobile.Pages.Base;

/// <summary>
/// ����� ������� ��������
/// </summary>
public partial class Main : ContentPage
{
	/// <summary>
	/// ����������� ������� ��������
	/// </summary>
	public Main()
    {
        //�������������� ����������
        InitializeComponent();

        //���� ��������� ����������
		if(DeviceInfo.Idiom == DeviceIdiom.Phone)
		{
            //������������� ������ ����
			StackLayout bottomMenuContent = new()
			{
				VerticalOptions = LayoutOptions.End
			};
            BottomMenuMobile bottomMenu = new("main");
            bottomMenuContent.Children.Add(bottomMenu);
            Page.Children.Add(bottomMenu);

            //�������������� ������� ����
            StackLayout topMenuContent = new()
            {
                VerticalOptions = LayoutOptions.Start
            };
            TopMenuMobile topMenu = new(true);
            topMenuContent.Children.Add(topMenu);
            Page.Children.Add(topMenuContent);
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