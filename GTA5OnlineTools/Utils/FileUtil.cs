namespace GTA5OnlineTools.Utils;

public static class FileUtil
{
    public const string ResFiles = "GTA5OnlineTools.Files";

    public const string Res_Kiddion_Kiddion = $"{ResFiles}.Kiddion.Kiddion.exe";
    public const string Res_Kiddion_KiddionChs = $"{ResFiles}.Kiddion.KiddionChs.dll";
    public const string Res_Kiddion_Config = $"{ResFiles}.Kiddion.config.json";
    public const string Res_Kiddion_Themes = $"{ResFiles}.Kiddion.themes.json";
    public const string Res_Kiddion_Teleports = $"{ResFiles}.Kiddion.teleports.json";
    public const string Res_Kiddion_Vehicles = $"{ResFiles}.Kiddion.vehicles.json";

    public const string Res_Kiddion_Scripts_Readme = $"{ResFiles}.Kiddion.scripts.Readme.api";

    public const string Res_Cache_BincoHax = $"{ResFiles}.Cache.BincoHax.exe";
    public const string Res_Kiddion_Config87 = $"{ResFiles}.Kiddion.config87.json";
    public const string Res_Cache_GTAHax = $"{ResFiles}.Cache.GTAHax.exe";
    public const string Res_Cache_LSCHax = $"{ResFiles}.Cache.LSCHax.exe";
    public const string Res_Cache_Notepad2 = $"{ResFiles}.Cache.Notepad2.exe";
    public const string Res_Cache_Stat = $"{ResFiles}.Cache.stat.txt";
    public const string Res_Cache_Xenos64Profile = $"{ResFiles}.Cache.XenosCurrentProfile.xpr";
    public const string Res_Cache_Xenos64 = $"{ResFiles}.Cache.Xenos64.exe";

    public const string Res_Inject_YimMenu = $"{ResFiles}.Inject.YimMenu.dll";

    public const string Res_Other_SGTA50000 = $"{ResFiles}.Other.SGTA50000";

    //////////////////////////////////////////////////////////////////

    public static string Dir_MyDocuments { get; private set; }

    public static string Dir_Default { get; private set; }

    public static string Dir_Kiddion { get; private set; }
    public static string Dir_Cache { get; private set; }
    public static string Dir_Config { get; private set; }
    public static string Dir_Inject { get; private set; }
    public static string Dir_Log { get; private set; }

    public static string Dir_Kiddion_Scripts { get; private set; }

    public static string Dir_Log_Crash { get; private set; }
    public static string Dir_Log_NLog { get; private set; }

    public static string File_Kiddion_Kiddion { get; private set; }
    public static string File_Kiddion_KiddionChs { get; private set; }
    public static string File_Kiddion_Config { get; private set; }
    public static string File_Kiddion_Themes { get; private set; }
    public static string File_Kiddion_Teleports { get; private set; }
    public static string File_Kiddion_Vehicles { get; private set; }

    public static string File_Kiddion_Scripts_Readme { get; private set; }

    public static string File_Cache_BincoHax { get; private set; }
    public static string File_Cache_GTAHax { get; private set; }
    public static string File_Cache_LSCHax { get; private set; }
    public static string File_Cache_Notepad2 { get; private set; }
    public static string File_Cache_Stat { get; private set; }
    public static string File_Cache_Xenos64 { get; private set; }
    public static string File_Cache_Xenos64Profile { get; private set; }

    public static string File_Inject_YimMenu { get; private set; }

    //////////////////////////////////////////////////////////////////

    /// <summary>
    /// 获取当前运行文件完整路径
    /// </summary>
    public static string File_MainApp { get; private set; }

    /// <summary>
    /// 获取当前文件目录，不加文件名及后缀
    /// </summary>
    public static string Dir_MainApp { get; private set; }

    /// <summary>
    /// AppData完整路径
    /// </summary>
    public static string Dir_AppData { get; private set; }

    /// <summary>
    /// YimMenu配置文件路径（BigBaseV2）
    /// </summary>
    public static string Dir_BigBaseV2 { get; private set; }

