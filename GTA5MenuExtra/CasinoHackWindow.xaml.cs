using GTA5Core.Native;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra;

/// <summary>
/// CasinoHackWindow.xaml 的交互逻辑
/// </summary>
public partial class CasinoHackWindow
{
    private bool _disposed = false;

    private int luckyWheelSlot = -1;
    private int slotMachineSlot = -1;

    public CasinoHackWindow()
    {
        InitializeComponent();
    }

    private void Window_CasinoHack_Loaded(object sender, RoutedEventArgs e)
    {
        new Thread(CasinoHackLoopThread)
        {
            Name = "CasinoHackLoopThread",
            IsBackground = true
        }.Start();
    }

    private void Window_CasinoHack_Closing(object sender, CancelEventArgs e)
    {

    }

    private void CasinoHackLoopThread()
    {
        while (!_disposed)
        {
            // 幸运轮盘
            if (luckyWheelSlot != -1)
            {
                Locals.WriteLocalAddress("casino_lucky_wheel", 276 + 14, luckyWheelSlot);
            }

            // 老虎机
            if (slotMachineSlot != -1)
            {
                var pointer = Locals.LocalAddress("casino_slots");
                if (Memory.IsValid(pointer))
                {
                    pointer = Memory.Read<long>(pointer);

                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 64; j++)
                        {
                            var offset = 1344 + 1 + 1 + i * 65 + 1 + j;
                            Memory.Write(pointer + offset * 8, slotMachineSlot);
                        }
                    }
                }
            }

            Thread.Sleep(250);
        }
    }

    private void Button_LuckyWheelSlot_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        luckyWheelSlot = ListBox_LuckyWheel.SelectedIndex;

        if (ListBox_LuckyWheel.SelectedItem is ListBoxItem item)
            TextBlock_LuckyWheelValue.Text = $"奖品：{item.Content}";
    }

    private void Button_SlotMachineSlot_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        slotMachineSlot = ListBox_SlotMachine.SelectedIndex;

        if (ListBox_SlotMachine.SelectedItem is ListBoxItem item)
            TextBlock_SlotMachineValue.Text = $"奖品：{item.Content}";
    }
}
