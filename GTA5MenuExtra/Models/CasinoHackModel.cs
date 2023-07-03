using CommunityToolkit.Mvvm.ComponentModel;

namespace GTA5MenuExtra.Models;

public partial class CasinoHackModel : ObservableObject
{
    /// <summary>
    /// 是否启用 老虎机操控中奖
    /// </summary>
    [ObservableProperty]
    private bool isEnabledSlotMachine;

    /// <summary>
    /// 是否启用 幸运轮盘操控中奖
    /// </summary>
    [ObservableProperty]
    private bool isEnabledLuckyWheel;

    /// <summary>
    /// 老虎机 选中索引
    /// </summary>
    [ObservableProperty]
    private int slotMachineSlot;

    /// <summary>
    /// 幸运轮盘 选中索引
    /// </summary>
    [ObservableProperty]
    private int luckyWheelSlot;
}