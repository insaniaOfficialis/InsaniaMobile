using Mobile.Pages.Base.Menu;

namespace Mobile.Pages.Base.Main;

/// <summary>
/// ����� ������� ��������
/// </summary>
public partial class MainMobile : ContentPage
{
	/// <summary>
	/// ����������� ������� ��������
	/// </summary>
	public MainMobile()
	{
		//�������������� ����������
		InitializeComponent();

        //������������� ����
        MenuMobile menu = new("main")
        {
            VerticalOptions = LayoutOptions.End
        };

        Menu.Children.Add(menu);
	}
}