namespace GTA5.Share;

public static class ShareHelper
{
    /// <summary>
    /// 获取载具对应预览图
    /// </summary>
    /// <param name="vehicleName">载具名称</param>
    /// <returns></returns>
    public static string GetVehicleImage(string vehicleName)
    {
        return $"pack://application:,,,/GTA5.Share;component/Assets/Vehicles/{vehicleName}.png";
    }

    /// <summary>
    /// 获取武器对应预览图
    /// </summary>
    /// <param name="weaponName">武器名称</param>
    /// <returns></returns>
    public static string GetWeaponImage(string weaponName)
    {
        return $"pack://application:,,,/GTA5.Share;component/Assets/Weapons/{weaponName}.png";
    }
}
