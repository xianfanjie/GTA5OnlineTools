namespace GTA5Core.RAGE.Onlines;

public static class OnlineData
{
    public class FlagInfo
    {
        public string Name;
        public int Value;
    }

    public static List<FlagInfo> Blips = new()
    {
        new FlagInfo(){ Name="游艇", Value=455 },
        new FlagInfo(){ Name="CEO仓库", Value=473 },
        new FlagInfo(){ Name="CEO办公室", Value=475 },
        new FlagInfo(){ Name="摩托帮会所", Value=492 },
        new FlagInfo(){ Name="大麻种植场", Value=496 },
        new FlagInfo(){ Name="可卡因工厂", Value=497 },
        new FlagInfo(){ Name="伪证件办公室", Value=498 },
        new FlagInfo(){ Name="冰毒实验室", Value=499 },
        new FlagInfo(){ Name="假钞工厂", Value=500 },
        new FlagInfo(){ Name="CEO载具仓库", Value=524 },
        new FlagInfo(){ Name="地堡", Value=557 },
        new FlagInfo(){ Name="机库", Value=569 },
        new FlagInfo(){ Name="设施", Value=590 },
        new FlagInfo(){ Name="夜总会", Value=614 },
        new FlagInfo(){ Name="恐霸", Value=632 },
        new FlagInfo(){ Name="游戏厅", Value=740 },
        new FlagInfo(){ Name="虎鲸", Value=760 },
        new FlagInfo(){ Name="车友会", Value=777 },
        new FlagInfo(){ Name="事务所", Value=826 },
    };

    public static List<FlagInfo> Sessions = new()
    {
        new FlagInfo(){ Name="离开线上模式", Value=-1 },
        new FlagInfo(){ Name="公共战局", Value=0 },
        new FlagInfo(){ Name="创建公共战局", Value=1 },
        new FlagInfo(){ Name="私人帮会战局", Value=2 },
        new FlagInfo(){ Name="帮会战局", Value=3 },
        new FlagInfo(){ Name="加入好友", Value=9 },
        new FlagInfo(){ Name="私人好友战局", Value=6 },
        new FlagInfo(){ Name="单人战局", Value=10 },
        new FlagInfo(){ Name="仅限邀请战局", Value=11 },
        new FlagInfo(){ Name="加入帮会伙伴", Value=12 },
    };

    public static List<FlagInfo> RPxNs = new()
    {
        new FlagInfo(){ Name="RPx1", Value=1 },
        new FlagInfo(){ Name="RPx2", Value=2 },
        new FlagInfo(){ Name="RPx5", Value=5 },
        new FlagInfo(){ Name="RPx10", Value=10 },
        new FlagInfo(){ Name="RPx20", Value=20 },
        new FlagInfo(){ Name="RPx50", Value=50 },
        new FlagInfo(){ Name="RPx100", Value=100 },
        new FlagInfo(){ Name="RPx500", Value=500 },
        new FlagInfo(){ Name="RPx1000", Value=1000 },
    };

    public static List<FlagInfo> REPxNs = new()
    {
        new FlagInfo(){ Name="REPx1", Value=1 },
        new FlagInfo(){ Name="REPx2", Value=2 },
        new FlagInfo(){ Name="REPx5", Value=5 },
        new FlagInfo(){ Name="REPx10", Value=10 },
        new FlagInfo(){ Name="REPx20", Value=20 },
        new FlagInfo(){ Name="REPx50", Value=50 },
        new FlagInfo(){ Name="REPx100", Value=100 },
        new FlagInfo(){ Name="REPx500", Value=500 },
        new FlagInfo(){ Name="REPx1000", Value=1000 },
    };

    // Set Global_1946791 to 1, otherwise you'll see regular crates.
    // Set Global_1946637 to one of these: 2, 4, 6, 7, 8, 9.
    // Now you'll see the unique cargo in your terrorbyte.

    public static List<FlagInfo> CEOCargos = new()
    {
        new FlagInfo(){ Name="医疗用品", Value=0 },
        new FlagInfo(){ Name="烟酒", Value=1 },
        new FlagInfo(){ Name="古董艺术品", Value=2 },
        new FlagInfo(){ Name="电子产品", Value=3 },
        new FlagInfo(){ Name="武器弹药", Value=4 },
        new FlagInfo(){ Name="迷幻药", Value=5 },
        new FlagInfo(){ Name="宝石", Value=6 },
        new FlagInfo(){ Name="动物材料", Value=7 },
        new FlagInfo(){ Name="仿制品", Value=8 },
        new FlagInfo(){ Name="珠宝", Value=9 },
        new FlagInfo(){ Name="银块", Value=10 },
    };

