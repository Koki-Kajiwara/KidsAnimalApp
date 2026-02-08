using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AVFoundation;
using KidsAnimalApp.Models;

namespace KidsAnimalApp.ViewModels;

public abstract class BaseAnimalViewModel : INotifyPropertyChanged
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

    /// <summary>
    /// タップされた動物を中央表示する際のViewModel。
    /// </summary>
    public SelectedAnimal_ViewModel SelectedAnimalViewModel{ get; set; }

    /// <summary>
    /// 動物の名称。
    /// </summary>
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
    /// 動物がタップされた時のイベント。
    /// </summary>
    public event Action<Animal>? AnimalTapped;

    /// <summary>
    /// 動物のアイコンパス。
    /// </summary>
    private string _selectedAnimalImagePath;
    public string SelectedAnimalImagePath
    {
        get => _selectedAnimalImagePath;
        set
        {
            _selectedAnimalImagePath = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    public BaseAnimalViewModel()
    {
        this.SelectedAnimalViewModel = new SelectedAnimal_ViewModel();
        this.Animals = new ObservableCollection<Animal>();
    }

    /// <remarks>
    /// 派生クラスでオーバーライドして、動物データをnewする必要があります。
    /// </remarks>
    protected abstract void LoadAnimals();

    /// <summary>
    /// 動物アイコンがタップされたときの処理。
    /// </summary>
    /// <remarks>
    /// このメソッドをオーバーライドして特定の動物のアニメーションを実装してください。
    /// </remarks>
    /// <param name="animal">動物クラス</param>
    protected virtual async Task OnAnimalTapped(Animal animal)
    {
        // 暗幕と動物アイコンタップ可否の設定
        this.SelectedAnimalViewModel.Opacity = 1.0;
        this.SelectedAnimalViewModel.IsInputTransparent = false;

        // 画面中央に表示させるためにセットする
        this.SelectedAnimalViewModel.SelectedAnimalName = animal.Name;
        this.SelectedAnimalViewModel.SelectedAnimalImagePath = animal.ImagePath;
        this.SelectedAnimalViewModel.SelectedAnimalSoundPath = animal.SoundPath;

        // View側にタップされたことを合図する
        this.SelectedAnimalViewModel.IsShown = true;
    }

    /// <summary>
    /// 戻るボタンが押されたときの処理。
    /// </summary>
    /// <returns></returns>
    protected virtual async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}