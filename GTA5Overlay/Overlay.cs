using GTA5HotKey;
using GTA5Core.Native;
using GTA5Core.Offsets;
using GTA5Core.Features;

using GameOverlay.Drawing;
using GameOverlay.Windows;

namespace GTA5Overlay;

public class Overlay : IDisposable
{
    private readonly GraphicsWindow _window;

    private readonly List<SolidBrush> _brushes;
    private readonly List<Font> _fonts;

    //////////////////////////////////

    private SolidBrush _brush_white;
    private SolidBrush _brush_red;
    private SolidBrush _brush_green;
    private SolidBrush _brush_blue;
    private SolidBrush _brush_deepPink;
    private SolidBrush _brush_transparency;

    private Font _font_YaHei;

    //////////////////////////////////

    private WindowData _windowData;

    // 视角宽和视角高
    private float _gviewWidth;
    private float _gviewHeight;

    private readonly StringBuilder _infoText = new();

    private bool _isDraw = true;
    private bool _isRun = true;

    //////////////////////////////////

    public Overlay()
    {
        _windowData = Memory.GetGameWindowData();
        Memory.SetForegroundWindow();

        Core.SetWindowData(_windowData.Width, _windowData.Height);
        Draw.SetWindowData(_windowData.Width, _windowData.Height);

        /////////////////////////////////////////////

        _brushes = new List<SolidBrush>();
        _fonts = new List<Font>();

        var gfx = new Graphics()
        {
            VSync = Setting.VSync,
            MeasureFPS = true,
            PerPrimitiveAntiAliasing = true,
            TextAntiAliasing = true,
            UseMultiThreadedFactories = true
        };

        _window = new GraphicsWindow(_windowData.Left, _windowData.Top, _windowData.Width, _windowData.Height, gfx)
        {
            FPS = Setting.FPS,
            IsTopmost = true,
            IsVisible = true
        };

        _window.DrawGraphics += _window_DrawGraphics;
        _window.DestroyGraphics += _window_DestroyGraphics;
        _window.SetupGraphics += _window_SetupGraphics;

        Draw.SetGraphicsIns(gfx);

        new Thread(AimbotThread)
        {
            Name = "AimbotThread",
            IsBackground = true
        }.Start();

        new Thread(IsDrawGameOverlay)
        {
            Name = "IsDrawGameOverlay",
            IsBackground = true
        }.Start();
    }

    private void IsDrawGameOverlay()
    {
        while (_isRun)
        {
            if (Setting.NoTopMostHide)
                _isDraw = Memory.IsForegroundWindow();
            else
                _isDraw = true;

            Thread.Sleep(1000);
        }
    }

    private void _window_SetupGraphics(object sender, SetupGraphicsEventArgs e)
    {
        var gfx = e.Graphics;

        if (e.RecreateResources)
        {
            foreach (var pair in _brushes)
                pair.Dispose();
        }

        _brush_white = gfx.CreateSolidBrush(255, 255, 255);
        _brush_red = gfx.CreateSolidBrush(255, 0, 98);
        _brush_green = gfx.CreateSolidBrush(0, 128, 0);
        _brush_blue = gfx.CreateSolidBrush(30, 144, 255);
        _brush_deepPink = gfx.CreateSolidBrush(247, 63, 147, 255);
        _brush_transparency = gfx.CreateSolidBrush(0, 0, 0, 0);

        _brushes.Add(_brush_white);
        _brushes.Add(_brush_red);
        _brushes.Add(_brush_green);
        _brushes.Add(_brush_blue);
        _brushes.Add(_brush_deepPink);
        _brushes.Add(_brush_transparency);

        if (e.RecreateResources)
            return;

        _font_YaHei = gfx.CreateFont("Microsoft YaHei", 12);

        _fonts.Add(_font_YaHei);
    }

    private void _window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
    {
        // 清理颜色资源
        foreach (var pair in _brushes)
            pair.Dispose();
        // 清理字体资源
        foreach (var pair in _fonts)
            pair.Dispose();
    }

