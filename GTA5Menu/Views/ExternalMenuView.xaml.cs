using GTA5Shared.Helper;

using CommunityToolkit.Mvvm.Input;

namespace GTA5Menu.Views;

/// <summary>
/// ExternalMenuView.xaml 的交互逻辑
/// </summary>
public partial class ExternalMenuView : UserControl
{
    /// <summary>
    /// 导航字典
    /// </summary>
    private readonly Dictionary<string, UserControl> NavDictionary = new();

    public ExternalMenuView()
    {
        InitializeComponent();

        CreateView();

        Navigate(NavDictionary.First().Key);
    }

    /// <summary>
    /// 创建页面
    /// </summary>
    private void CreateView()
    {
        foreach (var item in ControlHelper.GetControls(Grid_NavMenu).Cast<RadioButton>())
        {
            var viewName = item.CommandParameter.ToString();

            if (!NavDictionary.ContainsKey(viewName))
            {
                var type = Type.GetType($"GTA5Menu.Views.ExternalMenu.{viewName}");
                if (type == null)
                    continue;

                NavDictionary.Add(viewName, Activator.CreateInstance(type) as UserControl);
            }
        }
    }

    /// <summary>
    /// View页面导航
    /// </summary>
    /// <param name="viewName"></param>
    [RelayCommand]
    private void Navigate(string viewName)
    {
        if (!NavDictionary.ContainsKey(viewName))
            return;

        if (ContentControl_NavRegion.Content != NavDictionary[viewName])
            ContentControl_NavRegion.Content = NavDictionary[viewName];
    }
}
