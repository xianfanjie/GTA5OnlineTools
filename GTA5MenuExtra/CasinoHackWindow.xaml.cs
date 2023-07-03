using GTA5Core.Native;
using GTA5Core.Features;
using GTA5MenuExtra.Models;

namespace GTA5MenuExtra;

/// <summary>
/// CasinoHackWindow.xaml 的交互逻辑
/// </summary>
public partial class CasinoHackWindow
{
    public CasinoHackModel CasinoHackModel { get; set; } = new();

    private bool _disposed = false;

    public CasinoHackWindow()
    {
        InitializeComponent();
    }

    private void Window_CasinoHack_Loaded(object sender, RoutedEventArgs e)
    {
        new Thread(CasinoHackMainThread)
        {
            Name = "CasinoHackMainThread",
            IsBackground = true
        }.Start();
    }

    private void Window_CasinoHack_Closing(object sender, CancelEventArgs e)
    {
        _disposed = true;
    }

    private void CasinoHackMainThread()
    {
        while (!_disposed)
        {
            // 幸运轮盘
            if (CasinoHackModel.IsEnabledLuckyWheel &&
                CasinoHackModel.LuckyWheelSlot != -1)
            {
                // https://www.unknowncheats.me/forum/grand-theft-auto-v/483416-gtavcsmm.html

                var pointer = Locals.LocalAddress("casino_lucky_wheel");
                if (Memory.IsValid(pointer))
                {
                    pointer = Memory.Read<long>(pointer);

                    var index = 276 + 14;
                    Memory.Write(pointer + index * 8, CasinoHackModel.LuckyWheelSlot);
                }
            }

            // 老虎机
            if (CasinoHackModel.IsEnabledSlotMachine && 
                CasinoHackModel.SlotMachineSlot != -1)
            {
                var pointer = Locals.LocalAddress("casino_slots");
                if (Memory.IsValid(pointer))
                {
                    pointer = Memory.Read<long>(pointer);

                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 64; j++)
                        {
                            var index = 1344 + 1 + 1 + i * 65 + 1 + j * 1;
                            Memory.Write(pointer + index * 8, CasinoHackModel.SlotMachineSlot);
                        }
                    }
                }
            }

            Thread.Sleep(250);
        }
    }
}
