using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AVFoundation;
using KidsAnimalApp.Models;
using Plugin.Maui.Audio;

namespace KidsAnimalApp.ViewModels;

public class BaseAnimalViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// 変更通知イベント。
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// プロパティ変更通知を発行します。
    /// </summary>
    /// <param name="propertyName">対象プロパティ</param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// 動物クラスのコレクション。
    /// </summary>
    public ObservableCollection<Animal> Animals { get; set; }

    private string _selectedAnimalName;
    public string SelectedAnimalName
    {
        get => _selectedAnimalName;
        set
        {
            _selectedAnimalName = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    public BaseAnimalViewModel()
    {
        Animals = new ObservableCollection<Animal>();
        LoadAnimals();
    }

    /// <summary>
    /// 動物データをロードします。
    /// </summary>
    protected virtual void LoadAnimals()
    {
        // ここで動物のデータをロードする処理を実装する
        // 例: Animals.Add(new Animal { Name = "Lion", ImagePath = "lion.png", SoundPath = "lion.mp3" });
    }

    /// <summary>
    /// 動物アイコンがタップされたときの処理。
    /// </summary>
    /// <remarks>
    /// このメソッドをオーバーライドして特定の動物のアニメーションを実装してください。
    /// </remarks>
    /// <param name="animal">動物クラス</param>
    protected virtual async Task OnAnimalTapped(Animal animal)
    {
        this.SelectedAnimalName = animal.Name;

        // 動物を中央までフェードインさせる。
        await this.AnimateToCenter(animal.ImagePath);

        // 動物の鳴き声を再生する。(TODO: 音声を再生しながらアニメーションさせる方が良いか？（await不要？）)
        await this.PlayAnimalSound(animal.SoundPath);

        // 動物アイコンのアニメーションを実装する
    }

    /// <summary>
    /// 戻るボタンが押されたときの処理。
    /// </summary>
    /// <returns></returns>
    protected virtual async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

    /// <summary>
    /// 動物アイコンを中央にアニメーションさせます。
    /// </summary>
    /// <param name="imagePath">動物アイコンファイルパス</param>
    /// <returns></returns>
    private async Task AnimateToCenter(string imagePath)
    {
        // TODO: 動物アイコンを中央にアニメーションさせる処理を実装する。
    }
    /// <summary>
    /// 動物の鳴き声を再生します。
    /// </summary>
    /// <param name="soundPath">音声ファイルパス</param>
    /// <returns></returns>
    private async Task PlayAnimalSound(string soundPath)
    {
        var player = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(soundPath));
        player.Play();
    }
}