    private void _window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
    {
        var gfx = e.Graphics;

        gfx.ClearScene(_brush_transparency);

        if (!_isDraw)
            return;

        ResizeWindow(gfx);

        ///////////////////////////////////////////////////////
        //                 用户自定义绘制区域                   //
        ///////////////////////////////////////////////////////

        // 视角宽和视角高
        _gviewWidth = _windowData.Width / 2;
        _gviewHeight = _windowData.Height / 2;

        var pWordPTR = Memory.Read<long>(Pointers.WorldPTR);
        var pLocalCPed = Memory.Read<long>(pWordPTR + 0x08);

        // 自己坐标
        var pLocalCNavigation = Memory.Read<long>(pLocalCPed + 0x30);
        var localPosV3 = Memory.Read<Vector3>(pLocalCNavigation + 0x50);

        /////////////////////////////////////////////////////////////////////

        // 玩家列表
        var pCNetworkPlayerMgr = Memory.Read<long>(Pointers.NetworkPlayerMgrPTR);
        var playerCount = Memory.Read<int>(pCNetworkPlayerMgr + 0x180);

        var pReplayInterface = Memory.Read<long>(Pointers.ReplayInterfacePTR);

        // Ped
        var pCPedInterface = Memory.Read<long>(pReplayInterface + CReplayInterface.CPedInterface);
        var m_max_peds = Memory.Read<int>(pCPedInterface + CPedInterface.MaxPeds);
        var m_cur_peds = Memory.Read<int>(pCPedInterface + CPedInterface.CurPeds);

        // 载具
        var pCVehicleInterface = Memory.Read<long>(pReplayInterface + CReplayInterface.CVehicleInterface);
        var m_max_vehicles = Memory.Read<int>(pCVehicleInterface + CVehicleInterface.MaxVehicles);
        var m_cur_vehicles = Memory.Read<int>(pCVehicleInterface + CVehicleInterface.CurVehicles);

        // 可拾取
        var pCPickupInterface = Memory.Read<long>(pReplayInterface + CReplayInterface.CPickupInterface);
        var m_max_pickups = Memory.Read<int>(pCPickupInterface + CPickupInterface.MaxPickups);
        var m_cur_pickups = Memory.Read<int>(pCPickupInterface + CPickupInterface.CurPickups);

        // 对象
        var pCObjectInterface = Memory.Read<long>(pReplayInterface + CReplayInterface.CObjectInterface);
        var m_max_objects = Memory.Read<int>(pCObjectInterface + CObjectInterface.MaxObjects);
        var m_cur_objects = Memory.Read<int>(pCObjectInterface + CObjectInterface.CurObjects);

        if (Setting.ESP_InfoText)
        {
            // 绘制帧数文本
            gfx.DrawText(_font_YaHei, 12, _brush_green, 10, _window.Height / 3, $"FPS：{gfx.FPS}");

            // 绘制信息文本
            _infoText.Clear();
            _infoText.AppendLine("GTA5线上小助手\n");
            _infoText.AppendLine($"X: {localPosV3.X:0.0000}");
            _infoText.AppendLine($"Y: {localPosV3.Y:0.0000}");
            _infoText.AppendLine($"Z: {localPosV3.Z:0.0000}\n");
            _infoText.AppendLine($"线上玩家: {playerCount}");
            _infoText.AppendLine($"人物模型: {m_cur_peds}");
            _infoText.AppendLine($"载具模型: {m_cur_vehicles}");
            _infoText.AppendLine($"掉落物品: {m_cur_pickups}");
            _infoText.AppendLine($"游戏对象: {m_cur_objects}");
        }

        gfx.DrawText(_font_YaHei, 12, _brush_blue, 10, _window.Height / 3 + 30, _infoText.ToString());

        var pAimingPed = Memory.Read<long>(Pointers.AimingPedPTR);
        var isAimPed = Memory.Read<long>(pAimingPed + 0x280) > 0;

        if (Setting.ESP_Crosshair)
        {
            // 当玩家按住右键准心对准敌人，准心变成粉红色，否则为绿色
            if (isAimPed && KeyHelper.IsKeyPressed(WinVK.RBUTTON))
                Draw.DrawCrosshair(_brush_deepPink, 7.0f, 1.5f);
            else
                Draw.DrawCrosshair(_brush_green, 7.0f, 1.5f);
        }

        ///////////////////////////////////////////////////////

        for (var i = 0; i < m_max_peds; i++)
        {
            var pCPedList = Memory.Read<long>(pCPedInterface + CPedInterface.CPedList);
            var pCPed = Memory.Read<long>(pCPedList + i * 0x10);      // CEntityEntry
            if (!Memory.IsValid(pCPed))
                continue;

            // 如果是自己，跳过
            if (pLocalCPed == pCPed)
                continue;

            // 如果ped死亡，跳过
            var ped_Health = Memory.Read<float>(pCPed + 0x280);
            if (ped_Health <= 0)
                continue;

            var ped_MaxHealth = Memory.Read<float>(pCPed + 0x284);
            var ped_HPPercentage = ped_Health / ped_MaxHealth;

            var pCPlayerInfo = Memory.Read<long>(pCPed + 0x10A8);
            //if (!Memory.IsValid(pCPlayerInfo))
            //    continue;

            var pedName = Memory.ReadString(pCPlayerInfo + 0x104, 20);

            // 绘制玩家
            if (!Setting.ESP_Player)
            {
                // 当不绘制玩家时，跳过玩家名称不为空的
                if (!string.IsNullOrEmpty(pedName))
                    continue;
            }

            // 绘制Ped
            if (!Setting.ESP_NPC)
            {
                // 当不绘制NPC时，跳过玩家名称为空的
                if (string.IsNullOrEmpty(pedName))
                    continue;
            }

            var pCNavigation = Memory.Read<long>(pCPed + 0x30);
            if (!Memory.IsValid(pCNavigation))
                continue;

            // ped坐标
            var pedPosV3 = Memory.Read<Vector3>(pCNavigation + 0x50);

            // Ped与自己的距离
            var distance = (float)Math.Sqrt(
                Math.Pow(localPosV3.X - pedPosV3.X, 2) +
                Math.Pow(localPosV3.Y - pedPosV3.Y, 2) +
                Math.Pow(localPosV3.Z - pedPosV3.Z, 2));

            // m_heading    0x20
            // m_heading2   0x24
            var v2PedSinCos = new Vector2
            {
                X = Memory.Read<float>(pCNavigation + 0x20),
                Y = Memory.Read<float>(pCNavigation + 0x30)
            };

            if (Setting.ESP_3DBox)
            {
                if (!string.IsNullOrEmpty(pedName))
                {
                    // 玩家 3DBox
                    Draw.DrawAABBBox(_brush_red, pedPosV3, v2PedSinCos);
                }
                else
                {
                    // Ped 3DBox
                    Draw.DrawAABBBox(_brush_white, pedPosV3, v2PedSinCos);
                }
            }

            Vector2 pedPosV2 = Core.WorldToScreen(pedPosV3);
            Vector2 pedBoxV2 = Core.GetBoxWH(pedPosV3);

            if (!Core.IsNullVector2(pedPosV2))
            {
                //int ped_type = Memory.Read<int>(pCPed + 0x10B8);
                //ped_type = ped_type << 11 >> 25;
                //Draw2DNameText(_brush_white, pedPosV2, pedBoxV2, ped_type.ToString(), myToPedDistance);

                if (!string.IsNullOrEmpty(pedName))
                {
                    if (Setting.ESP_2DBox)
                    {
                        // 2D方框
                        Draw.Draw2DBox(_brush_red, pedPosV2, pedBoxV2, 0.7f);
                    }

                    if (Setting.ESP_2DLine)
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2DBox射线
                            Draw.Draw2DLine(_brush_red, pedPosV2, pedBoxV2, 0.7f);
                        }
                        else
                        {
                            // 3DBox射线
                            Draw.DrawAABBLine(_brush_red, pedPosV3, 0.7f);
                        }
                    }

                    if (Setting.ESP_2DHealthBar)
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2DBox血条
                            Draw.Draw2DHealthBar(_brush_white, _brush_green, pedPosV2, pedBoxV2, ped_HPPercentage, 0.7f);
                        }
                        else
                        {
                            // 3DBox血条
                            Draw.Draw3DHealthBar(_brush_white, _brush_green, pedPosV2, pedBoxV2, ped_HPPercentage, 0.7f);
                        }
                    }

