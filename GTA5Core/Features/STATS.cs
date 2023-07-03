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

        return Joaat(statName);
    }

    /// <summary>
    /// 字符串转Hash值
    /// </summary>
    /// <param name="statName"></param>
    /// <returns></returns>
    public static uint Joaat(string statName)
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

        var oldHash = Globals.ReadGA<uint>(statSetIntHash);             // if (STATS::STAT_GET_INT(statHash,
        var oldValue = Globals.ReadGA<int>(statSetIntValue);

        Globals.WriteGA(statSetIntHash, hash);
        Globals.WriteGA(statSetIntValue, value);
        Globals.WriteGA(statSetIntMinusOne, -1);

        await Task.Delay(1000);

        Globals.WriteGA(statSetIntHash, oldHash);
        Globals.WriteGA(statSetIntValue, oldValue);
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

        var oldGetIntHash = Memory.Read<uint>(StatGetIntHash() + Globals.ReadGA<int>(characterSlot) * 4);
        var oldGetIntValue = Globals.ReadGA<int>(statGetIntValue);

        var oldSetIntHash = Globals.ReadGA<uint>(statSetIntHash);
        var oldSetIntValue = Globals.ReadGA<int>(statSetIntValue);

        Memory.Write(StatGetIntHash() + Globals.ReadGA<int>(characterSlot), hash);

        Globals.WriteGA(statSetIntHash, hash);
        Globals.WriteGA(statSetIntValue, value);

        Globals.WriteGA(statGetIntValue, value - 1);

        for (var i = 0; i < 10; i++)
        {
            if (Globals.ReadGA<int>(statGetIntValue) == value)
                break;

            if (Globals.ReadGA<int>(callStat) != 9)
                Globals.WriteGA(callStat, 9);

            if (Globals.ReadGA<int>(callStat + 3) != 3)
                Globals.WriteGA(callStat + 3, 3);

            await Task.Delay(100);

            if (i > 5)
                Globals.WriteGA(statGetIntValue, value);
        }

        Memory.Write(StatGetIntHash() + Globals.ReadGA<int>(characterSlot), oldGetIntHash);
        Globals.WriteGA(statGetIntValue, oldGetIntValue);

        Globals.WriteGA(statSetIntHash, oldSetIntHash);
        Globals.WriteGA(statSetIntValue, oldSetIntValue);
    }
}
