using GTA5Menu.Data;
using GTA5Menu.Utils;
using GTA5Menu.Config;

using GTA5Core.RAGE;
using GTA5Core.Feature;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.CustonBilp;

/// <summary>
/// MyBilpView.xaml 的交互逻辑
/// </summary>
public partial class MyBilpView : UserControl
{
    public ObservableCollection<BlipInfo> MyFavorites { get; private set; } = new();

    public static Action<BlipInfo> ActionAddMyFavorite;

    public MyBilpView()
    {
        InitializeComponent();
        this.DataContext = this;
        CustomBilpWindow.WindowClosingEvent += CustomBilpWindow_WindowClosingEvent;

        ActionAddMyFavorite = AddMyFavorite;

        // 如果配置文件不存在就创建
        if (!File.Exists(GTA5Util.File_Config_Blips))
        {
            // 保存配置文件
            SaveConfig();
        }

        // 如果配置文件存在就读取
        if (File.Exists(GTA5Util.File_Config_Blips))
        {
            using var streamReader = new StreamReader(GTA5Util.File_Config_Blips);
            var bilps = JsonHelper.JsonDese<List<Blips>>(streamReader.ReadToEnd());

            // 填充数据
            foreach (var info in bilps)
            {
                MyFavorites.Add(new()
                {
                    Name = $"ID: {info.Value}",
                    Value = info.Value,
                    Color = info.Color,
                    Image = RAGEHelper.GetBilpModelImage(info.Value),
                });
            }
        }
    }

    private void CustomBilpWindow_WindowClosingEvent()
    {
        SaveConfig();
    }

    /// <summary>
    /// 保存配置文件
    /// </summary>
    private void SaveConfig()
    {
        if (Directory.Exists(FileHelper.Dir_Config))
        {
            var bilps = new List<Blips>();
            foreach (BlipInfo info in ListBox_BilpModels.Items)
            {
                bilps.Add(new()
                {
                    Value = info.Value,
                    Color = info.Color,
                });
            }
            // 写入到Json文件
            File.WriteAllText(GTA5Util.File_Config_Blips, JsonHelper.JsonSeri(bilps));
        }
    }

    private void AddMyFavorite(BlipInfo info)
    {
        if (!MyFavorites.Contains(info))
        {
            MyFavorites.Add(info);

            NotifierHelper.Show(NotifierType.Success, $"添加Blip {info.Name} 到我的收藏成功");
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, $"Blip {info.Name} 已存在，请勿重复添加");
        }
    }

    private void MenuItem_TeleportToBlips_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_BilpModels.SelectedItem is BlipInfo info)
        {
            Teleport.ToBlips(info.Value);
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "请选择正确的Blip，操作取消");
        }
    }

    private void MenuItem_DeleteMyFavorite_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_BilpModels.SelectedItem is BlipInfo info)
        {
            MyFavorites.Remove(info);

            NotifierHelper.Show(NotifierType.Success, $"从我的收藏删除Blip {info.Name} 成功");
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "请选择正确的Blip，操作取消");
        }
    }

    private void ListBox_BilpModels_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        MenuItem_TeleportToBlips_Click(null, null);
    }
}
