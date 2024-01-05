namespace Mobile.Pages.Base.Menu;

/// <summary>
/// ����� ���� ���������� ����������
/// </summary>
public partial class MenuMobile : ContentView
{
	/// <summary>
	/// ����������� ���� ���������� ����������
	/// </summary>
	public MenuMobile(string page)
	{
		//�������������� ����������
		InitializeComponent();

        //������������� ��������� �������� ��-���������
        if(Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            if (page == "main")
            {
                Main.Background = (RadialGradientBrush)color;
                Main.ImageSource = ImageSource.FromFile("castle_clicked.svg");
            }
            if (page == "message")
            {
                Message.Background = (RadialGradientBrush)color;
                Message.ImageSource = ImageSource.FromFile("crow_clicked.svg");
            }
            if (page == "mechanics")
            {
                Mechanics.Background = (RadialGradientBrush)color;
                Mechanics.ImageSource = ImageSource.FromFile("dice_clicked.svg");
            }
            if (page == "information")
            {
                Information.Background = (RadialGradientBrush)color;
                Information.ImageSource = ImageSource.FromFile("book_clicked.svg");
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
		//���� ���������� ����� �� ������� ���� ������, ���������� ����
		if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //������������� �������� ������ �������� ����
            Main.Background = (RadialGradientBrush)color;
            Main.ImageSource = ImageSource.FromFile("castle_clicked.svg");

            //������������� �������� ������ ���������
            Message.Background = null;
            Message.BackgroundColor = Colors.Transparent;
            Message.ImageSource = ImageSource.FromFile("crow.svg");

            //������������� �������� ������ ���������
            Mechanics.Background = null;
            Mechanics.BackgroundColor = Colors.Transparent;
            Mechanics.ImageSource = ImageSource.FromFile("dice.svg");

            //������������� �������� ������ ����������
            Information.Background = null;
            Information.BackgroundColor = Colors.Transparent;
            Information.ImageSource = ImageSource.FromFile("book.svg");
        }
    }

    /// <summary>
    /// ������� ������� �� ������ ���������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Message_Clicked(object sender, EventArgs e)
    {
        //���� ���������� ����� �� ������� ���� ������, ���������� ����
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //������������� �������� ������ �������� ����
            Main.Background = null;
            Main.BackgroundColor = Colors.Transparent;
            Main.ImageSource = ImageSource.FromFile("castle.svg");

            //������������� �������� ������ ���������
            Message.Background = (RadialGradientBrush)color;
            Message.ImageSource = ImageSource.FromFile("crow_clicked.svg");

            //������������� �������� ������ ���������
            Mechanics.Background = null;
            Mechanics.BackgroundColor = Colors.Transparent;
            Mechanics.ImageSource = ImageSource.FromFile("dice.svg");

            //������������� �������� ������ ����������
            Information.Background = null;
            Information.BackgroundColor = Colors.Transparent;
            Information.ImageSource = ImageSource.FromFile("book.svg");
        }
    }

    /// <summary>
    /// ������� ������� �� ������ ���������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Mechanics_Clicked(object sender, EventArgs e)
    {
        //���� ���������� ����� �� ������� ���� ������, ���������� ����
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //������������� �������� ������ �������� ����
            Main.Background = null;
            Main.BackgroundColor = Colors.Transparent;
            Main.ImageSource = ImageSource.FromFile("castle.svg");

            //������������� �������� ������ ���������
            Message.Background = null;
            Message.BackgroundColor = Colors.Transparent;
            Message.ImageSource = ImageSource.FromFile("crow.svg");

            //������������� �������� ������ ���������
            Mechanics.Background = (RadialGradientBrush)color;
            Mechanics.ImageSource = ImageSource.FromFile("dice_clicked.svg");

            //������������� �������� ������ ����������
            Information.Background = null;
            Information.BackgroundColor = Colors.Transparent;
            Information.ImageSource = ImageSource.FromFile("book.svg");
        }
    }

    /// <summary>
    /// ������� ������� �� ������ ����������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Information_Clicked(object sender, EventArgs e)
    {
        //���� ���������� ����� �� ������� ���� ������, ���������� ����
        if (Application.Current!.Resources.TryGetValue("MenuGradient", out var color))
        {
            //������������� �������� ������ �������� ����
            Main.Background = null;
            Main.BackgroundColor = Colors.Transparent;
            Main.ImageSource = ImageSource.FromFile("castle.svg");

            //������������� �������� ������ ���������
            Message.Background = null;
            Message.BackgroundColor = Colors.Transparent;
            Message.ImageSource = ImageSource.FromFile("crow.svg");

            //������������� �������� ������ ���������
            Mechanics.Background = null;
            Mechanics.BackgroundColor = Colors.Transparent;
            Mechanics.ImageSource = ImageSource.FromFile("dice.svg");

            //������������� �������� ������ ����������
            Information.Background = (RadialGradientBrush)color;
            Information.ImageSource = ImageSource.FromFile("book_clicked.svg");
        }
    }
}