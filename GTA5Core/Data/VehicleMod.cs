namespace GTA5Core.Data;

public class VehicleMod
{
    /// <summary>
    /// 车牌 License plate
    /// </summary>
    public string Plate { get; set; }
    /// <summary>
    /// 主色调 primary -1 auto 159
    /// </summary>
    public int Primary { get; set; }
    /// <summary>
    /// 副色调 secondary -1 auto 159
    /// </summary>
    public int Secondary { get; set; }
    /// <summary>
    /// 珠光色 pearlescent
    /// </summary>
    public int Pearlescent { get; set; }
    /// <summary>
    /// 车轮颜色 wheel color
    /// </summary>
    public int WheelColor { get; set; }
    /// <summary>
    /// 引擎 engine (0-3)
    /// </summary>
    public int Engine { get; set; } = 4;
    /// <summary>
    /// 刹车 brakes (0-6)
    /// </summary>
    public int Brakes { get; set; } = 3;
    /// <summary>
    /// 变速器 transmission (0-9)
    /// </summary>
    public int Transmission { get; set; } = 3;
    /// <summary>
    /// 喇叭 horn (0-77)
    /// </summary>
    public int Horn { get; set; }
    /// <summary>
    /// 悬吊系统 suspension (0-13)
    /// </summary>
    public int Suspension { get; set; } = 8;
    /// <summary>
    /// 装甲 armor (0-18)
    /// </summary>
    public int Armor { get; set; } = 5;
    /// <summary>
    /// 涡轮增压 turbo (0-1)
    /// </summary>
    public int Turbo { get; set; } = 1;
    /// <summary>
    /// 彩色灯光 colored light (0-14)
    /// </summary>
    public int ColoredLight { get; set; }
    /// <summary>
    /// 车轮类型，Wheel type
    /// </summary>
    public int WheelType { get; set; }
    /// <summary>
    /// 车轮ID+班尼车轮，wheel selection
    /// </summary>
    public int WheelSelection { get; set; }
    /// <summary>
    /// 烟雾RGB Tire smoke color
    /// </summary>
    public int TireSmokeR { get; set; }
    /// <summary>
    /// 烟雾RGB Tire smoke color
    /// </summary>
    public int TireSmokeG { get; set; }
    /// <summary>
    /// 烟雾RGB Tire smoke color
    /// </summary>
    public int TireSmokeB { get; set; }
    /// <summary>
    /// 窗户 Window tint 0-6
    /// </summary>
    public int WindowTint { get; set; } = -1;
    /// <summary>
    /// 涂装 Livery
    /// </summary>
    public int Livery { get; set; } = 0;
    /// <summary>
    /// 霓虹RGB Neon 0-255
    /// </summary>
    public int NeonR { get; set; }
    /// <summary>
    /// 霓虹RGB Neon 0-255
    /// </summary>
    public int NeonG { get; set; }
    /// <summary>
    /// 霓虹RGB Neon 0-255
    /// </summary>
    public int NeonB { get; set; }
    /// <summary>
    /// 载具防弹 2:bulletproof 0:false
    /// </summary>
    public byte BulletProof { get; set; } = 2;
    /// <summary>
    /// 主武器 primary weapon
    /// </summary>
    public int Weapon { get; set; }
    /// <summary>
    /// 副武器 secondary weaponget_teleKEYSpeed
    /// </summary>
    public int Weapon2 { get; set; }
}
