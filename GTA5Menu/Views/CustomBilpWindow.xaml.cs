using GTA5Menu.Data;
using GTA5Menu.Views.CustonBilp;

using CommunityToolkit.Mvvm.Input;

namespace GTA5Menu.Views;

/// <summary>
/// CustomBilpWindow.xaml 的交互逻辑
/// </summary>
public partial class CustomBilpWindow
{
    /// <summary>
    /// 导航菜单
    /// </summary>
    public List<NavMenu> NavMenus { get; set; } = new();

    private readonly MyBilpView MyBilpView = new();
    private readonly AllBilpView AllBilpView = new();

    /// <summary>
    /// 主窗口关闭事件
    /// </summary>
    public static event Action WindowClosingEvent;

    public CustomBilpWindow()
    {
        InitializeComponent();
    }

    private void Window_CustonBilp_Loaded(object sender, RoutedEventArgs e)
    {
        this.DataContext = this;

        // 创建菜单
        CreateNavMenus();
        // 设置主页
        ContentControl_Main.Content = MyBilpView;
    }

    private void Window_CustonBilp_Closing(object sender, CancelEventArgs e)
    {
        WindowClosingEvent();
    }

    /// <summary>
    /// 创建导航菜单
    /// </summary>
    private void CreateNavMenus()
    {
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "我的收藏", ViewName = "MyBilpView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "全部Bilp", ViewName = "AllBilpView" });
    }

    /// <summary>
    /// 页面导航
    /// </summary>
    /// <param name="menu"></param>
    [RelayCommand]
    private void Navigate(NavMenu menu)
    {
        if (menu == null || string.IsNullOrEmpty(menu.ViewName))
            return;

        switch (menu.ViewName)
        {
            case "MyBilpView":
                ContentControl_Main.Content = MyBilpView;
                break;
            case "AllBilpView":
                ContentControl_Main.Content = AllBilpView;
                break;
        }
    }
}
