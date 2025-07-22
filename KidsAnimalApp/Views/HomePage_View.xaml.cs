namespace KidsAnimalApp.Views;

public partial class HomePage_View : ContentPage
{
	public HomePage_View()
	{
		InitializeComponent();
		BindingContext = new ViewModels.HomePage_ViewModel();
	}
}