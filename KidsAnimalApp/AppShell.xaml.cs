using KidsAnimalApp.Views;
namespace KidsAnimalApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		this.SetRootingScreen();
	}

	/// <summary>
	/// 画面遷移のルーティングを設定します。
	/// 新しく画面を追加した場合は、このメソッドにルーティングの設定を追加してください。
	/// </summary>
	private void SetRootingScreen()
	{
		Routing.RegisterRoute(nameof(LandAnimalsPage_View), typeof(LandAnimalsPage_View));
	}
}
