using GTA5Core.Native;
using GTA5Core.Offsets;

namespace GTA5Core.Features;

public static class Game
{
    /// <summary>
    /// 获取 CPed 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCPed()
    {
        long pCPedFactory = Memory.Read<long>(Pointers.WorldPTR);
        return Memory.Read<long>(pCPedFactory + CPedFactory.CPed);
    }

    /// <summary>
    /// 获取 CPlayerInfo 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCPlayerInfo()
    {
        long pCPed = GetCPed();
        return Memory.Read<long>(pCPed + CPed.CPlayerInfo);
    }

    /// <summary>
    /// 获取 CVehicle 指针
    /// </summary>
    /// <param name="pCVehicle"></param>
    /// <returns></returns>
    public static bool GetCVehicle(out long pCVehicle)
    {
        pCVehicle = 0;

        long pCPed = GetCPed();
        byte oInVehicle = Memory.Read<byte>(pCPed + CPed.InVehicle);

        if (oInVehicle == 0x01)
        {
            pCVehicle = Memory.Read<long>(pCPed + CPed.CVehicle);
            return true;
        }

        return false;
    }

    /// <summary>
    /// 获取 CPedList 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCPedList()
    {
        long pCReplayInterface = Memory.Read<long>(Pointers.ReplayInterfacePTR);
        long pCPedInterface = Memory.Read<long>(pCReplayInterface + CReplayInterface.CPedInterface);
        return Memory.Read<long>(pCPedInterface + CPedInterface.CPedList);
    }

    /// <summary>
    /// 获取 CVehicleList 指针
    /// </summary>
    /// <returns></returns>
    public static long GetCVehicleList()
    {
        long pCReplayInterface = Memory.Read<long>(Pointers.ReplayInterfacePTR);
        long pCVehicleInterface = Memory.Read<long>(pCReplayInterface + CReplayInterface.CVehicleInterface);
        return Memory.Read<long>(pCVehicleInterface + CVehicleInterface.CVehicleList);
    }
}