    public static List<FlagInfo> CEOSpecialCargos = new()
    {
        new FlagInfo(){ Name="古董艺术品（华丽彩蛋）", Value=2 },
        new FlagInfo(){ Name="武器弹药（黄金火神机枪）", Value=4 },
        new FlagInfo(){ Name="宝石（一大颗钻石）", Value=6 },
        new FlagInfo(){ Name="动物材料（稀有皮草）", Value=7 },
        new FlagInfo(){ Name="仿制品（电影胶卷）", Value=8 },
        new FlagInfo(){ Name="珠宝（稀有怀表）", Value=9 },
    };

    public static List<FlagInfo> MerryWeatherServices = new()
    {
        new FlagInfo(){ Name="请求弹药空投", Value=886 },
        new FlagInfo(){ Name="请求重型防弹装甲", Value=896 },
        new FlagInfo(){ Name="请求牛鲨睾酮", Value=894 },
        new FlagInfo(){ Name="请求船只接送", Value=887 },
        new FlagInfo(){ Name="请求直升机接送", Value=888 },
    };

    public static List<FlagInfo> LocalWeathers = new()
    {
        new FlagInfo(){ Name="默认", Value=-1 },
        new FlagInfo(){ Name="格外晴朗", Value=0 },
        new FlagInfo(){ Name="晴朗", Value=1 },
        new FlagInfo(){ Name="多云", Value=2 },
        new FlagInfo(){ Name="阴霾", Value=3 },
        new FlagInfo(){ Name="大雾", Value=4 },
        new FlagInfo(){ Name="阴天", Value=5 },
        new FlagInfo(){ Name="下雨", Value=6 },
        new FlagInfo(){ Name="雷雨", Value=7 },
        new FlagInfo(){ Name="雨转晴", Value=8 },
        new FlagInfo(){ Name="阴雨", Value=9 },
        new FlagInfo(){ Name="下雪", Value=10 },
        new FlagInfo(){ Name="暴雪", Value=11 },
        new FlagInfo(){ Name="小雪", Value=12 },
        new FlagInfo(){ Name="圣诞", Value=13 },
        new FlagInfo(){ Name="万圣节", Value=14 },
    };

