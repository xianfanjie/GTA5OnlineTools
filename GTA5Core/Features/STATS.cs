using GTA5Core.Native;

namespace GTA5Core.Features;

public static class STATS
{
    private const int statGetIntValue = 2805862 + 267;

    private const int characterSlot = 1574918;
    private const int callStat = 1654054 + 1136;

    private const int statSetIntHash = 1665476 + 1 + 3;
    private const int statSetIntValue = 980531 + 5525;

    private const int statSetIntMinusOne = 1654054 + 1139;   // https://pastebin.com/VbfAmLYB 

    private static long StatGetIntHash()
    {
        return Memory.Read<long>(Memory.GTA5ProBaseAddress + 0x2699E98) + 0xAE8;
    }

    private static uint GET_STAT_HASH(string statName)
    {
        if (statName.StartsWith("MPx_"))
        {
            var index = Globals.GetPlayerIndex();
            statName = statName.Replace("MPx_", $"MP{index}_");
        }

        return JOATT(statName);
    }

    /// <summary>
    /// 字符串转Hash值
    /// </summary>
    /// <param name="statName"></param>
    /// <returns></returns>
    public static uint JOATT(string statName)
    {
        var hash = 0u;

        foreach (var c in statName.ToLower())
        {
            hash += c;
            hash += hash << 10;
            hash ^= hash >> 6;
        }

        hash += hash << 3;
        hash ^= hash >> 11;
        hash += hash << 15;

        return hash;
    }

    /// <summary>
    /// 设置INT类型STAT值
    /// </summary>
    /// <param name="statName"></param>
    /// <returns></returns>
    public static async Task STAT_SET_INT(string statName, int value)
    {
        await STAT_SET_INT2(statName, value);
    }

    /// <summary>
    /// 设置int类型stat值
    /// </summary>
    /// <param name="statName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private static async Task STAT_SET_INT1(string statName, int value)
    {
        var hash = GET_STAT_HASH(statName);

        var oldHash = Globals.Get_Global_Value<uint>(statSetIntHash);             // if (STATS::STAT_GET_INT(statHash,
        var oldValue = Globals.Get_Global_Value<int>(statSetIntValue);

        Globals.Set_Global_Value(statSetIntHash, hash);
        Globals.Set_Global_Value(statSetIntValue, value);
        Globals.Set_Global_Value(statSetIntMinusOne, -1);

        await Task.Delay(1000);

        Globals.Set_Global_Value(statSetIntHash, oldHash);
        Globals.Set_Global_Value(statSetIntValue, oldValue);
    }

    /// <summary>
    /// 设置int类型stat值（新方法）
    /// </summary>
    /// <param name="statName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private static async Task STAT_SET_INT2(string statName, int value)
    {
        var hash = GET_STAT_HASH(statName);

        var oldGetIntHash = Memory.Read<uint>(StatGetIntHash() + Globals.Get_Global_Value<int>(characterSlot) * 4);
        var oldGetIntValue = Globals.Get_Global_Value<int>(statGetIntValue);

        var oldSetIntHash = Globals.Get_Global_Value<uint>(statSetIntHash);
        var oldSetIntValue = Globals.Get_Global_Value<int>(statSetIntValue);

        Memory.Write(StatGetIntHash() + Globals.Get_Global_Value<int>(characterSlot), hash);

        Globals.Set_Global_Value(statSetIntHash, hash);
        Globals.Set_Global_Value(statSetIntValue, value);

        Globals.Set_Global_Value(statGetIntValue, value - 1);

        for (var i = 0; i < 10; i++)
        {
            if (Globals.Get_Global_Value<int>(statGetIntValue) == value)
                break;

            if (Globals.Get_Global_Value<int>(callStat) != 9)
                Globals.Set_Global_Value(callStat, 9);

            if (Globals.Get_Global_Value<int>(callStat + 3) != 3)
                Globals.Set_Global_Value(callStat + 3, 3);

            await Task.Delay(100);

            if (i > 5)
                Globals.Set_Global_Value(statGetIntValue, value);
        }

        Memory.Write(StatGetIntHash() + Globals.Get_Global_Value<int>(characterSlot), oldGetIntHash);
        Globals.Set_Global_Value(statGetIntValue, oldGetIntValue);

        Globals.Set_Global_Value(statSetIntHash, oldSetIntHash);
        Globals.Set_Global_Value(statSetIntValue, oldSetIntValue);
    }
}
