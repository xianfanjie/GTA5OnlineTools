namespace GTA5Core.Offsets;

public struct CNetworkPlayerMgr
{
    public const int CNetGamePlayerLocal = 0xE8;
    public const int CNetGamePlayer = 0x180;
    public const int PlayerLimit = 0x280;
    public const int PlayerCount = 0x28C;
}

public struct CNetGamePlayerLocal           // 0xE8
{

}

public struct CNetGamePlayer                // 0x180
{

    public const int IsSpectating = 0x0C;
    public const int CPlayerInfo = 0xA0;
    public const int ClanName = 0xE6;
    public const int ClanTag = 0xFF;
    public const int IsRockStarDev = 0x199;
    public const int IsRockStarQA = 0x19A;
    public const int IsCheater = 0x19B;
}
