namespace GTA5OnlineTools.Utils;

public static class FileUtil
{
    /// <summary>
    /// 默认路径
    /// </summary>
    public const string Default = "C:\\ProgramData\\GTA5OnlineTools";
    /// <summary>
    /// 资源路径
    /// </summary>
    public const string ResFiles = "GTA5OnlineTools.Files";

    public const string Dir_Kiddion = $"{Default}\\Kiddion";
    public const string Dir_Cache = $"{Default}\\Cache";
    public const string Dir_Config = $"{Default}\\Config";
    public const string Dir_Inject = $"{Default}\\Inject";
    public const string Dir_Log = $"{Default}\\Log";

    public const string Dir_Kiddion_Scripts = $"{Dir_Kiddion}\\scripts";

    public const string Res_Other_SGTA50000 = $"{ResFiles}.Other.SGTA50000";

    public const string Res_Kiddion_Kiddion = $"{ResFiles}.Kiddion.Kiddion.exe";
    public const string File_Kiddion_Kiddion = $"{Dir_Kiddion}\\Kiddion.exe";

    public const string Res_Kiddion_KiddionChs = $"{ResFiles}.Kiddion.KiddionChs.dll";
    public const string File_Kiddion_KiddionChs = $"{Dir_Kiddion}\\KiddionChs.dll";

    public const string Res_Kiddion_Config = $"{ResFiles}.Kiddion.config.json";
    public const string File_Kiddion_Config = $"{Dir_Kiddion}\\config.json";

    public const string Res_Kiddion_Config87 = $"{ResFiles}.Kiddion.config87.json";

    public const string Res_Kiddion_Themes = $"{ResFiles}.Kiddion.themes.json";
    public const string File_Kiddion_Themes = $"{Dir_Kiddion}\\themes.json";

    public const string Res_Kiddion_Teleports = $"{ResFiles}.Kiddion.teleports.json";
    public const string File_Kiddion_Teleports = $"{Dir_Kiddion}\\teleports.json";

    public const string Res_Kiddion_Vehicles = $"{ResFiles}.Kiddion.vehicles.json";
    public const string File_Kiddion_Vehicles = $"{Dir_Kiddion}\\vehicles.json";

    public const string Res_Kiddion_Scripts_Readme = $"{ResFiles}.Kiddion.scripts.Readme.api";
    public const string File_Kiddion_Scripts_Readme = $"{Dir_Kiddion_Scripts}\\Readme.api";

    public const string Res_Cache_BincoHax = $"{ResFiles}.Cache.BincoHax.exe";
    public const string File_Cache_BincoHax = $"{Dir_Cache}\\BincoHax.exe";

    public const string Res_Cache_GTAHax = $"{ResFiles}.Cache.GTAHax.exe";
    public const string File_Cache_GTAHax = $"{Dir_Cache}\\GTAHax.exe";

    public const string Res_Cache_LSCHax = $"{ResFiles}.Cache.LSCHax.exe";
    public const string File_Cache_LSCHax = $"{Dir_Cache}\\LSCHax.exe";

    public const string Res_Cache_Notepad2 = $"{ResFiles}.Cache.Notepad2.exe";
    public const string File_Cache_Notepad2 = $"{Dir_Cache}\\Notepad2.exe";

    public const string Res_Cache_Stat = $"{ResFiles}.Cache.stat.txt";
    public const string File_Cache_Stat = $"{Dir_Cache}\\stat.txt";

    public const string Res_Cache_Xenos64 = $"{ResFiles}.Cache.Xenos64.exe";
    public const string File_Cache_Xenos64 = $"{Dir_Cache}\\Xenos64.exe";

    public const string Res_Cache_Xenos64Profile = $"{ResFiles}.Cache.XenosCurrentProfile.xpr";
    public const string File_Cache_Xenos64Profile = $"{Dir_Cache}\\XenosCurrentProfile.xpr";

    public const string Res_Inject_YimMenu = $"{ResFiles}.Inject.YimMenu.dll";
    public const string File_Inject_YimMenu = $"{Dir_Inject}\\YimMenu.dll";

    /// <summary>
    /// 获取当前运行文件完整路径
    /// </summary>
    public static readonly string File_MainApp = Environment.ProcessPath;

    /// <summary>
    /// 获取当前文件目录，不加文件名及后缀
    /// </summary>
    public static readonly string Dir_MainApp = AppDomain.CurrentDomain.BaseDirectory;

    /// <summary>
    /// 我的文档完整路径
    /// </summary>
    public static readonly string Dir_MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    /// <summary>
    /// AppData完整路径
    /// </summary>
    public static readonly string Dir_AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

    /// <summary>
    /// YimMenu配置文件路径（BigBaseV2）
    /// </summary>
    public static readonly string Dir_BigBaseV2 = Path.Combine(Dir_AppData, "BigBaseV2");

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
        var path = Dir_Log + @"\Crash";
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
