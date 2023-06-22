using GTA5Core.Native;
using GTA5Core.Offsets;

namespace GTA5Core.Features;

public static class Online
{
    /// <summary>
    /// 线上战局切换
    /// -1, 离开线上模式
    ///  0, 公共战局
    ///  1, 创建公共战局
    ///  2, 私人帮会战局
    ///  3, 帮会战局
    ///  6, 私人好友战局
    ///  9, 加入好友
    /// 10, 单人战局
    /// 11, 仅限邀请战局
    /// 12, 加入帮会伙伴
    /// </summary>
    /// <param name="sessionID">战局ID</param>
    public static void LoadSession(int sessionID)
    {
        Task.Run(async () =>
        {
            Memory.SetForegroundWindow();

            if (sessionID == -1)
            {
                // 离开线上模式需要特殊处理
                Globals.WriteGA(Base.SessionSwitchCache, -1);
            }
            else
            {
                // 正常切换战局，修改战局类型
                Globals.WriteGA(Base.SessionSwitchType, sessionID);
            }

            // 切换战局状态
            Globals.WriteGA(Base.SessionSwitchState, 1);
            await Task.Delay(200);
            Globals.WriteGA(Base.SessionSwitchState, 0);
        });
    }

    /// <summary>
    /// 空战局
    /// </summary>
    public static void EmptySession()
    {

    }

    /// <summary>
    /// 挂机防踢
    /// </summary>
    /// <param name="isEnable"></param>
    public static void AntiAFK(bool isEnable)
    {
        // STATS::PLAYSTATS_IDLE_KICK
        Globals.WriteGA(Base.Default + 87, isEnable ? 99999999 : 120000);        // 120000     joaat("IDLEKICK_WARNING1") 
        Globals.WriteGA(Base.Default + 88, isEnable ? 99999999 : 300000);        // 300000     joaat("IDLEKICK_WARNING2")
        Globals.WriteGA(Base.Default + 89, isEnable ? 99999999 : 600000);        // 600000     joaat("IDLEKICK_WARNING3")
        Globals.WriteGA(Base.Default + 90, isEnable ? 99999999 : 900000);        // 900000     joaat("IDLEKICK_KICK")

        Globals.WriteGA(Base.Default + 8420, isEnable ? 2000000000 : 30000);     // 30000      joaat("ConstrainedKick_Warning1")
        Globals.WriteGA(Base.Default + 8421, isEnable ? 2000000000 : 60000);     // 60000      joaat("ConstrainedKick_Warning2")
        Globals.WriteGA(Base.Default + 8422, isEnable ? 2000000000 : 90000);     // 90000      joaat("ConstrainedKick_Warning3")
        Globals.WriteGA(Base.Default + 8423, isEnable ? 2000000000 : 120000);    // 120000     joaat("ConstrainedKick_Kick")
    }

    /// <summary>
    /// 挂机防踢（2023/06/19 未测试是否有效）
    /// </summary>
    public static void IdleKick()
    {
        Globals.WriteGA(1654054 + 1155, 0);        // STATS::PLAYSTATS_IDLE_KICK(time);
        Globals.WriteGA(1654054 + 1171, 0);        // AUDIO::PLAY_SOUND_FRONTEND(-1, "MP_IDLE_TIMER", "HUD_FRONTEND_DEFAULT_SOUNDSET", true);
    }

