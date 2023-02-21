using CommunityToolkit.Mvvm.Input;
using GTA5Menu.ESP;
using GTA5Shared.Helper;

namespace GTA5Menu.Views;

/// <summary>
/// ExternalOverlay.xaml 的交互逻辑
/// </summary>
public partial class ExternalOverlayWindow
{
    private GTA5Overlay GTA5Overlay = null;

    public ExternalOverlayWindow()
    {
        InitializeComponent();
    }

    private void Window_ExternalOverlay_Loaded(object sender, RoutedEventArgs e)
    {
        this.DataContext = this;
    }

    private void Window_ExternalOverlay_Closing(object sender, CancelEventArgs e)
    {
        CloseOverlay();
    }

    [RelayCommand]
    private async void RunOverlay()
    {
        if (GTA5Overlay == null)
        {
            GTA5Overlay = new GTA5Overlay();
            await GTA5Overlay.Run();
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "外置ESP覆盖已经在运行了，请勿重复启动");
        }
    }

    [RelayCommand]
    private void CloseOverlay()
    {
        if (GTA5Overlay != null)
        {
            GTA5Overlay.Close();
            GTA5Overlay.Dispose();
            GTA5Overlay = null;
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "外置ESP覆盖已经关闭，请勿重复关闭");
        }
    }
}
