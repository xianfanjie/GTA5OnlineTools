using GTA5Shared.Helper;

namespace GTA5.Utils;

public static class GTA5Util
{
    public const string Default = "C:\\ProgramData\\GTA5OnlineTools";

    public const string Dir_Cache = $"{Default}\\Cache";
    public const string Dir_Config = $"{Default}\\Config";

    public const string File_Cache_GTAHax = $"{Dir_Cache}\\GTAHax.exe";
    public const string File_Cache_Stat = $"{Dir_Cache}\\stat.txt";

    /// <summary>
    /// 判断程序是否运行
    /// </summary>
    /// <param name="appName">程序名称</param>
    /// <returns>正在运行返回true，未运行返回false</returns>
    public static bool IsAppRun(string appName)
    {
        return Process.GetProcessesByName(appName).Length > 0;
    }

    /// <summary>
    /// 打开http链接或者文件夹路径
    /// </summary>
    /// <param name="url"></param>
    public static void OpenLink(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }

    /// <summary>
    /// 打开指定进程，可以附带运行参数
    /// </summary>
    /// <param name="path">本地文件夹路径</param>
    public static void OpenProcess(string path, string args = "")
    {
        try
        {
            Process.Start(path, args);
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }

    /// <summary>
    /// 以管理员权限打开指定程序
    /// </summary>
    /// <param name="path">程序路径</param>
    public static void OpenProcessWithWorkDir(string path)
    {
        Directory.SetCurrentDirectory(Path.GetDirectoryName(path));
        OpenProcess(path);
    }

    /// <summary>
    /// 根据进程名字关闭指定程序
    /// </summary>
    /// <param name="processName">程序名字，不需要加.exe</param>
    public static void CloseProcess(string processName)
    {
        var pArray = Process.GetProcessesByName(processName);
        foreach (var process in pArray)
            process.Kill();
    }
}
