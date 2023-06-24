﻿namespace GTA5Core.Offsets;

public struct Base
{
    public const int GroundHeight = 0xA;

    public const int Default = 262145;

    public const int SessionSwitchState = 1574589;        // if (AUDIO::IS_AUDIO_SCENE_ACTIVE("MP_POST_MATCH_TRANSITION_SCENE"))
    public const int SessionSwitchCache = 1574589 + 2;
    public const int SessionTransitionState = 1574996;
    public const int SessionSwitchType = 1575020;         // NETWORK::NETWORK_SESSION_SET_UNIQUE_CREW_LIMIT(1);

    public const int oMaxPlayers = 32;

    public const int oMaxPeds = 256;
    public const int oMaxVehicles = 300;
    public const int oMaxPickups = 73;
    public const int oMaxObjects = 2300;

    // Vehicle Menus Globals
    public const int oVMCreate = 2694613;       // Create any vehicle. STREAMING::REQUEST_MODEL(Global_2694562.f_27.f_66);
    public const int oVMYCar = 2794162;         // Get my car. HUD::HIDE_HUD_AND_RADAR_THIS_FRAME();
    public const int oVGETIn = 2639889;         // Spawn into vehicle. if (SCRIPT::IS_THREAD_ACTIVE(Global_
    public const int oVMSlots = 1586488;        // Get vehicle slots. if (!NETWORK::NETWORK_DOES_NETWORK_ID_EXIST

    // Some Player / Network times associated Globals
    public const int oNETTimeHelp = 2672524;    // if (ENTITY::IS_ENTITY_DEAD(vehiclePedIsIn, false) || !VEHICLE::IS_VEHICLE_DRIVEABLE(vehiclePedIsIn, false)
    public const int oPlayerIDHelp = 2657704;   // NETWORK::NETWORK_SET_CURRENT_SPAWN_LOCATION_OPTION(MISC::GET_HASH_KEY(   // Global_2657704[PLAYER::PLAYER_ID() /*463*/].f_321.f_11 = _INVALID_PLAYER_INDEX_0();
    public const int oPlayerGA = 2672524;

    public const int statSetIntOldHash = 1665476;       // https://pastebin.com/VbfAmLYB 
    public const int statSetIntOldValue = 980531;
    public const int statSetIntMinusOne = 1654054;
}
