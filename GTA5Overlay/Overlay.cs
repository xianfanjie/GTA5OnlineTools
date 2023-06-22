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

    private readonly Dictionary<string, SolidBrush> _brushes;
    private readonly Dictionary<string, Font> _fonts;

    private WindowData _windowData;

    private readonly StringBuilder _builder = new();

    // 视角宽和视角高
    private float _gviewWidth;
    private float _gviewHeight;

    private bool _isDraw = true;
    private bool _isRun = true;

    public Overlay()
    {
        _windowData = Memory.GetGameWindowData();
        Memory.SetForegroundWindow();

        Core.SetWindowData(_windowData.Width, _windowData.Height);
        Draw.SetWindowData(_windowData.Width, _windowData.Height);

        /////////////////////////////////////////////

        _brushes = new Dictionary<string, SolidBrush>();
        _fonts = new Dictionary<string, Font>();

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

        Draw.SetGraphicsIns(gfx);

        if (e.RecreateResources)
        {
            foreach (var pair in _brushes)
                pair.Value.Dispose();
        }

        _brushes["black"] = gfx.CreateSolidBrush(0, 0, 0);
        _brushes["white"] = gfx.CreateSolidBrush(255, 255, 255);
        _brushes["red"] = gfx.CreateSolidBrush(255, 0, 98);
        _brushes["green"] = gfx.CreateSolidBrush(0, 128, 0);
        _brushes["blue"] = gfx.CreateSolidBrush(30, 144, 255);
        _brushes["bgcolor"] = gfx.CreateSolidBrush(11, 11, 11, 150);
        _brushes["grid"] = gfx.CreateSolidBrush(255, 255, 255, 0.2f);
        _brushes["deepPink"] = gfx.CreateSolidBrush(247, 63, 147, 255);

        _brushes["transparency"] = gfx.CreateSolidBrush(0, 0, 0, 0);

        if (e.RecreateResources)
            return;

        _fonts["Microsoft YaHei"] = gfx.CreateFont("Microsoft YaHei", 12);
    }

    private void _window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
    {
        // 清理颜色资源
        foreach (var pair in _brushes)
            pair.Value.Dispose();
        // 清理字体资源
        foreach (var pair in _fonts)
            pair.Value.Dispose();
    }

    private void _window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
    {
        var gfx = e.Graphics;

        gfx.ClearScene(_brushes["transparency"]);

        if (_isDraw)
        {
            ResizeWindow(gfx);

            // 绘制帧数
            gfx.DrawText(_fonts["Microsoft YaHei"], 12, _brushes["green"], 10, _window.Height / 3, $"FPS：{gfx.FPS}");

            ///////////////////////////////////////////////////////
            //                 用户自定义绘制区域                   //
            ///////////////////////////////////////////////////////

            // 视角宽和视角高
            _gviewWidth = _windowData.Width / 2;
            _gviewHeight = _windowData.Height / 2;

            long m_ped_factory = Memory.Read<long>(Pointers.WorldPTR);
            long m_local_ped = Memory.Read<long>(m_ped_factory + 0x08);

            // 自己坐标
            long pCNavigation = Memory.Read<long>(m_local_ped + 0x30);
            Vector3 myPosV3 = Memory.Read<Vector3>(pCNavigation + 0x50);

            /////////////////////////////////////////////////////////////////////

            // 玩家列表
            long pCNetworkPlayerMgr = Memory.Read<long>(Pointers.NetworkPlayerMgrPTR);
            int playerCount = Memory.Read<int>(pCNetworkPlayerMgr + 0x180);

            long pReplayInterface = Memory.Read<long>(Pointers.ReplayInterfacePTR);

            // Ped
            long pCPedInterface = Memory.Read<long>(pReplayInterface + CReplayInterface.CPedInterface.__Offset__);
            int m_max_peds = Memory.Read<int>(pCPedInterface + CReplayInterface.CPedInterface.MaxPeds);
            int m_cur_peds = Memory.Read<int>(pCPedInterface + CReplayInterface.CPedInterface.CurPeds);

            // 载具
            long pCVehicleInterface = Memory.Read<long>(pReplayInterface + CReplayInterface.CVehicleInterface.__Offset__);
            int m_max_vehicles = Memory.Read<int>(pCVehicleInterface + CReplayInterface.CVehicleInterface.MaxVehicles);
            int m_cur_vehicles = Memory.Read<int>(pCVehicleInterface + CReplayInterface.CVehicleInterface.CurVehicles);

            // 可拾取
            long pCPickupInterface = Memory.Read<long>(pReplayInterface + CReplayInterface.CPickupInterface.__Offset__);
            int m_max_pickups = Memory.Read<int>(pCPickupInterface + CReplayInterface.CPickupInterface.MaxPickups);
            int m_cur_pickups = Memory.Read<int>(pCPickupInterface + CReplayInterface.CPickupInterface.CurPickups);

            // 对象
            long pCObjectInterface = Memory.Read<long>(pReplayInterface + CReplayInterface.CObjectInterface.__Offset__);
            int m_max_objects = Memory.Read<int>(pCObjectInterface + CReplayInterface.CObjectInterface.MaxObjects);
            int m_cur_objects = Memory.Read<int>(pCObjectInterface + CReplayInterface.CObjectInterface.CurObjects);

            _builder.Clear();
            _builder.AppendLine("GTA5线上小助手\n");
            _builder.AppendLine($"X: {myPosV3.X:0.0000}");
            _builder.AppendLine($"Y: {myPosV3.Y:0.0000}");
            _builder.AppendLine($"Z: {myPosV3.Z:0.0000}\n");
            _builder.AppendLine($"线上玩家: {playerCount}");
            _builder.AppendLine($"人物模型: {m_cur_peds}");
            _builder.AppendLine($"载具模型: {m_cur_vehicles}");
            _builder.AppendLine($"掉落物品: {m_cur_pickups}");
            _builder.AppendLine($"游戏对象: {m_cur_objects}");

            gfx.DrawText(_fonts["Microsoft YaHei"], 12, _brushes["blue"], 10, _window.Height / 3 + 30, _builder.ToString());

            long pAimingPed = Memory.Read<long>(Pointers.AimingPedPTR);
            bool isAimPed = Memory.Read<long>(pAimingPed + 0x280) > 0;

            if (Setting.ESP_Crosshair)
            {
                // 当玩家按住右键准心对准敌人，准心变成粉红色，否则为绿色
                if (isAimPed && KeyHelper.IsKeyPressed(WinVK.RBUTTON))
                    Draw.DrawCrosshair(_brushes["deepPink"], 7.0f, 1.5f);
                else
                    Draw.DrawCrosshair(_brushes["green"], 7.0f, 1.5f);
            }

            ///////////////////////////////////////////////////////

            for (int i = 0; i < m_max_peds; i++)
            {
                long m_ped_list = Memory.Read<long>(pCPedInterface + 0x100);
                m_ped_list = Memory.Read<long>(m_ped_list + i * 0x10);      // CEntityEntry
                if (!Memory.IsValid(m_ped_list))
                    continue;

                // 如果是自己，跳过
                if (m_local_ped == m_ped_list)
                    continue;

                // 如果ped死亡，跳过
                float ped_Health = Memory.Read<float>(m_ped_list + 0x280);
                if (ped_Health <= 0)
                    continue;

                float ped_MaxHealth = Memory.Read<float>(m_ped_list + 0x284);
                float ped_HPPercentage = ped_Health / ped_MaxHealth;

                long m_player_info = Memory.Read<long>(m_ped_list + 0x10A8);
                //if (!Memory.IsValid(m_player_info))
                //    continue;

                string pedName = Memory.ReadString(m_player_info + 0x104, 20);

                // 绘制玩家
                if (!Setting.ESP_Player)
                    if (pedName != "")
                        continue;

                // 绘制Ped
                if (!Setting.ESP_NPC)
                    if (pedName == "")
                        continue;

                long m_navigation = Memory.Read<long>(m_ped_list + 0x30);
                if (!Memory.IsValid(m_navigation))
                    continue;

                // ped坐标
                var pedPosV3 = Memory.Read<Vector3>(m_navigation + 0x50);

                // Ped与自己的距离
                float myToPedDistance = (float)Math.Sqrt(
                    Math.Pow(myPosV3.X - pedPosV3.X, 2) +
                    Math.Pow(myPosV3.Y - pedPosV3.Y, 2) +
                    Math.Pow(myPosV3.Z - pedPosV3.Z, 2));

                // m_heading    0x20
                // m_heading2   0x24
                var v2PedSinCos = new Vector2
                {
                    X = Memory.Read<float>(m_navigation + 0x20),
                    Y = Memory.Read<float>(m_navigation + 0x30)
                };

                if (Setting.ESP_3DBox)
                {
                    if (pedName != "")
                    {
                        // 玩家 3DBox
                        Draw.DrawAABBBox(_brushes["red"], pedPosV3, v2PedSinCos);
                    }
                    else
                    {
                        // Ped 3DBox
                        Draw.DrawAABBBox(_brushes["white"], pedPosV3, v2PedSinCos);
                    }
                }

                Vector2 pedPosV2 = Core.WorldToScreen(pedPosV3);
                Vector2 pedBoxV2 = Core.GetBoxWH(pedPosV3);

                if (!Core.IsNullVector2(pedPosV2))
                {
                    //int ped_type = Memory.Read<int>(m_ped_list + 0x10B8);
                    //ped_type = ped_type << 11 >> 25;
                    //Draw2DNameText(_brushes["white"], pedPosV2, pedBoxV2, ped_type.ToString(), myToPedDistance);

                    if (pedName != "")
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2D方框
                            Draw.Draw2DBox(_brushes["red"], pedPosV2, pedBoxV2, 0.7f);
                        }

                        if (Setting.ESP_2DLine)
                        {
                            if (Setting.ESP_2DBox)
                            {
                                // 2DBox射线
                                Draw.Draw2DLine(_brushes["red"], pedPosV2, pedBoxV2, 0.7f);
                            }
                            else
                            {
                                // 3DBox射线
                                Draw.DrawAABBLine(_brushes["red"], pedPosV3, 0.7f);
                            }
                        }

                        if (Setting.ESP_2DHealthBar)
                        {
                            if (Setting.ESP_2DBox)
                            {
                                // 2DBox血条
                                Draw.Draw2DHealthBar(_brushes["white"], _brushes["green"], pedPosV2, pedBoxV2, ped_HPPercentage, 0.7f);
                            }
                            else
                            {
                                // 3DBox血条
                                Draw.Draw3DHealthBar(_brushes["white"], _brushes["green"], pedPosV2, pedBoxV2, ped_HPPercentage, 0.7f);
                            }
                        }

                        if (Setting.ESP_HealthText)
                        {
                            if (Setting.ESP_2DBox)
                            {
                                // 2DBox血量数字
                                Draw.Draw2DHealthText(_fonts["Microsoft YaHei"], _brushes["red"], pedPosV2, pedBoxV2, ped_Health, ped_MaxHealth, i);
                            }
                            else
                            {
                                // 3DBox血量数字
                                Draw.Draw3DHealthText(_fonts["Microsoft YaHei"], _brushes["red"], pedPosV2, pedBoxV2, ped_Health, ped_MaxHealth, i);
                            }
                        }

                        if (Setting.ESP_NameText)
                        {
                            if (Setting.ESP_2DBox)
                            {
                                // 2DBox玩家名称
                                Draw.Draw2DNameText(_fonts["Microsoft YaHei"], _brushes["red"], pedPosV2, pedBoxV2, pedName, myToPedDistance);
                            }
                            else
                            {
                                // 3DBox玩家名称
                                Draw.Draw3DNameText(_fonts["Microsoft YaHei"], _brushes["red"], pedPosV2, pedBoxV2, pedName, myToPedDistance);
                            }
                        }
                    }
                    else
                    {
                        if (Setting.ESP_2DBox)
                        {
                            // 2D方框
                            Draw.Draw2DBox(_brushes["white"], pedPosV2, pedBoxV2, 0.7f);
                        }

                        if (Setting.ESP_2DLine)
                        {
                            if (Setting.ESP_2DBox)
                            {
                                // 2DBox射线
                                Draw.Draw2DLine(_brushes["white"], pedPosV2, pedBoxV2, 0.7f);
                            }
                            else
                            {
                                // 3DBox射线
                                Draw.DrawAABBLine(_brushes["white"], pedPosV3, 0.7f);
                            }
                        }

                        if (Setting.ESP_2DHealthBar)
                        {
                            if (Setting.ESP_2DBox)
                            {
                                // 2DBox血条
                                Draw.Draw2DHealthBar(_brushes["white"], _brushes["green"], pedPosV2, pedBoxV2, ped_HPPercentage, 0.7f);
                            }
                            else
                            {
                                // 3DBox血条
                                Draw.Draw3DHealthBar(_brushes["white"], _brushes["green"], pedPosV2, pedBoxV2, ped_HPPercentage, 0.7f);
                            }
                        }

                        if (Setting.ESP_HealthText)
                        {
                            if (Setting.ESP_2DBox)
                            {
                                // 2DBox血量数字
                                Draw.Draw2DHealthText(_fonts["Microsoft YaHei"], _brushes["white"], pedPosV2, pedBoxV2, ped_Health, ped_MaxHealth, i);
                            }
                            else
                            {
                                // 3DBox血量数字
                                Draw.Draw3DHealthText(_fonts["Microsoft YaHei"], _brushes["white"], pedPosV2, pedBoxV2, ped_Health, ped_MaxHealth, i);
                            }
                        }

                        if (Setting.ESP_NameText)
                        {
                            if (Setting.ESP_2DBox)
                            {
                                // 2DBox玩家名称
                                Draw.Draw2DNameText(_fonts["Microsoft YaHei"], _brushes["white"], pedPosV2, pedBoxV2, pedName, myToPedDistance);
                            }
                            else
                            {
                                // 3DBox玩家名称
                                Draw.Draw3DNameText(_fonts["Microsoft YaHei"], _brushes["white"], pedPosV2, pedBoxV2, pedName, myToPedDistance);
                            }
                        }
                    }

                    //int pedEntityType = Memory.Read<int>(ped_offset_0 + 0x10B8);
                    //byte pedEntityType = Memory.Read<byte>(ped_offset_0 + 0x2B);
                    //byte oHostility = Memory.Read<byte>(ped_offset_0 + 0x18C);

                    //pedEntityType = pedEntityType >> 14 & 0x1F;

                    //gfx.DrawText(_fonts["Microsoft YaHei"], 10, _brushes["red"],
                    //    pedPosV2.X, pedPosV2.Y,
                    //    $"Type : {pedEntityType}");
                }

                if (Setting.ESP_Bone)
                {
                    // 骨骼
                    Draw.DrawBone(_brushes["white"], m_ped_list, 0, 7);
                    Draw.DrawBone(_brushes["white"], m_ped_list, 7, 8);
                    Draw.DrawBone(_brushes["white"], m_ped_list, 8, 3);
                    Draw.DrawBone(_brushes["white"], m_ped_list, 8, 4);
                    Draw.DrawBone(_brushes["white"], m_ped_list, 7, 5);
                    Draw.DrawBone(_brushes["white"], m_ped_list, 7, 6);
                }
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
                float aimBot_Min_Distance = Setting.AimBot_Fov;
                Vector3 aimBot_ViewAngles = new() { X = 0, Y = 0, Z = 0 };
                Vector3 teleW_pedCoords = new() { X = 0, Y = 0, Z = 0 };

                long pCPedFactory = Memory.Read<long>(Pointers.WorldPTR);
                long pCPed = Memory.Read<long>(pCPedFactory + CPed.__Offset__);
                byte oInVehicle = Memory.Read<byte>(pCPed + CPed.InVehicle);
                long pCPlayerInfo = Memory.Read<long>(pCPed + CPed.CPlayerInfo.__Offset__);

                // 玩家自己RID
                long myRID = Memory.Read<long>(pCPlayerInfo + CPed.CPlayerInfo.RockstarID);

                // 相机坐标
                long pCCameraPTR = Memory.Read<long>(Pointers.CCameraPTR);
                long pCCameraPTR_0 = Memory.Read<long>(pCCameraPTR + 0x00);
                pCCameraPTR_0 = Memory.Read<long>(pCCameraPTR_0 + 0x3C0);
                Vector3 cameraV3Pos = Memory.Read<Vector3>(pCCameraPTR_0 + 0x60);

                // 是否是第一人称，当Fov=0为第一人称或者开镜状态，第三人称50
                long offset = Memory.Read<long>(pCCameraPTR_0 + 0x10);
                float isFPP = Memory.Read<float>(offset + 0x30);

                // Ped实体
                long pReplayInterfacePTR = Memory.Read<long>(Pointers.ReplayInterfacePTR);
                long my_offset_0x18 = Memory.Read<long>(pReplayInterfacePTR + 0x18);

                for (int i = 0; i < 128; i++)
                {
                    long ped_offset_0 = Memory.Read<long>(my_offset_0x18 + 0x100);
                    ped_offset_0 = Memory.Read<long>(ped_offset_0 + i * 0x10);
                    if (ped_offset_0 == 0)
                    {
                        continue;
                    }

                    float pedHealth = Memory.Read<float>(ped_offset_0 + 0x280);
                    if (pedHealth <= 0)
                    {
                        continue;
                    }

                    long ped_offset_1 = Memory.Read<long>(ped_offset_0 + 0x10A8);
                    long pedRID = Memory.Read<long>(ped_offset_1 + 0x90);
                    if (myRID == pedRID)
                    {
                        continue;
                    }

                    string pedName = Memory.ReadString(ped_offset_1 + 0xA4, 20);

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

                    Vector3 pedV3Pos = Memory.Read<Vector3>(ped_offset_0 + 0x90);
                    var pedV2Pos = Core.WorldToScreen(pedV3Pos);

                    // 自瞄数据
                    float aimBot_Distance = (float)Math.Sqrt(Math.Pow(pedV2Pos.X - _gviewWidth, 2) + Math.Pow(pedV2Pos.Y - _gviewHeight, 2));
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