using GTA5HotKey;

namespace GTA5Overlay;

public static class Setting
{
    public static bool VSync = true;
    public static int FPS = 300;

    // Player
    public static bool ESP_Player = true;
    public static bool ESP_Player_2DBox = true;
    public static bool ESP_Player_3DBox = false;
    public static bool ESP_Player_Line = true;
    public static bool ESP_Player_Bone = false;
    public static bool ESP_Player_HealthBar = true;
    public static bool ESP_Player_HealthText = false;
    public static bool ESP_Player_NameText = false;
    public static bool AimBot_Player_Enabled = false;

    // NPC
    public static bool ESP_NPC = true;
    public static bool ESP_NPC_2DBox = true;
    public static bool ESP_NPC_3DBox = false;
    public static bool ESP_NPC_Line = true;
    public static bool ESP_NPC_Bone = false;
    public static bool ESP_NPC_HealthBar = true;
    public static bool ESP_NPC_HealthText = false;
    public static bool ESP_NPC_NameText = false;
    public static bool AimBot_NPC_Enabled = false;

    // Pickup
    public static bool ESP_Pickup = true;
    public static bool ESP_Pickup_2DBox = true;
    public static bool ESP_Pickup_3DBox = false;
    public static bool ESP_Pickup_Line = true;

    public static bool ESP_Crosshair = true;
    public static bool ESP_InfoText = true;

    public static int AimBot_BoneIndex = 0;
    public static float AimBot_Fov = 250.0f;
    public static WinVK AimBot_Key = WinVK.CONTROL;

    public static bool NoTopMostHide = false;

    public static void Reset()
    {
        VSync = true;
        FPS = 300;

        ESP_Player = true;
        ESP_Player_2DBox = true;
        ESP_Player_3DBox = false;
        ESP_Player_Line = true;
        ESP_Player_Bone = false;
        ESP_Player_HealthBar = true;
        ESP_Player_HealthText = false;
        ESP_Player_NameText = false;
        AimBot_Player_Enabled = false;

        ESP_NPC = true;
        ESP_NPC_2DBox = true;
        ESP_NPC_3DBox = false;
        ESP_NPC_Line = true;
        ESP_NPC_Bone = false;
        ESP_NPC_HealthBar = true;
        ESP_NPC_HealthText = false;
        ESP_NPC_NameText = false;
        AimBot_NPC_Enabled = false;

        ESP_Pickup = true;
        ESP_Pickup_2DBox = true;
        ESP_Pickup_3DBox = false;
        ESP_Pickup_Line = true;

        ESP_Crosshair = true;
        ESP_InfoText = true;

        AimBot_BoneIndex = 0;
        AimBot_Fov = 250.0f;
        AimBot_Key = WinVK.CONTROL;

        NoTopMostHide = false;
    }
}
