namespace KidsAnimalApp.Views;

public partial class LandAnimalsPage_View : ContentPage
{
	public LandAnimalsPage_View()
	{
		InitializeComponent();
		BindingContext = new ViewModels.LandAnimalsPage_ViewModel();
	}
}