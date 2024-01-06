using Mobile.Services.General.CheckConnection;
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
    /// ������ �������� ����������
    /// </summary>
    private readonly ICheckConnection? _checkConnection;

    /// <summary>
    /// ����������� ������ ��������� ��� ��
    /// </summary>
    private const int WidhtElementDesktop = 360;

    /// <summary>
    /// ����������� �������� �����������
    /// </summary>
    public Authorization()
    {
        //�������������� ����������
        InitializeComponent();

		//������������� �������
		if (DeviceInfo.Idiom == DeviceIdiom.Phone)
			Padding = new Thickness(15, 0, 15, 0);
		else
		{
			if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
			{
				Login.WidthRequest = WidhtElementDesktop;
				LoginLine.WidthRequest = WidhtElementDesktop;
				Password.WidthRequest = WidhtElementDesktop;
				PasswordLine.WidthRequest = WidhtElementDesktop;
				Authorize.WidthRequest = WidhtElementDesktop;
			}
		}

		//�������� �������
		_authorization = App.Services?.GetService<IAuthorization>();
        _checkConnection = App.Services?.GetService<ICheckConnection>();
    }

    /// <summary>
    /// ������� �������� ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        //���� ���� ������ �������� ����������
        if (_checkConnection != null)
        {
            try
            {
                //��������� ������ ��������
                Load.IsRunning = true;
                Content.IsVisible = false;

                //���� �������� ���������� ������, ��������� �� �������
                if (await _checkConnection.Handler(true))
                    ToMain(sender, e);
                else
                    //���������� ��������� ���������
                    Content.IsVisible = true;
            }
            catch (Exception ex)
            {
                //������������� ����� ������
                Error.Text = ex.Message;
            }
            finally
            {
                //������������� ������ ��������
                Load.IsRunning = false;
            }
        }
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
            //��������� ������ ��������
            Content.IsVisible = false;
            Load.IsRunning = true;

            //������� ����������
            Login.IsEnabled = false;
            Login.IsEnabled = true;
            Password.IsEnabled = false;
            Password.IsEnabled = true;

            //�������� ����� ������
            Error.Text = null;

			//�������� ����� �����������
			var result = await _authorization?.Handler(Login.Text, Password.Text)!;

			//���� �������� �����, ��������� �� ������� ��������
			if(!string.IsNullOrEmpty(result.Token))
				ToMain(sender, e);
		}
		catch(Exception ex)
        {
            //���������� ��������� ���������
            Content.IsVisible = true;

            //������������� ����� ������
            Error.Text = ex.Message;
        }
		finally
		{
            //�������������� ������ ��������
            Load.IsRunning = false;
        }
    }

    /// <summary>
    /// ����� �������� �� ������� ��������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void ToMain(object? sender, EventArgs? e)
    {
        await Navigation.PushModalAsync(new Main());
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