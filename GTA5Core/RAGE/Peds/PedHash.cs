namespace GTA5Core.RAGE.Peds;

public static class PedHash
{
    public class PedInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    /// <summary>
    /// Ped模型列表
    /// </summary>
    public static readonly List<PedInfo> PedHashClass = new()
    {
        new PedInfo(){ Name="默认线上角色", Value="MP_M_Freemode_01" },

        new PedInfo(){ Name="[动物] 喵咪", Value="A_C_Cat_01" },
        new PedInfo(){ Name="[动物] 草原狼", Value="A_C_Coyote" },
        new PedInfo(){ Name="[动物] 鸡", Value="A_C_Hen" },
        new PedInfo(){ Name="[动物] 哈士奇", Value="A_C_Husky" },
        new PedInfo(){ Name="[动物] 兔子", Value="A_C_Rabbit_01" },
        new PedInfo(){ Name="[动物] 小查", Value="A_C_Chop" },
        new PedInfo(){ Name="[动物] 牧羊犬", Value="A_C_Shepherd" },
        new PedInfo(){ Name="[动物] 老鼠", Value="A_C_Rat" },
        new PedInfo(){ Name="[动物] 鸽子", Value="A_C_Pigeon" },
        new PedInfo(){ Name="[动物] 狮子", Value="A_C_Mtlion" },
        new PedInfo(){ Name="[动物] 老鹰", Value="A_C_Chickenhawk" },
        new PedInfo(){ Name="[动物] 黑猩猩", Value="A_C_Chimp" },
        new PedInfo(){ Name="[动物] 奶牛", Value="A_C_Cow" },
        new PedInfo(){ Name="[动物] 鹿", Value="A_C_Deer" },

        new PedInfo(){ Name="14号探员", Value="CSB_MP_Agent14" },
        new PedInfo(){ Name="莱斯特", Value="CS_LesterCrest" },
        new PedInfo(){ Name="莱斯特2", Value="CS_LesterCrest_2" },
        new PedInfo(){ Name="贝克女士", Value="CSB_Agatha" },
        new PedInfo(){ Name="越狱光头", Value="CSB_Rashcosvki" },
        new PedInfo(){ Name="马丁", Value="CS_MartinMadrazo" },
        new PedInfo(){ Name="米米", Value="CSB_Mimi" },
        new PedInfo(){ Name="吉米", Value="IG_JimmyDiSanto" },
        new PedInfo(){ Name="吉米2", Value="IG_JimmyDiSanto2" },
        new PedInfo(){ Name="西门", Value="IG_SiemonYetarian" },
    };
}
