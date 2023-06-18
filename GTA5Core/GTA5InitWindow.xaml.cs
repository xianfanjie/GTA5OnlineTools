using GTA5Core.Native;
using GTA5Core.Offsets;

namespace GTA5Core;

/// <summary>
/// GTA5InitWindow.xaml 的交互逻辑
/// </summary>
public partial class GTA5InitWindow
{
    public bool IsAutoClose { get; }

    public GTA5InitWindow(bool isAutoClose = true)
    {
        InitializeComponent();

        IsAutoClose = isAutoClose;
    }

    private void Window_GTA5Init_Loaded(object sender, RoutedEventArgs e)
    {
        Task.Run(() =>
        {
            Memory.IsInitialized = false;

            if (GTA5Init())
            {
                if (PatternInit())
                {
                    Logger("《GTA5》相关模块初始化完毕");
                    Logger("请关闭此初始化窗口");
                    Memory.IsInitialized = true;

                    if (IsAutoClose)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            this.Close();
                        });
                    }

                    return;
                }
            }

            Memory.CloseHandle();
        });
    }

    private void Window_GTA5Init_Closing(object sender, CancelEventArgs e)
    {
        this.DialogResult = Memory.IsInitialized;
    }

    private void Logger(string log)
    {
        this.Dispatcher.Invoke(() =>
        {
            TextBox_Logger.AppendText($"{log}\n");
            TextBox_Logger.ScrollToEnd();
        });
    }

    private bool GTA5Init()
    {
        try
        {
            Logger("开始初始化《GTA5》内存模块");
            var pArray = Process.GetProcessesByName("GTA5");
            if (pArray.Length > 0)
            {
                Logger($"《GTA5》进程数量 {pArray.Length}");
                foreach (var item in pArray)
                {
                    for (int i = 0; i < item.Modules.Count; i++)
                    {
                        if (item.Modules[i].ModuleName.Equals("socialclub.dll"))
                        {
                            Memory.GTA5Process = item;
                            break;
                        }
                    }
                }

                if (Memory.GTA5Process == null)
                {
                    Logger("发生错误，未找到正确的《GTA5》进程");
                    return false;
                }

                if (Memory.GTA5Process.MainWindowHandle == IntPtr.Zero)
                {
                    Logger("发生错误，《GTA5》窗口句柄为空");
                    return false;
                }
                Memory.GTA5WinHandle = Memory.GTA5Process.MainWindowHandle;
                Logger($"《GTA5》程序窗口句柄 {Memory.GTA5WinHandle}");

                if (Memory.GTA5Process.Id == 0)
                {
                    Logger("发生错误，《GTA5》程序进程ID为空");
                    return false;
                }
                Memory.GTA5ProId = Memory.GTA5Process.Id;
                Logger($"《GTA5》程序进程ID {Memory.GTA5ProId}");

                if (Memory.GTA5Process.MainModule != null)
                {
                    Memory.GTA5ProBaseAddress = Memory.GTA5Process.MainModule.BaseAddress.ToInt64();
                    Logger($"《GTA5》程序主模块基址 0x{Memory.GTA5ProBaseAddress:x}");

                    Memory.GTA5ProHandle = Win32.OpenProcess(ProcessAccessFlags.All, false, Memory.GTA5ProId);
                    if (Memory.GTA5ProHandle == IntPtr.Zero)
                    {
                        Logger($"发生错误，《GTA5》程序进程句柄为空");
                        return false;
                    }

                    Logger($"《GTA5》程序进程句柄 {Memory.GTA5ProHandle}");
                    return true;
                }
                else
                {
                    Logger("发生错误，《GTA5》程序主模块基址为空");
                    return false;
                }
            }
            else
            {
                Logger("发生错误，未发现《GTA5》进程");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger($"《GTA5》内存模块初始化异常 {ex.Message}");
            return false;
        }
    }

    private bool PatternInit()
    {
        Logger("开始初始化《GTA5》特征码模块");

        Pointers.WorldPTR = Memory.FindPattern(Mask.World);
        Pointers.WorldPTR = Memory.Rip_37(Pointers.WorldPTR);
        Logger($"《GTA5》WorldPTR 0x{Pointers.WorldPTR:x}");
        if (Pointers.WorldPTR == 0)
            return false;

        Pointers.BlipPTR = Memory.FindPattern(Mask.Blip);
        Pointers.BlipPTR = Memory.Rip_37(Pointers.BlipPTR);
        Logger($"《GTA5》BlipPTR 0x{Pointers.BlipPTR:x}");
        if (Pointers.BlipPTR == 0)
            return false;

        Pointers.GlobalPTR = Memory.FindPattern(Mask.Global);
        Pointers.GlobalPTR = Memory.Rip_37(Pointers.GlobalPTR);
        Logger($"《GTA5》GlobalPTR 0x{Pointers.GlobalPTR:x}");
        if (Pointers.GlobalPTR == 0)
            return false;

        Pointers.ReplayInterfacePTR = Memory.FindPattern(Mask.ReplayInterface);
        Pointers.ReplayInterfacePTR = Memory.Rip_37(Pointers.ReplayInterfacePTR);
        Logger($"《GTA5》ReplayInterfacePTR 0x{Pointers.ReplayInterfacePTR:x}");
        if (Pointers.ReplayInterfacePTR == 0)
            return false;

        Pointers.NetworkPlayerMgrPTR = Memory.FindPattern(Mask.NetworkPlayerMgr);
        Pointers.NetworkPlayerMgrPTR = Memory.Rip_37(Pointers.NetworkPlayerMgrPTR);
        Logger($"《GTA5》NetworkPlayerMgrPTR 0x{Pointers.NetworkPlayerMgrPTR:x}");
        if (Pointers.NetworkPlayerMgrPTR == 0)
            return false;

        Pointers.NetworkInfoPTR = Memory.FindPattern(Mask.NetworkInfo);
        Pointers.NetworkInfoPTR = Memory.Rip_37(Pointers.NetworkInfoPTR);
        Logger($"《GTA5》NetworkInfoPTR 0x{Pointers.NetworkInfoPTR:x}");
        if (Pointers.NetworkInfoPTR == 0)
            return false;

        Pointers.ViewPortPTR = Memory.FindPattern(Mask.ViewPort);
        Pointers.ViewPortPTR = Memory.Rip_37(Pointers.ViewPortPTR);
        Logger($"《GTA5》ViewPortPTR 0x{Pointers.ViewPortPTR:x}");
        if (Pointers.ViewPortPTR == 0)
            return false;

        Pointers.CCameraPTR = Memory.FindPattern(Mask.CCamera);
        Pointers.CCameraPTR = Memory.Rip_37(Pointers.CCameraPTR);
        Logger($"《GTA5》CCameraPTR 0x{Pointers.CCameraPTR:x}");
        if (Pointers.CCameraPTR == 0)
            return false;

        Pointers.AimingPedPTR = Memory.FindPattern(Mask.AimingPed);
        Pointers.AimingPedPTR = Memory.Rip_37(Pointers.AimingPedPTR);
        Logger($"《GTA5》AimingPedPTR 0x{Pointers.AimingPedPTR:x}");
        if (Pointers.AimingPedPTR == 0)
            return false;

        Pointers.WeatherPTR = Memory.FindPattern(Mask.Weather);
        Pointers.WeatherPTR = Memory.Rip_6A(Pointers.WeatherPTR);
        Logger($"《GTA5》WeatherPTR 0x{Pointers.WeatherPTR:x}");
        if (Pointers.WeatherPTR == 0)
            return false;

        Pointers.PickupDataPTR = Memory.FindPattern(Mask.PickupData);
        Pointers.PickupDataPTR = Memory.Rip_37(Pointers.PickupDataPTR);
        Logger($"《GTA5》PickupDataPTR 0x{Pointers.PickupDataPTR:x}");
        if (Pointers.PickupDataPTR == 0)
            return false;

        Pointers.UnkModelPTR = Memory.FindPattern(Mask.UnkModel);
        Pointers.UnkModelPTR = Memory.Rip_37(Pointers.UnkModelPTR);
        Logger($"《GTA5》UnkModelPTR 0x{Pointers.UnkModelPTR:x}");
        if (Pointers.UnkModelPTR == 0)
            return false;

        Pointers.LocalScriptsPTR = Memory.FindPattern(Mask.LocalScripts);
        Pointers.LocalScriptsPTR = Memory.Rip_37(Pointers.LocalScriptsPTR);
        Logger($"《GTA5》LocalScriptsPTR 0x{Pointers.LocalScriptsPTR:x}");
        if (Pointers.LocalScriptsPTR == 0)
            return false;

        Pointers.UnkPTR = Memory.FindPattern(Mask.Unk);
        Pointers.UnkPTR = Memory.Rip_37(Pointers.UnkPTR);
        Logger($"《GTA5》UnkPTR 0x{Pointers.UnkPTR:x}");
        if (Pointers.UnkPTR == 0)
            return false;

        Pointers.HeightPTR = Memory.FindPattern(Mask.Height);
        Logger($"《GTA5》HeightPTR 0x{Pointers.HeightPTR:x}");
        if (Pointers.HeightPTR == 0)
            return true; // 返回 true 此特征码仅在游戏世界加载完毕后可搜索 如果当前未搜索到 将会在使用功能时再次搜索

        return true;
    }
}
