using System.Collections.ObjectModel;
using KidsAnimalApp.Models;

namespace KidsAnimalApp.ViewModels;

public class BaseAnimalViewModel
{
    public ObservableCollection<Animal> Animals { get; set; }

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
    /// <param name="animal0"></param>
    protected virtual void OnAnimalTapped(Animal animal0)
    {
        // TODO: アイコンファイルパスを取得する処理を実装する。
        // TODO: 音声ファイルパスを取得し、再生する処理を実装する。

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
}