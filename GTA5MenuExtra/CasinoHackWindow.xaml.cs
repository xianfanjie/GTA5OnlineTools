using GTA5Core.Native;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra;

/// <summary>
/// CasinoHackWindow.xaml 的交互逻辑
/// </summary>
public partial class CasinoHackWindow
{
    public CasinoHackWindow()
    {
        InitializeComponent();
    }

    private void Window_CasinoHack_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private void Window_CasinoHack_Closing(object sender, CancelEventArgs e)
    {
        
    }

    private void Button_SetLuckyWheelSlot_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var index = ListBox_LuckyWheel.SelectedIndex;
        if (index == -1)
            return;

        Locals.WriteLocalAddress("casino_lucky_wheel", 276 + 14, index);
    }

    private void Button_SlotMachineSlot_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var index = ListBox_SlotMachine.SelectedIndex;
        if (index == -1)
            return;

        var pointer = Locals.LocalAddress("casino_slots");
        if (Memory.IsValid(pointer))
        {
            pointer = Memory.Read<long>(pointer);

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 64; j++)
                {
                    var offset = 1344 + 1 + 1 + i * 65 + 1 + j;
                    Memory.Write(pointer + offset * 8, index);
                }
            }
        }
    }
}
