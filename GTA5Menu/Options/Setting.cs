namespace GTA5Menu.Options;

public static class Setting
{
    public static class Player
    {
        public static bool GodMode = false;
        public static bool AntiAFK = false;
        public static bool NoRagdoll = false;

        public static bool NoCollision = false;

        public static void Reset()
        {
            GodMode = false;
            AntiAFK = false;
            NoRagdoll = false;

            NoCollision = false;
        }
    }

    public static class Vehicle
    {
        public static bool GodMode = false;
        public static bool Seatbelt = false;

        public static void Reset()
        {
            GodMode = false;
            Seatbelt = false;
        }
    }

    public static class Weapon
    {
        public static int AmmoModifierFlag = 0;

        public static void Reset()
        {
            AmmoModifierFlag = 0;
        }
    }

    public static class Online
    {
        public static bool AllowSellOnNonPublic = false;

        public static void Reset()
        {
            AllowSellOnNonPublic = false;
        }
    }

    public static class Auto
    {
        public static bool ClearWanted = false;
        public static bool KillNPC = false;
        public static bool KillHostilityNPC = false;
        public static bool KillPolice = false;

        public static void Reset()
        {
            ClearWanted = false;
            KillNPC = false;
            KillHostilityNPC = false;
            KillPolice = false;
        }
    }
}
