using GTA5Core.Features;
using GTA5Core.GTA.Onlines;

using GTA5Menu.Options;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// OnlineOptionView.xaml 的交互逻辑
/// </summary>
public partial class OnlineOptionView : UserControl
{
    public OnlineOptionView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {

    }

    /////////////////////////////////////////////////

    private void Button_Sessions_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            var session = OnlineData.Sessions.Find(t => t.Name == button.Content.ToString());
            if (session != null)
                Online.LoadSession(session.Value);
        }
    }

    private void Button_Disconnect_Click(object sender, RoutedEventArgs e)
    {
        Online.Disconnect();
    }

    private void CheckBox_FreeChangeAppearance_Click(object sender, RoutedEventArgs e)
    {
        Online.FreeChangeAppearance(CheckBox_FreeChangeAppearance.IsChecked == true);
    }

    private void Button_RPxN_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            var rpxn = OnlineData.RPxNs.Find(t => t.Name == button.Content.ToString());
            if (rpxn != null)
                Online.RPMultiplier(rpxn.Value);
        }
    }

    private void Button_REPxN_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            var repxn = OnlineData.REPxNs.Find(t => t.Name == button.Content.ToString());
            if (repxn != null)
                Online.REPMultiplier(repxn.Value);
        }
    }

    private void CheckBox_RemovePassiveModeCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.PassiveModeCooldown(CheckBox_RemovePassiveModeCooldown.IsChecked == true);
    }

    private void CheckBox_RemoveSuicideCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.SuicideCooldown(CheckBox_RemoveSuicideCooldown.IsChecked == true);
    }

    private void CheckBox_DisableOrbitalCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.DisableOrbitalCooldown(CheckBox_DisableOrbitalCooldown.IsChecked == true);
    }

    private void CheckBox_OffRadar_Click(object sender, RoutedEventArgs e)
    {
        Online.OffRadar(CheckBox_OffRadar.IsChecked == true);
    }

    private void CheckBox_GhostOrganization_Click(object sender, RoutedEventArgs e)
    {
        Online.GhostOrganization(CheckBox_GhostOrganization.IsChecked == true);
    }

    private void CheckBox_BribeOrBlindCops_Click(object sender, RoutedEventArgs e)
    {
        Online.BribeOrBlindCops(CheckBox_BribeOrBlindCops.IsChecked == true);
    }

    private void CheckBox_BribeAuthorities_Click(object sender, RoutedEventArgs e)
    {
        Online.BribeAuthorities(CheckBox_BribeAuthorities.IsChecked == true);
    }

    private void CheckBox_RevealPlayers_Click(object sender, RoutedEventArgs e)
    {
        Online.RevealPlayers(CheckBox_RevealPlayers.IsChecked == true);
    }

    private void CheckBox_AllowSellOnNonPublic_Click(object sender, RoutedEventArgs e)
    {
        Setting.Online.AllowSellOnNonPublic = CheckBox_AllowSellOnNonPublic.IsChecked == true;
        Online.AllowSellOnNonPublic(CheckBox_AllowSellOnNonPublic.IsChecked == true);
    }

    private void CheckBox_OnlineSnow_Click(object sender, RoutedEventArgs e)
    {
        Online.SessionSnow(CheckBox_OnlineSnow.IsChecked == true);
    }

    private void Button_Blips_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            var blip = OnlineData.Blips.Find(t => t.Name == button.Content.ToString());
            if (blip != null)
                Teleport.ToBlips(blip.Value);
        }
    }

    private void Button_MerryweatherServices_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            var service = OnlineData.MerryWeatherServices.Find(t => t.Name == button.Content.ToString());
            if (service != null)
                Online.MerryWeatherServices(service.Value);
        }
    }

    private void CheckBox_InstantBullShark_Click(object sender, RoutedEventArgs e)
    {
        Online.InstantBullShark(CheckBox_InstantBullShark.IsChecked == true);
    }

    private void CheckBox_BackupHeli_Click(object sender, RoutedEventArgs e)
    {
        Online.CallBackupHeli(CheckBox_BackupHeli.IsChecked == true);
    }

    private void CheckBox_Airstrike_Click(object sender, RoutedEventArgs e)
    {
        Online.CallAirstrike(CheckBox_Airstrike.IsChecked == true);
    }
}
