using GTA5Core.Native;

using ImGuiNET;

using GameOverlay;
using GameOverlay.Native;

using Size = System.Drawing.Size;
using Point = System.Drawing.Point;
using GTA5Core.Feature;

namespace GTA5Menu.ESP;

internal class GTA5Overlay : Overlay
{
    private bool isShowMainMenu = true;

    private WindowData windowData;

    /// <summary>
    /// 初始化
    /// </summary>
    /// <returns></returns>
    protected override Task PostInitialized()
    {
        this.VSync = true;
        this.ReplaceFont("C:\\Windows\\Fonts\\msyh.ttc", 14, FontGlyphRangeType.ChineseFull);

        windowData = Memory.GetGameWindowData();

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
            ImGui.Text("按F12显示/隐藏菜单");

            long m_ped_factory = Memory.Read<long>(Pointers.WorldPTR);
            long m_local_ped = Memory.Read<long>(m_ped_factory + 0x08);

            // 自己坐标
            long pCNavigation = Memory.Read<long>(m_local_ped + 0x30);
            Vector3 myPosV3 = Memory.Read<Vector3>(pCNavigation + 0x50);

            ImGui.Text($"{myPosV3.X:0.000},{myPosV3.Y:0.000},{myPosV3.Z:0.000}");
        }
        ImGui.End();
    }
}
