using GTA5Menu.Options;

using GTA5Core.Native;
using GTA5Core.Offsets;
using GTA5Core.Features;
using GTA5Core.GTA.Onlines;
using GTA5Shared.Helper;

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
        GTA5MenuWindow.LoopTime1000MsEvent += GTA5MenuWindow_LoopTime1000MsEvent;

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

    private void GTA5MenuWindow_LoopTime1000MsEvent()
    {
        var pCPed = Game.GetCPed();

        // 弹药编辑
        var pCPedInventory = Memory.Read<long>(pCPed + CPed.CPedInventory);
        Memory.Write(pCPedInventory + CPedInventory.AmmoModifier, Setting.Weapon.AmmoModifierFlag);
    }

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
        AudioHelper.PlayClickSound();

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
        AudioHelper.PlayClickSound();

        Weapon.FillCurrentAmmo();
    }

    private void Button_FillAllAmmo_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Weapon.FillAllAmmo();
    }
}
