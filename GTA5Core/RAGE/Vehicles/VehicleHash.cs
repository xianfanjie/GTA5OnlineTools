namespace GTA5Core.RAGE.Vehicles;

public static class VehicleHash
{
    public class VehicleClass
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public List<VehicleInfo> VehicleInfos { get; set; }
    }

    public class VehicleInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    /// <summary>
    /// -1 当前分类: 常用载具
    /// </summary>
    public static readonly List<VehicleInfo> Common = new()
    {
        new VehicleInfo(){ Name="佩嘉西 暴君 Mk 2", Value="oppressor2" },
        new VehicleInfo(){ Name="卡林 骷髅马（装甲版）", Value="kuruma2" },
        new VehicleInfo(){ Name="警用巡逻车", Value="police3" },
        new VehicleInfo(){ Name="救护车", Value="ambulance" },
        new VehicleInfo(){ Name="秃鹰攻击直升机", Value="buzzard" },
        new VehicleInfo(){ Name="巨象 嘟嘟鸟", Value="dodo" },
        new VehicleInfo(){ Name="麦霸子 桑切斯（涂装版）", Value="sanchez" },
        new VehicleInfo(){ Name="犀牛坦克", Value="rhino" },
        new VehicleInfo(){ Name="巨象 九头蛇", Value="hydra" },
        new VehicleInfo(){ Name="P-996 天煞", Value="lazer" },
        new VehicleInfo(){ Name="出租车", Value="taxi" },
        new VehicleInfo(){ Name="巨象 推进者", Value="thruster" },
        new VehicleInfo(){ Name="TM-02 可汗贾利", Value="khanjali" },
        new VehicleInfo(){ Name="野蛮人", Value="savage" },
        new VehicleInfo(){ Name="长崎 小艇", Value="dinghy" },
        new VehicleInfo(){ Name="库尔兹 31 巡逻艇", Value="patrolboat" },
        new VehicleInfo(){ Name="佩嘉西 图拉尔多", Value="toreador" },
        new VehicleInfo(){ Name="英庞提 德罗索", Value="deluxo" },
    };

    /// <summary>
    /// 0 当前分类: 小型汽车
    /// </summary>
    public static readonly List<VehicleInfo> Compacts = new()
    {
        new VehicleInfo(){ Name="麦克斯韦 反社会", Value="asbo" },
        new VehicleInfo(){ Name="丁卡 旅行家", Value="blista" },
        new VehicleInfo(){ Name="古罗帝 精力霸 R/A", Value="brioso" },
        new VehicleInfo(){ Name="古罗帝 精力霸 300", Value="brioso2" },
        new VehicleInfo(){ Name="古罗帝 精力霸 300 宽体版", Value="brioso3" },
        new VehicleInfo(){ Name="毕福 俱乐部", Value="club" },
        new VehicleInfo(){ Name="卡林 半吊子", Value="dilettante" },
        new VehicleInfo(){ Name="卡林 半吊子", Value="dilettante2" },
        new VehicleInfo(){ Name="威尼 天威", Value="issi2" },
        new VehicleInfo(){ Name="威尼 天威经典版", Value="issi3" },
        new VehicleInfo(){ Name="威尼 末日天威", Value="issi4" },
        new VehicleInfo(){ Name="威尼 科幻天威", Value="issi5" },
        new VehicleInfo(){ Name="威尼 梦魇天威", Value="issi6" },
        new VehicleInfo(){ Name="丁卡 旅行家羽黑", Value="kanjo" },
        new VehicleInfo(){ Name="贝飞特 哑剧", Value="panto" },
        new VehicleInfo(){ Name="包洛坎 原野行者", Value="prairie" },
        new VehicleInfo(){ Name="绝致 狂想曲", Value="rhapsody" },
        new VehicleInfo(){ Name="毕福 象鼻虫", Value="weevil" },
        new VehicleInfo(){ Name="英庞提 德罗索", Value="deluxo" },
    };

    /// <summary>
    /// 1 当前分类: 轿车
    /// </summary>
    public static readonly List<VehicleInfo> Sedans = new()
    {
        new VehicleInfo(){ Name="绝致 海致", Value="asea" },
        new VehicleInfo(){ Name="绝致 海致", Value="asea2" },
        new VehicleInfo(){ Name="卡林 爱硕普", Value="asterope" },
        new VehicleInfo(){ Name="兰帕达缇 五千", Value="cinquemila" },
        new VehicleInfo(){ Name="埃努斯 至尊慧眼 55", Value="cog55" },
        new VehicleInfo(){ Name="埃努斯 至尊慧眼 55（装甲版）", Value="cog552" },
        new VehicleInfo(){ Name="埃努斯 至尊慧眼", Value="cognoscenti" },
        new VehicleInfo(){ Name="埃努斯 至尊慧眼（装甲版）", Value="cognoscenti2" },
        new VehicleInfo(){ Name="埃努斯 神灵", Value="deity" },
        new VehicleInfo(){ Name="亚班尼 皇霸天", Value="emperor" },
        new VehicleInfo(){ Name="亚班尼 皇霸天", Value="emperor2" },
        new VehicleInfo(){ Name="亚班尼 皇霸天", Value="emperor3" },
        new VehicleInfo(){ Name="雪佛 流星", Value="fugitive" },
        new VehicleInfo(){ Name="贝飞特 格伦戴尔", Value="glendale" },
        new VehicleInfo(){ Name="贝飞特 格伦戴尔改装版", Value="glendale2" },
        new VehicleInfo(){ Name="福狮 英卡特", Value="ingot" },
        new VehicleInfo(){ Name="卡林 入侵者", Value="intruder" },
        new VehicleInfo(){ Name="贝飞特 武装礼车", Value="limo2" },
        new VehicleInfo(){ Name="绝致 统领", Value="premier" },
        new VehicleInfo(){ Name="亚班尼 初代", Value="primo" },
        new VehicleInfo(){ Name="亚班尼 初代改装版", Value="primo2" },
        new VehicleInfo(){ Name="敦追里 女皇", Value="regina" },
        new VehicleInfo(){ Name="绝品 莱茵哈特", Value="rhinehart" },
        new VehicleInfo(){ Name="烈火马 钢骨灵车", Value="romero" },
        new VehicleInfo(){ Name="贝飞特 莎夫特", Value="schafter2" },
        new VehicleInfo(){ Name="贝飞特 莎夫特 V12（装甲版）", Value="schafter5" },
        new VehicleInfo(){ Name="贝飞特 长轴莎夫特（装甲版）", Value="schafter6" },
        new VehicleInfo(){ Name="埃努斯 斯塔福德", Value="stafford" },
        new VehicleInfo(){ Name="威皮 史塔尼亚", Value="stanier" },
        new VehicleInfo(){ Name="赛柯尼 地层先锋", Value="stratum" },
        new VehicleInfo(){ Name="敦追里 加长型礼车", Value="stretch" },
        new VehicleInfo(){ Name="埃努斯 金钻耀星", Value="superd" },
        new VehicleInfo(){ Name="雪佛 奔腾", Value="surge" },
        new VehicleInfo(){ Name="奥北 密探", Value="tailgater" },
        new VehicleInfo(){ Name="奥北 密探 S", Value="tailgater2" },
        new VehicleInfo(){ Name="福狮 守护星", Value="warrener" },
        new VehicleInfo(){ Name="福狮 守护星 HKR", Value="warrener2" },
        new VehicleInfo(){ Name="亚班尼 华盛顿", Value="washington" },
    };

    /// <summary>
    /// 2 当前分类: SUV
    /// </summary>
    public static readonly List<VehicleInfo> SUVs = new()
    {
        new VehicleInfo(){ Name="菲斯特 宇航", Value="astron" },
        new VehicleInfo(){ Name="悠游 行者", Value="baller" },
        new VehicleInfo(){ Name="悠游 行者", Value="baller2" },
        new VehicleInfo(){ Name="悠游 行者 LE", Value="baller3" },
        new VehicleInfo(){ Name="悠游 长轴行者 LE", Value="baller4" },
        new VehicleInfo(){ Name="悠游 行者 LE（装甲版）", Value="baller5" },
        new VehicleInfo(){ Name="悠游 长轴行者 LE（装甲版）", Value="baller6" },
        new VehicleInfo(){ Name="悠游 行者 ST", Value="baller7" },
        new VehicleInfo(){ Name="卡林 碧杰 XL", Value="bjxl" },
        new VehicleInfo(){ Name="亚班尼 骑兵", Value="cavalcade" },
        new VehicleInfo(){ Name="亚班尼 骑兵", Value="cavalcade2" },
        new VehicleInfo(){ Name="威皮 争夺者", Value="contender" },
        new VehicleInfo(){ Name="贝飞特 迪布达", Value="dubsta" },
        new VehicleInfo(){ Name="贝飞特 迪布达", Value="dubsta2" },
        new VehicleInfo(){ Name="深水 FQ 2", Value="fq2" },
        new VehicleInfo(){ Name="绝致 屌王", Value="granger" },
        new VehicleInfo(){ Name="绝致 屌王 3600LX", Value="granger2" },
        new VehicleInfo(){ Name="冒险家 情欲猎手", Value="gresley" },
        new VehicleInfo(){ Name="皇霸天 哈拔尼禄", Value="habanero" },
        new VehicleInfo(){ Name="埃努斯 亨特利 S", Value="huntley" },
        new VehicleInfo(){ Name="威尼 天威拉力", Value="issi8" },
        new VehicleInfo(){ Name="奥北 爱瓦根", Value="iwagen" },
        new VehicleInfo(){ Name="埃努斯 吉伯力", Value="jubilee" },
        new VehicleInfo(){ Name="敦追里 追捕者", Value="landstalker" },
        new VehicleInfo(){ Name="敦追里 追捕者 XL", Value="landstalker2" },
        new VehicleInfo(){ Name="卡尼斯 炎魔", Value="mesa" },
        new VehicleInfo(){ Name="卡尼斯 炎魔", Value="mesa2" },
        new VehicleInfo(){ Name="兰帕达缇 诺瓦克", Value="novak" },
        new VehicleInfo(){ Name="巨象 爱国者", Value="patriot" },
        new VehicleInfo(){ Name="巨象 爱国者加长型", Value="patriot2" },
        new VehicleInfo(){ Name="威皮 辐光", Value="radi" },
        new VehicleInfo(){ Name="绝品 瑞巴 GTS", Value="rebla" },
        new VehicleInfo(){ Name="奥北 小辣椒", Value="rocoto" },
        new VehicleInfo(){ Name="卡尼斯 陆上专家", Value="seminole" },
        new VehicleInfo(){ Name="卡尼斯 陆上专家边境", Value="seminole2" },
        new VehicleInfo(){ Name="贝飞特 瑟雷诺", Value="serrano" },
        new VehicleInfo(){ Name="巨象 列兵", Value="squaddie" },
        new VehicleInfo(){ Name="佩嘉西 奔牛", Value="toros" },
        new VehicleInfo(){ Name="贝飞特 XLS", Value="xls" },
        new VehicleInfo(){ Name="贝飞特 XLS(装甲版)", Value="xls2" },
    };

    /// <summary>
    /// 3 当前分类: 轿跑车
    /// </summary>
    public static readonly List<VehicleInfo> Coupes = new()
    {
        new VehicleInfo(){ Name="埃努斯 至尊慧眼敞篷版", Value="cogcabrio" },
        new VehicleInfo(){ Name="浪子 典范", Value="exemplar" },
        new VehicleInfo(){ Name="欧斯洛 F620", Value="f620" },
        new VehicleInfo(){ Name="兰帕达缇 恶龙", Value="felon" },
        new VehicleInfo(){ Name="兰帕达缇 恶龙 GT", Value="felon2" },
        new VehicleInfo(){ Name="欧斯洛 胡狼", Value="jackal" },
        new VehicleInfo(){ Name="丁卡 羽黑 SJ", Value="kanjosj" },
        new VehicleInfo(){ Name="绝品 先知 XS", Value="oracle" },
        new VehicleInfo(){ Name="绝品 先知", Value="oracle2" },
        new VehicleInfo(){ Name="丁卡 后奏", Value="postlude" },
        new VehicleInfo(){ Name="卡林 普莱温", Value="previon" },
        new VehicleInfo(){ Name="绝品 卫士 XS", Value="sentinel" },
        new VehicleInfo(){ Name="绝品 卫士", Value="sentinel2" },
        new VehicleInfo(){ Name="埃努斯 温莎", Value="windsor" },
        new VehicleInfo(){ Name="埃努斯 温莎敞篷版", Value="windsor2" },
        new VehicleInfo(){ Name="绝品 绝品天堂", Value="zion" },
        new VehicleInfo(){ Name="绝品 绝品天堂敞篷版", Value="zion2" },
    };

    /// <summary>
    /// 4 当前分类: 肌肉车
    /// </summary>
    public static readonly List<VehicleInfo> Muscle = new()
    {
        new VehicleInfo(){ Name="威皮 刀锋", Value="blade" },
        new VehicleInfo(){ Name="卡拉斯科 百老汇", Value="broadway" },
        new VehicleInfo(){ Name="亚班尼 风流海盗", Value="buccaneer" },
        new VehicleInfo(){ Name="亚班尼 风流海盗改装版", Value="buccaneer2" },
        new VehicleInfo(){ Name="冒险家 猛牛 STX", Value="buffalo4" },
        new VehicleInfo(){ Name="威皮 奇诺", Value="chino" },
        new VehicleInfo(){ Name="威皮 奇诺改装版", Value="chino2" },
        new VehicleInfo(){ Name="威皮 克里克", Value="clique" },
        new VehicleInfo(){ Name="非凡 艳妇黑鳍", Value="coquette3" },
        new VehicleInfo(){ Name="赛乐斯特 异类", Value="deviant" },
        new VehicleInfo(){ Name="威皮 公路霸者", Value="dominator" },
        new VehicleInfo(){ Name="威皮 尿汤啤公路霸者", Value="dominator2" },
        new VehicleInfo(){ Name="威皮 公路霸者 GTX", Value="dominator3" },
        new VehicleInfo(){ Name="威皮 末日公路霸者", Value="dominator4" },
        new VehicleInfo(){ Name="威皮 科幻公路霸者", Value="dominator5" },
        new VehicleInfo(){ Name="威皮 梦魇公路霸者", Value="dominator6" },
        new VehicleInfo(){ Name="威皮 公路霸者 ASP", Value="dominator7" },
        new VehicleInfo(){ Name="威皮 公路霸者 GTT", Value="dominator8" },
        new VehicleInfo(){ Name="英庞提 公爵", Value="dukes" },
        new VehicleInfo(){ Name="英庞提 死亡公爵", Value="dukes2" },
        new VehicleInfo(){ Name="英庞提 比特公爵", Value="dukes3" },
        new VehicleInfo(){ Name="威皮 爱利", Value="ellie" },
        new VehicleInfo(){ Name="威拉德 尤朵拉", Value="eudora" },
        new VehicleInfo(){ Name="威拉德 宗派", Value="faction" },
        new VehicleInfo(){ Name="威拉德 宗派改装版", Value="faction2" },
        new VehicleInfo(){ Name="威拉德 宗派改装巨轮版", Value="faction3" },
        new VehicleInfo(){ Name="冒险家 铁腕", Value="gauntlet" },
        new VehicleInfo(){ Name="冒险家 红木烟业铁腕", Value="gauntlet2" },
        new VehicleInfo(){ Name="冒险家 铁腕经典版", Value="gauntlet3" },
        new VehicleInfo(){ Name="冒险家 铁腕地狱火", Value="gauntlet4" },
        new VehicleInfo(){ Name="冒险家 铁腕经典改装版", Value="gauntlet5" },
        new VehicleInfo(){ Name="冒险家 格林伍德", Value="greenwood" },
        new VehicleInfo(){ Name="亚班尼 赫耳墨斯", Value="hermes" },
        new VehicleInfo(){ Name="威皮 热情使徒", Value="hotknife" },
        new VehicleInfo(){ Name="威皮 赫斯勒", Value="hustler" },
        new VehicleInfo(){ Name="绝致 刺刑官", Value="impaler" },
        new VehicleInfo(){ Name="绝致 末日刺刑官", Value="impaler2" },
        new VehicleInfo(){ Name="绝致 科幻刺刑官", Value="impaler3" },
        new VehicleInfo(){ Name="绝致 梦魇刺刑官", Value="impaler4" },
        new VehicleInfo(){ Name="威皮 末日凯撒大帝", Value="imperator" },
        new VehicleInfo(){ Name="威皮 科幻凯撒大帝", Value="imperator2" },
        new VehicleInfo(){ Name="威皮 梦魇凯撒大帝", Value="imperator3" },
        new VehicleInfo(){ Name="亚班尼 闹鬼灵车", Value="lurcher" },
        new VehicleInfo(){ Name="亚班尼 明日之星改装版", Value="manana2" },
        new VehicleInfo(){ Name="绝致 月光", Value="moonbeam" },
        new VehicleInfo(){ Name="绝致 月光改装版", Value="moonbeam2" },
        new VehicleInfo(){ Name="英庞提 暗夜魅影", Value="nightshade" },
        new VehicleInfo(){ Name="威皮 佩优特古董赛车", Value="peyote2" },
        new VehicleInfo(){ Name="英庞提 不死鸟", Value="phoenix" },
        new VehicleInfo(){ Name="雪佛 斗牛士", Value="picador" },
        new VehicleInfo(){ Name="老爷卡车", Value="ratloader" },
        new VehicleInfo(){ Name="冒险家 老爷货车", Value="ratloader2" },
        new VehicleInfo(){ Name="英庞提 灭世暴徒", Value="ruiner" },
        new VehicleInfo(){ Name="英庞提 灭世暴徒 2000", Value="ruiner2" },
        new VehicleInfo(){ Name="英庞提 灭世暴徒", Value="ruiner3" },
        new VehicleInfo(){ Name="英庞提 灭世暴徒 ZZ-8", Value="ruiner4" },
        new VehicleInfo(){ Name="绝致 军刀涡轮", Value="sabregt" },
        new VehicleInfo(){ Name="绝致 军刀涡轮改装版", Value="sabregt2" },
        new VehicleInfo(){ Name="威皮 大满贯皮卡", Value="slamvan" },
        new VehicleInfo(){ Name="威皮 失落摩托帮大满贯皮卡", Value="slamvan2" },
        new VehicleInfo(){ Name="威皮 大满贯皮卡改装版", Value="slamvan3" },
        new VehicleInfo(){ Name="威皮 末日大满贯皮卡", Value="slamvan4" },
        new VehicleInfo(){ Name="威皮 科幻大满贯皮卡", Value="slamvan5" },
        new VehicleInfo(){ Name="威皮 梦魇大满贯皮卡", Value="slamvan6" },
        new VehicleInfo(){ Name="绝致 种马", Value="stalion" },
        new VehicleInfo(){ Name="绝致 吃得饱汉堡种马", Value="stalion2" },
        new VehicleInfo(){ Name="绝致 塔霍马轿跑车", Value="tahoma" },
        new VehicleInfo(){ Name="绝致 坦帕", Value="tampa" },
        new VehicleInfo(){ Name="绝致 武装坦帕", Value="tampa3" },
        new VehicleInfo(){ Name="绝致 郁金", Value="tulip" },
        new VehicleInfo(){ Name="绝致 郁金 M-100", Value="tulip2" },
        new VehicleInfo(){ Name="绝致 瓦魔狮", Value="vamos" },
        new VehicleInfo(){ Name="绝致 活力够", Value="vigero" },
        new VehicleInfo(){ Name="绝致 活力够 ZX", Value="vigero2" },
        new VehicleInfo(){ Name="亚班尼 室女座", Value="virgo" },
        new VehicleInfo(){ Name="敦追里 经典室女座改装版", Value="virgo2" },
        new VehicleInfo(){ Name="敦追里 经典室女座", Value="virgo3" },
        new VehicleInfo(){ Name="绝致 巫毒改装版", Value="voodoo" },
        new VehicleInfo(){ Name="绝致 巫毒", Value="voodoo2" },
        new VehicleInfo(){ Name="毕福 象鼻虫改装版", Value="weevil2" },
        new VehicleInfo(){ Name="绝致 约塞米蒂", Value="yosemite" },
        new VehicleInfo(){ Name="绝致 漂移约塞米蒂", Value="yosemite2" },
    };

    /// <summary>
    /// 5 当前分类: 经典跑车
    /// </summary>
    public static readonly List<VehicleInfo> SportsClassics = new()
    {
        new VehicleInfo(){ Name="欧斯洛 炽焰", Value="ardent" },
        new VehicleInfo(){ Name="亚班尼 罗斯福", Value="btype" },
        new VehicleInfo(){ Name="亚班尼 科学怪人", Value="btype2" },
        new VehicleInfo(){ Name="亚班尼 罗斯福勇气", Value="btype3" },
        new VehicleInfo(){ Name="兰帕达缇 卡斯科", Value="casco" },
        new VehicleInfo(){ Name="卢恩 切布列克", Value="cheburek" },
        new VehicleInfo(){ Name="古罗帝 猎豹经典版", Value="cheetah2" },
        new VehicleInfo(){ Name="非凡 艳妇经典版", Value="coquette2" },
        new VehicleInfo(){ Name="英庞提 德罗索", Value="deluxo" },
        new VehicleInfo(){ Name="威尼 王朝", Value="dynasty" },
        new VehicleInfo(){ Name="福狮 法加洛亚", Value="fagaloa" },
        new VehicleInfo(){ Name="贝飞特 斯特林 GT", Value="feltzer3" },
        new VehicleInfo(){ Name="古罗帝 GT500", Value="gt500" },
        new VehicleInfo(){ Name="佩嘉西 炼狱魔经典版", Value="infernus2" },
        new VehicleInfo(){ Name="浪子 JB 700", Value="jb700" },
        new VehicleInfo(){ Name="浪子 JB 700W", Value="jb7002" },
        new VehicleInfo(){ Name="绝致 曼巴", Value="mamba" },
        new VehicleInfo(){ Name="亚班尼 明日之星", Value="manana" },
        new VehicleInfo(){ Name="兰帕达缇 米其利 GT", Value="michelli" },
        new VehicleInfo(){ Name="佩嘉西 门罗", Value="monroe" },
        new VehicleInfo(){ Name="福狮 星云涡轮", Value="nebula" },
        new VehicleInfo(){ Name="威皮 佩优特", Value="peyote" },
        new VehicleInfo(){ Name="威皮 佩优特改装版", Value="peyote3" },
        new VehicleInfo(){ Name="兰帕达缇 皮卡乐", Value="pigalle" },
        new VehicleInfo(){ Name="浪子 疾速 GT 经典版", Value="rapidgt3" },
        new VehicleInfo(){ Name="威皮 随行者", Value="retinue" },
        new VehicleInfo(){ Name="威皮 随行者 Mk 2", Value="retinue2" },
        new VehicleInfo(){ Name="爱尼仕 萨维斯特拉", Value="savestra" },
        new VehicleInfo(){ Name="古罗帝 史汀格", Value="stinger" },
        new VehicleInfo(){ Name="古罗帝 史汀格 GT", Value="stingergt" },
        new VehicleInfo(){ Name="欧斯洛 斯特龙伯格", Value="stromberg" },
        new VehicleInfo(){ Name="欧斯洛 放荡者", Value="swinger" },
        new VehicleInfo(){ Name="佩嘉西 图拉尔多", Value="toreador" },
        new VehicleInfo(){ Name="佩嘉西 斗牛", Value="torero" },
        new VehicleInfo(){ Name="绝致 龙卷风", Value="tornado" },
        new VehicleInfo(){ Name="绝致 龙卷风", Value="tornado2" },
        new VehicleInfo(){ Name="绝致 龙卷风", Value="tornado3" },
        new VehicleInfo(){ Name="绝致 龙卷风", Value="tornado4" },
        new VehicleInfo(){ Name="绝致 龙卷风改装版", Value="tornado5" },
        new VehicleInfo(){ Name="绝致 龙卷风破烂老爷车", Value="tornado6" },
        new VehicleInfo(){ Name="古罗帝 远途经典版", Value="turismo2" },
        new VehicleInfo(){ Name="兰帕达缇 维瑟瑞斯", Value="viseris" },
        new VehicleInfo(){ Name="卡林 190z", Value="z190" },
        new VehicleInfo(){ Name="绝品 天堂经典版", Value="zion3" },
        new VehicleInfo(){ Name="特卢菲 Z 型", Value="ztype" },
    };

    /// <summary>
    /// 6 当前分类: 跑车
    /// </summary>
    public static readonly List<VehicleInfo> Sports = new()
    {
        new VehicleInfo(){ Name="亚班尼 阿尔法", Value="alpha" },
        new VehicleInfo(){ Name="冒险家 女妖", Value="banshee" },
        new VehicleInfo(){ Name="古罗帝 野兽 GTS", Value="bestiagts" },
        new VehicleInfo(){ Name="丁卡 小型旅行家", Value="blista2" },
        new VehicleInfo(){ Name="丁卡 冲冲猴旅行家", Value="blista3" },
        new VehicleInfo(){ Name="冒险家 猛牛", Value="buffalo" },
        new VehicleInfo(){ Name="冒险家 猛牛 S", Value="buffalo2" },
        new VehicleInfo(){ Name="冒险家 霜碧猛牛", Value="buffalo3" },
        new VehicleInfo(){ Name="卡林 卡利科 GTF", Value="calico" },
        new VehicleInfo(){ Name="古罗帝 汗血宝马", Value="carbonizzare" },
        new VehicleInfo(){ Name="菲斯特 陆上彗星", Value="comet2" },
        new VehicleInfo(){ Name="菲斯特 陆上彗星怀旧改装版", Value="comet3" },
        new VehicleInfo(){ Name="菲斯特 彗星狩猎者", Value="comet4" },
        new VehicleInfo(){ Name="菲斯特 陆上彗星 SR", Value="comet5" },
        new VehicleInfo(){ Name="菲斯特 陆上彗星 S2", Value="comet6" },
        new VehicleInfo(){ Name="菲斯特 陆上彗星 S2 敞篷版", Value="comet7" },
        new VehicleInfo(){ Name="非凡 艳妇", Value="coquette" },
        new VehicleInfo(){ Name="非凡 艳妇 D10", Value="coquette4" },
        new VehicleInfo(){ Name="兰帕达缇 科西塔", Value="corsita" },
        new VehicleInfo(){ Name="绝品 塞弗", Value="cypher" },
        new VehicleInfo(){ Name="奥北 8F 尾随者", Value="drafter" },
        new VehicleInfo(){ Name="爱尼仕 挽歌怀旧改装版", Value="elegy" },
        new VehicleInfo(){ Name="爱尼仕 挽歌 RH8", Value="elegy2" },
        new VehicleInfo(){ Name="爱尼仕 欧洲", Value="euros" },
        new VehicleInfo(){ Name="卡林 燃轨埃弗伦", Value="everon2" },
        new VehicleInfo(){ Name="贝飞特 飞特者", Value="feltzer2" },
        new VehicleInfo(){ Name="威皮 闪电 GT", Value="flashgt" },
        new VehicleInfo(){ Name="兰帕达缇 沸洛雷 GT", Value="furoregt" },
        new VehicleInfo(){ Name="赛乐斯特 眩光", Value="fusilade" },
        new VehicleInfo(){ Name="卡林 福多", Value="futo" },
        new VehicleInfo(){ Name="卡林 福多 GTX", Value="futo2" },
        new VehicleInfo(){ Name="威皮 GB200", Value="gb200" },
        new VehicleInfo(){ Name="菲斯特 嚎叫者", Value="growler" },
        new VehicleInfo(){ Name="绝致 燃轨军刀", Value="hotring" },
        new VehicleInfo(){ Name="傲弗拉 明日", Value="imorgon" },
        new VehicleInfo(){ Name="威尼 天威跑车版", Value="issi7" },
        new VehicleInfo(){ Name="古罗帝 义塔力 GTO", Value="italigto" },
        new VehicleInfo(){ Name="古罗帝 义塔力 RSX", Value="italirsx" },
        new VehicleInfo(){ Name="丁卡 弄臣", Value="jester" },
        new VehicleInfo(){ Name="丁卡 弄臣（赛车）", Value="jester2" },
        new VehicleInfo(){ Name="丁卡 弄臣经典版", Value="jester3" },
        new VehicleInfo(){ Name="丁卡 弄臣 RR", Value="jester4" },
        new VehicleInfo(){ Name="欧斯洛 扼喉", Value="jugular" },
        new VehicleInfo(){ Name="海岬 变色龙", Value="khamelion" },
        new VehicleInfo(){ Name="兰帕达缇 科莫达", Value="komoda" },
        new VehicleInfo(){ Name="卡林 骷髅马", Value="kuruma" },
        new VehicleInfo(){ Name="卡林 骷髅马（装甲版）", Value="kuruma2" },
        new VehicleInfo(){ Name="欧斯洛 蝗虫", Value="locust" },
        new VehicleInfo(){ Name="欧斯洛 山猫", Value="lynx" },
        new VehicleInfo(){ Name="浪子 马萨克罗", Value="massacro" },
        new VehicleInfo(){ Name="浪子 马萨克罗（赛车）", Value="massacro2" },
        new VehicleInfo(){ Name="维沙 尼欧", Value="neo" },
        new VehicleInfo(){ Name="菲斯特 霓虹", Value="neon" },
        new VehicleInfo(){ Name="奥北 9F", Value="ninef" },
        new VehicleInfo(){ Name="奥北 9F 敞篷版", Value="ninef2" },
        new VehicleInfo(){ Name="奥北 奥姆尼斯", Value="omnis" },
        new VehicleInfo(){ Name="奥北 奥姆尼斯 e-GT", Value="omnisegt" },
        new VehicleInfo(){ Name="苔原 潘瑟力", Value="panthere" },
        new VehicleInfo(){ Name="埃努斯 帕拉贡 R", Value="paragon" },
        new VehicleInfo(){ Name="埃努斯 帕拉贡 R（装甲版）", Value="paragon2" },
        new VehicleInfo(){ Name="欧斯洛 放逐者", Value="pariah" },
        new VehicleInfo(){ Name="麦霸子 半影使者", Value="penumbra" },
        new VehicleInfo(){ Name="麦霸子 半影使者 FF", Value="penumbra2" },
        new VehicleInfo(){ Name="爱尼仕 300R", Value="r300" },
        new VehicleInfo(){ Name="旋风 雷电", Value="raiden" },
        new VehicleInfo(){ Name="浪子 疾速 GT", Value="rapidgt" },
        new VehicleInfo(){ Name="浪子 疾速 GT", Value="rapidgt2" },
        new VehicleInfo(){ Name="毕福 迅猛龙", Value="raptor" },
        new VehicleInfo(){ Name="爱尼仕 雷姆斯", Value="remus" },
        new VehicleInfo(){ Name="绝品 反叛者", Value="revolter" },
        new VehicleInfo(){ Name="丁卡 RT3000", Value="rt3000" },
        new VehicleInfo(){ Name="海岬 拉斯顿", Value="ruston" },
        new VehicleInfo(){ Name="贝飞特 莎夫特 V12", Value="schafter3" },
        new VehicleInfo(){ Name="贝飞特 长轴莎夫特", Value="schafter4" },
        new VehicleInfo(){ Name="贝飞特 撞击 GT", Value="schlagen" },
        new VehicleInfo(){ Name="贝飞特 施瓦兹", Value="schwarzer" },
        new VehicleInfo(){ Name="绝品 卫士经典版", Value="sentinel3" },
        new VehicleInfo(){ Name="绝品 卫士经典宽体版", Value="sentinel4" },
        new VehicleInfo(){ Name="浪子 柒-70", Value="seven70" },
        new VehicleInfo(){ Name="贝飞特 SM722", Value="sm722" },
        new VehicleInfo(){ Name="浪子 幽鬼", Value="specter" },
        new VehicleInfo(){ Name="浪子 幽鬼改装版", Value="specter2" },
        new VehicleInfo(){ Name="贝飞特 斯垂特", Value="streiter" },
        new VehicleInfo(){ Name="丁卡 斯国一", Value="sugoi" },
        new VehicleInfo(){ Name="卡林 王者", Value="sultan" },
        new VehicleInfo(){ Name="卡林 王者经典版", Value="sultan2" },
        new VehicleInfo(){ Name="卡林 王者 RS 经典版", Value="sultan3" },
        new VehicleInfo(){ Name="贝飞特 速雷", Value="surano" },
        new VehicleInfo(){ Name="绝致 漂移坦帕", Value="tampa2" },
        new VehicleInfo(){ Name="奥北 10F", Value="tenf" },
        new VehicleInfo(){ Name="奥北 10F 宽体版", Value="tenf2" },
        new VehicleInfo(){ Name="兰帕达缇 逐波雷厉", Value="tropos" },
        new VehicleInfo(){ Name="皇霸天 韦柯特", Value="vectre" },
        new VehicleInfo(){ Name="冒险家 迷失者", Value="verlierer2" },
        new VehicleInfo(){ Name="丁卡 微托经典版", Value="veto" },
        new VehicleInfo(){ Name="丁卡 微托现代版", Value="veto2" },
        new VehicleInfo(){ Name="亚班尼 V-STR", Value="vstr" },
        new VehicleInfo(){ Name="爱尼仕 ZR350", Value="zr350" },
        new VehicleInfo(){ Name="爱尼仕 末日 ZR380", Value="zr380" },
        new VehicleInfo(){ Name="爱尼仕 科幻 ZR380", Value="zr3802" },
        new VehicleInfo(){ Name="爱尼仕 梦魇 ZR380", Value="zr3803" },
    };

    /// <summary>
    /// 7 当前分类: 超级跑车
    /// </summary>
    public static readonly List<VehicleInfo> Super = new()
    {
        new VehicleInfo(){ Name="特卢菲 灵蛇", Value="adder" },
        new VehicleInfo(){ Name="傲弗拉 独裁者", Value="autarch" },
        new VehicleInfo(){ Name="冒险家 女妖 900R", Value="banshee2" },
        new VehicleInfo(){ Name="威皮 子弹", Value="bullet" },
        new VehicleInfo(){ Name="浪子 冠军", Value="champion" },
        new VehicleInfo(){ Name="古罗帝 猎豹", Value="cheetah" },
        new VehicleInfo(){ Name="旋风 飓风", Value="cyclone" },
        new VehicleInfo(){ Name="普林西比 蹂躏者 8", Value="deveste" },
        new VehicleInfo(){ Name="培罗 艾梅鲁斯", Value="emerus" },
        new VehicleInfo(){ Name="傲弗拉 本质 XXR", Value="entity2" },
        new VehicleInfo(){ Name="傲弗拉 本质 MT", Value="entity3" },
        new VehicleInfo(){ Name="傲弗拉 本质 XF", Value="entityxf" },
        new VehicleInfo(){ Name="威皮 FMJ", Value="fmj" },
        new VehicleInfo(){ Name="古罗帝 狂热", Value="furia" },
        new VehicleInfo(){ Name="培罗 GP1", Value="gp1" },
        new VehicleInfo(){ Name="佩嘉西 伊格纳斯", Value="ignus" },
        new VehicleInfo(){ Name="佩嘉西 炼狱魔", Value="infernus" },
        new VehicleInfo(){ Name="培罗 义塔力 GTB", Value="italigtb" },
        new VehicleInfo(){ Name="培罗 义塔力 GTB 改装版", Value="italigtb2" },
        new VehicleInfo(){ Name="贝飞特 武夫", Value="krieger" },
        new VehicleInfo(){ Name="爱尼仕 RE-7B", Value="le7b" },
        new VehicleInfo(){ Name="贝飞特 LM87", Value="lm87" },
        new VehicleInfo(){ Name="特卢菲 尼罗", Value="nero" },
        new VehicleInfo(){ Name="特卢菲 尼罗改装版", Value="nero2" },
        new VehicleInfo(){ Name="佩嘉西 奥西里斯", Value="osiris" },
        new VehicleInfo(){ Name="欧斯洛 穿刺者", Value="penetrator" },
        new VehicleInfo(){ Name="菲斯特 811", Value="pfister811" },
        new VehicleInfo(){ Name="古罗帝 X80 原型", Value="prototipo" },
        new VehicleInfo(){ Name="佩嘉西 死神", Value="reaper" },
        new VehicleInfo(){ Name="爱尼仕 S80RR", Value="s80" },
        new VehicleInfo(){ Name="绝品 SC1", Value="sc1" },
        new VehicleInfo(){ Name="绝致 超燃", Value="scramjet" },
        new VehicleInfo(){ Name="皇霸天 ETR1", Value="sheava" },
        new VehicleInfo(){ Name="卡林 王者 RS", Value="sultanrs" },
        new VehicleInfo(){ Name="培罗 T20", Value="t20" },
        new VehicleInfo(){ Name="雪佛 泰斑", Value="taipan" },
        new VehicleInfo(){ Name="佩嘉西 风暴", Value="tempesta" },
        new VehicleInfo(){ Name="佩嘉西 泰泽拉克", Value="tezeract" },
        new VehicleInfo(){ Name="特卢菲 特拉克斯", Value="thrax" },
        new VehicleInfo(){ Name="兰帕达缇 虎狮兽", Value="tigon" },
        new VehicleInfo(){ Name="佩嘉西 斗牛 XO", Value="torero2" },
        new VehicleInfo(){ Name="古罗帝 远途 R", Value="turismor" },
        new VehicleInfo(){ Name="傲弗拉 统治者", Value="tyrant" },
        new VehicleInfo(){ Name="培罗 泰勒斯", Value="tyrus" },
        new VehicleInfo(){ Name="佩嘉西 狂牛", Value="vacca" },
        new VehicleInfo(){ Name="浪子 瓦格纳", Value="vagner" },
        new VehicleInfo(){ Name="义警", Value="vigilante" },
        new VehicleInfo(){ Name="欧斯洛 美德", Value="virtue" },
        new VehicleInfo(){ Name="古罗帝 幻象", Value="visione" },
        new VehicleInfo(){ Name="旋风 狂雷", Value="voltic" },
        new VehicleInfo(){ Name="旋风 火箭狂雷", Value="voltic2" },
        new VehicleInfo(){ Name="欧斯洛 XA-21", Value="xa21" },
        new VehicleInfo(){ Name="傲弗拉 捷诺", Value="zeno" },
        new VehicleInfo(){ Name="佩嘉西 桑托劳", Value="zentorno" },
        new VehicleInfo(){ Name="佩嘉西 佐路索", Value="zorrusso" },
    };

    /// <summary>
    /// 8 当前分类: 摩托车
    /// </summary>
    public static readonly List<VehicleInfo> Motorcycles = new()
    {
        new VehicleInfo(){ Name="丁卡 街头恶魔", Value="akuma" },
        new VehicleInfo(){ Name="LCC 阿瓦鲁斯", Value="avarus" },
        new VehicleInfo(){ Name="西部 驮兽", Value="bagger" },
        new VehicleInfo(){ Name="佩嘉西 801 巴提", Value="bati" },
        new VehicleInfo(){ Name="佩嘉西 801RR 巴提", Value="bati2" },
        new VehicleInfo(){ Name="长崎 BF400", Value="bf400" },
        new VehicleInfo(){ Name="长崎 碳纤 RS 型", Value="carbonrs" },
        new VehicleInfo(){ Name="长崎 奇美拉", Value="chimera" },
        new VehicleInfo(){ Name="西部 高潮", Value="cliffhanger" },
        new VehicleInfo(){ Name="西部 恶魔", Value="daemon" },
        new VehicleInfo(){ Name="西部 恶魔", Value="daemon2" },
        new VehicleInfo(){ Name="西部 末日丧尸", Value="deathbike" },
        new VehicleInfo(){ Name="西部 科幻丧尸", Value="deathbike2" },
        new VehicleInfo(){ Name="西部 梦魇丧尸", Value="deathbike3" },
        new VehicleInfo(){ Name="诗津 亵渎者", Value="defiler" },
        new VehicleInfo(){ Name="普林西比 蒂雅布萝", Value="diablous" },
        new VehicleInfo(){ Name="普林西比 蒂雅布萝改装版", Value="diablous2" },
        new VehicleInfo(){ Name="丁卡 双 T", Value="double" },
        new VehicleInfo(){ Name="丁卡 恩斗罗", Value="enduro" },
        new VehicleInfo(){ Name="佩嘉西 爱时吉", Value="esskey" },
        new VehicleInfo(){ Name="佩嘉西 费甲欧现代版", Value="faggio" },
        new VehicleInfo(){ Name="佩嘉西 费甲欧", Value="faggio2" },
        new VehicleInfo(){ Name="佩嘉西 费甲欧摩登版", Value="faggio3" },
        new VehicleInfo(){ Name="佩嘉西 FCR 1000", Value="fcr" },
        new VehicleInfo(){ Name="佩嘉西 FCR 1000 改装版", Value="fcr2" },
        new VehicleInfo(){ Name="西部 石像鬼", Value="gargoyle" },
        new VehicleInfo(){ Name="诗津 白鸟", Value="hakuchou" },
        new VehicleInfo(){ Name="诗津 白鸟竞速版", Value="hakuchou2" },
        new VehicleInfo(){ Name="LCC 迷魅光轮", Value="hexer" },
        new VehicleInfo(){ Name="LCC 创新", Value="innovation" },
        new VehicleInfo(){ Name="普林西比 雷克卓", Value="lectro" },
        new VehicleInfo(){ Name="麦霸子 曼切兹", Value="manchez" },
        new VehicleInfo(){ Name="麦霸子 曼切兹侦查", Value="manchez2" },
        new VehicleInfo(){ Name="麦霸子 曼切兹侦查 C", Value="manchez3" },
        new VehicleInfo(){ Name="普林西比 复仇女神", Value="nemesis" },
        new VehicleInfo(){ Name="西部 夜刃", Value="nightblade" },
        new VehicleInfo(){ Name="佩嘉西 暴君", Value="oppressor" },
        new VehicleInfo(){ Name="佩嘉西 暴君 Mk 2", Value="oppressor2" },
        new VehicleInfo(){ Name="诗津 PCJ 600", Value="pcj" },
        new VehicleInfo(){ Name="西部 电涌", Value="powersurge" },
        new VehicleInfo(){ Name="西部 破烂摩托车", Value="ratbike" },
        new VehicleInfo(){ Name="西部 里弗", Value="reever" },
        new VehicleInfo(){ Name="西部 狂暴火箭", Value="rrocket" },
        new VehicleInfo(){ Name="佩嘉西 恶霸", Value="ruffian" },
        new VehicleInfo(){ Name="麦霸子 桑切斯（涂装版）", Value="sanchez" },
        new VehicleInfo(){ Name="麦霸子 桑切斯", Value="sanchez2" },
        new VehicleInfo(){ Name="LCC 圣驹", Value="sanctus" },
        new VehicleInfo(){ Name="长崎 信奴比", Value="shinobi" },
        new VehicleInfo(){ Name="长崎 圣太郎", Value="shotaro" },
        new VehicleInfo(){ Name="西部 君主", Value="sovereign" },
        new VehicleInfo(){ Name="长崎 斯特德", Value="stryder" },
        new VehicleInfo(){ Name="丁卡 猛冲", Value="thrust" },
        new VehicleInfo(){ Name="诗津 威德", Value="vader" },
        new VehicleInfo(){ Name="丁卡 审判者", Value="vindicator" },
        new VehicleInfo(){ Name="佩嘉西 漩涡", Value="vortex" },
        new VehicleInfo(){ Name="西部 恶狼克星", Value="wolfsbane" },
        new VehicleInfo(){ Name="西部 鞭尸者", Value="zombiea" },
        new VehicleInfo(){ Name="西部 碎尸者", Value="zombieb" },
    };

    /// <summary>
    /// 9 当前分类: 越野车
    /// </summary>
    public static readonly List<VehicleInfo> OffRoad = new()
    {
        new VehicleInfo(){ Name="毕福 沙丘征服者", Value="bfinjection" },
        new VehicleInfo(){ Name="毕福 必浮塔", Value="bifta" },
        new VehicleInfo(){ Name="长崎 烈焰", Value="blazer" },
        new VehicleInfo(){ Name="长崎 烈焰救生型", Value="blazer2" },
        new VehicleInfo(){ Name="长崎 火辣烈焰", Value="blazer3" },
        new VehicleInfo(){ Name="长崎 街头烈焰", Value="blazer4" },
        new VehicleInfo(){ Name="长崎 水陆烈焰骑士", Value="blazer5" },
        new VehicleInfo(){ Name="卡尼斯 万用行者", Value="bodhi2" },
        new VehicleInfo(){ Name="卡林 粗人", Value="boor" },
        new VehicleInfo(){ Name="旋风 斗殴者", Value="brawler" },
        new VehicleInfo(){ Name="贝飞特 末日捍士", Value="bruiser" },
        new VehicleInfo(){ Name="贝飞特 科幻捍士", Value="bruiser2" },
        new VehicleInfo(){ Name="贝飞特 梦魇捍士", Value="bruiser3" },
        new VehicleInfo(){ Name="绝致 末日布鲁图斯", Value="brutus" },
        new VehicleInfo(){ Name="绝致 科幻布鲁图斯", Value="brutus2" },
        new VehicleInfo(){ Name="绝致 梦魇布鲁图斯", Value="brutus3" },
        new VehicleInfo(){ Name="威皮 卡拉卡拉", Value="caracara" },
        new VehicleInfo(){ Name="威皮 卡拉卡拉四驱车", Value="caracara2" },
        new VehicleInfo(){ Name="冒险家 越野游侠", Value="dloader" },
        new VehicleInfo(){ Name="绝致 德劳古尔", Value="draugur" },
        new VehicleInfo(){ Name="贝飞特 迪布达 6x6", Value="dubsta3" },
        new VehicleInfo(){ Name="毕福 沙丘魔宝", Value="dune" },
        new VehicleInfo(){ Name="太空码头工", Value="dune2" },
        new VehicleInfo(){ Name="毕福 沙丘 FAV", Value="dune3" },
        new VehicleInfo(){ Name="斜面魔宝", Value="dune4" },
        new VehicleInfo(){ Name="斜面魔宝", Value="dune5" },
        new VehicleInfo(){ Name="卡林 埃弗伦", Value="everon" },
        new VehicleInfo(){ Name="卡尼斯 自由攀登者", Value="freecrawler" },
        new VehicleInfo(){ Name="爱尼仕 恶人", Value="hellion" },
        new VehicleInfo(){ Name="HVY 叛乱分子皮卡", Value="insurgent" },
        new VehicleInfo(){ Name="HVY 叛乱分子", Value="insurgent2" },
        new VehicleInfo(){ Name="HVY 叛乱分子皮卡改装版", Value="insurgent3" },
        new VehicleInfo(){ Name="卡尼斯 卡拉哈里", Value="kalahari" },
        new VehicleInfo(){ Name="卡尼斯 卡马乔", Value="kamacho" },
        new VehicleInfo(){ Name="雪佛 马绍尔", Value="marshall" },
        new VehicleInfo(){ Name="HVY 威胁者", Value="menacer" },
        new VehicleInfo(){ Name="卡尼斯 炎魔", Value="mesa3" },
        new VehicleInfo(){ Name="威皮 解放者", Value="monster" },
        new VehicleInfo(){ Name="冒险家 末日大脚怪", Value="monster3" },
        new VehicleInfo(){ Name="冒险家 科幻大脚怪", Value="monster4" },
        new VehicleInfo(){ Name="冒险家 梦魇大脚怪", Value="monster5" },
        new VehicleInfo(){ Name="HVY 夜鲨", Value="nightshark" },
        new VehicleInfo(){ Name="长崎 不法之徒", Value="outlaw" },
        new VehicleInfo(){ Name="巨象 爱国者军用版", Value="patriot3" },
        new VehicleInfo(){ Name="绝致 蓝彻 XL", Value="rancherxl" },
        new VehicleInfo(){ Name="绝致 蓝彻 XL", Value="rancherxl2" },
        new VehicleInfo(){ Name="RC 匪徒", Value="rcbandito" },
        new VehicleInfo(){ Name="卡林 叛逆男女生锈版", Value="rebel" },
        new VehicleInfo(){ Name="卡林 叛逆男女", Value="rebel2" },
        new VehicleInfo(){ Name="威皮 利雅塔", Value="riata" },
        new VehicleInfo(){ Name="威皮 大脚霸王 XL", Value="sandking" },
        new VehicleInfo(){ Name="威皮 大脚霸王 SWB", Value="sandking2" },
        new VehicleInfo(){ Name="卡林 铁尼高", Value="technical" },
        new VehicleInfo(){ Name="卡林 水陆铁尼高", Value="technical2" },
        new VehicleInfo(){ Name="卡林 铁尼高改装版", Value="technical3" },
        new VehicleInfo(){ Name="威皮 越野卡车", Value="trophytruck" },
        new VehicleInfo(){ Name="威皮 沙漠突击", Value="trophytruck2" },
        new VehicleInfo(){ Name="麦克斯韦 流浪者", Value="vagrant" },
        new VehicleInfo(){ Name="丁卡 维鲁斯", Value="verus" },
        new VehicleInfo(){ Name="威皮 威起", Value="winky" },
        new VehicleInfo(){ Name="绝致 约塞米蒂蓝彻", Value="yosemite3" },
        new VehicleInfo(){ Name="卢恩 炸吧", Value="zhaba" },
    };

    /// <summary>
    /// 10 当前分类: 工业用车
    /// </summary>
    public static readonly List<VehicleInfo> Industrial = new()
    {
        new VehicleInfo(){ Name="HVY 推土机", Value="bulldozer" },
        new VehicleInfo(){ Name="HVY 钻洞机", Value="cutter" },
        new VehicleInfo(){ Name="HVY 矿石搬运车", Value="dump" },
        new VehicleInfo(){ Name="MTL 平板拖车", Value="flatbed" },
        new VehicleInfo(){ Name="威皮 守护者", Value="guardian" },
        new VehicleInfo(){ Name="码头装卸车", Value="handler" },
        new VehicleInfo(){ Name="HVY 混凝土搅拌车", Value="mixer" },
        new VehicleInfo(){ Name="HVY 混凝土搅拌车", Value="mixer2" },
        new VehicleInfo(){ Name="乔氏 砂通天", Value="rubble" },
        new VehicleInfo(){ Name="威霸 工地倾卸车", Value="tiptruck" },
        new VehicleInfo(){ Name="工地倾卸车", Value="tiptruck2" },
    };

    /// <summary>
    /// 11 当前分类: 公共事业用车
    /// </summary>
    public static readonly List<VehicleInfo> Utility = new()
    {
        new VehicleInfo(){ Name="行李拖车", Value="airtug" },
        new VehicleInfo(){ Name="军用拖车", Value="armytanker" },
        new VehicleInfo(){ Name="军用拖车", Value="armytrailer" },
        new VehicleInfo(){ Name="军用拖车", Value="armytrailer2" },
        new VehicleInfo(){ Name="草捆拖车", Value="baletrailer" },
        new VehicleInfo(){ Name="拖船", Value="boattrailer" },
        new VehicleInfo(){ Name="高尔夫球车", Value="caddy" },
        new VehicleInfo(){ Name="高尔夫球车", Value="caddy2" },
        new VehicleInfo(){ Name="高尔夫球车", Value="caddy3" },
        new VehicleInfo(){ Name="", Value="docktrailer" },
        new VehicleInfo(){ Name="码头拖车", Value="docktug" },
        new VehicleInfo(){ Name="HVY 叉车", Value="forklift" },
        new VehicleInfo(){ Name="", Value="freighttrailer" },
        new VehicleInfo(){ Name="", Value="graintrailer" },
        new VehicleInfo(){ Name="割草车", Value="mower" },
        new VehicleInfo(){ Name="", Value="proptrailer" },
        new VehicleInfo(){ Name="拖车", Value="raketrailer" },
        new VehicleInfo(){ Name="机场牵引车", Value="ripley" },
        new VehicleInfo(){ Name="威皮 沙德勒", Value="sadler" },
        new VehicleInfo(){ Name="威皮 沙德勒", Value="sadler2" },
        new VehicleInfo(){ Name="废五金回收车", Value="scrap" },
        new VehicleInfo(){ Name="威皮 大满贯卡车", Value="slamtruck" },
        new VehicleInfo(){ Name="拖车", Value="tanker" },
        new VehicleInfo(){ Name="", Value="tanker2" },
        new VehicleInfo(){ Name="拖吊车", Value="towtruck" },
        new VehicleInfo(){ Name="拖吊车", Value="towtruck2" },
        new VehicleInfo(){ Name="拖车", Value="tr2" },
        new VehicleInfo(){ Name="拖车", Value="tr3" },
        new VehicleInfo(){ Name="拖车", Value="tr4" },
        new VehicleInfo(){ Name="老式拖拉机", Value="tractor" },
        new VehicleInfo(){ Name="斯坦利 农耕机", Value="tractor2" },
        new VehicleInfo(){ Name="斯坦利 农耕机", Value="tractor3" },
        new VehicleInfo(){ Name="机动作战中心", Value="trailerlarge" },
        new VehicleInfo(){ Name="拖车", Value="trailerlogs" },
        new VehicleInfo(){ Name="拖车", Value="trailers" },
        new VehicleInfo(){ Name="拖车", Value="trailers2" },
        new VehicleInfo(){ Name="拖车", Value="trailers3" },
        new VehicleInfo(){ Name="拖车", Value="trailers4" },
        new VehicleInfo(){ Name="拖车", Value="trailersmall" },
        new VehicleInfo(){ Name="拖车", Value="trflat" },
        new VehicleInfo(){ Name="拖车", Value="tvtrailer" },
        new VehicleInfo(){ Name="公共事业卡车", Value="utillitruck" },
        new VehicleInfo(){ Name="公共事业卡车", Value="utillitruck2" },
        new VehicleInfo(){ Name="公共事业卡车", Value="utillitruck3" },
    };

    /// <summary>
    /// 12 当前分类: 厢型车
    /// </summary>
    public static readonly List<VehicleInfo> Vans = new()
    {
        new VehicleInfo(){ Name="冒险家 野牛", Value="bison" },
        new VehicleInfo(){ Name="冒险家 野牛", Value="bison2" },
        new VehicleInfo(){ Name="冒险家 野牛", Value="bison3" },
        new VehicleInfo(){ Name="威皮 雄猫 XL", Value="bobcatxl" },
        new VehicleInfo(){ Name="威霸 厢村", Value="boxville" },
        new VehicleInfo(){ Name="厢村", Value="boxville2" },
        new VehicleInfo(){ Name="威霸 厢村", Value="boxville3" },
        new VehicleInfo(){ Name="威霸 厢村", Value="boxville4" },
        new VehicleInfo(){ Name="装甲版厢村", Value="boxville5" },
        new VehicleInfo(){ Name="绝致 屌客", Value="burrito" },
        new VehicleInfo(){ Name="绝致 除虫大师屌客", Value="burrito2" },
        new VehicleInfo(){ Name="绝致 屌客", Value="burrito3" },
        new VehicleInfo(){ Name="绝致 屌客", Value="burrito4" },
        new VehicleInfo(){ Name="绝致 屌客", Value="burrito5" },
        new VehicleInfo(){ Name="威霸 露营车", Value="camper" },
        new VehicleInfo(){ Name="绝致 屌客帮派版", Value="gburrito" },
        new VehicleInfo(){ Name="绝致 屌客帮派版", Value="gburrito2" },
        new VehicleInfo(){ Name="赛柯尼 安旅者", Value="journey" },
        new VehicleInfo(){ Name="赛柯尼 安旅者 2", Value="journey2" },
        new VehicleInfo(){ Name="威皮 迷你厢型车", Value="minivan" },
        new VehicleInfo(){ Name="威皮 迷你厢型车改装版", Value="minivan2" },
        new VehicleInfo(){ Name="冒险家 天堂", Value="paradise" },
        new VehicleInfo(){ Name="威霸 小马", Value="pony" },
        new VehicleInfo(){ Name="威霸 小马", Value="pony2" },
        new VehicleInfo(){ Name="冒险家 澜波", Value="rumpo" },
        new VehicleInfo(){ Name="冒险家 澜波", Value="rumpo2" },
        new VehicleInfo(){ Name="冒险家 澜波改装版", Value="rumpo3" },
        new VehicleInfo(){ Name="威皮 劲速", Value="speedo" },
        new VehicleInfo(){ Name="威皮 小丑花车", Value="speedo2" },
        new VehicleInfo(){ Name="威皮 劲速改装版", Value="speedo4" },
        new VehicleInfo(){ Name="毕福 乘风", Value="surfer" },
        new VehicleInfo(){ Name="毕福 乘风", Value="surfer2" },
        new VehicleInfo(){ Name="毕福 乘风改装版", Value="surfer3" },
        new VehicleInfo(){ Name="玉米饼餐车", Value="taco" },
        new VehicleInfo(){ Name="冒险家 游侠", Value="youga" },
        new VehicleInfo(){ Name="冒险家 游侠经典版", Value="youga2" },
        new VehicleInfo(){ Name="冒险家 游侠经典四驱车", Value="youga3" },
        new VehicleInfo(){ Name="威皮 游侠改装版", Value="youga4" },
    };

    /// <summary>
    /// 13 当前分类: 自行车
    /// </summary>
    public static readonly List<VehicleInfo> Cycles = new()
    {
        new VehicleInfo(){ Name="BMX", Value="bmx" },
        new VehicleInfo(){ Name="巡航者", Value="cruiser" },
        new VehicleInfo(){ Name="费斯特", Value="fixter" },
        new VehicleInfo(){ Name="先驱者", Value="scorcher" },
        new VehicleInfo(){ Name="惠比特竞速自行车", Value="tribike" },
        new VehicleInfo(){ Name="极限耐力竞速自行车", Value="tribike2" },
        new VehicleInfo(){ Name="特莱赛可竞速自行车", Value="tribike3" },
    };

    /// <summary>
    /// 14 当前分类: 船
    /// </summary>
    public static readonly List<VehicleInfo> Boats = new()
    {
        new VehicleInfo(){ Name="海怪 阿维萨", Value="avisa" },
        new VehicleInfo(){ Name="长崎 小艇", Value="dinghy" },
        new VehicleInfo(){ Name="长崎 小艇", Value="dinghy2" },
        new VehicleInfo(){ Name="长崎 小艇", Value="dinghy3" },
        new VehicleInfo(){ Name="长崎 小艇", Value="dinghy4" },
        new VehicleInfo(){ Name="长崎 武装小艇", Value="dinghy5" },
        new VehicleInfo(){ Name="诗津 极限快艇", Value="jetmax" },
        new VehicleInfo(){ Name="卢恩 虎鲸", Value="kosatka" },
        new VehicleInfo(){ Name="诗津 长鳍", Value="longfin" },
        new VehicleInfo(){ Name="丁卡 水上侯爵", Value="marquis" },
        new VehicleInfo(){ Name="库尔兹 31 巡逻艇", Value="patrolboat" },
        new VehicleInfo(){ Name="警用追猎快艇", Value="predator" },
        new VehicleInfo(){ Name="水上枭雄 海鲨摩托艇", Value="seashark" },
        new VehicleInfo(){ Name="水上枭雄 海鲨摩托艇", Value="seashark2" },
        new VehicleInfo(){ Name="水上枭雄 海鲨摩托艇", Value="seashark3" },
        new VehicleInfo(){ Name="佩嘉西 飙速", Value="speeder" },
        new VehicleInfo(){ Name="佩嘉西 飙速", Value="speeder2" },
        new VehicleInfo(){ Name="诗津 思快乐快艇", Value="squalo" },
        new VehicleInfo(){ Name="潜水艇", Value="submersible" },
        new VehicleInfo(){ Name="海怪", Value="submersible2" },
        new VehicleInfo(){ Name="诗津 向阳号", Value="suntrap" },
        new VehicleInfo(){ Name="兰帕达缇 公牛", Value="toro" },
        new VehicleInfo(){ Name="兰帕达缇 公牛", Value="toro2" },
        new VehicleInfo(){ Name="诗津 烈阳号", Value="tropic" },
        new VehicleInfo(){ Name="诗津 烈阳号", Value="tropic2" },
        new VehicleInfo(){ Name="拖船", Value="tug" },
    };

    /// <summary>
    /// 15 当前分类: 直升机
    /// </summary>
    public static readonly List<VehicleInfo> Helicopters = new()
    {
        new VehicleInfo(){ Name="阿库拉", Value="akula" },
        new VehicleInfo(){ Name="歼灭者", Value="annihilator" },
        new VehicleInfo(){ Name="歼灭者隐形版", Value="annihilator2" },
        new VehicleInfo(){ Name="秃鹰攻击直升机", Value="buzzard" },
        new VehicleInfo(){ Name="秃鹰直升机", Value="buzzard2" },
        new VehicleInfo(){ Name="运兵直升机", Value="cargobob" },
        new VehicleInfo(){ Name="运兵直升机", Value="cargobob2" },
        new VehicleInfo(){ Name="运兵直升机", Value="cargobob3" },
        new VehicleInfo(){ Name="运兵直升机", Value="cargobob4" },
        new VehicleInfo(){ Name="白金汉 康纳达", Value="conada" },
        new VehicleInfo(){ Name="穿梭者", Value="frogger" },
        new VehicleInfo(){ Name="穿梭者", Value="frogger2" },
        new VehicleInfo(){ Name="长崎 浩劫者", Value="havok" },
        new VehicleInfo(){ Name="FH-1 猎杀者", Value="hunter" },
        new VehicleInfo(){ Name="小蛮牛", Value="maverick" },
        new VehicleInfo(){ Name="警用小蛮牛", Value="polmav" },
        new VehicleInfo(){ Name="野蛮人", Value="savage" },
        new VehicleInfo(){ Name="海雀", Value="seasparrow" },
        new VehicleInfo(){ Name="麻雀", Value="seasparrow2" },
        new VehicleInfo(){ Name="麻雀", Value="seasparrow3" },
        new VehicleInfo(){ Name="吊挂直升机", Value="skylift" },
        new VehicleInfo(){ Name="白金汉 超级沃利托", Value="supervolito" },
        new VehicleInfo(){ Name="白金汉 超级沃利托碳纤版", Value="supervolito2" },
        new VehicleInfo(){ Name="白金汉 斯威夫特", Value="swift" },
        new VehicleInfo(){ Name="白金汉 斯威夫特豪华版", Value="swift2" },
        new VehicleInfo(){ Name="女武神", Value="valkyrie" },
        new VehicleInfo(){ Name="女武神 MOD.0", Value="valkyrie2" },
        new VehicleInfo(){ Name="白金汉 弗拉图斯", Value="volatus" },
    };

    /// <summary>
    /// 16 当前分类: 飞机
    /// </summary>
    public static readonly List<VehicleInfo> Planes = new()
    {
        new VehicleInfo(){ Name="RO-86 阿尔科诺斯特", Value="alkonost" },
        new VehicleInfo(){ Name="白金汉 阿尔法-Z1", Value="alphaz1" },
        new VehicleInfo(){ Name="巨象 复仇者", Value="avenger" },
        new VehicleInfo(){ Name="巨象 复仇者", Value="avenger2" },
        new VehicleInfo(){ Name="西部 雀鹰", Value="besra" },
        new VehicleInfo(){ Name="原子飞艇", Value="blimp" },
        new VehicleInfo(){ Name="希罗飞艇", Value="blimp2" },
        new VehicleInfo(){ Name="飞艇", Value="blimp3" },
        new VehicleInfo(){ Name="RM-10 邦布什卡", Value="bombushka" },
        new VehicleInfo(){ Name="货机", Value="cargoplane" },
        new VehicleInfo(){ Name="货机", Value="cargoplane2" },
        new VehicleInfo(){ Name="古邦 800", Value="cuban800" },
        new VehicleInfo(){ Name="巨象 嘟嘟鸟", Value="dodo" },
        new VehicleInfo(){ Name="洒药机", Value="duster" },
        new VehicleInfo(){ Name="白金汉 霍华德 NX-25", Value="howard" },
        new VehicleInfo(){ Name="巨象 九头蛇", Value="hydra" },
        new VehicleInfo(){ Name="喷气机", Value="jet" },
        new VehicleInfo(){ Name="P-996 天煞", Value="lazer" },
        new VehicleInfo(){ Name="白金汉 乐梭", Value="luxor" },
        new VehicleInfo(){ Name="白金汉 乐梭豪华版", Value="luxor2" },
        new VehicleInfo(){ Name="天行巨兽", Value="mammatus" },
        new VehicleInfo(){ Name="长崎 鸿毛", Value="microlight" },
        new VehicleInfo(){ Name="白金汉 军用喷气机", Value="miljet" },
        new VehicleInfo(){ Name="巨象 莫古尔", Value="mogul" },
        new VehicleInfo(){ Name="V-65 莫洛托克", Value="molotok" },
        new VehicleInfo(){ Name="白金汉 灵气号", Value="nimbus" },
        new VehicleInfo(){ Name="P-45 诺克塔", Value="nokota" },
        new VehicleInfo(){ Name="白金汉 狂焰", Value="pyro" },
        new VehicleInfo(){ Name="西部 恶徒", Value="rogue" },
        new VehicleInfo(){ Name="西部 海风", Value="seabreeze" },
        new VehicleInfo(){ Name="白金汉 夏玛尔客机", Value="shamal" },
        new VehicleInfo(){ Name="LF-22 星椋", Value="starling" },
        new VehicleInfo(){ Name="B-11 突击部队", Value="strikeforce" },
        new VehicleInfo(){ Name="野鸭", Value="stunt" },
        new VehicleInfo(){ Name="泰坦号", Value="titan" },
        new VehicleInfo(){ Name="巨象 图拉", Value="tula" },
        new VehicleInfo(){ Name="梅杜莎", Value="velum" },
        new VehicleInfo(){ Name="梅杜莎 5 座", Value="velum2" },
        new VehicleInfo(){ Name="白金汉 威斯特拉", Value="vestra" },
        new VehicleInfo(){ Name="沃拉托", Value="volatol" },
    };

    /// <summary>
    /// 17 当前分类: 服务用车
    /// </summary>
    public static readonly List<VehicleInfo> Service = new()
    {
        new VehicleInfo(){ Name="机场巴士", Value="airbus" },
        new VehicleInfo(){ Name="MTL 布里凯德", Value="brickade" },
        new VehicleInfo(){ Name="MTL 布里凯德 6x6", Value="brickade2" },
        new VehicleInfo(){ Name="巴士", Value="bus" },
        new VehicleInfo(){ Name="白狗巴士", Value="coach" },
        new VehicleInfo(){ Name="音乐节巴士", Value="pbus2" },
        new VehicleInfo(){ Name="MTL 沙丘", Value="rallytruck" },
        new VehicleInfo(){ Name="租用穿梭巴士", Value="rentalbus" },
        new VehicleInfo(){ Name="出租车", Value="taxi" },
        new VehicleInfo(){ Name="观光巴士", Value="tourbus" },
        new VehicleInfo(){ Name="垃圾大王", Value="trash" },
        new VehicleInfo(){ Name="垃圾大王", Value="trash2" },
        new VehicleInfo(){ Name="MTL 拓荒者", Value="wastelander" },
    };

    /// <summary>
    /// 18 当前分类: 特种车
    /// </summary>
    public static readonly List<VehicleInfo> Emergency = new()
    {
        new VehicleInfo(){ Name="救护车", Value="ambulance" },
        new VehicleInfo(){ Name="FIB", Value="fbi" },
        new VehicleInfo(){ Name="FIB", Value="fbi2" },
        new VehicleInfo(){ Name="MTL 消防车", Value="firetruk" },
        new VehicleInfo(){ Name="绝致 沙滩急救车", Value="lguard" },
        new VehicleInfo(){ Name="移监巴士", Value="pbus" },
        new VehicleInfo(){ Name="警用巡逻车", Value="police" },
        new VehicleInfo(){ Name="警用巡逻车", Value="police2" },
        new VehicleInfo(){ Name="警用巡逻车", Value="police3" },
        new VehicleInfo(){ Name="无标识巡航者", Value="police4" },
        new VehicleInfo(){ Name="警用摩托车", Value="policeb" },
        new VehicleInfo(){ Name="警用蓝彻", Value="policeold1" },
        new VehicleInfo(){ Name="警用公路巡逻车", Value="policeold2" },
        new VehicleInfo(){ Name="警用运输车", Value="policet" },
        new VehicleInfo(){ Name="国家公园警用车", Value="pranger" },
        new VehicleInfo(){ Name="警用防暴车", Value="riot" },
        new VehicleInfo(){ Name="防暴车", Value="riot2" },
        new VehicleInfo(){ Name="警长座车", Value="sheriff" },
        new VehicleInfo(){ Name="警长 SUV", Value="sheriff2" },
    };

    /// <summary>
    /// 19 当前分类: 军用车
    /// </summary>
    public static readonly List<VehicleInfo> Military = new()
    {
        new VehicleInfo(){ Name="HVY APC", Value="apc" },
        new VehicleInfo(){ Name="地霸王", Value="barracks" },
        new VehicleInfo(){ Name="HVY 拖车型地霸王", Value="barracks2" },
        new VehicleInfo(){ Name="地霸王", Value="barracks3" },
        new VehicleInfo(){ Name="巴拉杰", Value="barrage" },
        new VehicleInfo(){ Name="切尔诺伯格", Value="chernobog" },
        new VehicleInfo(){ Name="卡尼斯 傲世铁骑", Value="crusader" },
        new VehicleInfo(){ Name="冒险家 半履战车", Value="halftrack" },
        new VehicleInfo(){ Name="TM-02 可汗贾利", Value="khanjali" },
        new VehicleInfo(){ Name="入侵与说服 坦克", Value="minitank" },
        new VehicleInfo(){ Name="犀牛坦克", Value="rhino" },
        new VehicleInfo(){ Name="HVY 末日圣甲虫", Value="scarab" },
        new VehicleInfo(){ Name="HVY 科幻圣甲虫", Value="scarab2" },
        new VehicleInfo(){ Name="HVY 梦魇圣甲虫", Value="scarab3" },
        new VehicleInfo(){ Name="巨象 推进者", Value="thruster" },
        new VehicleInfo(){ Name="冯·伏厄 防空拖车", Value="trailersmall2" },
        new VehicleInfo(){ Name="维泰尔", Value="vetir" },
    };

    /// <summary>
    /// 20 当前分类: 商用车
    /// </summary>
    public static readonly List<VehicleInfo> Commercial = new()
    {
        new VehicleInfo(){ Name="威皮 班森", Value="benson" },
        new VehicleInfo(){ Name="HVY 倾卸车", Value="biff" },
        new VehicleInfo(){ Name="MTL 末日地狱犬", Value="cerberus" },
        new VehicleInfo(){ Name="MTL 科幻地狱犬", Value="cerberus2" },
        new VehicleInfo(){ Name="MTL 梦魇地狱犬", Value="cerberus3" },
        new VehicleInfo(){ Name="乔氏 搬运者", Value="hauler" },
        new VehicleInfo(){ Name="乔氏 搬运者改装版", Value="hauler2" },
        new VehicleInfo(){ Name="麦霸子 猛骡", Value="mule" },
        new VehicleInfo(){ Name="麦霸子 猛骡", Value="mule2" },
        new VehicleInfo(){ Name="麦霸子 猛骡", Value="mule3" },
        new VehicleInfo(){ Name="麦霸子 猛骡改装版", Value="mule4" },
        new VehicleInfo(){ Name="麦霸子 猛骡", Value="mule5" },
        new VehicleInfo(){ Name="MTL 车辆运送车", Value="packer" },
        new VehicleInfo(){ Name="乔氏 魅影", Value="phantom" },
        new VehicleInfo(){ Name="乔氏 尖锥魅影", Value="phantom2" },
        new VehicleInfo(){ Name="乔氏 魅影改装版", Value="phantom3" },
        new VehicleInfo(){ Name="MTL 跑德", Value="pounder" },
        new VehicleInfo(){ Name="MTL 跑德改装版", Value="pounder2" },
        new VehicleInfo(){ Name="威霸 拦截者", Value="stockade" },
        new VehicleInfo(){ Name="威霸 拦截者", Value="stockade3" },
        new VehicleInfo(){ Name="贝飞特 恐霸", Value="terbyte" },
    };

    /// <summary>
    /// 21 当前分类: 火车
    /// </summary>
    public static readonly List<VehicleInfo> Trains = new()
    {
        new VehicleInfo(){ Name="缆车", Value="cablecar" },
        new VehicleInfo(){ Name="货运列车", Value="freight" },
        new VehicleInfo(){ Name="货运列车", Value="freightcar" },
        new VehicleInfo(){ Name="货运列车", Value="freightcar2" },
        new VehicleInfo(){ Name="货运列车", Value="freightcont1" },
        new VehicleInfo(){ Name="货运列车", Value="freightcont2" },
        new VehicleInfo(){ Name="货运列车", Value="freightgrain" },
        new VehicleInfo(){ Name="货运列车", Value="metrotrain" },
        new VehicleInfo(){ Name="货运列车", Value="tankercar" },
    };

    /// <summary>
    /// 22 当前分类: 开轮式
    /// </summary>
    public static readonly List<VehicleInfo> OpenWheel = new()
    {
        new VehicleInfo(){ Name="培罗 PR4", Value="formula" },
        new VehicleInfo(){ Name="欧斯洛 R88", Value="formula2" },
        new VehicleInfo(){ Name="贝飞特 BR8", Value="openwheel1" },
        new VehicleInfo(){ Name="绝致 DR1", Value="openwheel2" },
    };

    /// <summary>
    /// 载具分类
    /// </summary>
    public static readonly List<VehicleClass> VehicleClasses = new()
    {
        /*
             0 当前分类: 小型汽车
             1 当前分类: 轿车
             2 当前分类: SUV
             3 当前分类: 轿跑车
             4 当前分类: 肌肉车
             5 当前分类: 经典跑车
             6 当前分类: 跑车
             7 当前分类: 超级跑车
             8 当前分类: 摩托车
             9 当前分类: 越野车
            10 当前分类: 工业用车
            11 当前分类: 公共事业用车
            12 当前分类: 厢型车
            13 当前分类: 自行车
            14 当前分类: 船
            15 当前分类: 直升机
            16 当前分类: 飞机
            17 当前分类: 服务用车
            18 当前分类: 特种车
            19 当前分类: 军用车
            20 当前分类: 商用车
            21 当前分类: 火车
            22 当前分类: 开轮式
         */
        new VehicleClass(){ Icon="\xe63b", Name="常用载具", VehicleInfos=Common },
        new VehicleClass(){ Icon="\xe63b", Name="小型汽车", VehicleInfos=Compacts },
        new VehicleClass(){ Icon="\xe63b", Name="轿车", VehicleInfos=Sedans },
        new VehicleClass(){ Icon="\xe63b", Name="SUV", VehicleInfos=SUVs },
        new VehicleClass(){ Icon="\xe63b", Name="轿跑车", VehicleInfos=Coupes },
        new VehicleClass(){ Icon="\xe63b", Name="肌肉车", VehicleInfos=Muscle },
        new VehicleClass(){ Icon="\xe63b", Name="经典跑车", VehicleInfos=SportsClassics },
        new VehicleClass(){ Icon="\xe63b", Name="跑车", VehicleInfos=Sports },
        new VehicleClass(){ Icon="\xe63b", Name="超级跑车", VehicleInfos=Super },
        new VehicleClass(){ Icon="\xe63b", Name="摩托车", VehicleInfos=Motorcycles },
        new VehicleClass(){ Icon="\xe63b", Name="越野车", VehicleInfos=OffRoad },
        new VehicleClass(){ Icon="\xe63b", Name="工业用车", VehicleInfos=Industrial },
        new VehicleClass(){ Icon="\xe63b", Name="公共事业用车", VehicleInfos=Utility },
        new VehicleClass(){ Icon="\xe63b", Name="厢型车", VehicleInfos=Vans },
        new VehicleClass(){ Icon="\xe63b", Name="自行车", VehicleInfos=Cycles },
        new VehicleClass(){ Icon="\xe63b", Name="船", VehicleInfos=Boats },
        new VehicleClass(){ Icon="\xe63b", Name="直升机", VehicleInfos=Helicopters },
        new VehicleClass(){ Icon="\xe63b", Name="飞机", VehicleInfos=Planes },
        new VehicleClass(){ Icon="\xe63b", Name="服务用车", VehicleInfos=Service },
        new VehicleClass(){ Icon="\xe63b", Name="特种车", VehicleInfos=Emergency },
        new VehicleClass(){ Icon="\xe63b", Name="军用车", VehicleInfos=Military },
        new VehicleClass(){ Icon="\xe63b", Name="商用车", VehicleInfos=Commercial },
        new VehicleClass(){ Icon="\xe63b", Name="火车", VehicleInfos=Trains },
        new VehicleClass(){ Icon="\xe63b", Name="开轮式", VehicleInfos=OpenWheel }
    };
}
