namespace Mobile.Pages.Base.Menu;

/// <summary>
/// ����� ���� ��� ��
/// </summary>
public partial class MenuDesktop : ContentView
{
    /// <summary>
    /// ����������� ������ ���� ��� ��
    /// </summary>
    /// <param name="page"></param>
    public MenuDesktop(string? page)
	{
		//�������������� ����������
		InitializeComponent();

        //������������� ��������� �������� ��-���������
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style))
        {
            if (page == "main")
            {
                Main.Style = (Style)style;
                Main.ImageSource = ImageSource.FromFile("castle_clicked.png");
            }
            if (page == "message")
            {
                Message.Style = (Style)style;
                Message.ImageSource = ImageSource.FromFile("crow_clicked.png");
            }
            if (page == "mechanics")
            {
                Mechanics.Style = (Style)style;
                Mechanics.ImageSource = ImageSource.FromFile("dice_clicked.png");
            }
            if (page == "information")
            {
                Information.Style = (Style)style;
                Information.ImageSource = ImageSource.FromFile("book_clicked.png");
            }
        }
    }

    /// <summary>
    /// ������� ������� �� ������ �������� ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Main_Clicked(object sender, EventArgs e)
    {
        //���� ���������� ����� �� ������� ����� ������, ���������� ���
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style)
            && Application.Current!.Resources.TryGetValue("ButtonSecondary", out var styleDefault))
        {
            //������������� �������� ������ �������� ����
            Main.Style = (Style)style;
            Main.ImageSource = ImageSource.FromFile("castle_clicked.png");

            //������������� �������� ������ ���������
            Message.Style = (Style)styleDefault;
            Message.ImageSource = ImageSource.FromFile("crow.png");

            //������������� �������� ������ ���������
            Mechanics.Style = (Style)styleDefault;
            Mechanics.ImageSource = ImageSource.FromFile("dice.png");

            //������������� �������� ������ ����������
            Information.Style = (Style)styleDefault;
            Information.ImageSource = ImageSource.FromFile("book.png");
        }
    }

    /// <summary>
    /// ������� ������� �� ������ ���������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Message_Clicked(object sender, EventArgs e)
    {
        //���� ���������� ����� �� ������� ����� ������, ���������� ���
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style)
            && Application.Current!.Resources.TryGetValue("ButtonSecondary", out var styleDefault))
        {
            //������������� �������� ������ �������� ����
            Main.Style = (Style)styleDefault;
            Main.ImageSource = ImageSource.FromFile("castle.png");

            //������������� �������� ������ ���������
            Message.Style = (Style)style;
            Message.ImageSource = ImageSource.FromFile("crow_clicked.png");

            //������������� �������� ������ ���������
            Mechanics.Style = (Style)styleDefault;
            Mechanics.ImageSource = ImageSource.FromFile("dice.png");

            //������������� �������� ������ ����������
            Information.Style = (Style)styleDefault;
            Information.ImageSource = ImageSource.FromFile("book.png");
        }
    }

    /// <summary>
    /// ������� ������� �� ������ ���������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Mechanics_Clicked(object sender, EventArgs e)
    {
        //���� ���������� ����� �� ������� ����� ������, ���������� ���
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style)
            && Application.Current!.Resources.TryGetValue("ButtonSecondary", out var styleDefault))
        {
            //������������� �������� ������ �������� ����
            Main.Style = (Style)styleDefault;
            Main.ImageSource = ImageSource.FromFile("castle.png");

            //������������� �������� ������ ���������
            Message.Style = (Style)styleDefault;
            Message.ImageSource = ImageSource.FromFile("crow.png");

            //������������� �������� ������ ���������
            Mechanics.Style = (Style)style;
            Mechanics.ImageSource = ImageSource.FromFile("dice_clicked.png");

            //������������� �������� ������ ����������
            Information.Style = (Style)styleDefault;
            Information.ImageSource = ImageSource.FromFile("book.png");
        }
    }

    /// <summary>
    /// ������� ������� �� ������ ����������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Information_Clicked(object sender, EventArgs e)
    {
        //���� ���������� ����� �� ������� ����� ������, ���������� ���
        if (Application.Current!.Resources.TryGetValue("ButtonFifth", out var style)
            && Application.Current!.Resources.TryGetValue("ButtonSecondary", out var styleDefault))
        {
            //������������� �������� ������ �������� ����
            Main.Style = (Style)styleDefault;
            Main.ImageSource = ImageSource.FromFile("castle.png");

            //������������� �������� ������ ���������
            Message.Style = (Style)styleDefault;
            Message.ImageSource = ImageSource.FromFile("crow.png");

            //������������� �������� ������ ���������
            Mechanics.Style = (Style)styleDefault;
            Mechanics.ImageSource = ImageSource.FromFile("dice.png");

            //������������� �������� ������ ����������
            Information.Style = (Style)style;
            Information.ImageSource = ImageSource.FromFile("book_clicked.png");
        }
    }

    /// <summary>
    /// ������� ������� �� ������ ������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Out_Clicked(object sender, EventArgs e)
    {
        //������� �����
        SecureStorage.Default.Remove("token");

        //��������� �� �������� �����������
        ToAuthorization(sender, e);
    }

    /// <summary>
    /// ����� �������� �� �������� �����������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void ToAuthorization(object? sender, EventArgs? e)
    {
        await Navigation.PushModalAsync(new Authorization());
    }
}