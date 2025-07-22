namespace KidsAnimalApp.Models;

public class Animal
{
    /// <summary>
    /// 動物名称。
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// アイコンのパス。
    /// </summary>
    public required string ImagePath { get; set; }

    /// <summary>
    /// 音声のパス。
    /// </summary>
    public required string SoundPath { get; set; }
}