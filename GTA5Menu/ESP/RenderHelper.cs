using GTA5Core.Native;
using GTA5Core.Feature;

using ImGuiNET;
using static System.Net.Mime.MediaTypeNames;
using Vortice.Mathematics;

namespace GTA5Menu.ESP;

public static class RenderHelper
{
    /// <summary>
    /// 获取相机矩阵信息
    /// </summary>
    public static float[] GetMatrix()
    {
        return Memory.ReadMatrix<float>(Pointers.ViewPortPTR + 0xC0, 16);
    }

    /// <summary>
    /// 判断Vector2是否有效
    /// </summary>
    public static bool IsValid(Vector2 vector)
    {
        return vector != Vector2.Zero;
    }

    /// <summary>
    /// 判断Vector3是否有效
    /// </summary>
    public static bool IsValid(Vector3 vector)
    {
        return vector != Vector3.Zero;
    }

    /// <summary>
    /// 3D世界坐标转2D屏幕坐标
    /// </summary>
    public static Vector2 WorldToScreen(Vector3 posV3)
    {
        if (!IsValid(posV3))
            return Vector2.Zero;

        var cameraV3 = Vector3.Zero;
        var screenV2 = Vector2.Zero;

        var viewMatrix = GetMatrix();
        var width = ImGui.GetIO().DisplaySize.X;
        var height = ImGui.GetIO().DisplaySize.Y;

        cameraV3.Z = viewMatrix[2] * posV3.X + viewMatrix[6] * posV3.Y + viewMatrix[10] * posV3.Z + viewMatrix[14];
        if (cameraV3.Z < 0.001f)
            return Vector2.Zero;

        screenV2.X = viewMatrix[0] * posV3.X + viewMatrix[4] * posV3.Y + viewMatrix[8] * posV3.Z + viewMatrix[12];
        screenV2.Y = viewMatrix[1] * posV3.X + viewMatrix[5] * posV3.Y + viewMatrix[9] * posV3.Z + viewMatrix[13];

        cameraV3.X = width / 2;
        cameraV3.Y = height / 2;
        cameraV3.Z = 1 / cameraV3.Z;

        screenV2.X = cameraV3.X + cameraV3.X * screenV2.X * cameraV3.Z;
        screenV2.Y = cameraV3.Y - cameraV3.Y * screenV2.Y * cameraV3.Z;

        return screenV2;
    }

    /// <summary>
    /// 获取方框宽度和高度信息
    /// </summary>
    public static Vector2 GetBoxInfo(Vector3 posV3)
    {
        if (!IsValid(posV3))
            return Vector2.Zero;

        var cameraV3 = Vector3.Zero;
        var boxV2 = Vector2.Zero;

        var viewMatrix = GetMatrix();
        var height = ImGui.GetIO().DisplaySize.Y;

        cameraV3.Z = viewMatrix[2] * posV3.X + viewMatrix[6] * posV3.Y + viewMatrix[10] * posV3.Z + viewMatrix[14];
        if (cameraV3.Z < 0.001f)
            return Vector2.Zero;

        boxV2.X = viewMatrix[1] * posV3.X + viewMatrix[5] * posV3.Y + viewMatrix[9] * (posV3.Z + 1.0f) + viewMatrix[13];
        boxV2.Y = viewMatrix[1] * posV3.X + viewMatrix[5] * posV3.Y + viewMatrix[9] * (posV3.Z - 1.0f) + viewMatrix[13];

        cameraV3.Y = height / 2;
        cameraV3.Z = 1 / cameraV3.Z;

        boxV2.X = cameraV3.Y - cameraV3.Y * boxV2.X * cameraV3.Z;
        boxV2.Y = cameraV3.Y - cameraV3.Y * boxV2.Y * cameraV3.Z;

        boxV2.Y = Math.Abs(boxV2.X - boxV2.Y);
        boxV2.X = boxV2.Y / 2;

        return boxV2;
    }

    public static void ImGuiDrawText(Vector2 pos, Vector4 color, string text)
    {
        ImGui.GetForegroundDrawList().AddText(pos, ImGui.ColorConvertFloat4ToU32(color), text);
    }

    public static void ImGuiDrawLine(Vector2 p1, Vector2 p2, Vector4 color, float thickness)
    {
        ImGui.GetForegroundDrawList().AddLine(p1, p2, ImGui.ColorConvertFloat4ToU32(color), thickness);
    }

    public static void ImGuiDrawCircle(Vector2 center, float radius, Vector4 color)
    {
        ImGui.GetForegroundDrawList().AddCircle(center, radius, ImGui.ColorConvertFloat4ToU32(color));
    }

    public static void ImGuiDrawRect(Vector2 p_min, Vector2 p_max, Vector4 color)
    {
        ImGui.GetForegroundDrawList().AddRect(p_min, p_max, ImGui.ColorConvertFloat4ToU32(color));
    }

    public static void ImGuiDrawRectFilled(Vector2 p_min, Vector2 p_max, Vector4 color)
    {
        ImGui.GetForegroundDrawList().AddRectFilled(p_min, p_max, ImGui.ColorConvertFloat4ToU32(color));
    }

    /////////////////////////////////////////////////////

    public static void DrawText(Vector2 pos, Vector4 color, string text)
    {
        ImGuiDrawText(pos, color, text);
    }

    public static void DrawLine(Vector2 pos, Vector2 box, Vector4 color, float thickness = 0.7f)
    {
        var width = ImGui.GetIO().DisplaySize.X / 2;
        pos.Y -= box.Y / 2;

        ImGuiDrawLine(new Vector2(width / 2, 0), pos, color, thickness);
    }

    public static void DrawBox(Vector2 p_min, Vector2 p_max, Vector4 color)
    {
        p_min.X -= p_max.X / 2;
        p_min.Y -= p_max.Y / 2;

        p_max.X += p_min.X;
        p_max.Y += p_min.Y;

        ImGuiDrawRect(p_min, p_max, color);
    }
}
