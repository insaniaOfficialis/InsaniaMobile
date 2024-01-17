namespace Mobile.Pages.Base.Menu;

/// <summary>
/// ���� �������
/// </summary>
public partial class MenuMechanics : ContentView
{
	/// <summary>
	/// ����������� ���� �������
	/// </summary>
	public MenuMechanics()
	{
		//�������������� ����������
		InitializeComponent();

		//���� ������� � ��
		if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
			//������������� ������
			StackContent.Margin = new(0, 74, 0, 0);

    }
}