    /// <summary>
    /// 免费更改角色外观
    /// </summary>
    /// <param name="isEnable"></param>
    public static void FreeChangeAppearance(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 19290, isEnable ? 0 : 100000);         // joaat("CHARACTER_APPEARANCE_CHARGE")
    }

    /// <summary>
    /// 模型变更
    /// </summary>
    /// <param name="hash"></param>
    public static void ModelChange(long hash)
    {
        // else if (!PED::HAS_PED_HEAD_BLEND_FINISHED(PLAYER::PLAYER_PED_ID())
        Globals.WriteGA(Base.oVGETIn + 61, 1);                 // triggerModelChange
        Globals.WriteGA(Base.oVGETIn + 48, hash);              // modelChangeHash
        Thread.Sleep(10);
        Globals.WriteGA(Base.oVGETIn + 61, 0);
    }

    /// <summary>
    /// 允许非公共战局运货
    /// </summary>
    /// <param name="isEnable"></param>
    public static void AllowSellOnNonPublic(bool isEnable)
    {
        Globals.WriteGA(2683883 + 744, isEnable ? 0 : 1);         // NETWORK::NETWORK_SESSION_GET_PRIVATE_SLOTS()
    }

    /// <summary>
    /// 移除被动模式CD
    /// </summary>
    /// <param name="isEnable"></param>
    public static void PassiveModeCooldown(bool isEnable)
    {
        Globals.WriteGA(2794162 + 4497, isEnable ? 0 : 1);        // AUDIO::REQUEST_SCRIPT_AUDIO_BANK("DLC_HEI4/DLC_HEI4_Submarine" // _STOPWATCH_RESET(&(Global_2794162.f_4497), false, false);
        Globals.WriteGA(1971499, isEnable ? 0 : 1);               // joaat("VEHICLE_WEAPON_SUB_MISSILE_HOMING")
    }

    /// <summary>
    /// 移除自杀CD
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SuicideCooldown(bool isEnable)
    {
        if (isEnable)
            Globals.WriteGA(Base.oVMYCar + 6898, 0);      // joaat("XPCATEGORY_ACTION_KILLS")

        Globals.WriteGA(Base.Default + 28615, isEnable ? 1 : 300000);         // 247954694
        Globals.WriteGA(Base.Default + 28616, isEnable ? 1 : 60000);          // -1771488297
    }

    /// <summary>
    /// 移除轨道炮CD
    /// </summary>
    /// <param name="isEnable"></param>
    public static void DisableOrbitalCooldown(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 23264, isEnable ? 0 : 2880000);         // -1707434973
    }

    /// <summary>
    /// 进入线上个人载具
    /// </summary>
    public static void GetInOnlinePV()
    {
        Globals.WriteGA(Base.oVGETIn + 8, 1);     // (PLAYER::PLAYER_ID()), 0f, 0f, 0f, Global_
    }

    /// <summary>
    /// 战局雪天
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SessionSnow(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 4752, isEnable ? 1 : 0);            // joaat("turn_snow_on_off")
    }

    /// <summary>
    /// 雷达影踪/人间蒸发
    /// </summary>
    /// <param name="isEnable"></param>
    public static void OffRadar(bool isEnable)
    {
        Globals.WriteGA(Base.oPlayerIDHelp + 1 + Globals.GetPlayerID() * 466 + 210, isEnable ? 1 : 0);
        if (isEnable)
            Globals.WriteGA(Base.oNETTimeHelp + 57, Globals.GetNetworkTime() + 3600000);
        Globals.WriteGA(Base.oVMYCar + 4660, isEnable ? 3 : 0);
    }

    /// <summary>
    /// 幽灵组织
    /// </summary>
    /// <param name="isEnable"></param>
    public static void GhostOrganization(bool isEnable)
    {
        Globals.WriteGA(Base.oPlayerIDHelp + 1 + Globals.GetPlayerID() * 466 + 210, isEnable ? 1 : 0);
        if (isEnable)
            Globals.WriteGA(Base.oNETTimeHelp + 57, Globals.GetNetworkTime() + 3600000);        // iVar0 = NETWORK::GET_TIME_DIFFERENCE(NETWORK::GET_NETWORK_TIME()
        Globals.WriteGA(Base.oVMYCar + 4660, isEnable ? 4 : 0);
    }

    /// <summary>
    /// 警察无视犯罪
    /// </summary>
    /// <param name="isEnable"></param>
    public static void BribeOrBlindCops(bool isEnable)
    {
        Globals.WriteGA(Base.oVMYCar + 4661 + 1, isEnable ? 1 : 0);           // _DISPLAY_HELP_TEXT("FM_LEST_NCPW"
        Globals.WriteGA(Base.oVMYCar + 4661 + 3, isEnable ? Globals.GetNetworkTime() + 3600000 : 0);
        Globals.WriteGA(Base.oVMYCar + 4661, isEnable ? 5 : 0);
    }

    /// <summary>
    /// 贿赂当局
    /// </summary>
    /// <param name="isEnable"></param>
    public static void BribeAuthorities(bool isEnable)
    {
        Globals.WriteGA(Base.oVMYCar + 4661 + 1, isEnable ? 1 : 0);
        Globals.WriteGA(Base.oVMYCar + 4661 + 3, isEnable ? Globals.GetNetworkTime() + 3600000 : 0);
        Globals.WriteGA(Base.oVMYCar + 4661, isEnable ? 21 : 0);
    }

    /// <summary>
    /// 显示玩家
    /// </summary>
    /// <param name="isEnable"></param>
    public static void RevealPlayers(bool isEnable)
    {
        Globals.WriteGA(Base.oPlayerIDHelp + 1 + Globals.GetPlayerID() * 466 + 213, isEnable ? 1 : 0);
        Globals.WriteGA(Base.oNETTimeHelp + 58, isEnable ? Globals.GetNetworkTime() + 3600000 : 0);
    }

    /// <summary>
    /// 设置角色等级经验倍数
    /// </summary>
    /// <param name="multiplier"></param>
    public static void RPMultiplier(float multiplier)
    {
        Globals.WriteGA(Base.Default + 1, multiplier);           // xpMultiplier Global_Base.Default.f_1
    }

    /// <summary>
    /// 设置角色AP经验倍数
    /// </summary>
    /// <param name="multiplier"></param>
    public static void APMultiplier(float multiplier)
    {
        Globals.WriteGA(Base.Default + 25926, multiplier);
    }

    /// <summary>
    /// 设置车友会等级经验倍数
    /// </summary>
    /// <param name="multiplier"></param>
    public static void REPMultiplier(float multiplier)
    {
        Globals.WriteGA(Base.Default + 31855, multiplier);        // Street Race         街头比赛        -147149995  joaat("TUNER_STREET_RACE_PLACE_XP_MULTIPLIER")
        Globals.WriteGA(Base.Default + 31856, multiplier);        // Pursuit Race        追逐赛
        Globals.WriteGA(Base.Default + 31857, multiplier);        // Scramble            攀登
        Globals.WriteGA(Base.Default + 31858, multiplier);        // Head 2 Head         头对头          1434998920

        Globals.WriteGA(Base.Default + 31860, multiplier);        // LS Car Meet         汽车见面会       1819417801  joaat("TUNER_CARCLUB_TIME_XP_MULTIPLIER")
        Globals.WriteGA(Base.Default + 31861, multiplier);        // LS Car Meet Track
        Globals.WriteGA(Base.Default + 31862, multiplier);        // LS Car Meet Cloth Shop
    }

    /// <summary>
    /// 使用牛鲨睾酮
    /// </summary>
    /// <param name="isEnable"></param>
    public static void InstantBullShark(bool isEnable)
    {
        if (isEnable)
            Globals.WriteGA(Base.oNETTimeHelp + 3690, 1);
        else
        {
            int temp = Globals.ReadGA<int>(Base.oNETTimeHelp + 3690);
            if (temp != 0)
                Globals.WriteGA(Base.oNETTimeHelp + 3690, 5);
        }
    }

    /// <summary>
    /// 呼叫支援直升机
    /// </summary>
    /// <param name="isEnable"></param>
    public static void CallBackupHeli(bool isEnable)
    {
        Globals.WriteGA(Base.oVMYCar + 4491, isEnable ? 1 : 0);   // SCRIPT::GET_NUMBER_OF_THREADS_RUNNING_THE_SCRIPT_WITH_THIS_HASH(joaat("am_backup_heli")
    }

    /// <summary>
    /// 呼叫空袭
    /// </summary>
    /// <param name="isEnable"></param>
    public static void CallAirstrike(bool isEnable)
    {
        Globals.WriteGA(Base.oVMYCar + 4492, isEnable ? 1 : 0);   // SCRIPT::GET_NUMBER_OF_THREADS_RUNNING_THE_SCRIPT_WITH_THIS_HASH(joaat("am_airstrike")
    }

    /// <summary>
    /// 启用CEO特殊货物
    /// </summary>
    /// <param name="isEnable"></param>
    public static void CEOSpecialCargo(bool isEnable)
    {
        Globals.WriteGA(1950703, isEnable ? 1 : 0);           // MISC::GET_RANDOM_INT_IN_RANGE(1, 101);   // Global_1950703 = 1;
    }

    /// <summary>
    /// 设置CEO特殊货物类型
    /// </summary>
    /// <param name="cargoID"></param>
    public static void CEOCargoType(int cargoID)
    {
        Globals.WriteGA(1950549, cargoID);                    // MISC::GET_RANDOM_INT_IN_RANGE(1, 101);   // Global_1950549 = num;
    }

    /// <summary>
    /// 移除购买CEO板条箱冷却
    /// </summary>
    /// <param name="isEnable"></param>
    public static void CEOBuyingCratesCooldown(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 15728, isEnable ? 0 : 300000);          // 153204142 joaat("EXEC_BUY_COOLDOWN")
    }

    /// <summary>
    /// 移除出售CEO板条箱冷却
    /// </summary>
    /// <param name="isEnable"></param>
    public static void CEOSellingCratesCooldown(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 15729, isEnable ? 0 : 1800000);         // 1291620941 joaat("EXEC_SELL_COOLDOWN")
    }

    /// <summary>
    /// 移除地堡进货延迟
    /// </summary>
    /// <param name="isEnable"></param>
    public static void BunkerSupplyDelay(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 21737, isEnable ? 0 : 600);            // -2094564985 joaat("GR_PURCHASE_SUPPLIES_DELAY")
    }

    /// <summary>
    /// 解锁地堡所有研究 (临时)
    /// </summary>
    /// <param name="isEnable"></param>
    public static void UnlockBunkerResearch(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 21865, isEnable ? 1 : 0);                // 886070202
    }

    /// <summary>
    /// 移除摩托帮进货延迟
    /// </summary>
    /// <param name="isEnable"></param>
    public static void MCSupplyDelay(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 19179, isEnable ? 0 : 600);          // 728170457  joaat("WEBSITE_PEGASSI_FAGGIO_SPORT")
    }

    /// <summary>
    /// 设置梅利威瑟服务类型
    /// </summary>
    /// <param name="serverId"></param>
    public static void MerryWeatherServices(int serverId)
    {
        Globals.WriteGA(Base.oVMYCar + serverId, 1);
    }

    /// <summary>
    /// 移除进出口大亨出货CD
    /// </summary>
    /// <param name="isEnable"></param>
    public static void ExportVehicleDelay(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 19862, isEnable ? 0 : 1200000);        // 1001423248  tuneables_processing.c
        Globals.WriteGA(Base.Default + 19863, isEnable ? 0 : 1680000);        // 240134765
        Globals.WriteGA(Base.Default + 19864, isEnable ? 0 : 2340000);        // 1915379148
        Globals.WriteGA(Base.Default + 19865, isEnable ? 0 : 2880000);        // -824005590
    }

    /// <summary>
    /// 断开战局连接
    /// </summary>
    public static async void Disconnect()
    {
        Globals.WriteGA(32561, 1);              // NETWORK::NETWORK_BAIL(1, 0, 0)
        await Task.Delay(200);
        Globals.WriteGA(32561, 0);              // return NETWORK::NETWORK_CAN_ACCESS_MULTIPLAYER
    }

    /// <summary>
    /// 结束过场动画
    /// </summary>
    public static async void StopCutscene()
    {
        Globals.WriteGA(2766640 + 3, 1);        // return MISC::GET_HASH_KEY("AVISA")
        Globals.WriteGA(1575063, 1);            // NETWORK::NETWORK_TRANSITION_ADD_STAGE(hashKey, 1, num, etsParam0, 0);
        await Task.Delay(200);
        Globals.WriteGA(2766640 + 3, 0);
        Globals.WriteGA(1575063, 0);
    }

    /// <summary>
    /// 移除机库进货CD
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SmugglerRunInDelay(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 22931, isEnable ? 0 : 120000);         // 1278611667  tuneables_processing.c
        Globals.WriteGA(Base.Default + 22932, isEnable ? 0 : 180000);         // -1424847540
        Globals.WriteGA(Base.Default + 22933, isEnable ? 0 : 240000);         // -1817541754
        Globals.WriteGA(Base.Default + 22934, isEnable ? 0 : 60000);          // 1722502526
    }

    /// <summary>
    /// 移除机库出货CD
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SmugglerRunOutDelay(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 22972, isEnable ? 0 : 180000);         // -1525481945  tuneables_processing.c
    }

    /// <summary>
    /// 移除夜总会出货CD
    /// </summary>
    /// <param name="isEnable"></param>
    public static void NightclubOutDelay(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 24629, isEnable ? 0 : 300000);         // 1763921019  tuneables_processing.c
        Globals.WriteGA(Base.Default + 24671, isEnable ? 0 : 300000);         // -1004589438  Global_262145.f_24671 = 300000;
        Globals.WriteGA(Base.Default + 24672, isEnable ? 0 : 300000);         // 464940095
    }

    /// <summary>
    /// 未知功能
    /// </summary>
    /// <param name="index"></param>
    public static void DeliverPersonalVehicle(int index)
    {
        Globals.WriteGA(Base.oVMYCar + 965, index);
        Globals.WriteGA(Base.oVMYCar + 962, 1);
    }

    /// <summary>
    /// 移除CEO工作冷却
    /// </summary>
    /// <param name="isEnable"></param>
    public static void CEOWorkCooldown(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 13254, isEnable ? 0 : 300000);       // -1404265088 joaat("GB_COOLDOWN_UNTIL_NEXT_BOSS_WORK")
        Globals.WriteGA(Base.Default + 13151, isEnable ? 0 : 600000);       // -1911318106 joaat("GB_SIGHTSEER_COOLDOWN")
    }

    /// <summary>
    /// 移除恐霸客户差事冷却
    /// </summary>
    /// <param name="isEnable"></param>
    public static void ClientJonCooldown(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 24818 + 0, isEnable ? 0 : 300000);       // Between Jobs           -926426916
        Globals.WriteGA(Base.Default + 24818 + 1, isEnable ? 0 : 1800000);      // Robbery in Progress    1733390598
        Globals.WriteGA(Base.Default + 24818 + 2, isEnable ? 0 : 1800000);      // Data Sweep             724724668
        Globals.WriteGA(Base.Default + 24818 + 3, isEnable ? 0 : 1800000);      // Targeted Data          846317886
        Globals.WriteGA(Base.Default + 24818 + 4, isEnable ? 0 : 1800000);      // Diamond Shopping       443623246
    }

    /// <summary>
    /// 移除事务所安保合约冷却
    /// </summary>
    /// <param name="isEnable"></param>
    public static void SecurityHitCooldown(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 31908, isEnable ? 0 : 300000);           // -1462622971 joaat("FIXER_SECURITY_CONTRACT_COOLDOWN_TIME")
    }

    /// <summary>
    /// 移除公共电话任务合约冷却
    /// </summary>
    /// <param name="isEnable"></param>
    public static void PayphoneHitCooldown(bool isEnable)
    {
        Globals.WriteGA(Base.Default + 31989, isEnable ? 0 : 1200000);          // 1872071131
    }

    /// <summary>
    /// 进入RC匪徒z
    /// </summary>
    /// <param name="isEnable"></param>
    public static void TriggerRCBandito(bool isEnable)
    {
        Globals.WriteGA(Base.oVMYCar + 6879, isEnable ? 1 : 0);               // if (PED::IS_PED_IN_ANY_VEHICLE(PLAYER::PLAYER_PED_ID(), true) || PED::IS_PED_GETTING_INTO_A_VEHICLE(PLAYER::PLAYER_PED_ID()))
    }

    /// <summary>
    /// 进入迷你坦克
    /// </summary>
    /// <param name="isEnable"></param>
    public static void TriggerMiniTank(bool isEnable)
    {
        Globals.WriteGA(Base.oVMYCar + 6880, isEnable ? 1 : 0);
    }
}
