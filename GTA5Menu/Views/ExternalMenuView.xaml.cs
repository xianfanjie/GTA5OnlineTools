using GTA5Menu.Data;
using GTA5Menu.Views.ExternalMenu;

using CommunityToolkit.Mvvm.Input;

namespace GTA5Menu.Views;

/// <summary>
/// ExternalMenuView.xaml 的交互逻辑
/// </summary>
public partial class ExternalMenuView : UserControl
{
    /// <summary>
    /// 导航菜单
    /// </summary>
    public List<NavMenu> NavMenus { get; set; } = new();

    private readonly SelfStateView SelfStateView = new();
    private readonly WorldFunctionView WorldFunctionView = new();
    private readonly OnlineOptionView OnlineOptionView = new();
    private readonly SpawnVehicleView SpawnVehicleView = new();
    private readonly SpawnWeaponView SpawnWeaponView = new();
    private readonly CustomTeleportView CustomTeleportView = new();
    private readonly DriverButlerView DriverButlerView = new();
    private readonly JobHelperView JobHelperView = new();
    private readonly ExternalOverlayView ExternalOverlayView = new();
    private readonly PlayerListView PlayerListView = new();

    private readonly ReadMeView ReadMeView = new();

    public ExternalMenuView()
    {
        InitializeComponent();

        // 创建菜单
        CreateNavMenus();
        // 设置主页
        ContentControl_Main.Content = SelfStateView;
    }

    /// <summary>
    /// 创建导航菜单
    /// </summary>
    private void CreateNavMenus()
    {
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "自身属性", ViewName = "SelfStateView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "世界功能", ViewName = "WorldFunctionView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "线上选项", ViewName = "OnlineOptionView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "线上载具", ViewName = "SpawnVehicleView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "线上武器", ViewName = "SpawnWeaponView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "自定传送", ViewName = "CustomTeleportView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "随身技工", ViewName = "DriverButlerView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "任务帮手", ViewName = "JobHelperView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "外部ESP", ViewName = "ExternalOverlayView" });
        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "玩家列表", ViewName = "PlayerListView" });

        NavMenus.Add(new NavMenu() { Icon = "\xe610", Title = "README", ViewName = "ReadMeView" });
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
            case "SelfStateView":
                ContentControl_Main.Content = SelfStateView;
                break;
            case "WorldFunctionView":
                ContentControl_Main.Content = WorldFunctionView;
                break;
            case "OnlineOptionView":
                ContentControl_Main.Content = OnlineOptionView;
                break;
            case "SpawnVehicleView":
                ContentControl_Main.Content = SpawnVehicleView;
                break;
            case "SpawnWeaponView":
                ContentControl_Main.Content = SpawnWeaponView;
                break;
            case "CustomTeleportView":
                ContentControl_Main.Content = CustomTeleportView;
                break;
            case "DriverButlerView":
                ContentControl_Main.Content = DriverButlerView;
                break;
            case "JobHelperView":
                ContentControl_Main.Content = JobHelperView;
                break;
            case "ExternalOverlayView":
                ContentControl_Main.Content = ExternalOverlayView;
                break;
            case "PlayerListView":
                ContentControl_Main.Content = PlayerListView;
                break;
            case "ReadMeView":
                ContentControl_Main.Content = ReadMeView;
                break;
        }
    }
}