                    if (Setting.ESP_HealthText)
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2DBox血量数字
                            Draw.Draw2DHealthText(_font_YaHei, _brush_red, pedPosV2, pedBoxV2, ped_Health, ped_MaxHealth, i);
                        }
                        else
                        {
                            // 3DBox血量数字
                            Draw.Draw3DHealthText(_font_YaHei, _brush_red, pedPosV2, pedBoxV2, ped_Health, ped_MaxHealth, i);
                        }
                    }

                    if (Setting.ESP_NameText)
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2DBox玩家名称
                            Draw.Draw2DNameText(_font_YaHei, _brush_red, pedPosV2, pedBoxV2, pedName, distance);
                        }
                        else
                        {
                            // 3DBox玩家名称
                            Draw.Draw3DNameText(_font_YaHei, _brush_red, pedPosV2, pedBoxV2, pedName, distance);
                        }
                    }
                }
                else
                {
                    if (Setting.ESP_2DBox)
                    {
                        // 2D方框
                        Draw.Draw2DBox(_brush_white, pedPosV2, pedBoxV2, 0.7f);
                    }

                    if (Setting.ESP_2DLine)
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2DBox射线
                            Draw.Draw2DLine(_brush_white, pedPosV2, pedBoxV2, 0.7f);
                        }
                        else
                        {
                            // 3DBox射线
                            Draw.DrawAABBLine(_brush_white, pedPosV3, 0.7f);
                        }
                    }

                    if (Setting.ESP_2DHealthBar)
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2DBox血条
                            Draw.Draw2DHealthBar(_brush_white, _brush_green, pedPosV2, pedBoxV2, ped_HPPercentage, 0.7f);
                        }
                        else
                        {
                            // 3DBox血条
                            Draw.Draw3DHealthBar(_brush_white, _brush_green, pedPosV2, pedBoxV2, ped_HPPercentage, 0.7f);
                        }
                    }

                    if (Setting.ESP_HealthText)
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2DBox血量数字
                            Draw.Draw2DHealthText(_font_YaHei, _brush_white, pedPosV2, pedBoxV2, ped_Health, ped_MaxHealth, i);
                        }
                        else
                        {
                            // 3DBox血量数字
                            Draw.Draw3DHealthText(_font_YaHei, _brush_white, pedPosV2, pedBoxV2, ped_Health, ped_MaxHealth, i);
                        }
                    }

                    if (Setting.ESP_NameText)
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2DBox玩家名称
                            Draw.Draw2DNameText(_font_YaHei, _brush_white, pedPosV2, pedBoxV2, pedName, distance);
                        }
                        else
                        {
                            // 3DBox玩家名称
                            Draw.Draw3DNameText(_font_YaHei, _brush_white, pedPosV2, pedBoxV2, pedName, distance);
                        }
                    }
                }

                //int pedEntityType = Memory.Read<int>(ped_offset_0 + 0x10B8);
                //byte pedEntityType = Memory.Read<byte>(ped_offset_0 + 0x2B);
                //byte oHostility = Memory.Read<byte>(ped_offset_0 + 0x18C);

                //pedEntityType = pedEntityType >> 14 & 0x1F;

                //gfx.DrawText(_font_YaHei, 10, _brush_red,
                //    pedPosV2.X, pedPosV2.Y,
                //    $"Type : {pedEntityType}");
            }

            if (Setting.ESP_Bone)
            {
                // 骨骼
                Draw.DrawBone(_brush_white, pCPed, 0, 7);
                Draw.DrawBone(_brush_white, pCPed, 7, 8);
                Draw.DrawBone(_brush_white, pCPed, 8, 3);
                Draw.DrawBone(_brush_white, pCPed, 8, 4);
                Draw.DrawBone(_brush_white, pCPed, 7, 5);
                Draw.DrawBone(_brush_white, pCPed, 7, 6);
            }
        }
    }

    /// <summary>
    /// 窗口移动跟随
    /// </summary>
    /// <param name="gfx"></param>
    private void ResizeWindow(Graphics gfx)
    {
        _windowData = Memory.GetGameWindowData();

        if (_window.X != _windowData.Left)
        {
            _window.X = _windowData.Left;
            _window.Y = _windowData.Top;
            _window.Width = _windowData.Width;
            _window.Height = _windowData.Height;

            gfx.Resize(_window.Width, _window.Height);

            Core.SetWindowData(_windowData.Width, _windowData.Height);
            Draw.SetWindowData(_windowData.Width, _windowData.Height);
        }
    }

    private void AimbotThread()
    {
        while (_isRun)
        {
            if (Setting.AimBot_Enabled)
            {
                var aimBot_Min_Distance = Setting.AimBot_Fov;
                var aimBot_ViewAngles = new Vector3() { X = 0, Y = 0, Z = 0 };
                var teleW_pedCoords = new Vector3() { X = 0, Y = 0, Z = 0 };

                var pCPedFactory = Memory.Read<long>(Pointers.WorldPTR);
                var pCPed = Memory.Read<long>(pCPedFactory + CPed.__Offset__);
                var oInVehicle = Memory.Read<byte>(pCPed + CPed.InVehicle);
                var pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo.__Offset__);

                // 玩家自己RID
                var myRID = Memory.Read<long>(pCPlayerInfo + CPed.CPlayerInfo.RockstarID);

                // 相机坐标
                var pCCameraPTR = Memory.Read<long>(Pointers.CCameraPTR);
                var pCCameraPTR_0 = Memory.Read<long>(pCCameraPTR + 0x00);
                pCCameraPTR_0 = Memory.Read<long>(pCCameraPTR_0 + 0x3C0);
                var cameraV3Pos = Memory.Read<Vector3>(pCCameraPTR_0 + 0x60);

                // 是否是第一人称，当Fov=0为第一人称或者开镜状态，第三人称50
                var offset = Memory.Read<long>(pCCameraPTR_0 + 0x10);
                var isFPP = Memory.Read<float>(offset + 0x30);

                // Ped实体
                var pReplayInterfacePTR = Memory.Read<long>(Pointers.ReplayInterfacePTR);
                var my_offset_0x18 = Memory.Read<long>(pReplayInterfacePTR + 0x18);

                for (var i = 0; i < 128; i++)
                {
                    var ped_offset_0 = Memory.Read<long>(my_offset_0x18 + 0x100);
                    ped_offset_0 = Memory.Read<long>(ped_offset_0 + i * 0x10);
                    if (ped_offset_0 == 0)
                    {
                        continue;
                    }

                    var pedHealth = Memory.Read<float>(ped_offset_0 + 0x280);
                    if (pedHealth <= 0)
                    {
                        continue;
                    }

                    var ped_offset_1 = Memory.Read<long>(ped_offset_0 + 0x10A8);
                    var pedRID = Memory.Read<long>(ped_offset_1 + 0x90);
                    if (myRID == pedRID)
                    {
                        continue;
                    }

                    var pedName = Memory.ReadString(ped_offset_1 + 0xA4, 20);

                    // 绘制玩家
                    if (!Setting.ESP_Player)
                    {
                        if (pedName != "")
                        {
                            continue;
                        }
                    }

                    // 绘制Ped
                    if (!Setting.ESP_NPC)
                    {
                        if (pedName == "")
                        {
                            continue;
                        }
                    }

                    var pedV3Pos = Memory.Read<Vector3>(ped_offset_0 + 0x90);
                    var pedV2Pos = Core.WorldToScreen(pedV3Pos);

                    // 自瞄数据
                    var aimBot_Distance = (float)Math.Sqrt(Math.Pow(pedV2Pos.X - _gviewWidth, 2) + Math.Pow(pedV2Pos.Y - _gviewHeight, 2));
                    // 获取距离准心最近的方框
                    if (aimBot_Distance < aimBot_Min_Distance)
                    {
                        aimBot_Min_Distance = aimBot_Distance;
                        aimBot_ViewAngles = Core.GetCCameraViewAngles(cameraV3Pos, Core.GetBonePosition(ped_offset_0, Setting.AimBot_BoneIndex));
                        teleW_pedCoords = pedV3Pos;
                    }
                }

                // 玩家处于载具或者掩护状态中不启用自瞄，无目标取消自瞄
                if (oInVehicle != 0x01 && aimBot_Min_Distance != Setting.AimBot_Fov)
                {
                    // 默认按住Ctrl键自瞄
                    if (KeyHelper.IsKeyPressed(Setting.AimBot_Key))
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

                        if (KeyHelper.IsKeyPressed(WinVK.F5))
                        {
                            Teleport.SetTeleportPosition(teleW_pedCoords);
                        }
                    }
                }
            }

            Thread.Sleep(1);
        }
    }

    /////////////////////////////////////////////

    public void Run()
    {
        _window.Create();
        _window.Join();
    }

    ~Overlay()
    {
        Dispose(false);
    }

    #region IDisposable Support
    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            _window.Dispose();

            disposedValue = true;
        }

        _isRun = false;

        Setting.Reset();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}