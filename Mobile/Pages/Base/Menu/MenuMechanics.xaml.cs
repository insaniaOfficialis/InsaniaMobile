namespace Mobile.Pages.Base.Menu;

/// <summary>
/// Меню механик
/// </summary>
public partial class MenuMechanics : ContentView
{
	/// <summary>
	/// Конструктор меню механик
	/// </summary>
	public MenuMechanics()
	{
		//Инициализируем компоненты
		InitializeComponent();

		//Если вызвано с пк
		if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
			//Устанавливаем отступ
			StackContent.Margin = new(0, 74, 0, 0);

    }
}