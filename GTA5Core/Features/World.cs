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
        var pCPedList = Game.GetCPedList();

        for (var i = 0; i < Base.oMaxPeds; i++)
        {
            var pCPed = Memory.Read<long>(pCPedList + i * 0x10);
            if (!Memory.IsValid(pCPed))
                continue;

            // 跳过玩家
            var pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo);
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
        var pCPedList = Game.GetCPedList();

        for (var i = 0; i < Base.oMaxPeds; i++)
        {
            var pCPed = Memory.Read<long>(pCPedList + i * 0x10);
            if (!Memory.IsValid(pCPed))
                continue;

            // 跳过玩家
            var pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo);
            if (Memory.IsValid(pCPlayerInfo))
                continue;

            var ped_type = Memory.Read<int>(pCPed + CPed.Ragdoll);
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
        var pCPedList = Game.GetCPedList();

        for (int i = 0; i < Base.oMaxPeds; i++)
        {
            var pCPed = Memory.Read<long>(pCPedList + i * 0x10);
            if (!Memory.IsValid(pCPed))
                continue;

            // 跳过玩家
            var pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo);
            if (Memory.IsValid(pCPlayerInfo))
                continue;

            var pCVehicle = Memory.Read<long>(pCPed + CPed.CVehicle);
            if (!Memory.IsValid(pCVehicle))
                continue;

            if (isOnlyKillHostility)
            {
                var oHostility = Memory.Read<byte>(pCPed + CPed.Hostility);
                if (oHostility > 0x01)
                {
                    Memory.Write(pCVehicle + CVehicle.Health, -1.0f);
                    Memory.Write(pCVehicle + CVehicle.HealthBody, -1.0f);
                    Memory.Write(pCVehicle + CVehicle.HealthPetrolTank, -1.0f);
                    Memory.Write(pCVehicle + CVehicle.HealthEngine, -1.0f);
                }
            }
            else
            {
                Memory.Write(pCVehicle + CVehicle.Health, -1.0f);
                Memory.Write(pCVehicle + CVehicle.HealthBody, -1.0f);
                Memory.Write(pCVehicle + CVehicle.HealthPetrolTank, -1.0f);
                Memory.Write(pCVehicle + CVehicle.HealthEngine, -1.0f);
            }
        }
    }

    /// <summary>
    /// 摧毁全部载具（玩家自己的载具也会摧毁）
    /// </summary>
    public static void DestroyAllVehicles()
    {
        var pCVehicleList = Game.GetCVehicleList();

        for (var i = 0; i < Base.oMaxPeds; i++)
        {
            var pCVehicle = Memory.Read<long>(pCVehicleList + i * 0x10);
            if (!Memory.IsValid(pCVehicle))
                continue;

            Memory.Write(pCVehicle + CVehicle.Health, -1.0f);
            Memory.Write(pCVehicle + CVehicle.HealthBody, -1.0f);
            Memory.Write(pCVehicle + CVehicle.HealthPetrolTank, -1.0f);
            Memory.Write(pCVehicle + CVehicle.HealthEngine, -1.0f);
        }
    }

    /// <summary>
    /// 传送全部NPC到我这里，仅敌对？
    /// </summary>
    public static void TeleportAllNPCToMe(bool isOnlyHostility)
    {
        var v3MyPos = Teleport.GetPlayerPosition();

        var pCPedList = Game.GetCPedList();

        for (var i = 0; i < Base.oMaxPeds; i++)
        {
            var pCPed = Memory.Read<long>(pCPedList + i * 0x10);
            if (!Memory.IsValid(pCPed))
                continue;

            // 跳过玩家
            var pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo);
            if (Memory.IsValid(pCPlayerInfo))
                continue;

            var pCNavigation = Memory.Read<long>(pCPed + CPed.CNavigation);
            if (!Memory.IsValid(pCNavigation))
                continue;

            if (isOnlyHostility)
            {
                var oHostility = Memory.Read<byte>(pCPed + CPed.Hostility);
                if (oHostility > 0x01)
                {
                    Memory.Write(pCPed + CVehicle.VisualX, v3MyPos);
                    Memory.Write(pCNavigation + CNavigation.PositionX, v3MyPos);
                }
            }
            else
            {
                Memory.Write(pCPed + CVehicle.VisualX, v3MyPos);
                Memory.Write(pCNavigation + CNavigation.PositionX, v3MyPos);
            }
        }
    }
}