    static FileUtil()
    {
        File_MainApp = Environment.ProcessPath;
        Dir_MainApp = AppDomain.CurrentDomain.BaseDirectory;

        Dir_AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        Dir_MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        Dir_Default = Path.Combine(Dir_MyDocuments, "GTA5OnlineTools");

        Dir_Kiddion = Path.Combine(Dir_Default, "Kiddion");
        Dir_Cache = Path.Combine(Dir_Default, "Cache");
        Dir_Config = Path.Combine(Dir_Default, "Config");
        Dir_Inject = Path.Combine(Dir_Default, "Inject");
        Dir_Log = Path.Combine(Dir_Default, "Log");

        Dir_Kiddion_Scripts = Path.Combine(Dir_Kiddion, "scripts");

        Dir_Log_Crash = Path.Combine(Dir_Log, "Crash");
        Dir_Log_NLog = Path.Combine(Dir_Log, "NLog");

        File_Kiddion_Kiddion = Path.Combine(Dir_Kiddion, "Kiddion.exe");
        File_Kiddion_KiddionChs = Path.Combine(Dir_Kiddion, "KiddionChs.dll");
        File_Kiddion_Config = Path.Combine(Dir_Kiddion, "config.json");
        File_Kiddion_Themes = Path.Combine(Dir_Kiddion, "themes.json");
        File_Kiddion_Teleports = Path.Combine(Dir_Kiddion, "teleports.json");
        File_Kiddion_Vehicles = Path.Combine(Dir_Kiddion, "vehicles.json");

        File_Kiddion_Scripts_Readme = Path.Combine(Dir_Kiddion_Scripts, "Readme.api");

        File_Cache_BincoHax = Path.Combine(Dir_Cache, "BincoHax.exe");
        File_Cache_GTAHax = Path.Combine(Dir_Cache, "GTAHax.exe");
        File_Cache_LSCHax = Path.Combine(Dir_Cache, "LSCHax.exe");
        File_Cache_Notepad2 = Path.Combine(Dir_Cache, "Notepad2.exe");
        File_Cache_Stat = Path.Combine(Dir_Cache, "stat.txt");
        File_Cache_Xenos64 = Path.Combine(Dir_Cache, "Xenos64.exe");
        File_Cache_Xenos64Profile = Path.Combine(Dir_Cache, "XenosCurrentProfile.xpr");

        File_Inject_YimMenu = Path.Combine(Dir_Inject, "YimMenu.dll");

        Dir_BigBaseV2 = Path.Combine(Dir_AppData, "BigBaseV2");
    }

    /// <summary>
    /// 文件重命名
    /// </summary>
    public static void FileReName(string oldPath, string newPath)
    {
        var ReName = new FileInfo(oldPath);
        ReName.MoveTo(newPath);
    }

    /// <summary>
    /// 给文件名，得出当前目录完整路径，AppName带文件名后缀
    /// </summary>
    public static string GetCurrFullPath(string appName)
    {
        return Path.Combine(Dir_MainApp, appName);
    }

    /// <summary>
    /// 保存崩溃日志
    /// </summary>
    /// <param name="log">日志内容</param>
    public static void SaveCrashLog(string log)
    {
        var path = Dir_Log_Crash;
        Directory.CreateDirectory(path);
        path += $@"\#Crash#{DateTime.Now:yyyyMMdd_HH-mm-ss_ffff}.log";
        File.WriteAllText(path, log);
    }

    /// <summary>
    /// 从资源文件中抽取资源文件
    /// </summary>
    /// <param name="resFileName">资源文件路径</param>
    /// <param name="outputFile">输出文件</param>
    public static void ExtractResFile(string resFileName, string outputFile)
    {
        BufferedStream inStream = null;
        FileStream outStream = null;

        try
        {
            var assembly = Assembly.GetExecutingAssembly();
            inStream = new BufferedStream(assembly.GetManifestResourceStream(resFileName));
            outStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

            var buffer = new byte[1024];
            int length;

            while ((length = inStream.Read(buffer, 0, buffer.Length)) > 0)
                outStream.Write(buffer, 0, length);

            outStream.Flush();
        }
        finally
        {
            outStream?.Close();
            inStream?.Close();
        }
    }

    /// <summary>
    /// 判断文件是否被占用
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static bool IsOccupied(string filePath)
    {
        FileStream stream = null;

        try
        {
            stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            return false;
        }
        catch
        {
            return true;
        }
        finally
        {
            stream?.Close();
        }
    }

    /// <summary>
    /// 清空指定文件夹下的文件及文件夹
    /// </summary>
    /// <param name="srcPath">文件夹路径</param>
    public static void ClearDirectory(string srcPath)
    {
        try
        {
            var dir = new DirectoryInfo(srcPath);
            var fileinfo = dir.GetFileSystemInfos();

            foreach (var file in fileinfo)
            {
                if (file is DirectoryInfo)
                {
                    var subdir = new DirectoryInfo(file.FullName);
                    subdir.Delete(true);
                }
                else
                {
                    File.Delete(file.FullName);
                }
            }
        }
        catch { }
    }
}
