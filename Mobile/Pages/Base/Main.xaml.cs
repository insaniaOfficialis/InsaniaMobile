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
            //�������������� ������� ����
            TopMenuMobile topMenu = new(true);
            GridContent.Add(topMenu, 0, 0);

            //������������� ������ ����
            BottomMenuMobile bottomMenu = new("main");
            GridContent.Add(bottomMenu, 0, 2);
        }

        //���� ��
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            //������������� ����
            MenuDesktop menu = new("main");
            GridContent.Add(menu);
            menu.SetValue(Grid.RowSpanProperty, 3);
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