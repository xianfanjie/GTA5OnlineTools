using GTA5Menu.Data;

using GTA5Core.RAGE.Teleports;

namespace GTA5Menu.Views.OnlineTeleport;

/// <summary>
/// DefaultTeleportView.xaml 的交互逻辑
/// </summary>
public partial class DefaultTeleportView : UserControl
{
    public DefaultTeleportView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += ExternalMenuWindow_WindowClosingEvent;

        // 传送分类列表
        foreach (var tClass in TeleportData.TeleportClasses)
        {
            ListBox_TeleportClasses.Items.Add(new IconMenu()
            {
                Icon = tClass.Icon,
                Title = tClass.Name
            });
        }
        ListBox_TeleportClasses.SelectedIndex = 0;
    }

    private void ExternalMenuWindow_WindowClosingEvent()
    {

    }

    /////////////////////////////////////////////////////

    private void ListBox_TeleportClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        lock (this)
        {
            var index = ListBox_TeleportClasses.SelectedIndex;
            if (index == -1)
                return;

            ListBox_TeleportInfos.Items.Clear();

            foreach (var item in TeleportData.TeleportClasses[index].TeleportInfos)
            {
                this.Dispatcher.Invoke(DispatcherPriority.Background, () =>
                {
                    if (index == ListBox_TeleportClasses.SelectedIndex)
                    {
                        ListBox_TeleportInfos.Items.Add(new TeleportInfo()
                        {
                            Name = item.Name,
                            X = item.X,
                            Y = item.Y,
                            Z = item.Z
                        });
                    }
                    else
                    {
                        return;
                    }
                });
            }

            ListBox_TeleportInfos.SelectedIndex = 0;
        }
    }

    private void ListBox_TeleportInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {

    }
}
