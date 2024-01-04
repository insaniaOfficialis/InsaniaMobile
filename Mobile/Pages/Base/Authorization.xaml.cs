using Services.Identification.Authorization;

namespace Mobile.Pages.Base;

/// <summary>
/// �������� �����������
/// </summary>
public partial class Authorization : ContentPage
{
	/// <summary>
	/// ������ �����������
	/// </summary>
	private readonly IAuthorization? _authorization;

	/// <summary>
	/// ����������� �������� �����������
	/// </summary>
	public Authorization()
	{
		//�������������� ����������
		InitializeComponent();

		//�������� ������ �����������
		_authorization = App.Services?.GetService<IAuthorization>();
	}

	/// <summary>
	/// ������� ������� �� ������ �����������
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private async void Authorize_Clicked(object sender, EventArgs e)
    {
		try
		{
			//�������� ����� ������
			Error.Text = null;

			//�������� ����� �����������
			var result = await _authorization?.Handler(Login.Text, Password.Text)!;
		}
		catch(Exception ex)
        {
            //������������� ����� ������
            Error.Text = ex.Message;
        }
    }
}