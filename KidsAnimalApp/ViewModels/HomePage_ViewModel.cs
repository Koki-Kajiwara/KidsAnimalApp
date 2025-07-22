using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KidsAnimalApp.ViewModels;

public class HomePage_ViewModel
{
    /// <summary>
    /// りくのいきものボタンのコマンド。
    /// </summary>
    public ICommand LandAnimalsCommand { get; set; }

    /// <summary>
    /// うみのいきものボタンのコマンド。
    /// </summary>
    public ICommand SeaAnimalsCommand { get; set; }

    /// <summary>
    /// そらのいきものボタンのコマンド。
    /// </summary>
    public ICommand SkyAnimalsCommand { get; set; }

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    public HomePage_ViewModel()
    {
        LandAnimalsCommand = new Command(async () => await OnLandAnimalsButtonClicked());
        SeaAnimalsCommand = new Command(OnSeaAnimalsButtonClicked);
        SkyAnimalsCommand = new Command(OnSkyAnimalsButtonClicked);

    }

    /// <summary>
    /// りくのいきものボタンがクリックされたときの処理。
    /// </summary>
    private async Task OnLandAnimalsButtonClicked()
    {
        // TODO: りくのいきもの画面に遷移する処理を実装する
        await Shell.Current.DisplayAlert("test message", "りくのいきものボタンがクリックされました", "OK"); // コマンド押下で処理が走るかのテストコード
    }

    /// <summary>
    /// うみのいきものボタンがクリックされたときの処理。
    /// </summary>
    private void OnSeaAnimalsButtonClicked()
    {
        // TODO: うみのいきもの画面に遷移する処理を実装する
    }

    /// <summary>
    /// そらのいきものボタンがクリックされたときの処理。
    /// </summary>
    private void OnSkyAnimalsButtonClicked()
    {
        // TODO: そらのいきもの画面に遷移する処理を実装する
    }
}
