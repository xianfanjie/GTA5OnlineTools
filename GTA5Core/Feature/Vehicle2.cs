using GTA5Core.Data;
using GTA5Core.Client;
using GTA5Core.Native;

namespace GTA5Core.Feature;

public static class Vehicle2
{
    /// <summary>
    /// 刷出线上载具
    /// </summary>
    /// <param name="model">载具名称</param>
    /// <param name="z255">高度</param>
    /// <param name="dist">距离</param>
    /// <param name="pegasus">帕格萨斯</param>
    /// <param name="mod">载具改装mod</param>
    public static void SpawnVehicle(string model, float z255, int dist, int pegasus, VehicleMod mod)
    {
        if (string.IsNullOrEmpty(model))
            return;

        Task.Run(() =>
        {
            long pCPed = Globals.GetCPed();
            Vector3 vector3 = Memory.Read<Vector3>(pCPed + Offsets.CPed_VisualX);

            long pCNavigation = Memory.Read<long>(pCPed + Offsets.CPed_CNavigation);

            float sin = Memory.Read<float>(pCNavigation + Offsets.CPed_CNavigation_RightX);
            float cos = Memory.Read<float>(pCNavigation + Offsets.CPed_CNavigation_ForwardX);

            vector3.X += cos * dist;
            vector3.Y += sin * dist;

            if (z255 == -255.0f)
                vector3.Z = z255;
            else
                vector3.Z += z255;

            Hacks.WriteGA(Offsets.oVMCreate + 7 + 0, vector3.X);                // 载具坐标x
            Hacks.WriteGA(Offsets.oVMCreate + 7 + 1, vector3.Y);                // 载具坐标y
            Hacks.WriteGA(Offsets.oVMCreate + 7 + 2, vector3.Z);                // 载具坐标z

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 66, Hacks.Joaat(model));     // 载具哈希值

            Hacks.WriteGA(Offsets.oVMCreate + 3, pegasus);
            Hacks.WriteGA(Offsets.oVMCreate + 5, 1);                            // can spawn flag must be odd
            Hacks.WriteGA(Offsets.oVMCreate + 2, 1);                            // spawn toggle gets reset to 0 on car spawn

            var plate = Guid.NewGuid().ToString()[..8];
            if (string.IsNullOrEmpty(mod.Plate))
                Hacks.WriteGAString(Offsets.oVMCreate + 27 + 1, plate);         // License plate  车牌
            else
                Hacks.WriteGAString(Offsets.oVMCreate + 27 + 1, mod.Plate);

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 5, mod.Primary);             // primary -1 auto 159  主色调
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 6, mod.Secondary);           // secondary -1 auto 159  副色调
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 7, mod.Pearlescent);         // pearlescent
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 8, mod.WheelColor);          // wheel color

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 15, mod.Weapon);             // primary weapon
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 19, -1);

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 20, mod.Weapon2);            // secondary weaponget_teleKEYSpeed
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 21, mod.Engine);             // engine (0-3)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 22, mod.Brakes);             // brakes (0-6)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 23, mod.Transmission);       // transmission (0-9)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 24, mod.Horn);               // horn (0-77)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 25, mod.Suspension);         // suspension (0-13)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 26, mod.Armor);              // armor (0-18)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 27, mod.Turbo);              // turbo (0-1)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 28, 1);                      // weaponised ownerflag

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 32, mod.ColoredLight);       // colored light (0-14)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 33, mod.WheelType);          // wheel selection

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 60, 1);
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 62, mod.TireSmokeR);         // Tire smoke color R
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 63, mod.TireSmokeG);         // G
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 64, mod.TireSmokeB);         // B
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 65, mod.WindowTint);         // Window tint 0-6
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 67, mod.Livery);             // Livery
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 69, mod.WheelType);          // Wheel type

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 74, mod.NeonR);              // Neon R 0-255
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 75, mod.NeonG);              // G
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 76, mod.NeonB);              // B
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 77, 4030726305);             // vehstate

            Memory.Write(Hacks.GlobalAddress(Offsets.oVMCreate + 27 + 77), mod.BulletProof);    // 2:bulletproof 0:false

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 95, 14);                     // ownerflag  拥有者标志
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 94, 2);                      // personal car ownerflag  个人载具拥有者标志
        });
    }

    /// <summary>
    /// 刷出线上载具
    /// </summary>
    /// <param name="model"></param>
    /// <param name="z255"></param>
    /// <param name="dist"></param>
    /// <param name="pegasus"></param>
    public static void SpawnVehicle(string model, float z255, int dist, int pegasus)
    {
        if (string.IsNullOrEmpty(model))
            return;

        Task.Run(() =>
        {
            long pCPed = Globals.GetCPed();
            Vector3 vector3 = Memory.Read<Vector3>(pCPed + Offsets.CPed_VisualX);

            long pCNavigation = Memory.Read<long>(pCPed + Offsets.CPed_CNavigation);

            float sin = Memory.Read<float>(pCNavigation + Offsets.CPed_CNavigation_RightX);
            float cos = Memory.Read<float>(pCNavigation + Offsets.CPed_CNavigation_ForwardX);

            vector3.X += cos * dist;
            vector3.Y += sin * dist;

            if (z255 == -255.0f)
                vector3.Z = z255;
            else
                vector3.Z += z255;

            Hacks.WriteGA(Offsets.oVMCreate + 7 + 0, vector3.X);                // 载具坐标x
            Hacks.WriteGA(Offsets.oVMCreate + 7 + 1, vector3.Y);                // 载具坐标y
            Hacks.WriteGA(Offsets.oVMCreate + 7 + 2, vector3.Z);                // 载具坐标z

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 66, Hacks.Joaat(model));     // 载具哈希值

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 28, 1);                      // Weaponised ownerflag
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 60, 1);

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 95, 14);                     // Ownerflag  拥有者标志
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 94, 2);                      // Personal car ownerflag  个人载具拥有者标志

            Hacks.WriteGA(Offsets.oVMCreate + 5, 1);                            // SET('i',CarSpawn+0x1168, 1)  --can spawn flag must be odd
            Hacks.WriteGA(Offsets.oVMCreate + 2, 1);                            // SET('i',CarSpawn+0x1180, 1) --spawn toggle gets reset to 0 on car spawn
            Hacks.WriteGA(Offsets.oVMCreate + 3, pegasus);

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 74, 1);                      // Red Neon Amount 1-255 100%-0%
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 75, 1);                      // G
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 76, 0);                      // B
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 60, 4030726305);             // landinggear/vehstate

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 5, -1);                      // primary -1 auto 159  主色调
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 6, -1);                      // secondary -1 auto 159  副色调
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 7, -1);                      // pearlescent
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 8, -1);                      // wheel color

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 19, 4);
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 21, 4);                      // Engine (0-3)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 22, 3);                      // Brakes (0-6)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 23, 3);                      // Transmission (0-9)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 24, 58);                     // Horn (0-77)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 26, 5);                      // Armor (0-18)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 27, 1);                      // Turbo (0-1)

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 65, 2);                      // Window tint 0-6
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 69, -1);                     // Wheel type

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 33, -1);                     // wheel selection
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 25, 8);                      // Suspension (0-13)
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 19, -1);

            Memory.Write(Hacks.GlobalAddress(Offsets.oVMCreate + 27 + 77) + 1, 2);    // 2:bulletproof 0:false

            var weapon = 2;
            var weapon2 = 1;

            if (model == "oppressor2")
                weapon = 2;
            else if (model == "apc" || model == "deluxo")
                weapon = -1;
            else if (model == "bombushka")
                weapon = 1;
            else if (model == "tampa3" || model == "insurgent3" || model == "halftrack")
                weapon = 3;
            else if (model == "barrage")
                weapon = 30;

            Hacks.WriteGA(Offsets.oVMCreate + 27 + 15, weapon);                 // primary weapon
            Hacks.WriteGA(Offsets.oVMCreate + 27 + 20, weapon2);                // secondary weapon

            var plate = Guid.NewGuid().ToString()[..8];
            Hacks.WriteGAString(Offsets.oVMCreate + 27 + 1, plate);             // License plate  车牌
        });
    }

    /// <summary>
    /// 查找载具显示名称
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="isDisplay"></param>
    /// <returns></returns>
    public static string FindVehicleDisplayName(long hash, bool isDisplay)
    {
        foreach (var item in VehicleData.VehicleClassData)
        {
            foreach (var item0 in item.VehicleInfo)
            {
                if (item0.Hash == hash)
                {
                    if (isDisplay)
                        return item0.Display;
                    else
                        return item0.Name;
                }
            }
        }

        return string.Empty;
    }
}
