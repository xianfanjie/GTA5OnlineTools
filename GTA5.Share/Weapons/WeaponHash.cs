using System.Collections.Generic;

namespace GTA5.Share.Weapons;

public static class WeaponHash
{
    /// <summary>
    /// 近战
    /// </summary>
    public static readonly Dictionary<string, string> Melee = new()
    {
        { "weapon_dagger", "古董骑兵匕首" },
        { "weapon_bat", "球棒" },
        { "weapon_bottle", "酒瓶" },
        { "weapon_crowbar", "撬棒" },
        { "weapon_unarmed", "徒手" },
        { "weapon_flashlight", "手电筒" },
        { "weapon_golfclub", "高尔夫球杆" },
        { "weapon_hammer", "铁锤" },
        { "weapon_hatchet", "手斧" },
        { "weapon_knuckle", "手指虎" },
        { "weapon_knife", "小刀" },
        { "weapon_machete", "开山刀" },
        { "weapon_switchblade", "弹簧刀" },
        { "weapon_nightstick", "警棍" },
        { "weapon_wrench", "管钳扳手" },
        { "weapon_battleaxe", "战斧" },
        { "weapon_poolcue", "台球杆" },
        { "weapon_stone_hatchet", "石斧" },
    };

    /// <summary>
    /// 手枪
    /// </summary>
    public static readonly Dictionary<string, string> Handguns = new()
    {
        { "weapon_pistol", "手枪" },
        { "weapon_pistol_mk2", "MK2 手枪" },
        { "weapon_combatpistol", "战斗手枪" },
        { "weapon_appistol", "穿甲手枪" },
        { "weapon_stungun", "电击枪" },
        { "weapon_pistol50", "0.5口径手枪" },
        { "weapon_snspistol", "劣质手枪" },
        { "weapon_snspistol_mk2", "MK2 劣质手枪" },
        { "weapon_heavypistol", "重型手枪" },
        { "weapon_vintagepistol", "老式手枪" },
        { "weapon_flaregun", "信号枪" },
        { "weapon_marksmanpistol", "射手手枪" },
        { "weapon_revolver", "重型左轮手枪" },
        { "weapon_revolver_mk2", "MK2 重型左轮手枪" },
        { "weapon_doubleaction", "双动式左轮手枪 " },
        { "weapon_raypistol", "原子能手枪" },
        { "weapon_ceramicpistol", "陶瓷手枪" },
        { "weapon_navyrevolver", "海军左轮手枪" },
        { "weapon_gadgetpistol", "佩里科手枪" },
        { "weapon_stungun_mp", "电击枪（多人）" },
    };

    /// <summary>
    /// 冲锋枪
    /// </summary>
    public static readonly Dictionary<string, string> SubmachineGuns = new()
    {
        { "weapon_microsmg", "微型冲锋枪" },
        { "weapon_smg", "冲锋枪" },
        { "weapon_smg_mk2", "MK2 冲锋枪" },
        { "weapon_assaultsmg", "突击冲锋枪" },
        { "weapon_combatpdw", "作战自卫冲锋枪" },
        { "weapon_machinepistol", "冲锋手枪" },
        { "weapon_minismg", "迷你冲锋枪" },
        { "weapon_gusenberg", "古森柏冲锋枪" },
    };

    /// <summary>
    /// 霰弹枪
    /// </summary>
    public static readonly Dictionary<string, string> Shotguns = new()
    {
        { "weapon_pumpshotgun", "泵动式霰弹枪" },
        { "weapon_pumpshotgun_mk2", "MK2 泵动式霰弹枪" },
        { "weapon_sawnoffshotgun", "短管霰弹枪" },
        { "weapon_assaultshotgun", "突击霰弹枪" },
        { "weapon_bullpupshotgun", "无托式霰弹枪" },
        { "weapon_musket", "老式火枪" },
        { "weapon_heavyshotgun", "重型霰弹枪" },
        { "weapon_dbshotgun", "双管霰弹枪" },
        { "weapon_autoshotgun", "冲锋霰弹枪" },
        { "weapon_combatshotgun", "战斗霰弹枪" },
    };

