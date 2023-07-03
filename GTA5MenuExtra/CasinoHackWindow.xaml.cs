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
        for (int i = 0; i < 37; i++)
        {
            ComboBox_Roulette.Items.Add($"号码 {i}");
        }
        ComboBox_Roulette.Items.Add("号码 00");

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
            // 黑杰克（21点）
            if (CasinoHackModel.BlackjackIsCheck)
            {
                var pointer = Locals.LocalAddress("blackjack");
                if (Memory.IsValid(pointer))
                {
                    pointer = Memory.Read<long>(pointer);

                    var index = Memory.Read<int>(pointer + (2026 + 2 + 1 + 1 * 1) * 8);

                    var builder = new StringBuilder();
                    if ((index - 1) / 13 == 0)
                        builder.Append($"♣梅花{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 1)
                        builder.Append($"♦方块{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 2)
                        builder.Append($"♥红心{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 3)
                        builder.Append($"♠黑桃{(index - 1) % 13 + 1}");

                    CasinoHackModel.BlackjackContent = builder.ToString();

                    ///////////////////////////////////////////////////////

                    var current_table = Memory.Read<int>(pointer + (1769 + (1 + Globals.ReadGA<int>(2703735) * 8) + 4) * 8);
                    var nums = Memory.Read<int>(pointer + (109 + 1 + 1 + current_table * 211 + 209) * 8);

                    index = Memory.Read<int>(pointer + (2026 + 2 + 1 + nums * 1) * 8);

                    builder.Clear();
                    if ((index - 1) / 13 == 0)
                        builder.Append($"♣梅花{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 1)
                        builder.Append($"♦方块{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 2)
                        builder.Append($"♥红心{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 3)
                        builder.Append($"♠黑桃{(index - 1) % 13 + 1}");

                    CasinoHackModel.BlackjackNextContent = builder.ToString();
                }
            }

            // 三张扑克
            if (CasinoHackModel.PokerIsCheck)
            {
                var pointer = Locals.LocalAddress("three_card_poker");
                if (Memory.IsValid(pointer))
                {
                    pointer = Memory.Read<long>(pointer);

                    var index = Memory.Read<int>(pointer + (1033 + 799 + 2 + 1 + 2 * 1) * 8);

                    var builder = new StringBuilder();
                    if ((index - 1) / 13 == 0)
                        builder.Append($"♣梅花{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 1)
                        builder.Append($"♦方块{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 2)
                        builder.Append($"♥红心{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 3)
                        builder.Append($"♠黑桃{(index - 1) % 13 + 1}");
                    builder.Append('\n');

                    index = Memory.Read<int>(pointer + (1033 + 799 + 2 + 1 + 0 * 1) * 8);
                    if ((index - 1) / 13 == 0)
                        builder.Append($"♣梅花{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 1)
                        builder.Append($"♦方块{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 2)
                        builder.Append($"♥红心{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 3)
                        builder.Append($"♠黑桃{(index - 1) % 13 + 1}");
                    builder.Append('\n');

                    index = Memory.Read<int>(pointer + (1033 + 799 + 2 + 1 + 1 * 1) * 8);
                    if ((index - 1) / 13 == 0)
                        builder.Append($"♣梅花{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 1)
                        builder.Append($"♦方块{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 2)
                        builder.Append($"♥红心{(index - 1) % 13 + 1}");
                    if ((index - 1) / 13 == 3)
                        builder.Append($"♠黑桃{(index - 1) % 13 + 1}");

                    CasinoHackModel.PokerContent = builder.ToString();
                }
            }

            // 轮盘
            if (CasinoHackModel.RouletteIsCheck && CasinoHackModel.RouletteSelectedIndex != -1)
            {
                var pointer = Locals.LocalAddress("casinoroulette");
                if (Memory.IsValid(pointer))
                {
                    pointer = Memory.Read<long>(pointer);

                    for (var i = 0; i < 6; i++)
                    {
                        Memory.Write(pointer + (117 + 1357 + 153 + 1 + i * 1) * 8, CasinoHackModel.RouletteSelectedIndex);
                    }
                }
            }

            // 老虎机
            if (CasinoHackModel.SlotMachineIsCheck && CasinoHackModel.SlotMachineSelectedIndex != -1)
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
                            Memory.Write(pointer + index * 8, CasinoHackModel.SlotMachineSelectedIndex);
                        }
                    }
                }
            }

            // 幸运轮盘
            if (CasinoHackModel.LuckyWheelIsCheck && CasinoHackModel.LuckyWheelSelectedIndex != -1)
            {
                // https://www.unknowncheats.me/forum/grand-theft-auto-v/483416-gtavcsmm.html

                var pointer = Locals.LocalAddress("casino_lucky_wheel");
                if (Memory.IsValid(pointer))
                {
                    pointer = Memory.Read<long>(pointer);

                    var index = 276 + 14;
                    Memory.Write(pointer + index * 8, CasinoHackModel.LuckyWheelSelectedIndex);
                }
            }

            Thread.Sleep(250);
        }
    }
}
