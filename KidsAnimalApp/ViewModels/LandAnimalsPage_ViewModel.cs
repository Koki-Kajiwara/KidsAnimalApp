using System.Windows.Input;
using KidsAnimalApp.Models;

namespace KidsAnimalApp.ViewModels;

/// <summary>
/// 陸の生き物画面ViewModel。
/// </summary>
public class LandAnimalsPage_ViewModel : BaseAnimalViewModel
{
    /// <summary>
    /// 動物アイコンのコマンド。
    /// </summary>
    public ICommand AnimalTappedCommand { get; set; }

    /// <summary>
    /// 戻るボタンのコマンド。
    /// </summary>
    public ICommand BackCommand { get; set; }

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    public LandAnimalsPage_ViewModel()
    {
        // 派生クラスで実装された動物データの設定処理を呼び出す
        this.LoadAnimals();

        // 動物アイコン押下時の処理。
        this.AnimalTappedCommand = new Command(animal =>
        {
            if (animal is Animal tappedAnimal)
            {
                base.OnAnimalTapped(tappedAnimal);
            }
        });

        // 戻るボタン押下時の処理。
        this.BackCommand = new Command(async () => await base.GoBackAsync());
    }

    /// <summary>
    /// 動物データを設定します。
    /// </summary>
    protected override void LoadAnimals()
    {
        // 陸の生き物データを設定する
        base.Animals.Add(new Animal { Name = "いぬ", ImagePath = "image_land_dog.png", SoundPath = "sound_land_dog.mp3" });
        base.Animals.Add(new Animal { Name = "ねこ", ImagePath = "image_land_cat.png", SoundPath = "sound_land_cat.mp3" });
        base.Animals.Add(new Animal { Name = "ぞう", ImagePath = "image_land_elephant.png", SoundPath = "sound_land_elephant.mp3" });
        base.Animals.Add(new Animal { Name = "らいおん", ImagePath = "image_land_lion.png", SoundPath = "sound_land_lion.mp3" });
        base.Animals.Add(new Animal { Name = "きりん", ImagePath = "image_land_giraffe.png", SoundPath = "sound_land_giraffe.mp3" });
        base.Animals.Add(new Animal { Name = "うま", ImagePath = "image_land_horse.png", SoundPath = "sound_land_horse.mp3" });
        base.Animals.Add(new Animal { Name = "ひつじ", ImagePath = "image_land_sheep.png", SoundPath = "sound_land_sheep.mp3" });
        base.Animals.Add(new Animal { Name = "ぶた", ImagePath = "image_land_pig.png", SoundPath = "sound_land_pig.mp3" });
        base.Animals.Add(new Animal { Name = "うし", ImagePath = "image_land_cow.png", SoundPath = "sound_land_cow.mp3" });
        base.Animals.Add(new Animal { Name = "おおかみ", ImagePath = "image_land_wolf.png", SoundPath = "sound_land_wolf.mp3" });
    }
}