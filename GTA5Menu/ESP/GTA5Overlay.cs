using GTA5Core.Native;
using GTA5Core.Feature;
using GTA5Core.Settings;
using GTA5HotKey;

using ImGuiNET;

using GameOverlay;
using GameOverlay.Native;

using Size = System.Drawing.Size;
using Point = System.Drawing.Point;

namespace GTA5Menu.ESP;

internal class GTA5Overlay : Overlay
{
    private bool isRunning = true;
    private bool isShowMainMenu = true;

    private const int maxPedCount = 256;

    private WindowData windowData;

    private Vector4 lineColor = new(1.000f, 1.000f, 1.000f, 1.000f);
    private Vector4 boxColor = new(1.000f, 1.000f, 1.000f, 1.000f);
    private Vector4 boneColor = new(1.000f, 1.000f, 1.000f, 1.000f);

    public GTA5Overlay(string title) : base(title)
    {
        new Thread(LogicUpdateThread)
        {
            Name = "LogicUpdateThread",
            IsBackground = true
        }.Start();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <returns></returns>
    protected override Task PostInitialized()
    {
        this.VSync = true;

        var font = "C:\\Windows\\Fonts\\msyh.ttc";
        if (!File.Exists(font))
            font = "C:\\Windows\\Fonts\\msyh.ttf";

        this.ReplaceFont(font, 16, FontGlyphRangeType.ChineseFull);

        return Task.CompletedTask;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        isRunning = false;
    }

    protected override void Render()
    {
        if (Misc.IsKeyPressedAndNotTimeout(VK.F12))
        {
            isShowMainMenu = !isShowMainMenu;
        }

        if (isShowMainMenu)
        {
            RenderMainMenu();

            windowData = Memory.GetGameWindowData();
            this.Position = new Point(windowData.Left, windowData.Top);
            this.Size = new Size(windowData.Width, windowData.Height);
        }

        RenderESP();
        RenderOverlay();
    }

    private void RenderMainMenu()
    {
        ImGui.Begin("GTA5线上小助手 外部ESP覆盖");

        ImGui.ColorEdit4("射线颜色", ref lineColor);
        ImGui.ColorEdit4("方框颜色", ref boxColor);
        ImGui.ColorEdit4("骨骼颜色", ref boneColor);

        ImGui.End();
    }

    private void RenderOverlay()
    {
        ImGui.SetNextWindowPos(new Vector2(0f, ImGui.GetIO().DisplaySize.Y / 3));
        ImGui.SetNextWindowBgAlpha(0.5f);
        ImGui.Begin(
            "GTA5线上小助手",
            ImGuiWindowFlags.NoInputs |
            ImGuiWindowFlags.NoCollapse |
            ImGuiWindowFlags.NoTitleBar |
            ImGuiWindowFlags.AlwaysAutoResize |
            ImGuiWindowFlags.NoResize);

        ImGui.Text("== GTA5线上小助手 ==");
        ImGui.Text("== crazyzhang.cn ==");
        ImGui.Text("按 F12键 显示/隐藏菜单");
        ImGui.NewLine();
        ImGui.Text($"渲染帧数: {ImGui.GetIO().Framerate:F1} FPS");
        ImGui.Text($"渲染延迟: {ImGui.GetIO().DeltaTime:F4} 秒");
        ImGui.NewLine();

        // 玩家列表
        long pCNetworkPlayerMgr = Memory.Read<long>(Pointers.NetworkPlayerMgrPTR);
        int playerCount = Memory.Read<int>(pCNetworkPlayerMgr + 0x178);

        // Ped数量
        long m_replay = Memory.Read<long>(Pointers.ReplayInterfacePTR);
        long m_ped_interface = Memory.Read<long>(m_replay + 0x18);
        int m_max_peds = Memory.Read<int>(m_ped_interface + 0x108);
        int m_cur_peds = Memory.Read<int>(m_ped_interface + 0x110);

        ImGui.Text($"玩家数量: {playerCount}");
        ImGui.Text($"Ped数量: {m_cur_peds} / {m_max_peds}");

        ImGui.End();
    }

    private void RenderESP()
    {
        long m_replay = Memory.Read<long>(Pointers.ReplayInterfacePTR);
        long m_ped_interface = Memory.Read<long>(m_replay + 0x18);

        for (int i = 0; i < maxPedCount; i++)
        {
            long m_ped_list = Memory.Read<long>(m_ped_interface + 0x100);
            m_ped_list = Memory.Read<long>(m_ped_list + i * 0x10);
            if (!Memory.IsValid(m_ped_list))
                continue;

            // 如果ped死亡，跳过
            float ped_Health = Memory.Read<float>(m_ped_list + 0x280);
            if (ped_Health <= 0)
                continue;

            float ped_MaxHealth = Memory.Read<float>(m_ped_list + 0x284);
            float ped_HPPercentage = ped_Health / ped_MaxHealth;

            long m_navigation = Memory.Read<long>(m_ped_list + 0x30);
            if (!Memory.IsValid(m_navigation))
                continue;

            // ped坐标
            Vector3 pedPosV3 = Memory.Read<Vector3>(m_navigation + 0x50);

            // 屏幕坐标
            Vector2 pedPosV2 = RenderHelper.WorldToScreen(pedPosV3, windowData.Width, windowData.Height);
            // 方框信息
            Vector2 pedBoxV2 = RenderHelper.GetBoxInfo(pedPosV3, windowData.Height);

            // 绘制射线
            RenderHelper.DrawLine(pedPosV2, pedBoxV2, lineColor);
            // 绘制方框
            RenderHelper.DrawBox(pedPosV2, pedBoxV2, boxColor);

            // 绘制血条
            RenderHelper.DrawHPBar(pedPosV2, pedBoxV2, ped_HPPercentage);

            // 绘制骨骼
            RenderHelper.DrawBone(m_ped_list, 0, 7, windowData.Width, windowData.Height, boneColor);
            RenderHelper.DrawBone(m_ped_list, 7, 8, windowData.Width, windowData.Height, boneColor);
            RenderHelper.DrawBone(m_ped_list, 8, 3, windowData.Width, windowData.Height, boneColor);
            RenderHelper.DrawBone(m_ped_list, 8, 4, windowData.Width, windowData.Height, boneColor);
            RenderHelper.DrawBone(m_ped_list, 7, 5, windowData.Width, windowData.Height, boneColor);
            RenderHelper.DrawBone(m_ped_list, 7, 6, windowData.Width, windowData.Height, boneColor);
        }
    }

    private void LogicUpdateThread()
    {
        while (isRunning)
        {
            float aimBot_Min_Distance = MenuSetting.Overlay.AimBot_Fov;
            Vector3 aimBot_ViewAngles = Vector3.Zero;
            Vector3 teleW_pedCoords = Vector3.Zero;

            long m_ped_factory = Memory.Read<long>(Pointers.WorldPTR);
            long m_local_ped = Memory.Read<long>(m_ped_factory + 0x08);

            // 相机坐标
            long pCCameraPTR = Memory.Read<long>(Pointers.CCameraPTR);
            long pCCameraPTR_0 = Memory.Read<long>(pCCameraPTR + 0x00);
            pCCameraPTR_0 = Memory.Read<long>(pCCameraPTR_0 + 0x3C0);
            Vector3 cameraV3Pos = Memory.Read<Vector3>(pCCameraPTR_0 + 0x60);

            // 是否是第一人称，当Fov=0为第一人称或者开镜状态，第三人称50
            long offset = Memory.Read<long>(pCCameraPTR_0 + 0x10);
            float isFPP = Memory.Read<float>(offset + 0x30);

            // Ped实体
            long m_replay = Memory.Read<long>(Pointers.ReplayInterfacePTR);
            long m_ped_interface = Memory.Read<long>(m_replay + 0x18);

            for (int i = 0; i < maxPedCount; i++)
            {
                long m_ped_list = Memory.Read<long>(m_ped_interface + 0x100);
                m_ped_list = Memory.Read<long>(m_ped_list + i * 0x10);
                if (!Memory.IsValid(m_ped_list))
                    continue;

                // 如果是自己，跳过
                if (m_local_ped == m_ped_list)
                    continue;

                // 如果ped死亡，跳过
                float ped_Health = Memory.Read<float>(m_ped_list + 0x280);
                if (ped_Health <= 0)
                    continue;

                long m_navigation = Memory.Read<long>(m_ped_list + 0x30);
                if (!Memory.IsValid(m_navigation))
                    continue;

                // ped坐标
                Vector3 pedPosV3 = Memory.Read<Vector3>(m_navigation + 0x50);

                // 屏幕坐标
                Vector2 pedPosV2 = RenderHelper.WorldToScreen(pedPosV3, windowData.Width, windowData.Height);

                var gview_width = windowData.Width / 2;
                var gview_height = windowData.Height / 2;

                // 自瞄数据
                float aimBot_Distance = (float)Math.Sqrt(Math.Pow(pedPosV2.X - gview_width, 2) + Math.Pow(pedPosV2.Y - gview_height, 2));
                // 获取距离准心最近的方框
                if (aimBot_Distance < aimBot_Min_Distance)
                {
                    aimBot_Min_Distance = aimBot_Distance;
                    aimBot_ViewAngles = RenderHelper.GetCCameraViewAngles(cameraV3Pos, RenderHelper.GetBonePosition(m_ped_list, MenuSetting.Overlay.AimBot_BoneIndex));
                    teleW_pedCoords = pedPosV3;
                }
            }

            // 默认按住Ctrl键自瞄
            if (Convert.ToBoolean(HotKeys.GetAsyncKeyState((int)MenuSetting.Overlay.AimBot_Key) & Win32.KEY_PRESSED))
            {
                if (isFPP == 0)
                {
                    // 第一人称及开镜自瞄
                    Memory.Write(pCCameraPTR_0 + 0x40, aimBot_ViewAngles);
                }
                else
                {
                    // 第三人称及自瞄
                    Memory.Write(pCCameraPTR_0 + 0x3D0, aimBot_ViewAngles);
                }

                if (Convert.ToBoolean(HotKeys.GetAsyncKeyState((int)WinVK.F5) & Win32.KEY_PRESSED))
                {
                    Teleport.SetTeleportPosition(teleW_pedCoords);
                }
            }

            Thread.Sleep(1);
        }
    }
}
