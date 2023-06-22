using GTA5Menu.Options;

using GTA5HotKey;
using GTA5Core.Native;
using GTA5Core.Offsets;
using GTA5Core.Features;
using GTA5Core.GTA.Rage;
using GTA5Shared.Helper;

using CommunityToolkit.Mvvm.Input;

namespace GTA5Menu;

/// <summary>
/// GTA5MenuWindow.xaml 的交互逻辑
/// </summary>
public partial class GTA5MenuWindow
{
    /// <summary>
    /// 导航字典
    /// </summary>
    private readonly Dictionary<string, UserControl> NavDictionary = new();

    ///////////////////////////////////////////

    /// <summary>
    /// 主窗口关闭事件
    /// </summary>
    public static event Action WindowClosingEvent;

    /// <summary>
    /// 主窗口 鼠标坐标数据
    /// </summary>
    private POINT ThisWinPOINT;

    /// <summary>
    /// 是否显示外置窗口菜单
    /// </summary>
    private bool IsShowExternalMenu = true;

    /// <summary>
    /// 判断程序是否在运行，用于结束线程
    /// </summary>
    private bool IsAppRunning = true;

    ///////////////////////////////////////////

    public GTA5MenuWindow()
    {
        InitializeComponent();

        CreateView();
    }

    private void Window_GTA5Menu_Loaded(object sender, RoutedEventArgs e)
    {
        Navigate(NavDictionary.First().Key);

        HotKeys.AddKey(WinVK.DELETE);
        HotKeys.KeyDownEvent += HotKeys_KeyDownEvent;

        new Thread(CPedThread)
        {
            Name = "CPedThread",
            IsBackground = true
        }.Start();

        new Thread(CommonThread)
        {
            Name = "CommonThread",
            IsBackground = true
        }.Start();
    }

    private void Window_GTA5Menu_Closing(object sender, CancelEventArgs e)
    {
        WindowClosingEvent();

        IsAppRunning = false;

        Setting.Player.Reset();
        Setting.Vehicle.Reset();
        Setting.Weapon.Reset();
        Setting.Auto.Reset();

        HotKeys.ClearKeys();
    }

    /// <summary>
    /// 创建页面
    /// </summary>
    private void CreateView()
    {
        foreach (var item in ControlHelper.GetControls(Grid_NavMenu).Cast<RadioButton>())
        {
            var viewName = item.CommandParameter.ToString();

            if (!NavDictionary.ContainsKey(viewName))
            {
                var type = Type.GetType($"GTA5Menu.Views.{viewName}");
                if (type == null)
                    continue;

                NavDictionary.Add(viewName, Activator.CreateInstance(type) as UserControl);
            }
        }
    }

    /// <summary>
    /// View页面导航
    /// </summary>
    /// <param name="viewName"></param>
    [RelayCommand]
    private void Navigate(string viewName)
    {
        if (!NavDictionary.ContainsKey(viewName))
            return;

        if (ContentControl_NavRegion.Content != NavDictionary[viewName])
            ContentControl_NavRegion.Content = NavDictionary[viewName];
    }

    /// <summary>
    /// 外置菜单窗口是否置顶
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBox_IsTopMost_Click(object sender, RoutedEventArgs e)
    {
        if (CheckBox_IsTopMost.IsChecked == true)
            Topmost = true;
        else
            Topmost = false;
    }

    /// <summary>
    /// 全局热键 按键按下事件
    /// </summary>
    /// <param name="vK"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void HotKeys_KeyDownEvent(WinVK vK)
    {
        this.Dispatcher.Invoke(() =>
        {
            switch (vK)
            {
                case WinVK.DELETE:
                    ShowWindow();
                    break;
            }
        });
    }

    /// <summary>
    /// 显示隐藏外置菜单窗口
    /// </summary>
    private void ShowWindow()
    {
        IsShowExternalMenu = !IsShowExternalMenu;
        if (IsShowExternalMenu)
        {
            this.WindowState = WindowState.Normal;

            if (CheckBox_IsTopMost.IsChecked == false)
            {
                Topmost = true;
                Topmost = false;
            }

            Win32.SetCursorPos(ThisWinPOINT.X, ThisWinPOINT.Y);
        }
        else
        {
            this.WindowState = WindowState.Minimized;

            Win32.GetCursorPos(out ThisWinPOINT);
            Memory.SetForegroundWindow();
        }
    }

