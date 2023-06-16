namespace GTA5Core.Offsets;

public struct CReplayInterface
{
    public struct CVehicleInterface  // 0x10
    {
        public const int __Offset__ = 0x10;

        public const int CVehicleList = 0x180;
        public const int MaxVehicles = 0x188;       // int32
        public const int CurVehicles = 0x190;
    }
    public struct CPedInterface  // 0x18
    {
        public const int __Offset__ = 0x18;

        public const int CPedList = 0x100;
        public const int MaxPeds = 0x108;           // int32
        public const int CurPeds = 0x110;
    }
    public struct CPickupInterface  // 0x20
    {
        public const int __Offset__ = 0x20;

    }
    public struct CObjectInterface  // 0x28
    {
        public const int __Offset__ = 0x28;

    }
}
