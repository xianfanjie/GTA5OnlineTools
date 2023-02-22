using GTA5Core.Native;
using GTA5Core.Feature;

using ImGuiNET;

namespace GTA5Menu.ESP;

public static class RenderHelper
{
    private static Vector4 GreenColor = new(0.063f, 0.542f, 0.063f, 1.000f);
    private static Vector4 YellowColor = new(0.939f, 0.948f, 0.183f, 1.000f);
    private static Vector4 RedColor = new(0.976f, 0.215f, 0.086f, 1.000f);

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
    public static Vector2 WorldToScreen(Vector3 posV3, float width, float height)
    {
        if (!IsValid(posV3))
            return Vector2.Zero;

        var cameraV3 = Vector3.Zero;
        var screenV2 = Vector2.Zero;

        var viewMatrix = GetMatrix();

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
    public static Vector2 GetBoxInfo(Vector3 posV3, float height)
    {
        if (!IsValid(posV3))
            return Vector2.Zero;

        var cameraV3 = Vector3.Zero;
        var boxV2 = Vector2.Zero;

        var viewMatrix = GetMatrix();

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

    public static Vector3 GetBonePosition(long pointer, int boneId)
    {
        float[] bomematrix = Memory.ReadMatrix<float>(pointer + 0x60, 16);

        Vector3 bone_offset_pos = Memory.Read<Vector3>(pointer + 0x410 + boneId * 0x10);

        Vector3 bone_pos;
        bone_pos.X = bomematrix[0] * bone_offset_pos.X + bomematrix[4] * bone_offset_pos.Y + bomematrix[8] * bone_offset_pos.Z + bomematrix[12];
        bone_pos.Y = bomematrix[1] * bone_offset_pos.X + bomematrix[5] * bone_offset_pos.Y + bomematrix[9] * bone_offset_pos.Z + bomematrix[13];
        bone_pos.Z = bomematrix[2] * bone_offset_pos.X + bomematrix[6] * bone_offset_pos.Y + bomematrix[10] * bone_offset_pos.Z + bomematrix[14];

        return bone_pos;
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

    public static void DrawText(Vector2 screen, Vector4 color, string text)
    {
        if (!IsValid(screen))
            return;

        ImGuiDrawText(screen, color, text);
    }

    public static void DrawLine(Vector2 screen, Vector2 box, Vector4 color, float thickness = 0.7f)
    {
        if (!IsValid(screen) || !IsValid(box))
            return;

        screen.Y -= box.Y / 2;

        ImGuiDrawLine(new Vector2(ImGui.GetIO().DisplaySize.X / 2, 0), screen, color, thickness);
    }

    public static void DrawBox(Vector2 screen, Vector2 box, Vector4 color)
    {
        if (!IsValid(screen) || !IsValid(box))
            return;

        screen.X -= box.X / 2;
        screen.Y -= box.Y / 2;

        box.X += screen.X;
        box.Y += screen.Y;

        ImGuiDrawRect(screen, box, color);
    }

    public static void DrawCircle(Vector2 center, float radius, Vector4 color)
    {
        if (!IsValid(center) || radius == 0)
            return;

        ImGuiDrawCircle(center, radius, color);
    }

    public static void DrawHPBar(Vector2 screen, Vector2 box, float pct)
    {
        if (!IsValid(screen) || !IsValid(box))
            return;

        float width = box.X / 8.0f;

        Vector2 p_min, p_max;

        if (pct > 1)
            pct = 1;

        p_min.X = screen.X - box.X / 2 - width * 1.2f;
        p_min.Y = screen.Y + box.Y / 2;
        p_max.X = p_min.X + width;
        p_max.Y = p_min.Y - box.Y * pct;

        Vector4 color;
        if (pct > 0.7)
            color = GreenColor;
        else if (pct <= 0.7 && pct > 0.4)
            color = YellowColor;
        else
            color = RedColor;

        ImGuiDrawRectFilled(p_min, p_max, color);
    }

    public static void DrawBone(long pointer, int index1, int index2, float width, float height, Vector4 color, float thickness = 0.7f)
    {
        Vector2 boneScreen1 = WorldToScreen(GetBonePosition(pointer, index1), width, height);
        Vector2 boneScreen2 = WorldToScreen(GetBonePosition(pointer, index2), width, height);

        if (!IsValid(boneScreen1) || !IsValid(boneScreen2))
            return;

        ImGuiDrawLine(boneScreen1, boneScreen2, color, thickness);
    }

    public static Vector3 GetCCameraViewAngles(Vector3 cameraV3, Vector3 targetV3)
    {
        float distance = (float)Math.Sqrt(Math.Pow(cameraV3.X - targetV3.X, 2) + Math.Pow(cameraV3.Y - targetV3.Y, 2) + Math.Pow(cameraV3.Z - targetV3.Z, 2));

        return new Vector3
        {
            X = (targetV3.X - cameraV3.X) / distance,
            Y = (targetV3.Y - cameraV3.Y) / distance,
            Z = (targetV3.Z - cameraV3.Z) / distance
        };
    }
}
