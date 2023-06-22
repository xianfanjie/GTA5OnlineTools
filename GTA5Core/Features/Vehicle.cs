using GTA5Core.Native;
using GTA5Core.Offsets;

namespace GTA5Core.Features;

public static class Vehicle
{
    /// <summary>
    /// 玩家是否在载具中
    /// </summary>
    public static bool IsInVehicle()
    {
        long pCPed = Game.GetCPed();
        return Memory.Read<byte>(pCPed + CPed.InVehicle) == 0x01;
    }

    /// <summary>
    /// 载具无敌模式
    /// </summary>
    public static void GodMode(bool isEnable)
    {
        if (Game.GetCVehicle(out long pCVehicle))
            Memory.Write(pCVehicle + CPed.CVehicle.God, (byte)(isEnable ? 0x01 : 0x00));
    }

    /// <summary>
    /// 载具安全带
    /// </summary>
    public static void Seatbelt(bool isEnable)
    {
        long pCPed = Game.GetCPed();
        Memory.Write(pCPed + CPed.Seatbelt, (byte)(isEnable ? 0xC9 : 0xC8));
    }

    /// <summary>
    /// 载具隐形
    /// </summary>
    public static void Invisible(bool isEnable)
    {
        if (Game.GetCVehicle(out long pCVehicle))
            Memory.Write(pCVehicle + CPed.CVehicle.Invisible, (byte)(isEnable ? 0x01 : 0x27));
    }

    /// <summary>
    /// 载具附加功能
    /// </summary>
    public static void Extras(short flag)
    {
        if (Game.GetCVehicle(out long pCVehicle))
        {
            long pCModelInfo = Memory.Read<long>(pCVehicle + CPed.CVehicle.CModelInfo.__Offset__);
            Memory.Write(pCModelInfo + CPed.CVehicle.CModelInfo.Extras, flag);
        }
    }

    /// <summary>
    /// 载具降落伞，关0，开1
    /// </summary>
    public static void Parachute(bool isEnable)
    {
        if (Game.GetCVehicle(out long pCVehicle))
        {
            long pCModelInfo = Memory.Read<long>(pCVehicle + CPed.CVehicle.CModelInfo.__Offset__);
            Memory.Write(pCModelInfo + CPed.CVehicle.CModelInfo.Parachute, (byte)(isEnable ? 0x01 : 0x00));
        }
    }

    /// <summary>
    /// 补满载具血量
    /// </summary>
    public static void FillHealth()
    {
        if (Game.GetCVehicle(out long pCVehicle))
        {
            float oVHealth = Memory.Read<float>(pCVehicle + CPed.CVehicle.Health);
            float oVHealthMax = Memory.Read<float>(pCVehicle + CPed.CVehicle.HealthMax);
            if (oVHealth <= oVHealthMax)
            {
                Memory.Write(pCVehicle + CPed.CVehicle.Health, oVHealthMax);
                Memory.Write(pCVehicle + CPed.CVehicle.HealthBody, oVHealthMax);
                Memory.Write(pCVehicle + CPed.CVehicle.HealthPetrolTank, oVHealthMax);
                Memory.Write(pCVehicle + CPed.CVehicle.HealthEngine, oVHealthMax);
            }
            else
            {
                Memory.Write(pCVehicle + CPed.CVehicle.Health, 1000.0f);
                Memory.Write(pCVehicle + CPed.CVehicle.HealthBody, 1000.0f);
                Memory.Write(pCVehicle + CPed.CVehicle.HealthPetrolTank, 1000.0f);
                Memory.Write(pCVehicle + CPed.CVehicle.HealthEngine, 1000.0f);
            }
        }
    }

