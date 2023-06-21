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

        Globals.WriteGA(Base.oVMCreate + 3, 0);                     // pegasus

        Globals.WriteGAString(Base.oVMCreate + 27 + 1, plate);      // License plate  车牌

        // 使用Mods
        UseVehicleMods(model, mods);

        Globals.WriteGA(Base.oVMCreate + 27 + 66, hash);            // 载具哈希值
        Globals.WriteGA(Base.oVMCreate + 27 + 77, -264240640);      // 载具状态

        Globals.WriteGA(Base.oVMCreate + 27 + 94, 2);               // 个人载具标志 Personal car ownerflag
        Globals.WriteGA(Base.oVMCreate + 27 + 95, 14);              // 拥有载具标志 Ownerflag

        Globals.WriteGA(Base.oVMCreate + 5, 1);                     // 开始生成载具1 can spawn flag must be odd
        Globals.WriteGA(Base.oVMCreate + 2, 1);                     // 开始生成载具2 spawn toggle gets reset to 0 on car spawn
    }

    /// <summary>
    /// 使用载具mod
    /// </summary>
    /// <param name="model"></param>
    /// <param name="mods"></param>
    private static void UseVehicleMods(string model, int[] mods)
    {
        // 这两辆载具使用mod会导致崩溃
        if (model == "issi8" || model == "entity3")
            return;

        VehicleMods1(mods);
    }

    /// <summary>
    /// 载具mod
    /// </summary>
    /// <param name="mods"></param>
    private static void VehicleMods1(int[] mods)
    {
        // 27 + 10 ~ 27 + 58
        for (int i = 0; i < 48; i++)
        {
            Globals.WriteGA(Base.oVMCreate + 27 + 10 + i, mods[i]);
        }

        Globals.WriteGA(Base.oVMCreate + 27 + 10 + 48, RandomMod(mods[48]));    // 随机涂装

        Globals.WriteGA(Base.oVMCreate + 27 + 5, -1);       // 主色调  primary -1 auto 159  
        Globals.WriteGA(Base.oVMCreate + 27 + 6, -1);       // 副色调  secondary -1 auto 159  
        Globals.WriteGA(Base.oVMCreate + 27 + 7, -1);       // 珠光色  pearlescent  

        Globals.WriteGA(Base.oVMCreate + 27 + 8, -1);       // 车轮颜色 wheel color  
        Globals.WriteGA(Base.oVMCreate + 27 + 33, -1);      // 车轮选择 wheel selection  
        Globals.WriteGA(Base.oVMCreate + 27 + 69, -1);      // 车轮类型 Wheel type  

        Globals.WriteGA(Base.oVMCreate + 27 + 24, -1);      // 喇叭
        Globals.WriteGA(Base.oVMCreate + 27 + 27, 1);       // Turbo (0-1)  涡轮增压
        Globals.WriteGA(Base.oVMCreate + 27 + 28, 1);       // weaponised ownerflag

        Globals.WriteGA(Base.oVMCreate + 27 + 30, -1);       // 烧胎烟雾
        Globals.WriteGA(Base.oVMCreate + 27 + 32, -1);       // 氙气车灯 (0-14)

        Globals.WriteGA(Base.oVMCreate + 27 + 62, RandomMod(255));      // 烧胎烟雾颜色  Tire smoke color R  
        Globals.WriteGA(Base.oVMCreate + 27 + 63, RandomMod(255));      // G
        Globals.WriteGA(Base.oVMCreate + 27 + 64, RandomMod(255));      // B
        Globals.WriteGA(Base.oVMCreate + 27 + 65, RandomMod(6));        // 窗户  Window tint 0-6  

        Globals.WriteGA(Base.oVMCreate + 27 + 74, RandomMod(255));      // 霓虹灯颜色  Red Neon Amount 1-255 100%-0%  
        Globals.WriteGA(Base.oVMCreate + 27 + 75, RandomMod(255));      // G
        Globals.WriteGA(Base.oVMCreate + 27 + 76, RandomMod(255));      // B
    }

    /// <summary>
    /// 载具mod
    /// </summary>
    /// <param name="mods"></param>
    private static void VehicleMods2(int[] mods)
    {
        Globals.WriteGA(Base.oVMCreate + 27 + 5, -1);                       // 主色调  primary     -1 auto 159
        Globals.WriteGA(Base.oVMCreate + 27 + 6, -1);                       // 副色调  secondary   -1 auto 159
        Globals.WriteGA(Base.oVMCreate + 27 + 7, -1);                       // 珠光色  pearlescent   
        Globals.WriteGA(Base.oVMCreate + 27 + 8, -1);                       // 车轮颜色 wheel color  

        Globals.WriteGA(Base.oVMCreate + 27 + 10, mods[0]);                 // 尾翼
        Globals.WriteGA(Base.oVMCreate + 27 + 11, mods[1]);                 // 前保险杠
        Globals.WriteGA(Base.oVMCreate + 27 + 12, mods[2]);                 // 后保险杠
        Globals.WriteGA(Base.oVMCreate + 27 + 13, mods[3]);                 // 侧裙
        Globals.WriteGA(Base.oVMCreate + 27 + 14, mods[4]);                 // 排气管
        Globals.WriteGA(Base.oVMCreate + 27 + 15, mods[5]);                 // 载具主武器
        Globals.WriteGA(Base.oVMCreate + 27 + 16, mods[6]);                 // 中网
        Globals.WriteGA(Base.oVMCreate + 27 + 17, mods[7]);                 // 引擎盖
        Globals.WriteGA(Base.oVMCreate + 27 + 18, mods[8]);                 // 前翼子板
        Globals.WriteGA(Base.oVMCreate + 27 + 19, mods[9]);                 // 后翼子板
        Globals.WriteGA(Base.oVMCreate + 27 + 20, mods[10]);                // 载具副武器
        Globals.WriteGA(Base.oVMCreate + 27 + 21, mods[11]);                // 引擎
        Globals.WriteGA(Base.oVMCreate + 27 + 22, mods[12]);                // 刹车
        Globals.WriteGA(Base.oVMCreate + 27 + 23, mods[13]);                // 变速箱
        Globals.WriteGA(Base.oVMCreate + 27 + 24, RandomMod(mods[14]));     // 喇叭
        Globals.WriteGA(Base.oVMCreate + 27 + 25, mods[15]);                // 悬挂系统
        Globals.WriteGA(Base.oVMCreate + 27 + 26, mods[16]);                // 防御
        Globals.WriteGA(Base.oVMCreate + 27 + 27, mods[17]);                // 涡轮增压
        Globals.WriteGA(Base.oVMCreate + 27 + 28, mods[18]);                // 武器化标志
        Globals.WriteGA(Base.oVMCreate + 27 + 29, mods[19]);                // ???
        Globals.WriteGA(Base.oVMCreate + 27 + 30, mods[20]);                // ???  烧胎烟雾
        Globals.WriteGA(Base.oVMCreate + 27 + 31, mods[21]);                // ???
        Globals.WriteGA(Base.oVMCreate + 27 + 32, RandomMod(mods[22]));     // 大灯颜色 氙气车灯 (0-14)
        Globals.WriteGA(Base.oVMCreate + 27 + 33, mods[23]);                // 前轮   车轮选择
        Globals.WriteGA(Base.oVMCreate + 27 + 34, mods[24]);                // 后轮
        Globals.WriteGA(Base.oVMCreate + 27 + 35, mods[25]);                // 车牌架 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 36, mods[26]);                // 个性车牌 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 37, mods[27]);                // 内饰设计 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 38, mods[28]);                // 装饰品 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 39, mods[29]);                // 仪表盘 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 40, mods[30]);                // 仪表盘设计 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 41, mods[31]);                // 车门音响 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 42, mods[32]);                // 座椅 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 43, mods[33]);                // 方向盘 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 44, mods[34]);                // 排档头 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 45, mods[35]);                // 装饰牌 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 46, mods[36]);                // 音响 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 47, mods[37]);                // 后备箱 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 48, mods[38]);                // 液压系统 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 49, mods[39]);                // 气缸体 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 50, mods[40]);                // 空气滤清器 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 51, mods[41]);                // 平衡杠 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 52, mods[42]);                // 正时皮带罩 [本尼]
        Globals.WriteGA(Base.oVMCreate + 27 + 53, mods[43]);                // 天线
        Globals.WriteGA(Base.oVMCreate + 27 + 54, mods[44]);                // 内饰
        Globals.WriteGA(Base.oVMCreate + 27 + 55, mods[45]);                // 油箱
        Globals.WriteGA(Base.oVMCreate + 27 + 56, mods[46]);                // 车窗
        Globals.WriteGA(Base.oVMCreate + 27 + 57, mods[47]);                // 门
        Globals.WriteGA(Base.oVMCreate + 27 + 58, RandomMod(mods[48]));     // 涂装

        Globals.WriteGA(Base.oVMCreate + 27 + 62, RandomMod(255));          // Tire smoke color R  烧胎烟雾颜色
        Globals.WriteGA(Base.oVMCreate + 27 + 63, RandomMod(255));          // G
        Globals.WriteGA(Base.oVMCreate + 27 + 64, RandomMod(255));          // B
        Globals.WriteGA(Base.oVMCreate + 27 + 65, RandomMod(6));            // Window tint 0-6  窗户

        Globals.WriteGA(Base.oVMCreate + 27 + 69, -1);                      // Wheel type  车轮类型 -> 运动跑车[0] - 肌肉车[1] - 低底盘车[2] - SUV[3] - 越野车[4] - 改装车[5] - 高档车[7] - 本尼原创[8] - 本尼订制[9] - F1[10] - 街头[11] - 赛道[12]

        Globals.WriteGA(Base.oVMCreate + 27 + 74, RandomMod(255));          // Red Neon Amount 1-255 100%-0%  红霓虹灯数量
        Globals.WriteGA(Base.oVMCreate + 27 + 75, RandomMod(255));          // G
        Globals.WriteGA(Base.oVMCreate + 27 + 76, RandomMod(255));          // B
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
