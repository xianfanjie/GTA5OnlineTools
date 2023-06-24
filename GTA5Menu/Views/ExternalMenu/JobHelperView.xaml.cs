using GTA5Core.Features;
using GTA5Core.GTA.Onlines;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// JobHelperView.xaml 的交互逻辑
/// </summary>
public partial class JobHelperView : UserControl
{
    public JobHelperView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
        GTA5MenuWindow.LoopTime1000MsEvent += GTA5MenuWindow_LoopTime1000MsEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {

    }

    private void GTA5MenuWindow_LoopTime1000MsEvent()
    {
        this.Dispatcher.BeginInvoke(() =>
        {
            // 只有用户勾选才开启循环写入，不勾选不修改值（避免与其他工具冲突）

            // 移除购买板条箱冷却
            if (CheckBox_CEOBuyingCratesCooldown.IsChecked == true)
                Online.CEOBuyingCratesCooldown(true);
            // 移除出售板条箱冷却
            if (CheckBox_CEOSellingCratesCooldown.IsChecked == true)
                Online.CEOSellingCratesCooldown(true);

            // 移除CEO工作冷却
            if (CheckBox_CEOWorkCooldown.IsChecked == true)
                Online.CEOWorkCooldown(true);
            // 移除恐霸客户差事冷却
            if (CheckBox_ClientJobCooldown.IsChecked == true)
                Online.ClientJobCooldown(true);

            // 移除地堡进货延迟
            if (CheckBox_BunkerSupplyDelay.IsChecked == true)
                Online.BunkerSupplyDelay(true);
            // 解锁地堡所有研究 (临时)
            if (CheckBox_UnlockBunkerResearch.IsChecked == true)
                Online.UnlockBunkerResearch(true);

            // 移除摩托帮进货延迟
            if (CheckBox_MCSupplyDelay.IsChecked == true)
                Online.MCSupplyDelay(true);

            // 移除夜总会出货延迟
            if (CheckBox_NightclubOutDelay.IsChecked == true)
                Online.NightclubOutDelay(true);

            // 移除进出口大亨出货延迟
            if (CheckBox_ExportVehicleDelay.IsChecked == true)
                Online.ExportVehicleDelay(true);

            // 移除机库进货延迟
            if (CheckBox_SmugglerRunInDelay.IsChecked == true)
                Online.SmugglerRunInDelay(true);
            // 移除机库出货延迟
            if (CheckBox_SmugglerRunOutDelay.IsChecked == true)
                Online.SmugglerRunOutDelay(true);

            // 移除事务所安保合约冷却
            if (CheckBox_SecurityHitCooldown.IsChecked == true)
                Online.SecurityHitCooldown(true);
            // 移除公共电话任务合约冷却
            if (CheckBox_PayphoneHitCooldown.IsChecked == true)
                Online.PayphoneHitCooldown(true);

        });
    }

    /////////////////////////////////////////////////

    private void Button_CEOCargos_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (sender is Button button)
        {
            var btnContent = button.Content.ToString();

            var cargo = OnlineData.CEOCargos.Find(t => t.Name == btnContent);
            if (cargo != null)
            {
                Online.CEOSpecialCargo(false);
                Online.CEOCargoType(cargo.Value);
            }
        }
    }

    private void Button_CEOSpecialCargos_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (sender is Button button)
        {
            var btnContent = button.Content.ToString();

            var specialCargo = OnlineData.CEOSpecialCargos.Find(t => t.Name == btnContent);
            if (specialCargo != null)
            {
                // They are in gb_contraband_buy at func_915, for future updates.
                Online.CEOSpecialCargo(true);
                Online.CEOCargoType(specialCargo.Value);
            }
        }
    }

    private void CheckBox_CEOBuyingCratesCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.CEOBuyingCratesCooldown(CheckBox_CEOBuyingCratesCooldown.IsChecked == true);
    }

    private void CheckBox_CEOSellingCratesCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.CEOSellingCratesCooldown(CheckBox_CEOSellingCratesCooldown.IsChecked == true);
    }

    private void CheckBox_CEOWorkCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.CEOWorkCooldown(CheckBox_CEOWorkCooldown.IsChecked == true);
    }

    private void CheckBox_ClientJobCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.ClientJobCooldown(CheckBox_ClientJobCooldown.IsChecked == true);
    }

    private void CheckBox_BunkerSupplyDelay_Click(object sender, RoutedEventArgs e)
    {
        Online.BunkerSupplyDelay(CheckBox_BunkerSupplyDelay.IsChecked == true);
    }

    private void CheckBox_UnlockBunkerResearch_Click(object sender, RoutedEventArgs e)
    {
        Online.UnlockBunkerResearch(CheckBox_UnlockBunkerResearch.IsChecked == true);
    }

    private void CheckBox_MCSupplyDelay_Click(object sender, RoutedEventArgs e)
    {
        Online.MCSupplyDelay(CheckBox_MCSupplyDelay.IsChecked == true);
    }

    private void CheckBox_NightclubOutDelay_Click(object sender, RoutedEventArgs e)
    {
        Online.NightclubOutDelay(CheckBox_NightclubOutDelay.IsChecked == true);
    }

    private void CheckBox_ExportVehicleDelay_Click(object sender, RoutedEventArgs e)
    {
        Online.ExportVehicleDelay(CheckBox_ExportVehicleDelay.IsChecked == true);
    }

    private void CheckBox_SmugglerRunInDelay_Click(object sender, RoutedEventArgs e)
    {
        Online.SmugglerRunInDelay(CheckBox_SmugglerRunInDelay.IsChecked == true);
    }

    private void CheckBox_SmugglerRunOutDelay_Click(object sender, RoutedEventArgs e)
    {
        Online.SmugglerRunOutDelay(CheckBox_SmugglerRunOutDelay.IsChecked == true);
    }

    private void CheckBox_SecurityHitCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.SecurityHitCooldown(CheckBox_SecurityHitCooldown.IsChecked == true);
    }

    private void CheckBox_PayphoneHitCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.PayphoneHitCooldown(CheckBox_PayphoneHitCooldown.IsChecked == true);
    }
}
