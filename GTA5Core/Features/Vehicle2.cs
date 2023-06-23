using GTA5Core.Native;
using GTA5Core.Offsets;
using GTA5Core.GTA.Vehicles;

namespace GTA5Core.Features;

public static class Vehicle2
{
    /// <summary>
    /// 刷出线上载具
    /// </summary>
    /// <param name="model"></param>
    /// <param name="mods"></param>
    /// <returns></returns>
    public static async Task SpawnVehicle(string model, int[] mods)
    {
        await Task.Run(async () =>
        {
            var dist = 5;

            if (string.IsNullOrEmpty(model))
                return;

            long pCPed = Game.GetCPed();
            Vector3 vector3 = Memory.Read<Vector3>(pCPed + CPed.VisualX);
            float temp_z = vector3.Z;

            long pCNavigation = Memory.Read<long>(pCPed + CPed.CNavigation);

            float sin = Memory.Read<float>(pCNavigation + CNavigation.RightX);
            float cos = Memory.Read<float>(pCNavigation + CNavigation.ForwardX);

            vector3.X += cos * dist;
            vector3.Y += sin * dist;

            vector3.Z = -255.0f;
            SpawnVehicle(vector3, model, mods);

            await Task.Delay(100);

            vector3.Z = temp_z;
            SpawnVehicle(vector3, model, mods);
        });
    }

    /// <summary>
    /// 刷出线上载具
    /// </summary>
    /// <param name="vector3"></param>
    /// <param name="model"></param>
    /// <param name="mods"></param>
    private static void SpawnVehicle(Vector3 vector3, string model, int[] mods)
    {
        var plate = Guid.NewGuid().ToString()[..8];
        var hash = Globals.Joaat(model);

        Globals.WriteGA(Base.oVMCreate + 7 + 0, vector3.X);         // 载具坐标x
        Globals.WriteGA(Base.oVMCreate + 7 + 1, vector3.Y);         // 载具坐标y
        Globals.WriteGA(Base.oVMCreate + 7 + 2, vector3.Z);         // 载具坐标z

        Globals.WriteGA(Base.oVMCreate + 27 + 66, hash);            // 载具哈希值

        Globals.WriteGA(Base.oVMCreate + 3, 0);                     // pegasus
        Globals.WriteGA(Base.oVMCreate + 5, 1);                     // 开始生成载具1 can spawn flag must be odd
        Globals.WriteGA(Base.oVMCreate + 2, 1);                     // 开始生成载具2 spawn toggle gets reset to 0 on car spawn

        Globals.WriteGAString(Base.oVMCreate + 27 + 1, plate);      // License plate  车牌

        // 使用Mods
        UseVehicleMods(model, mods);

        Globals.WriteGA(Base.oVMCreate + 27 + 77, 0xF0400200);      // 载具状态

        Globals.WriteGA(Base.oVMCreate + 27 + 95, 14);              // 拥有载具标志 Ownerflag
        Globals.WriteGA(Base.oVMCreate + 27 + 94, 2);               // 个人载具标志 Personal car ownerflag
    }

    /// <summary>
    /// 使用载具mod
    /// </summary>
    /// <param name="model"></param>
    /// <param name="mods"></param>
    private static void UseVehicleMods(string model, int[] mods)
    {
        // 值设置-1代表载具默认配置

        Globals.WriteGA(Base.oVMCreate + 27 + 5, -1);       // 主色调  primary -1 auto 159  
        Globals.WriteGA(Base.oVMCreate + 27 + 6, -1);       // 副色调  secondary -1 auto 159  
        Globals.WriteGA(Base.oVMCreate + 27 + 7, -1);       // 珠光色  pearlescent  

        // 27 + 10 ~ 27 + 58
        for (int i = 0; i < 48; i++)
        {
            // 27 + 27  (17)  涡轮增压
            // 27 + 28  (18)  武器化标志
            // 27 + 29  (19)  ???
            // 27 + 30  (20)  ???
            // 27 + 31  (21)  ???
            // 27 + 32  (22)  大灯颜色

            // 过滤会崩溃的载具mod
            if (model == "banshee" ||
                model == "sentinel" ||
                model == "turismo2" ||
                model == "deveste" ||
                model == "hakuchou2" ||
                model == "entity3" ||
                model == "issi8" ||
                model == "brioso")
                return;

            Globals.WriteGA(Base.oVMCreate + 27 + 10 + i, mods[i]);
        }

        Globals.WriteGA(Base.oVMCreate + 27 + 58, RandomMod(mods[48]));    // 随机涂装

        Globals.WriteGA(Base.oVMCreate + 27 + 8, -1);       // 车轮颜色 wheel color  
        Globals.WriteGA(Base.oVMCreate + 27 + 69, -1);      // 车轮类型 Wheel type  
        Globals.WriteGA(Base.oVMCreate + 27 + 33, -1);      // 车轮选择 wheel selection  

        //Globals.WriteGA(Base.oVMCreate + 27 + 15, mods[5]);         // 主武器 primary weapon
        //Globals.WriteGA(Base.oVMCreate + 27 + 30, mods[20]);        // 副武器 secondary weapon

        Globals.WriteGA(Base.oVMCreate + 27 + 24, -1);      // 喇叭

        Globals.WriteGA(Base.oVMCreate + 27 + 27, 1);       // Turbo (0-1)  涡轮增压
        Globals.WriteGA(Base.oVMCreate + 27 + 28, 1);       // weaponised ownerflag

        Globals.WriteGA(Base.oVMCreate + 27 + 30, -1);      // 烧胎烟雾
        Globals.WriteGA(Base.oVMCreate + 27 + 32, -1);      // 氙气车灯 (0-14)

        Globals.WriteGA(Base.oVMCreate + 27 + 60, 1);       // landinggear/vehstate  起落架/载具状态
        Globals.WriteGA(Base.oVMCreate + 27 + 62, RandomMod(255));      // 烧胎烟雾颜色  Tire smoke color R  
        Globals.WriteGA(Base.oVMCreate + 27 + 63, RandomMod(255));      // G
        Globals.WriteGA(Base.oVMCreate + 27 + 64, RandomMod(255));      // B
        Globals.WriteGA(Base.oVMCreate + 27 + 65, RandomMod(6));        // 窗户  Window tint 0-6  

        Globals.WriteGA(Base.oVMCreate + 27 + 74, RandomMod(255));      // 霓虹灯颜色  Red Neon Amount 1-255 100%-0%  
        Globals.WriteGA(Base.oVMCreate + 27 + 75, RandomMod(255));      // G
        Globals.WriteGA(Base.oVMCreate + 27 + 76, RandomMod(255));      // B
    }

    /// <summary>
    /// 获取随机值
    /// </summary>
    /// <param name="mod"></param>
    /// <returns></returns>
    private static int RandomMod(int mod)
    {
        return mod > 0 ? new Random().Next(0, mod + 1) : mod;
    }

    /// <summary>
    /// 通过Hash值查找载具信息
    /// </summary>
    /// <param name="hash"></param>
    /// <returns></returns>
    public static VehicleInfo FindVehicleNameByHash(long hash)
    {
        var result = VehicleHash.AllVehicles.Find(v => v.Hash == hash);
        if (result != null)
            return result;

        return null;
    }
}
