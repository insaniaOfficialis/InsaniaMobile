namespace Mobile.Pages.Base.Menu;

/// <summary>
/// ����� �������� ����
/// </summary>
public partial class TopMenuMobile : ContentView
{
    /// <summary>
    /// ������ ������ �������� ����
    /// </summary>
    public TopMenuMobile()
    {
        //�������������� ����������
        InitializeComponent();

        //J�������� ������� ����������� ����
        Bar.IsVisible = false;
    }

    /// <summary>
    /// ����������� ������ �������� ���� � ����������
    /// </summary>
    /// <param name="useBar"></param>
    public TopMenuMobile(bool useBar)
    {
        //�������������� ����������
        InitializeComponent();

        //�������� ��� ��������� ������� ����������� ����
        Bar.IsVisible = useBar;
    }

    /// <summary>
    /// ������� ������� �� ������ �����������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Notification_Clicked(object sender, EventArgs e)
    {
        //���� ���������� ����� �� ������� ���� ������, ���������� ����
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //������������� �������� ������ �����������
            Notification.Background = (RadialGradientBrush)color;

            //������������� �������� ������ ����
            Bar.Background = null;
            Bar.BackgroundColor = Colors.Transparent;
        }
    }

    /// <summary>
    /// ������� ������� �� ������ ����������� ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bar_Clicked(object sender, EventArgs e)
    {
        //���� ���������� ����� �� ������� ���� ������, ���������� ����
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //������������� �������� ������ �����������
            Notification.Background = null;
            Notification.BackgroundColor = Colors.Transparent;

            //������������� �������� ������ ����
            Bar.Background = (RadialGradientBrush)color;
        }
    }
}