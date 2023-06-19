using GTA5Shared.Helper;

using CommunityToolkit.Mvvm.Input;

namespace GTA5Heists;

/// <summary>
/// GTA5HeistsWindow.xaml 的交互逻辑
/// </summary>
public partial class GTA5HeistsWindow
{
    /// <summary>
    /// 导航字典
    /// </summary>
    private readonly Dictionary<string, UserControl> NavDictionary = new();

    public GTA5HeistsWindow()
    {
        InitializeComponent();

        CreateView();
    }

    private void Window_GTA5Heists_Loaded(object sender, RoutedEventArgs e)
    {
        Navigate(NavDictionary.First().Key);
    }

    private void Window_GTA5Heists_Closing(object sender, CancelEventArgs e)
    {

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
                var type = Type.GetType($"GTA5Heists.Views.{viewName}");
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
