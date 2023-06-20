using GTA5Core.Native;
using GTA5Core.Offsets;
using GTA5Core.GTA.Rage;

namespace GTA5Core.Features;

public static class World
{
    /// <summary>
    /// 设置本地天气
    /// 
    /// -1, Default
    ///  0, Extra Sunny
    ///  1, Clear
    ///  2, Clouds
    ///  3, Smog
    ///  4, Foggy
    ///  5, Overcast
    ///  6, Rain
    ///  7, Thunder
    ///  8, Light Rain
    ///  9, Smoggy Light Rain
    /// 10, Very Light Snow
    /// 11, Windy Snow
    /// 12, Light Snow
    /// 14, Halloween
    /// </summary>
    /// <param name="weatherId">天气Id</param>
    public static void SetLocalWeather(int weatherId)
    {
        if (weatherId == -1)
        {
            Memory.Write(Pointers.WeatherPTR + 0x24, -1);
            Memory.Write(Pointers.WeatherPTR + 0x104, 13);
        }
        if (weatherId == 13)
        {
            Memory.Write(Pointers.WeatherPTR + 0x24, 13);
            Memory.Write(Pointers.WeatherPTR + 0x104, 13);
        }

        Memory.Write(Pointers.WeatherPTR + 0x104, weatherId);
    }

    /// <summary>
    /// 杀死全部NPC（仅敌对？）
    /// </summary>
    public static void KillAllNPC(bool isOnlyKillHostility)
    {
        long pCPedList = Game.GetCPedList();

        for (int i = 0; i < Base.oMaxPeds; i++)
        {
            long pCPed = Memory.Read<long>(pCPedList + i * 0x10);
            if (!Memory.IsValid(pCPed))
                continue;

            // 跳过玩家
            long pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo.__Offset__);
            if (Memory.IsValid(pCPlayerInfo))
                continue;

            if (isOnlyKillHostility)
            {
                byte oHostility = Memory.Read<byte>(pCPed + CPed.Hostility);
                if (oHostility > 0x01)
                {
                    Memory.Write(pCPed + CPed.Health, 0.0f);
                }
            }
            else
            {
                Memory.Write(pCPed + CPed.Health, 0.0f);
            }
        }
    }

    /// <summary>
    /// 杀死全部警察
    /// </summary>
    public static void KillAllPolice()
    {
        long pCPedList = Game.GetCPedList();

        for (int i = 0; i < Base.oMaxPeds; i++)
        {
            long pCPed = Memory.Read<long>(pCPedList + i * 0x10);
            if (!Memory.IsValid(pCPed))
                continue;

            // 跳过玩家
            long pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo.__Offset__);
            if (Memory.IsValid(pCPlayerInfo))
                continue;

            int ped_type = Memory.Read<int>(pCPed + CPed.Ragdoll);
            ped_type = ped_type << 11 >> 25;

            if (ped_type == (int)PedType.COP ||
                ped_type == (int)PedType.SWAT ||
                ped_type == (int)PedType.ARMY)
            {
                Memory.Write(pCPed + CPed.Health, 0.0f);
            }
        }
    }

    /// <summary>
    /// 摧毁全部NPC载具（仅敌对？）
    /// </summary>
    public static void DestroyAllNPCVehicles(bool isOnlyKillHostility)
    {
        long pCPedList = Game.GetCPedList();

        for (int i = 0; i < Base.oMaxPeds; i++)
        {
            long pCPed = Memory.Read<long>(pCPedList + i * 0x10);
            if (!Memory.IsValid(pCPed))
                continue;

            // 跳过玩家
            long pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo.__Offset__);
            if (Memory.IsValid(pCPlayerInfo))
                continue;

            long pCVehicle = Memory.Read<long>(pCPed + CPed.CVehicle.__Offset__);
            if (!Memory.IsValid(pCVehicle))
                continue;

            if (isOnlyKillHostility)
            {
                byte oHostility = Memory.Read<byte>(pCPed + CPed.Hostility);
                if (oHostility > 0x01)
                {
                    Memory.Write(pCVehicle + CPed.CVehicle.Health, -1.0f);
                    Memory.Write(pCVehicle + CPed.CVehicle.HealthBody, -1.0f);
                    Memory.Write(pCVehicle + CPed.CVehicle.HealthPetrolTank, -1.0f);
                    Memory.Write(pCVehicle + CPed.CVehicle.HealthEngine, -1.0f);
                }
            }
            else
            {
                Memory.Write(pCVehicle + CPed.CVehicle.Health, -1.0f);
                Memory.Write(pCVehicle + CPed.CVehicle.HealthBody, -1.0f);
                Memory.Write(pCVehicle + CPed.CVehicle.HealthPetrolTank, -1.0f);
                Memory.Write(pCVehicle + CPed.CVehicle.HealthEngine, -1.0f);
            }
        }
    }

    /// <summary>
    /// 摧毁全部载具（玩家自己的载具也会摧毁）
    /// </summary>
    public static void DestroyAllVehicles()
    {
        long pCVehicleList = Game.GetCVehicleList();

        for (int i = 0; i < Base.oMaxPeds; i++)
        {
            long pCVehicle = Memory.Read<long>(pCVehicleList + i * 0x10);
            if (!Memory.IsValid(pCVehicle))
                continue;

            Memory.Write(pCVehicle + CPed.CVehicle.Health, -1.0f);
            Memory.Write(pCVehicle + CPed.CVehicle.HealthBody, -1.0f);
            Memory.Write(pCVehicle + CPed.CVehicle.HealthPetrolTank, -1.0f);
            Memory.Write(pCVehicle + CPed.CVehicle.HealthEngine, -1.0f);
        }
    }

    /// <summary>
    /// 传送全部NPC到我这里，仅敌对？
    /// </summary>
    public static void TeleportAllNPCToMe(bool isOnlyHostility)
    {
        Vector3 v3MyPos = Teleport.GetPlayerPosition();

        long pCPedList = Game.GetCPedList();

        for (int i = 0; i < Base.oMaxPeds; i++)
        {
            long pCPed = Memory.Read<long>(pCPedList + i * 0x10);
            if (!Memory.IsValid(pCPed))
                continue;

            // 跳过玩家
            long pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo.__Offset__);
            if (Memory.IsValid(pCPlayerInfo))
                continue;

            long pCNavigation = Memory.Read<long>(pCPed + CPed.CNavigation.__Offset__);
            if (!Memory.IsValid(pCNavigation))
                continue;

            if (isOnlyHostility)
            {
                byte oHostility = Memory.Read<byte>(pCPed + CPed.Hostility);
                if (oHostility > 0x01)
                {
                    Memory.Write(pCPed + CPed.CVehicle.VisualX, v3MyPos);
                    Memory.Write(pCNavigation + CPed.CVehicle.CNavigation.PositionX, v3MyPos);
                }
            }
            else
            {
                Memory.Write(pCPed + CPed.CVehicle.VisualX, v3MyPos);
                Memory.Write(pCNavigation + CPed.CVehicle.CNavigation.PositionX, v3MyPos);
            }
        }
    }
}
