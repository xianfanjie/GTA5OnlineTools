using GTA5Menu.Data;

using GTA5Core.Feature;
using GTA5Core.RAGE;
using GTA5Core.RAGE.Weapons;
using GTA5Core.RAGE.Onlines;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// SpawnWeaponView.xaml 的交互逻辑
/// </summary>
public partial class SpawnWeaponView : UserControl
{
    public SpawnWeaponView()
    {
        InitializeComponent();
        this.DataContext = this;
        ExternalMenuWindow.WindowClosingEvent += ExternalMenuWindow_WindowClosingEvent;

        // 武器列表
        foreach (var wClass in WeaponHash.WeaponClasses)
        {
            ComboBox_WeaponClasses.Items.Add(new IconMenu()
            {
                Icon = wClass.Icon,
                Title = wClass.Name
            });
        }
        ComboBox_WeaponClasses.SelectedIndex = 0;

        // 子弹类型
        foreach (var item in OnlineData.ImpactExplosions)
        {
            ComboBox_ImpactExplosion.Items.Add(item.Name);
        }
    }

    private void ExternalMenuWindow_WindowClosingEvent()
    {

    }

    private void ComboBox_WeaponClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        lock (this)
        {
            var index = ComboBox_WeaponClasses.SelectedIndex;
            if (index == -1)
                return;

            ListBox_WeaponInfo.Items.Clear();

            Task.Run(() =>
            {
                foreach (var item in WeaponHash.WeaponClasses[index].WeaponInfos)
                {
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
                    {
                        if (index == ComboBox_WeaponClasses.SelectedIndex)
                        {
                            ListBox_WeaponInfo.Items.Add(new ModelInfo()
                            {
                                Name = item.Name,
                                Value = item.Value,
                                Image = RAGEHelper.GetWeaponImage(item.Value)
                            });
                        }
                    });
                }
            });

            ListBox_WeaponInfo.SelectedIndex = 0;
        }
    }

    private void Button_SpawnWeapon_Click(object sender, RoutedEventArgs e)
    {
        if (ListBox_WeaponInfo.SelectedItem is ModelInfo info)
        {
            Hacks.CreateAmbientPickup($"pickup_{info.Name}");
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    private void RadioButton_AmmoModifier_None_Click(object sender, RoutedEventArgs e)
    {
        if (RadioButton_AmmoModifier_None.IsChecked == true)
        {
            Setting.Weapon.AmmoModifierFlag = 0;
            Weapon.AmmoModifier(0);
        }
        else if (RadioButton_AmmoModifier_AMMO.IsChecked == true)
        {
            Setting.Weapon.AmmoModifierFlag = 1;
            Weapon.AmmoModifier(1);
        }
        else if (RadioButton_AmmoModifier_CLIP.IsChecked == true)
        {
            Setting.Weapon.AmmoModifierFlag = 2;
            Weapon.AmmoModifier(2);
        }
        else if (RadioButton_AmmoModifier_Both.IsChecked == true)
        {
            Setting.Weapon.AmmoModifierFlag = 3;
            Weapon.AmmoModifier(3);
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
