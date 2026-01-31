using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KidsAnimalApp.ViewModels;

/// <summary>
/// タップされた動物を中央表示する際のViewModel。
/// </summary>
public class SelectedAnimal_ViewModel : INotifyPropertyChanged
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
    /// 選択された動物の名称。
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
    /// 選択された動物の画像パス。
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
    /// 暗幕の表示状態管理。
    /// </summary>
    private bool _isVisible;
    public bool IsVisible
    {
        get => _isVisible;
        set
        {
            _isVisible = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 暗幕の表示状態管理。
    /// </summary>
    private double _opacity;
    public double Opacity
    {
        get => _opacity;
        set
        {
            _opacity = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 入力を透過するかどうかのフラグ。
    /// </summary>
    private bool _isInputTransparent;
    public bool IsInputTransparent
    {
        get => _isInputTransparent;
        set
        {
            _isInputTransparent = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 動物タップの管理。
    /// </summary>
    private bool _isShown;
    public bool IsShown
    {
        get => _isShown;
        set
        {
            _isShown = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    public SelectedAnimal_ViewModel()
    {
        // 初期状態では非表示
        this.IsInputTransparent = true;
        this.Opacity = 0.0;
    }


}