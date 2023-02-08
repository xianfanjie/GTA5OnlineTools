using System.Collections.Generic;

namespace GTA5.Share.Vehicles;

public static class VehicleWheel
{
    /// <summary>
    /// Sport
    /// </summary>
    public static readonly Dictionary<int, string> Sport = new()
    {
        { 1, "Inferno" },
        { 2, "Deep Five" },
        { 3, "Lozspeed Mk.V" },
        { 4, "Diamond Cut" },
        { 5, "Chrono" },
        { 6, "Feroci RR" },
        { 7, "FiftyNine" },
        { 8, "Mercie" },
        { 9, "Synthetic Z" },
        { 10, "Organic Type O" },
        { 11, "Endo v.1" },
        { 12, "GT One" },
        { 13, "Duper 7" },
        { 14, "Uzer" },
        { 15, "GroundRide" },
        { 16, "S Racer" },
        { 17, "Venum" },
        { 18, "Cosmo" },
        { 19, "Dash VIP" },
        { 20, "Ice Kid" },
        { 21, "Ruff Weld" },
        { 22, "Wangan Master" },
        { 23, "Super Five" },
        { 24, "Endo v.2" },
        { 25, "Split Six" },
    };

    /// <summary>
    /// Muscle
    /// </summary>
    public static readonly Dictionary<int, string> Muscle = new()
    {
        { 1, "Classic Five" },
        { 2, "Dukes" },
        { 3, "Muscle Freak" },
        { 4, "Kracka" },
        { 5, "Azreal" },
        { 6, "Mecha" },
        { 7, "Black Top" },
        { 8, "Drag SPL" },
        { 9, "Revolver" },
        { 10, "Classic Rod" },
        { 11, "Fairlie" },
    };

    /// <summary>
    /// Lowrider
    /// </summary>
    public static readonly Dictionary<int, string> Lowrider = new()
    {
        { 1, "Flare" },
        { 2, "Wired" },
        { 3, "Triple Golds" },
        { 4, "Big Worm" },
        { 5, "Seven Fives" },
        { 6, "Split Six" },
        { 7, "Fresh Mesh" },
        { 8, "Lead Sled" },
        { 9, "Turbine" },
        { 10, "Super Fin" },
        { 11, "Classic Rod" },
        { 12, "Dollar" },
        { 13, "Dukes" },
        { 14, "Low Five" },
        { 15, "Gooch" },
    };

    /// <summary>
    /// SUV
    /// </summary>
    public static readonly Dictionary<int, string> SUV = new()
    {
        { 1, "VIP" },
        { 2, "Benefactor" },
        { 3, "Cosmo" },
        { 4, "Bippu" },
        { 5, "Royal Six" },
        { 6, "Fagorme" },
        { 7, "Deluxe" },
        { 8, "Iced Out" },
        { 9, "Cognescenti" },
        { 10, "LozSpeed Ten" },
        { 11, "Supernova" },
        { 12, "Obey RS" },
        { 13, "LozSpeed Baller" },
        { 14, "Extravaganzo" },
        { 15, "Split Six" },
        { 16, "Empowered" },
        { 17, "Sunrise" },
        { 18, "Dash VIP" },
        { 19, "Cutter" },
    };

    /// <summary>
    /// Offroad
    /// </summary>
    public static readonly Dictionary<int, string> Offroad = new()
    {
        { 1, "Raider" },
        { 2, "Mudslinger" },
        { 3, "Nevis" },
        { 4, "Cairngorm" },
        { 5, "Amazon" },
        { 6, "Challenger" },
        { 7, "Dune Basher" },
        { 8, "Five Star" },
        { 9, "Rock Crawler" },
        { 10, "Mil Spec Steelie" },
    };

    /// <summary>
    /// Tuner
    /// </summary>
    public static readonly Dictionary<int, string> Tuner = new()
    {
        { 1, "Cosmo" },
        { 2, "Super Mesh" },
        { 3, "Outsider" },
        { 4, "Rollas" },
        { 5, "Driftmeister" },
        { 6, "Slicer" },
        { 7, "El Quattro" },
        { 8, "Dubbed" },
        { 9, "Five Star" },
        { 10, "Sideways" },
        { 11, "Apex" },
        { 12, "Stanced EG" },
        { 13, "Countersteer" },
        { 14, "Endo v.1" },
        { 15, "Endo v.2 Dish" },
        { 16, "Gruppe Z" },
        { 17, "Choku Dori" },
        { 18, "Chicane" },
        { 19, "Saisoku" },
        { 20, "Dished Eight" },
        { 21, "Fujiwara" },
        { 22, "Zokusha" },
        { 23, "Battle VIII" },
        { 24, "Rally Master" },
    };

