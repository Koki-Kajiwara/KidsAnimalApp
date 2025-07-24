using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AVFoundation;
using KidsAnimalApp.Models;
using Plugin.Maui.Audio;

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
        Animals = new ObservableCollection<Animal>();
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
    protected virtual void OnAnimalTapped(Animal animal)
    {
        this.SelectedAnimalName = animal.Name;
        this.SelectedAnimalImagePath = animal.ImagePath;

        // ViewコードビハインドにてUI処理。(TODO: 派生クラスでオーバーライドした際にAnimalTapped.Invoke()をしなければいけないか・・・？)
        this.AnimalTapped?.Invoke(animal);
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