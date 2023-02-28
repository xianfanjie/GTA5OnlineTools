using GTA5Menu.Data;

using GTA5Core.RAGE;
using GTA5Core.RAGE.Blips;
using GTA5Core.Feature;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.CustonBilp;

/// <summary>
/// AllBilpView.xaml 的交互逻辑
/// </summary>
public partial class AllBilpView : UserControl
{
    public AllBilpView()
    {
        InitializeComponent();
        this.DataContext = this;
        CustomBilpWindow.WindowClosingEvent += CustomBilpWindow_WindowClosingEvent;

        foreach (var item in BlipData.BlipModels)
        {
            ListBox_BilpModels.Items.Add(new BlipInfo()
            {
                Name = $"ID: {item}",
                Value = item,
                Image = RAGEHelper.GetBilpModelImage(item)
            });
        }
    }

    private void CustomBilpWindow_WindowClosingEvent()
    {

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

    private void MenuItem_AddMyFavorite_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_BilpModels.SelectedItem is BlipInfo info)
        {
            MyBilpView.ActionAddMyFavorite(info);
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