    /// <summary>
    /// Bike Wheels
    /// </summary>
    public static readonly Dictionary<int, string> Bike = new()
    {
        { 1, "Speedway" },
        { 2, "Street Special" },
        { 3, "Racer" },
        { 4, "Track Star" },
        { 5, "Overlord" },
        { 6, "Trident" },
        { 7, "Triple Threat" },
        { 8, "Stiletto" },
        { 9, "Wires" },
        { 10, "Bobber" },
        { 11, "Solidus" },
        { 12, "Ice Shield" },
        { 13, "Loops" },
    };

    /// <summary>
    /// High End
    /// </summary>
    public static readonly Dictionary<int, string> High = new()
    {
        { 1, "Shadow" },
        { 2, "Hypher" },
        { 3, "Blade" },
        { 4, "Diamond" },
        { 5, "Supa Gee" },
        { 6, "Chromatic Z" },
        { 7, "Mercie Ch.Lip" },
        { 8, "Obey RS" },
        { 9, "GT Chrome" },
        { 10, "Cheetah RR" },
        { 11, "Solar" },
        { 12, "Split Ten" },
        { 13, "Dash VIP" },
        { 14, "LozSpeed Ten" },
        { 15, "Carbon Inferno" },
        { 16, "Carbon Shadow" },
        { 17, "Carbonic Z" },
        { 18, "Carbon Solar" },
        { 19, "Cheetah Carbon R" },
        { 20, "Carbon S Racer" },
    };

    /// <summary>
    /// Benny's Original
    /// </summary>
    public static readonly Dictionary<int, string> Original = new()
    {
        { 1, "OG Hunnets" },
        { 2, "OG Hunnets (Chrome)" },
        { 3, "Knock-Offs" },
        { 4, "Knock-Offs (Chrome)" },
        { 5, "Spoked Out" },
        { 6, "Spoked Out (Chrome)" },
        { 7, "Vintage Wire" },
        { 8, "Vintage Wire (Chrome)" },
        { 9, "Smoothie" },
        { 10, "Smoothie (Chrome)" },
        { 11, "Smoothie (Solid)" },
        { 12, "Rod Me Up" },
        { 13, "Rod Me Up (Chrome)" },
        { 14, "Rod Me Up (Solid)" },
        { 15, "Clean" },
        { 16, "Lotta Chrome" },
        { 17, "Spindles" },
        { 18, "Viking" },
        { 19, "Triple Spoke" },
        { 20, "Pharohe" },
        { 21, "Tiger Style" },
        { 22, "Three Wheelin" },
        { 23, "Big Bar" },
        { 24, "Hiohazard" },
        { 25, "Waves" },
        { 26, "lick Lick" },
        { 27, "Spiralizer" },
        { 28, "Hypnotics" },
        { 29, "Psycho-Delic" },
        { 30, "Half Cut" },
        { 31, "Super Electric" },
    };

    /// <summary>
    /// Benny's Bespoke
    /// </summary>
    public static readonly Dictionary<int, string> Bespoke = new()
    {
        { 1, "Chrome OG Hunnets" },
        { 2, "Gold OG Hunnets" },
        { 3, "Chrome Wires" },
        { 4, "Gold Wires" },
        { 5, "Chrome Spoked Out" },
        { 6, "Gold Spoked Out" },
        { 7, "Chrome Knock-Offs" },
        { 8, "Gold Knock-Offs" },
        { 9, "Chrome Bigger Worm" },
        { 10, "Gold Bigger Worm" },
        { 11, "Chrome Vintage Wire" },
        { 12, "Gold Vintage Wire" },
        { 13, "Chrome Classic Wire" },
        { 14, "Gold Classic Wire" },
        { 15, "Chrome Smoothie" },
        { 16, "Gold Smoothie" },
        { 17, "Chrome Classic Rod" },
        { 18, "Gold Classic Rod" },
        { 19, "Chrome Dollar" },
        { 20, "Gold Dollar" },
        { 21, "Chrome Mighty Star" },
        { 22, "Gold Mighty Star" },
        { 23, "Chrome Decadent Dish" },
        { 24, "Gold Decadent Dish" },
        { 25, "Chrome Razor Style" },
        { 26, "Gold Razor Style" },
        { 27, "Chrome Celtic Knot" },
        { 28, "Gold Celtic Knot" },
        { 29, "Chrome Warrior Dish" },
        { 30, "Gold Warrior Dish" },
        { 31, "Gold Big Dog Spokes" },
    };

