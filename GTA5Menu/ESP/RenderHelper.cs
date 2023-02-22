using GTA5Core.Native;
using GTA5Core.Feature;

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
    /// 世界坐标转屏幕坐标
    /// </summary>
    public static Vector2 WorldToScreen(Vector3 posV3, float width, float height)
    {
        Vector2 screenV2;
        Vector3 cameraV3;

        float[] viewMatrix = GetMatrix();

        cameraV3.Z = viewMatrix[2] * posV3.X + viewMatrix[6] * posV3.Y + viewMatrix[10] * posV3.Z + viewMatrix[14];
        if (cameraV3.Z < 0.001f)
            return Vector2.Zero;

        cameraV3.X = width / 2;
        cameraV3.Y = height / 2;
        cameraV3.Z = 1 / cameraV3.Z;

        screenV2.X = viewMatrix[0] * posV3.X + viewMatrix[4] * posV3.Y + viewMatrix[8] * posV3.Z + viewMatrix[12];
        screenV2.Y = viewMatrix[1] * posV3.X + viewMatrix[5] * posV3.Y + viewMatrix[9] * posV3.Z + viewMatrix[13];

        screenV2.X = cameraV3.X + cameraV3.X * screenV2.X * cameraV3.Z;
        screenV2.Y = cameraV3.Y - cameraV3.Y * screenV2.Y * cameraV3.Z;

        return screenV2;
    }

    /// <summary>
    /// 获取方框高度
    /// </summary>
    public static Vector2 GetBoxWH(Vector3 posV3, float height)
    {
        Vector2 boxV2;
        Vector3 cameraV3;

        float[] viewMatrix = GetMatrix();

        cameraV3.Z = viewMatrix[2] * posV3.X + viewMatrix[6] * posV3.Y + viewMatrix[10] * posV3.Z + viewMatrix[14];
        if (cameraV3.Z < 0.001f)
            return Vector2.Zero;

        cameraV3.Y = height / 2;
        cameraV3.Z = 1 / cameraV3.Z;

        boxV2.X = viewMatrix[1] * posV3.X + viewMatrix[5] * posV3.Y + viewMatrix[9] * (posV3.Z + 1.0f) + viewMatrix[13];
        boxV2.Y = viewMatrix[1] * posV3.X + viewMatrix[5] * posV3.Y + viewMatrix[9] * (posV3.Z - 1.0f) + viewMatrix[13];

        boxV2.X = cameraV3.Y - cameraV3.Y * boxV2.X * cameraV3.Z;
        boxV2.Y = cameraV3.Y - cameraV3.Y * boxV2.Y * cameraV3.Z;

        boxV2.Y = Math.Abs(boxV2.X - boxV2.Y);
        boxV2.X = boxV2.Y / 2;

        return boxV2;
    }
}