    private void CPedThread()
    {
        while (IsAppRunning)
        {
            var pCPed = Game.GetCPed();
            var pCNavigation = Memory.Read<long>(pCPed + CPed.CNavigation);

            var oInVehicle = Memory.Read<byte>(pCPed + CPed.InVehicle);

            var oGod = Memory.Read<byte>(pCPed + CPed.God);
            var oRagdoll = Memory.Read<byte>(pCPed + CPed.Ragdoll);
            var oSeatbelt = Memory.Read<byte>(pCPed + CPed.Seatbelt);

            ////////////////////////////////////////////////////////////////

            // 玩家无敌
            if (Setting.Player.GodMode)
            {
                if (oGod != 0x01)
                    Memory.Write<byte>(pCPed + CPed.God, 0x01);
            }

            // 挂机防踢
            if (Setting.Player.AntiAFK)
            {
                if (Globals.ReadGA<int>(262145 + 87) != 99999999)
                    Online.AntiAFK(true);
            }

            // 无布娃娃
            if (Setting.Player.NoRagdoll)
            {
                if (oRagdoll != 0x01)
                    Memory.Write<byte>(pCPed + CPed.Ragdoll, 0x01);
            }

            // 玩家无碰撞体积
            if (Setting.Player.NoCollision)
            {
                long pointer = Memory.Read<long>(pCNavigation + 0x10);
                pointer = Memory.Read<long>(pointer + 0x20);
                pointer = Memory.Read<long>(pointer + 0x70);
                pointer = Memory.Read<long>(pointer + 0x00);
                Memory.Write(pointer + 0x2C, -1.0f);
            }

            // 安全带
            if (Setting.Vehicle.Seatbelt)
            {
                if (oSeatbelt != 0xC9)
                    Memory.Write<byte>(pCPed + CPed.Seatbelt, 0xC9);
            }

            // 弹药编辑
            if (Setting.Weapon.AmmoModifierFlag != 0)
            {
                long pCPedInventory = Memory.Read<long>(pCPed + CPed.CPedInventory);
                Memory.Write(pCPedInventory + CPedInventory.AmmoModifier, Setting.Weapon.AmmoModifierFlag);
            }

            // 非公开战局运货
            if (Setting.Online.AllowSellOnNonPublic)
                Online.AllowSellOnNonPublic(true);

            ////////////////////////////////////////////////////////////////

            if (oInVehicle != 0x00)
            {
                var pCVehicle = Memory.Read<long>(pCPed + CPed.CVehicle);
                var oVehicleGod = Memory.Read<byte>(pCVehicle + CVehicle.God);

                // 载具无敌
                if (Setting.Vehicle.GodMode)
                {
                    if (oVehicleGod != 0x01)
                        Memory.Write<byte>(pCVehicle + CVehicle.God, 0x01);
                }
            }

            Thread.Sleep(1000);
        }
    }

    private void CommonThread()
    {
        while (IsAppRunning)
        {
            // 自动消星
            if (Setting.Auto.ClearWanted)
                Player.WantedLevel(0x00);

            var pCPedList = Game.GetCPedList();

            for (var i = 0; i < Base.oMaxPeds; i++)
            {
                var pCPed = Memory.Read<long>(pCPedList + i * 0x10);
                if (!Memory.IsValid(pCPed))
                    continue;

                // 跳过玩家
                var pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo);
                if (Memory.IsValid(pCPlayerInfo))
                    continue;

                // 自动击杀NPC
                if (Setting.Auto.KillNPC)
                    Memory.Write(pCPed + CPed.Health, 0.0f);

                // 自动击杀敌对NPC
                if (Setting.Auto.KillHostilityNPC)
                {
                    var oHostility = Memory.Read<byte>(pCPed + CPed.Hostility);
                    if (oHostility > 0x01)
                    {
                        Memory.Write(pCPed + CPed.Health, 0.0f);
                    }
                }

                // 自动击杀警察
                if (Setting.Auto.KillPolice)
                {
                    var ped_type = Memory.Read<int>(pCPed + CPed.Ragdoll);
                    ped_type = ped_type << 11 >> 25;

                    if (ped_type == (int)PedType.COP ||
                        ped_type == (int)PedType.SWAT ||
                        ped_type == (int)PedType.ARMY)
                    {
                        Memory.Write(pCPed + CPed.Health, 0.0f);
                    }
                }
            }

            Thread.Sleep(200);
        }
    }
}
