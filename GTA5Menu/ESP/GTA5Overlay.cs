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

    private List<PedInfo> pedInfos = new();

    public GTA5Overlay()
    {
        for (int i = 0; i < maxPedCount; i++)
        {
            pedInfos.Add(new());
        }

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

    protected override void Render()
    {
        if (Misc.IsKeyPressedAndNotTimeout(VK.F12))
        {
            isShowMainMenu = !isShowMainMenu;
        }

        if (isShowMainMenu)
        {
            RenderMainMenu();

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

            for (int i = 0; i < pedInfos.Count; i++)
            {
                if (pedInfos[i].Health == 0)
                    continue;

                var v1 = pedInfos[i].Screen;
                var v2 = pedInfos[i].Box;

                v1.X -= v2.X / 2;
                v1.Y -= v2.Y / 2;

                v2.X += v1.X;
                v2.Y += v1.Y;

                ImGui.GetForegroundDrawList().AddRect(v1, v2,
                    ImGui.ColorConvertFloat4ToU32(new Vector4(0.919f, 0.202f, 0.551f, 1.000f)));
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
            for (int i = 0; i < maxPedCount; i++)
            {
                pedInfos[i].Reset();
            }

            windowData = Memory.GetGameWindowData();

            long m_ped_factory = Memory.Read<long>(Pointers.WorldPTR);
            long m_local_ped = Memory.Read<long>(m_ped_factory + 0x08);

            // 自己坐标
            long pCNavigation = Memory.Read<long>(m_local_ped + 0x30);
            Vector3 myPosV3 = Memory.Read<Vector3>(pCNavigation + 0x50);

            // Ped数量
            long m_replay = Memory.Read<long>(Pointers.ReplayInterfacePTR);
            if (!Memory.IsValid(m_replay))
                goto SLEEP;
            long m_ped_interface = Memory.Read<long>(m_replay + 0x18);
            if (!Memory.IsValid(m_ped_interface))
                goto SLEEP;

            for (int i = 0; i < maxPedCount; i++)
            {
                long m_ped_list = Memory.Read<long>(m_ped_interface + 0x100);
                m_ped_list = Memory.Read<long>(m_ped_list + i * 0x10);
                if (!Memory.IsValid(m_ped_list))
                    continue;

                // 当前生命值
                pedInfos[i].Health = Memory.Read<float>(m_ped_list + 0x280);
                // 如果ped死亡，跳过
                if (pedInfos[i].Health <= 0)
                    continue;

                // 最大生命值
                pedInfos[i].MaxHealth = Memory.Read<float>(m_ped_list + 0x284);
                // 生命值百分比
                pedInfos[i].PCTGealth = pedInfos[i].Health / pedInfos[i].MaxHealth;

                long m_player_info = Memory.Read<long>(m_ped_list + 0x10A8);

                // 名称
                pedInfos[i].Name = Memory.ReadString(m_player_info + 0x104, 20);

                long m_navigation = Memory.Read<long>(m_ped_list + 0x30);
                if (!Memory.IsValid(m_navigation))
                    continue;

                // 坐标
                pedInfos[i].Position = Memory.Read<Vector3>(m_navigation + 0x50);

                // 与自己的距离
                pedInfos[i].Distance = (float)Math.Sqrt(
                    Math.Pow(myPosV3.X - pedInfos[i].Position.X, 2) +
                    Math.Pow(myPosV3.Y - pedInfos[i].Position.Y, 2) +
                    Math.Pow(myPosV3.Z - pedInfos[i].Position.Z, 2));

                // 方向
                pedInfos[i].Heading = new Vector2
                {
                    X = Memory.Read<float>(m_navigation + 0x20),
                    Y = Memory.Read<float>(m_navigation + 0x30)
                };

                // 屏幕坐标
                pedInfos[i].Screen = RenderHelper.WorldToScreen(pedInfos[i].Position, windowData.Width, windowData.Height);
                // 方框坐标
                pedInfos[i].Box = RenderHelper.GetBoxWH(pedInfos[i].Position, windowData.Height);











            }

        SLEEP:
            Thread.Sleep(1);
        }
    }
}