    /// <summary>
    /// 突击步枪
    /// </summary>
    public static readonly Dictionary<string, string> AssaultRifles = new()
    {
        { "weapon_assaultrifle", "突击步枪" },
        { "weapon_assaultrifle_mk2", "MK2 突击步枪" },
        { "weapon_carbinerifle", "卡宾步枪" },
        { "weapon_carbinerifle_mk2", "MK2 卡宾步枪" },
        { "weapon_advancedrifle", "高级步枪" },
        { "weapon_specialcarbine", "特制卡宾步枪" },
        { "weapon_specialcarbine_mk2", "MK2 特制卡宾步枪" },
        { "weapon_bullpuprifle", "无托式步枪" },
        { "weapon_bullpuprifle_mk2", "MK2 无托式步枪" },
        { "weapon_compactrifle", "紧凑型步枪" },
        { "weapon_militaryrifle", "军用步枪" },
        { "weapon_heavyrifle", "重型步枪" },
        { "weapon_tacticalrifle", "制式卡宾步枪" },
    };

    /// <summary>
    /// 轻机枪
    /// </summary>
    public static readonly Dictionary<string, string> LightMachineGuns = new()
    {
        { "weapon_mg", "机枪" },
        { "weapon_combatmg", "战斗机枪" },
        { "weapon_combatmg_mk2", "MK2 战斗机枪" },
        { "weapon_raycarbine", "邪恶冥王" },
    };

    /// <summary>
    /// 狙击枪
    /// </summary>
    public static readonly Dictionary<string, string> SniperRifles = new()
    {
        { "weapon_sniperrifle", "狙击步枪" },
        { "weapon_heavysniper", "重型狙击步枪" },
        { "weapon_heavysniper_mk2", "MK2 重型狙击步枪" },
        { "weapon_marksmanrifle", "射手步枪" },
        { "weapon_marksmanrifle_mk2", "MK2 射手步枪" },
        { "weapon_precisionrifle", "精确步枪" },
    };

    /// <summary>
    /// 重武器
    /// </summary>
    public static readonly Dictionary<string, string> HeavyWeapons = new()
    {
        { "weapon_rpg", "火箭炮" },
        { "weapon_grenadelauncher", "榴弹发射器" },
        { "weapon_grenadelauncher_smoke", "烟雾榴弹发射器" },
        { "weapon_minigun", "火神机枪" },
        { "weapon_firework", "烟火发射器" },
        { "weapon_railgun", "电磁步枪" },
        { "weapon_hominglauncher", "制导火箭发射器" },
        { "weapon_compactlauncher", "紧凑型榴弹发射器" },
        { "weapon_rayminigun", "寡妇制造者" },
        { "weapon_emplauncher", "紧凑电磁脉冲发射器" },
    };

    /// <summary>
    /// 投掷物
    /// </summary>
    public static readonly Dictionary<string, string> Throwables = new()
    {
        { "weapon_grenade", "手榴弹" },
        { "weapon_bzgas", "毒气手榴弹" },
        { "weapon_molotov", "汽油弹" },
        { "weapon_stickybomb", "黏弹" },
        { "weapon_proxmine", "感应地雷" },
        { "weapon_snowball", "雪球" },
        { "weapon_pipebomb", "土制炸弹" },
        { "weapon_ball", "棒球" },
        { "weapon_smokegrenade", "催泪瓦斯" },
        { "weapon_flare", "信号弹" },
    };

    /// <summary>
    /// 杂项
    /// </summary>
    public static readonly Dictionary<string, string> Miscellaneous = new()
    {
        { "weapon_petrolcan", "油桶" },
        { "gadget_parachute", "降落伞" },
        { "weapon_fireextinguisher", "灭火器" },
        { "weapon_weapon_hazardcan", "危险的杰瑞罐" },
        { "weapon_weapon_fertilizercan", "肥料罐" },
    };

    /// <summary>
    /// 武器分类
    /// </summary>
    public static readonly Dictionary<string, Dictionary<string, string>> WeaponTypes = new()
    {
        { "近战", Melee },
        { "手枪", Handguns },
        { "冲锋枪", SubmachineGuns },
        { "霰弹枪", Shotguns },
        { "突击步枪", AssaultRifles },
        { "轻机枪", LightMachineGuns },
        { "狙击枪", SniperRifles },
        { "重武器", HeavyWeapons },
        { "投掷物", Throwables },
        { "杂项", Miscellaneous }
    };
}