    /// <summary>
    /// 修复载具外观
    /// </summary>
    public static async Task FixVehicleByBST()
    {
        await Task.Run(async () =>
        {
            if (Game.GetCVehicle(out long pCVehicle))
            {
                Globals.WriteGA(Base.oVMYCar + 899, 1);       // if (!NETWORK::NETWORK_IS_SCRIPT_ACTIVE("AM_BRU_BOX", PLAYER::PLAYER_ID(), true, 0))

                await Task.Delay(1000);

                long pCPickupData = Memory.Read<long>(Pointers.PickupDataPTR);
                long FixVehValue = Memory.Read<long>(pCPickupData + 0x230);       // pFixVeh
                long BSTValue = Memory.Read<long>(pCPickupData + 0x160);          // pBST

                Memory.Write(pCVehicle + CPed.CVehicle.Health, 999.0f);

                long pCPickupInterface = Memory.Read<long>(Pointers.ReplayInterfacePTR);
                long pCReplayInterface_CPickupInterface = Memory.Read<long>(pCPickupInterface + CReplayInterface.CPickupInterface);

                long mPickupCount = Memory.Read<int>(pCReplayInterface_CPickupInterface + 0x110);       // oPickupNum
                long pPickupList = Memory.Read<long>(pCReplayInterface_CPickupInterface + 0x100);       // pPickupList

                await Task.Delay(100);

                for (long i = 0; i < mPickupCount; i++)
                {
                    long dwpPickup = Memory.Read<long>(pPickupList + i * 0x10);
                    if (!Memory.IsValid(dwpPickup))
                        continue;

                    long dwPickupValue = Memory.Read<long>(dwpPickup + 0x470);        // pDroppedPickupData
                    if (!Memory.IsValid(dwPickupValue))
                        continue;

                    if (dwPickupValue == BSTValue || dwPickupValue == FixVehValue)
                    {
                        Memory.Write(dwpPickup + 0x470, FixVehValue);

                        await Task.Delay(10);

                        Vector3 dwpPickupV3 = Memory.Read<Vector3>(dwpPickup + 0x90);
                        Vector3 vehicleV3 = Memory.Read<Vector3>(pCVehicle + CPed.CVehicle.VisualX);

                        await Task.Delay(10);

                        Memory.Write(dwpPickup + 0x90, vehicleV3);      // oVPositionX
                        Memory.Write(pCVehicle + 0x9D8, 0.0f);          // oVDirt  float  Wash Vehicle
                    }
                }

                await Task.Delay(1000);

                if (Globals.ReadGA<int>(Base.oNETTimeHelp + 3690) != 0)
                    Globals.WriteGA(Base.oNETTimeHelp + 3690, -1);
            }
        });
    }

    /// <summary>
    /// 请求个人载具
    /// </summary>
    /// <param name="index"></param>
    public static void RequestPersonalVehicle(int index)
    {
        Globals.WriteGA(Base.oVMYCar + 992, index);
        Globals.WriteGA(Base.oVMYCar + 989, 1);
    }

    /// <summary>
    /// 提前解锁1.67新载具（避免刷出消失）
    /// </summary>
    public static void Unlock167Vehicle()
    {
        Globals.WriteGA(Base.Default + 35462, 1);         // walton
        Globals.WriteGA(Base.Default + 35463, 1);         // vapid ratel
        Globals.WriteGA(Base.Default + 35464, 1);         // maibatsu
        Globals.WriteGA(Base.Default + 35465, 1);         // vapid vagon
        Globals.WriteGA(Base.Default + 35466, 1);         // stinger
        Globals.WriteGA(Base.Default + 35467, 1);         // streame216
        Globals.WriteGA(Base.Default + 35468, 1);         // f-160
        Globals.WriteGA(Base.Default + 35469, 1);         // buffalo5
        Globals.WriteGA(Base.Default + 35471, 1);         // penaud
        Globals.WriteGA(Base.Default + 35472, 1);         // conada
        Globals.WriteGA(Base.Default + 35473, 1);         // bravodo hotring
        Globals.WriteGA(Base.Default + 35474, 1);         // albany brigrham
    }
}
