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

            long pCNavigation = Memory.Read<long>(pCPed + CPed.CNavigation.__Offset__);

            float sin = Memory.Read<float>(pCNavigation + CPed.CNavigation.RightX);
            float cos = Memory.Read<float>(pCNavigation + CPed.CNavigation.ForwardX);

            vector3.X += cos * dist;
            vector3.Y += sin * dist;

            vector3.Z = -255.0f;
            SpawnVehicle(vector3, model, mods);

            await Task.Delay(10);

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
        Globals.WriteGA(Base.oVMCreate + 7 + 0, vector3.X);        // 载具坐标x
        Globals.WriteGA(Base.oVMCreate + 7 + 1, vector3.Y);        // 载具坐标y
        Globals.WriteGA(Base.oVMCreate + 7 + 2, vector3.Z);        // 载具坐标z

        Globals.WriteGA(Base.oVMCreate + 27 + 66, Globals.Joaat(model));     // 载具哈希值

        Globals.WriteGA(Base.oVMCreate + 3, 0);            // pegasus
        Globals.WriteGA(Base.oVMCreate + 5, 1);            // can spawn flag must be odd
        Globals.WriteGA(Base.oVMCreate + 2, 1);            // spawn toggle gets reset to 0 on car spawn

        Globals.WriteGAString(Base.oVMCreate + 27 + 1, Guid.NewGuid().ToString()[..8]);    // License plate  车牌

        // 使用Mods
        VehicleUseMods(model, mods);



        Globals.WriteGA(Base.oVMCreate + 27 + 8, -1);      // wheel color  车轮颜色
        Globals.WriteGA(Base.oVMCreate + 27 + 69, -1);     // Wheel type  车轮类型
        Globals.WriteGA(Base.oVMCreate + 27 + 33, -1);     // wheel selection  车轮选择

        Globals.WriteGA(Base.oVMCreate + 27 + 24, new Random().Next(0, mods[14] + 1));      // 喇叭
        Globals.WriteGA(Base.oVMCreate + 27 + 27, 1);      // Turbo (0-1)  涡轮增压
        Globals.WriteGA(Base.oVMCreate + 27 + 28, 1);      // weaponised ownerflag

        Globals.WriteGA(Base.oVMCreate + 27 + 30, 1);      // 烧胎烟雾
        Globals.WriteGA(Base.oVMCreate + 27 + 32, 1);      // 氙气车灯 (0-14)

        Globals.WriteGA(Base.oVMCreate + 27 + 60, 1);      // landinggear/vehstate  起落架/载具状态
        Globals.WriteGA(Base.oVMCreate + 27 + 62, new Random().Next(0, 256));      // Tire smoke color R  烧胎烟雾颜色
        Globals.WriteGA(Base.oVMCreate + 27 + 63, new Random().Next(0, 256));      // G
        Globals.WriteGA(Base.oVMCreate + 27 + 64, new Random().Next(0, 256));      // B
        Globals.WriteGA(Base.oVMCreate + 27 + 65, new Random().Next(0, 7));        // Window tint 0-6  窗户

        Globals.WriteGA(Base.oVMCreate + 27 + 74, new Random().Next(0, 256));      // Red Neon Amount 1-255 100%-0%  红霓虹灯数量
        Globals.WriteGA(Base.oVMCreate + 27 + 75, new Random().Next(0, 256));      // G
        Globals.WriteGA(Base.oVMCreate + 27 + 76, new Random().Next(0, 256));      // B

        Globals.WriteGA(Base.oVMCreate + 27 + 77, 0xF0400200);   // vehstate 4030726305  载具状态 没有这个载具起落架是收起状态

        Globals.WriteGA(Base.oVMCreate + 27 + 95, 14);     // Ownerflag  拥有者标志
        Globals.WriteGA(Base.oVMCreate + 27 + 94, 2);      // Personal car ownerflag  个人载具拥有者标志
    }

    /// <summary>
    /// 载具使用mod
    /// </summary>
    /// <param name="model"></param>
    /// <param name="mods"></param>
    private static void VehicleUseMods(string model, int[] mods)
    {
        // 这两辆载具使用mod会导致崩溃
        if (model == "issi8" || model == "entity3")
            return;

        Globals.WriteGA(Base.oVMCreate + 27 + 5, -1);      // primary       主色调     -1 auto 159
        Globals.WriteGA(Base.oVMCreate + 27 + 6, -1);      // secondary     副色调     -1 auto 159
        Globals.WriteGA(Base.oVMCreate + 27 + 7, -1);      // pearlescent   珠光色

        // 最大化升级载具
        for (int i = 0; i < 48; i++)
        {
            if (i < 17)
            {
                Globals.WriteGA(Base.oVMCreate + 27 + 10 + i, mods[i]);
            }
            else if (i > 22)
            {
                Globals.WriteGA(Base.oVMCreate + 27 + 10 + 6 + i, mods[i]);
            }
        }

        // 随机涂装
        if (mods[48] > 0)
            Globals.WriteGA(Base.oVMCreate + 27 + 10 + 48, new Random().Next(0, mods[48] + 1));
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
