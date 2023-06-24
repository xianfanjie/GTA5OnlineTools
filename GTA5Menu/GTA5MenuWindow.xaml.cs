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
    /// 每间隔1000ms调用一次事件
    /// </summary>
    public static event Action LoopTime1000MsEvent;
    /// <summary>
    /// 每间隔200ms调用一次事件
    /// </summary>
    public static event Action LoopTime200MsEvent;

    ///////////////////////////////////////////

    /// <summary>
    /// 窗口句柄
    /// </summary>
    private IntPtr ThisWindowHandle = IntPtr.Zero;

    /// <summary>
    /// 窗口鼠标坐标数据
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

        // 获取当前窗口句柄
        ThisWindowHandle = new WindowInteropHelper(this).Handle;

        // 添加快捷键
        HotKeys.AddKey(WinVK.DELETE);
        // 订阅按钮事件
        HotKeys.KeyDownEvent += HotKeys_KeyDownEvent;

        new Thread(LoopTime1000MsThread)
        {
            Name = "LoopTime200MsThread",
            IsBackground = true
        }.Start();

        new Thread(LoopTime200MsThread)
        {
            Name = "LoopTime1000MsThread",
            IsBackground = true
        }.Start();
    }

    private void Window_GTA5Menu_Closing(object sender, CancelEventArgs e)
    {
        IsAppRunning = false;
        WindowClosingEvent?.Invoke();

        Setting.Player.Reset();
        Setting.Vehicle.Reset();
        Setting.Weapon.Reset();
        Setting.Auto.Reset();

        // 移除快捷键
        HotKeys.RemoveKey(WinVK.DELETE);
        // 取消订阅按钮事件（2023/06/24 这里一定要取消订阅，否则会照成事件累加）
        HotKeys.KeyDownEvent -= HotKeys_KeyDownEvent;
    }

    /// <summary>
    /// 创建页面
    /// </summary>
    private void CreateView()
    {
        foreach (var item in ControlHelper.GetControls(Grid_NavMenu).Cast<RadioButton>())
        {
            var viewName = item.CommandParameter.ToString();

            if (NavDictionary.ContainsKey(viewName))
                continue;

            var typeView = Type.GetType($"GTA5Menu.Views.{viewName}");
            if (typeView == null)
                continue;

            NavDictionary.Add(viewName, Activator.CreateInstance(typeView) as UserControl);
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

        if (ContentControl_NavRegion.Content == NavDictionary[viewName])
            return;

        ContentControl_NavRegion.Content = NavDictionary[viewName];
    }

    /// <summary>
    /// 窗口是否置顶
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
    /// 窗口是否隐藏任务栏图标
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBox_IsShowInTaskbar_Click(object sender, RoutedEventArgs e)
    {
        if (CheckBox_IsShowInTaskbar.IsChecked == true)
            ShowInTaskbar = false;
        else
            ShowInTaskbar = true;
    }

    /// <summary>
    /// 按键按下事件
    /// </summary>
    /// <param name="vK"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void HotKeys_KeyDownEvent(WinVK vK)
    {
        switch (vK)
        {
            case WinVK.DELETE:
                ShowWindow();
                break;
        }
    }

    /// <summary>
    /// 显示隐藏外置菜单窗口
    /// </summary>
    private void ShowWindow()
    {
        this.Dispatcher.Invoke(() =>
        {
            IsShowExternalMenu = !IsShowExternalMenu;

            if (IsShowExternalMenu)
            {
                var thisWindowThreadId = Win32.GetWindowThreadProcessId(ThisWindowHandle, IntPtr.Zero);
                var currentForegroundWindow = Win32.GetForegroundWindow();
                var currentForegroundWindowThreadId = Win32.GetWindowThreadProcessId(currentForegroundWindow, IntPtr.Zero);

                Win32.AttachThreadInput(currentForegroundWindowThreadId, thisWindowThreadId, true);

                this.Show();
                this.Activate();
                this.Focus();

                this.WindowState = WindowState.Normal;

                Win32.AttachThreadInput(currentForegroundWindowThreadId, thisWindowThreadId, false);

                this.Topmost = true;
                this.Topmost = false;

                if (CheckBox_IsTopMost.IsChecked == true)
                    this.Topmost = true;

                Win32.SetForegroundWindow(ThisWindowHandle);
                Win32.SetCursorPos(ThisWinPOINT.X, ThisWinPOINT.Y);
            }
            else
            {
                this.Hide();

                Win32.GetCursorPos(out ThisWinPOINT);
                Memory.SetForegroundWindow();
            }
        });
    }

    private void LoopTime1000MsThread()
    {
        while (IsAppRunning)
        {
            LoopTime1000MsEvent?.Invoke();

            Thread.Sleep(1000);
        }
    }

    private void LoopTime200MsThread()
    {
        while (IsAppRunning)
        {
            LoopTime200MsEvent?.Invoke();

            Thread.Sleep(200);
        }
    }
}
