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
	/// 初回ロード済みフラグ。
	/// </summary>
	private bool _isLoaded = false;

	/// <summary>
	/// コンストラクタ。
	/// </summary>
	public CmnParts_AnimalCentralPlacement_View()
	{
		InitializeComponent();

		// 初期状態は非表示、縮小にする
		this.Opacity = 0;
		this.Scale = 0.6;

		//画面準備完了。
		Loaded += (_, _) => this._isLoaded = true;
	}

	/// <summary>
	/// BindingContextが変更された時の処理。
	/// </summary>
	protected override void OnBindingContextChanged()
	{
		base.OnBindingContextChanged();

		if (BindingContext is SelectedAnimal_ViewModel vm)
		{
			vm.PropertyChanged += async (s, e) =>
			{
				// 動物タップを認知して一連の処理を動かす。
				if (e.PropertyName == nameof(vm.IsShown) && vm.IsShown)
				{
					if (!this._isLoaded)
					{
						// 画面準備が完了していない場合は処理しない。
						return;
					}

					// フェードイン。
					await this.ShowAsync();

					// 音声再生。
					this.PlayAnimalSound(vm);
					// TODO アニメーション

					// フェードアウト。
					// await this.HideAsync();
				}
			};
		}
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

	/// <summary>
	/// 動物タップ時の表示アニメーション。
	/// </summary>
	/// <returns></returns>
	private async Task ShowAsync()
	{
		// 表示前に一旦初期化（重要）
		this.Opacity = 0;
		this.Scale = 0.6;

		Dispatcher.Dispatch(async () =>
		{
			// 中央からサイズを大きくしながらフェードイン
			await Task.WhenAll(
				this.FadeTo(1, 1500, Easing.CubicOut),
				this.ScaleTo(1.0, 1500, Easing.CubicOut)
			);
		});

	}

	/// <summary>
	/// 一通りの処理が終わった後の非表示アニメーション
	/// </summary>
	/// <returns></returns>
	private async Task HideAsync()
	{
		await Task.WhenAll(
			this.FadeTo(0, 250, Easing.CubicIn),
			this.ScaleTo(0.6, 250, Easing.CubicIn)
		);
	}

	/// <summary>
	/// 動物の音声を再生する。
	/// </summary>
	private void PlayAnimalSound(SelectedAnimal_ViewModel vm)
	{
		// TODO: 動物の音声を再生する処理を実装
		var audioService = Plugin.Maui.Audio.AudioManager.Current;
		using var player = audioService.CreatePlayer(vm.SelectedAnimalSoundPath);
		player.Play();
	}
}