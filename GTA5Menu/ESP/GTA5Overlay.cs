using GTA5Core.Native;
using GTA5Core.Feature;

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

    private Vector4 lineColor = new(0.919f, 0.202f, 0.551f, 1.000f);
    private Vector4 boxColor = new(0.919f, 0.202f, 0.551f, 1.000f);

    public GTA5Overlay(string title) : base(title)
    {
        //new Thread(LogicUpdateThread)
        //{
        //    Name = "LogicUpdateThread",
        //    IsBackground = true
        //}.Start();
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
    }

    private void RenderMainMenu()
    {
        if (ImGui.Begin("GTA5线上小助手 外部ESP覆盖"))
        {
            ImGui.Text($"D3D11: {ImGui.GetIO().Framerate:0.0} fps / {1000.0f / ImGui.GetIO().Framerate:0.000} ms    ");
            ImGui.Text("按F12显示/隐藏菜单");

            ImGui.ColorEdit4("射线颜色", ref lineColor);
            ImGui.ColorEdit4("方框颜色", ref boxColor);

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

                long m_navigation = Memory.Read<long>(m_ped_list + 0x30);
                if (!Memory.IsValid(m_navigation))
                    continue;

                // ped坐标
                Vector3 pedPosV3 = Memory.Read<Vector3>(m_navigation + 0x50);

                // 屏幕坐标
                Vector2 pedPosV2 = RenderHelper.WorldToScreen(pedPosV3);
                // 方框坐标
                Vector2 pedBoxV2 = RenderHelper.GetBoxInfo(pedPosV3);

                // 绘制2D射线
                RenderHelper.DrawLine(pedPosV2, pedBoxV2, lineColor);
                // 绘制2D方框
                RenderHelper.DrawBox(pedPosV2, pedBoxV2, boxColor);
            }
        }
        ImGui.End();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        isRunning = false;
    }

    private void LogicUpdateThread()
    {
        while (isRunning)
        {

            Thread.Sleep(1);
        }
    }
}
