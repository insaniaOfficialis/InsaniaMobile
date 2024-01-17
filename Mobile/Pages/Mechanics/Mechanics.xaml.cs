using Mobile.Models.Pages.Mechanics;
using Mobile.Pages.Base.Menu;
using System.Collections.ObjectModel;

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
            TopMenuMobile topMenu = new(true);
            GridContent.Add(topMenu, 0, 0);

            //������������� ���� �������
            MenuMechanics menuMechanics = new();
            GridContent.Add(menuMechanics, 0, 1);

            //������������� ������ ����
            BottomMenuMobile bottomMenu = new("mechanics");
            GridContent.Add(bottomMenu, 0, 2);
        }

        //���� ��
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            //������������� ����
            MenuDesktop menu = new("mechanics");
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