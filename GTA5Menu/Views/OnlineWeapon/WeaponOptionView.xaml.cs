using GTA5Core.Features;
using GTA5Core.RAGE.Onlines;

using GTA5Menu.Options;

namespace GTA5Menu.Views.OnlineWeapon;

/// <summary>
/// WeaponOptionView.xaml 的交互逻辑
/// </summary>
public partial class WeaponOptionView : UserControl
{
    public WeaponOptionView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        // 子弹类型
        foreach (var item in OnlineData.ImpactExplosions)
        {
            ComboBox_ImpactExplosion.Items.Add(item.Name);
        }
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {

    }

    /////////////////////////////////////////////////////

    private void ComboBox_AmmoModifier_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ComboBox_AmmoModifier.SelectedIndex;
        if (index != -1)
        {
            Setting.Weapon.AmmoModifierFlag = index;
            Weapon.AmmoModifier((byte)index);
        }
    }

    private void CheckBox_ReloadMult_Click(object sender, RoutedEventArgs e)
    {
        Weapon.ReloadMult(CheckBox_ReloadMult.IsChecked == true);
    }

    private void Button_NoRecoil_Click(object sender, RoutedEventArgs e)
    {
        Weapon.NoRecoil();
    }

    private void CheckBox_NoSpread_Click(object sender, RoutedEventArgs e)
    {
        Weapon.NoSpread();
    }

    private void CheckBox_Range_Click(object sender, RoutedEventArgs e)
    {
        Weapon.Range();
    }

    private void ComboBox_ImpactExplosion_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ComboBox_ImpactExplosion.SelectedIndex;
        if (index != -1)
        {
            if (index == 0)
                Weapon.ImpactType(3);
            else
                Weapon.ImpactType(5);

            Weapon.ImpactExplosion(OnlineData.ImpactExplosions[index].Value);
        }
    }

    private void Button_FillCurrentAmmo_Click(object sender, RoutedEventArgs e)
    {
        Weapon.FillCurrentAmmo();
    }

    private void Button_FillAllAmmo_Click(object sender, RoutedEventArgs e)
    {
        Weapon.FillAllAmmo();
    }
}
