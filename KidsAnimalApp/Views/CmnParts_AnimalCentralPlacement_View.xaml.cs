using KidsAnimalApp.ViewModels;
using Microsoft.Maui.Controls;
namespace KidsAnimalApp.Views;

public partial class CmnParts_AnimalCentralPlacement_View : ContentView
{
	/// <summary>
	/// xamlとバインドするためのBindableProperty。
	/// </summary>
	public static readonly BindableProperty ViewModelProperty =
		BindableProperty.Create(
			nameof(ViewModel),
			typeof(SelectedAnimal_ViewModel),
			typeof(CmnParts_AnimalCentralPlacement_View),
			propertyChanged: OnViewModelChanged
		);

	/// <summary>
	/// 外部とやりとりするViewModelプロパティ。
	/// </summary>
	public SelectedAnimal_ViewModel ViewModel
	{
		get => (SelectedAnimal_ViewModel)GetValue(ViewModelProperty);
		set => SetValue(ViewModelProperty, value);
	}

	/// <summary>
	/// コンストラクタ。
	/// </summary>
	public CmnParts_AnimalCentralPlacement_View()
	{
		InitializeComponent();
	}

	/// <summary>
	/// ViewModelが変更された時の処理。
	/// </summary>
	/// <param name="bindable"></param>
	/// <param name="oldValue"></param>
	/// <param name="newValue"></param>
	private static void OnViewModelChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var control = (CmnParts_AnimalCentralPlacement_View)bindable;
		control.BindingContext = newValue;
	}
}