    /// <summary>
    /// Race (Formula)
    /// </summary>
    public static readonly Dictionary<int, string> Race = new()
    {
        { 1, "Classic 5" },
        { 2, "Classic 5 (Striped)" },
        { 3, "Retro Star" },
        { 4, "Retro Star (Striped)" },
        { 5, "Triplex" },
        { 6, "Triplex (Striped)" },
        { 7, "70s Spec" },
        { 8, "70s Spec (Striped)" },
        { 9, "Super 5R" },
        { 10, "Super 5R (Striped)" },
        { 11, "Speedster" },
        { 12, "Speedster (Striped)" },
        { 13, "GP-90" },
        { 14, "GP-90 (Striped)" },
        { 15, "Superspoke" },
        { 16, "Superspoke (Striped)" },
        { 17, "Gridline" },
        { 18, "Gridline (Striped)" },
        { 19, "Snowflake" },
        { 20, "Snowflake (Striped)" },
    };

    /// <summary>
    /// Street
    /// </summary>
    public static readonly Dictionary<int, string> Street = new()
    {
        { 1, "Retro Steelie" },
        { 2, "Poverty Spec Steelie" },
        { 3, "Concave Steelie" },
        { 4, "Nebula" },
        { 5, "Hotring Steelie" },
        { 6, "Cup Champion" },
        { 7, "Stanced EG Custom" },
        { 8, "Kracka Custom" },
        { 9, "Dukes Custom" },
        { 10, "Endo v.3 Custom" },
        { 11, "V8 Killer" },
        { 12, "Fujiwara Custom" },
        { 13, "Cosmo MK2" },
        { 14, "Aero Star" },
        { 15, "Hype Five" },
        { 16, "Ruff Weld Mega Deep" },
        { 17, "Mercie Concave" },
        { 18, "Sugoi Concave" },
        { 19, "Synthetic Z Concave" },
        { 20, "Endo v.4 Dished" },
        { 21, "Hyperfresh" },
        { 22, "Truffade Concave" },
        { 23, "Organic Type 2" },
        { 24, "Big Mamba" },
        { 25, "Deep Flake" },
        { 26, "Cosmo MK3" },
        { 27, "Concave Racer" },
        { 28, "Deep Flake Reverse" },
        { 29, "Wild Wagon" },
        { 30, "Concave Mega Mesh" },
    };

    /// <summary>
    /// Track
    /// </summary>
    public static readonly Dictionary<int, string> Track = new()
    {
        { 1, "Rally Throwback" },
        { 2, "Gravel Trap" },
        { 3, "Stove Top" },
        { 4, "Stove Top Mesh" },
        { 5, "Retro 3 Piece" },
        { 6, "Rally Monoblock" },
        { 7, "Forged 5" },
        { 8, "Split Star" },
        { 9, "Speed Boy" },
        { 10, "90s Running" },
        { 11, "Tropos" },
        { 12, "Exos" },
        { 13, "High Five" },
        { 14, "Super Luxe" },
        { 15, "Pure Business" },
        { 16, "Pepper Pot" },
        { 17, "BlackTop Blender" },
        { 18, "Throwback" },
        { 19, "Expressway" },
        { 20, "Hidden Six" },
        { 21, "Dinka SPL" },
        { 22, "Retro Turbofan" },
        { 23, "Conical Turbofan" },
        { 24, "Ice Storm" },
        { 25, "Super Turbine" },
        { 26, "Modern Mash" },
        { 27, "Forged Star" },
        { 28, "Showflake" },
        { 29, "Giga Mesh" },
        { 30, "Mesh Meister" },
    };

    /// <summary>
    /// Wheels
    /// </summary>
    public static readonly Dictionary<string, Dictionary<int, string>> WheelTypes = new()
    {
        { "Sport", Sport },
        { "Muscle", Muscle },
        { "Lowrider", Lowrider },
        { "SUV", SUV },
        { "Offroad", Offroad },
        { "Tuner", Tuner },
        { "Bike Wheels", Bike },
        { "High End", High },
        { "Benny's Original", Original },
        { "Benny's Bespoke", Bespoke },
        { "Race (Formula)", Race },
        { "Street", Street },
        { "Track", Track },
    };
}
