namespace GTA5Core.Offsets;

public struct Globals
{
    public const int GroundHeight = 0xA;

    public const int InitSessionState = 1574589;        // if (AUDIO::IS_AUDIO_SCENE_ACTIVE("MP_POST_MATCH_TRANSITION_SCENE"))
    public const int InitSessionCache = 1574589 + 2;
    public const int InitSessionType = 1575020;         // NETWORK::NETWORK_SESSION_SET_UNIQUE_CREW_LIMIT(1);

    public const int oMaxPeds = 256;

    // Vehicle Menus Globals
    public const int oVMCreate = 2694613;       // Create any vehicle. STREAMING::REQUEST_MODEL(Global_2694562.f_27.f_66);
    public const int oVMYCar = 2794162;         // Get my car. HUD::HIDE_HUD_AND_RADAR_THIS_FRAME();
    public const int oVGETIn = 2639889;         // Spawn into vehicle. if (SCRIPT::IS_THREAD_ACTIVE(Global_
    public const int oVMSlots = 1586488;        // Get vehicle slots. if (!NETWORK::NETWORK_DOES_NETWORK_ID_EXIST

    // Some Player / Network times associated Globals
    public const int oNETTimeHelp = 2672524;    // if (NETWORK::NETWORK_IS_PLAYER_ACTIVE(player))
    public const int oPlayerIDHelp = 2657704;
    public const int oPlayerGA = 2672524;
}
