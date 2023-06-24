using GTA5Core.Features;
using GTA5Core.GTA.Onlines;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineWeapon;

/// <summary>
/// WeaponOptionView.xaml 的交互逻辑
/// </summary>
public partial class WeaponOptionView : UserControl
{
    private class Options
    {
        public bool AmmoModifier = false;
        public byte AmmoModifierFlag = 0;

        public bool FastReload = false;
        public bool NoRecoil = false;
        public bool NoSpread = false;
        public bool LongRange = false;

        public bool ImpactExplosion = false;
        public int ImpactExplosionFlag = -1;
    }
    private readonly Options _options = new();

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
        // 弹药编辑
        if (_options.AmmoModifier)
            Weapon.AmmoModifier(_options.AmmoModifierFlag);

        // 快速换弹
        if (_options.FastReload)
            Weapon.FastReload(true);
        // 无后坐力
        if (_options.NoRecoil)
            Weapon.NoRecoil();
        // 无子弹扩散
        if (_options.NoSpread)
            Weapon.NoSpread();
        // 提升射程
        if (_options.LongRange)
            Weapon.LongRange();

        // 子弹类型
        if (_options.ImpactExplosion)
        {
            if (_options.ImpactExplosionFlag == -1)
                Weapon.ImpactType(3);
            else
                Weapon.ImpactType(5);

            Weapon.ImpactExplosion(_options.ImpactExplosionFlag);
        }
    }

    private void ComboBox_AmmoModifier_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ComboBox_AmmoModifier.SelectedIndex;
        if (index == -1)
        {
            _options.AmmoModifier = false;
            return;
        }

        _options.AmmoModifier = true;
        _options.AmmoModifierFlag = (byte)index;
        Weapon.AmmoModifier(_options.AmmoModifierFlag);
    }

    private void CheckBox_FastReload_Click(object sender, RoutedEventArgs e)
    {
        _options.FastReload = CheckBox_FastReload.IsChecked == true;
        Weapon.FastReload(_options.FastReload);
    }

    private void CheckBox_NoRecoil_Click(object sender, RoutedEventArgs e)
    {
        _options.NoRecoil = CheckBox_NoRecoil.IsChecked == true;
        Weapon.NoRecoil();
    }

    private void CheckBox_NoSpread_Click(object sender, RoutedEventArgs e)
    {
        _options.NoSpread = CheckBox_NoSpread.IsChecked == true;
        Weapon.NoSpread();
    }

    private void CheckBox_LongRange_Click(object sender, RoutedEventArgs e)
    {
        _options.LongRange = CheckBox_LongRange.IsChecked == true;
        Weapon.LongRange();
    }

    private void ComboBox_ImpactExplosion_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ComboBox_ImpactExplosion.SelectedIndex;
        if (index == -1)
        {
            _options.ImpactExplosion = false;
            return;
        }

        _options.ImpactExplosion = true;

        if (index == 0)
            Weapon.ImpactType(3);
        else
            Weapon.ImpactType(5);

        _options.ImpactExplosionFlag = OnlineData.ImpactExplosions[index].Value;
        Weapon.ImpactExplosion(_options.ImpactExplosionFlag);
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