    public static List<FlagInfo> ImpactExplosions = new()
    {
        new FlagInfo(){ Name="默认", Value=-1 },
        new FlagInfo(){ Name="手榴弹", Value=0 },
        new FlagInfo(){ Name="榴弹发射器", Value=1 },
        new FlagInfo(){ Name="粘弹", Value=2 },
        new FlagInfo(){ Name="燃烧瓶", Value=3 },
        new FlagInfo(){ Name="火箭弹", Value=4 },
        new FlagInfo(){ Name="坦克炮弹", Value=5 },
        new FlagInfo(){ Name="火球爆炸", Value=6 },
        new FlagInfo(){ Name="汽车爆炸", Value=7 },
        new FlagInfo(){ Name="飞机爆炸", Value=8 },
        new FlagInfo(){ Name="加油站爆炸", Value=9 },
        new FlagInfo(){ Name="摩托车爆炸", Value=10 },
        new FlagInfo(){ Name="蒸汽", Value=11 },
        new FlagInfo(){ Name="火焰", Value=12 },
        new FlagInfo(){ Name="消防栓", Value=13 },
        new FlagInfo(){ Name="燃气罐", Value=14 },
        new FlagInfo(){ Name="小艇", Value=15 },
        new FlagInfo(){ Name="船只", Value=16 },
        new FlagInfo(){ Name="卡车爆炸", Value=17 },
        new FlagInfo(){ Name="MKⅡ爆炸子弹", Value=18 },
        new FlagInfo(){ Name="烟雾弹发射器", Value=19 },
        new FlagInfo(){ Name="烟雾弹", Value=20 },
        new FlagInfo(){ Name="毒气弹", Value=21 },
        new FlagInfo(){ Name="信号弹", Value=22 },
        new FlagInfo(){ Name="带特效的爆炸", Value=23 },
        new FlagInfo(){ Name="灭火器", Value=24 },
        new FlagInfo(){ Name="可调榴弹", Value=25 },
        new FlagInfo(){ Name="火车爆炸", Value=26 },
        new FlagInfo(){ Name="油桶", Value=27 },
        new FlagInfo(){ Name="丙烷", Value=28 },
        new FlagInfo(){ Name="飞艇", Value=29 },
        new FlagInfo(){ Name="火焰 ", Value=30 },
        new FlagInfo(){ Name="油罐车", Value=31 },
        new FlagInfo(){ Name="飞机导弹", Value=32 },
        new FlagInfo(){ Name="汽车导弹", Value=33 },
        new FlagInfo(){ Name="燃油泵", Value=34 },
        new FlagInfo(){ Name="鸟屎", Value=35 },
        new FlagInfo(){ Name="电磁步枪", Value=36 },
        new FlagInfo(){ Name="飞艇爆炸", Value=37 },
        new FlagInfo(){ Name="烟花发射器", Value=38 },
        new FlagInfo(){ Name="雪球", Value=39 },
        new FlagInfo(){ Name="地雷", Value=40 },
        new FlagInfo(){ Name="女武神机炮", Value=41 },
        new FlagInfo(){ Name="游艇防御", Value=42 },
        new FlagInfo(){ Name="爆破筒", Value=43 },
        new FlagInfo(){ Name="汽车炸弹", Value=44 },
        new FlagInfo(){ Name="MK2 定向导弹", Value=45 },
        new FlagInfo(){ Name="APC炮弹", Value=46 },
        new FlagInfo(){ Name="飞机集束炸弹", Value=47 },
        new FlagInfo(){ Name="飞机瓦斯", Value=48 },
        new FlagInfo(){ Name="飞机燃烧弹", Value=49 },
        new FlagInfo(){ Name="飞机炸弹", Value=50 },
        new FlagInfo(){ Name="鱼雷", Value=51 },
        new FlagInfo(){ Name="水下鱼雷", Value=52 },
        new FlagInfo(){ Name="邦布须卡炮", Value=53 },
        new FlagInfo(){ Name="第二集束炸弹", Value=54 },
        new FlagInfo(){ Name="猎杀者连发导弹", Value=55 },
        new FlagInfo(){ Name="FH-1 猎杀者 机炮", Value=56 },
        new FlagInfo(){ Name="流氓大炮", Value=57 },
        new FlagInfo(){ Name="水下地雷", Value=58 },
        new FlagInfo(){ Name="天基炮", Value=59 },
        new FlagInfo(){ Name="轨道炮", Value=60 },
        new FlagInfo(){ Name="MK2爆炸子弹霰弹枪", Value=61 },
        new FlagInfo(){ Name="MK2导弹", Value=62 },
        new FlagInfo(){ Name="武装坦帕迫击炮", Value=63 },
        new FlagInfo(){ Name="追踪地雷", Value=64 },
        new FlagInfo(){ Name="电磁脉冲地雷", Value=65 },
        new FlagInfo(){ Name="尖刺式地雷", Value=66 },
        new FlagInfo(){ Name="感应式地雷", Value=67 },
        new FlagInfo(){ Name="定时地雷", Value=68 },
        new FlagInfo(){ Name="无人机自爆", Value=69 },
        new FlagInfo(){ Name="原子能枪", Value=70 },
        new FlagInfo(){ Name="跳雷", Value=71 },
        new FlagInfo(){ Name="脚本化导弹", Value=72 },
        new FlagInfo(){ Name="潜艇导弹", Value=82 },
        new FlagInfo(){ Name="无伤害爆炸", Value=99 },
    };

    public static List<FlagInfo> VehicleExtras = new()
    {
        new FlagInfo(){ Name="默认", Value=0x00 },
        new FlagInfo(){ Name="载具跳跃", Value=0x20 },
        new FlagInfo(){ Name="火箭推进", Value=0x40 },
        new FlagInfo(){ Name="载具降落伞", Value=0x100 },
        new FlagInfo(){ Name="跳台魔宝", Value=0x200 },
        new FlagInfo(){ Name="载具跳跃+火箭推进", Value=0x60 },
        new FlagInfo(){ Name="载具跳跃+载具降落伞", Value=0x120 },
        new FlagInfo(){ Name="火箭推进+载具降落伞", Value=0x140 },
        new FlagInfo(){ Name="载具跳跃+火箭推进+载具降落伞", Value=0x160 },
        new FlagInfo(){ Name="火箭推进+载具降落伞+跳台魔宝", Value=0x340 },
        new FlagInfo(){ Name="载具跳跃+火箭推进+载具降落伞+跳台魔宝", Value=0x360 },
    };
}
