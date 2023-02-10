using Notification.Wpf;
using Notification.Wpf.Controls;
using Notification.Wpf.Constants;

namespace GTA5Shared.Helper;

public static class NotifierHelper
{
    private static readonly NotificationManager _NotificationManager = new();

    private static readonly TimeSpan ExpirationTime = TimeSpan.FromSeconds(2);

    static NotifierHelper()
    {
        NotificationConstants.MessagePosition = NotificationPosition.BottomCenter;
        NotificationConstants.NotificationsOverlayWindowMaxCount = 5;

        NotificationConstants.MinWidth = 500D;
        NotificationConstants.MaxWidth = 500D;

        NotificationConstants.FontName = "微软雅黑";
        NotificationConstants.TitleSize = 14;
        NotificationConstants.MessageSize = 12;
        NotificationConstants.MessageTextAlignment = TextAlignment.Left;
        NotificationConstants.TitleTextAlignment = TextAlignment.Left;

        NotificationConstants.DefaultBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#444444"));
        NotificationConstants.DefaultForegroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

        NotificationConstants.InformationBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#409EFF"));
        NotificationConstants.SuccessBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#67C23A"));
        NotificationConstants.WarningBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E6A23C"));
        NotificationConstants.ErrorBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F56C6C"));
    }

    /// <summary>
    /// 显示Toast通知
    /// </summary>
    /// <param name="type">通知类型</param>
    /// <param name="message">通知消息字符串</param>
    public static void Show(NotifierType type, string message)
    {
        string title = type switch
        {
            NotifierType.None => "",
            NotifierType.Information => "信息",
            NotifierType.Success => "成功",
            NotifierType.Warning => "警告",
            NotifierType.Error => "错误",
            NotifierType.Notification => "通知",
            _ => "",
        };

        var clickContent = new NotificationContent
        {
            Title = title,
            Message = message,
            Type = (NotificationType)type,
            TrimType = NotificationTextTrimType.NoTrim,
        };

        _NotificationManager.Show(clickContent, "", ExpirationTime, null, null, true, false);

        HideAltTabWindow();
    }

    /// <summary>
    /// 显示异常通知信息
    /// </summary>
    /// <param name="ex"></param>
    public static void ShowException(Exception ex)
    {
        var clickContent = new NotificationContent
        {
            Title = "错误",
            Message = $"发生未知异常\n{ex.Message}",
            Type = NotificationType.Error,
            TrimType = NotificationTextTrimType.NoTrim,
        };

        _NotificationManager.Show(clickContent, "", ExpirationTime, null, null, true, false);

        HideAltTabWindow();
    }

    //////////////////////////////////////////////////////////////////////////

    #region 隐藏 Alt+Tab 中的 ToastWindow 窗口

    [Flags]
    private enum GetWindowLongFields
    {
        // ...
        GWL_EXSTYLE = -20,
        // ...
    }
    [Flags]
    private enum ExtendedWindowStyles
    {
        // ...
        WS_EX_TOOLWINDOW = 0x00000080,
        // ...
    }

    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    private static void HideAltTabWindow()
    {
        IntPtr handle = FindWindow(null, "ToastWindow");
        int exStyle = (int)GetWindowLong(handle, (int)GetWindowLongFields.GWL_EXSTYLE);
        exStyle |= (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;
        SetWindowLongPtr(handle, (int)GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
    }

    #endregion
}

public enum NotifierType
{
    /// <summary>
    /// 无
    /// </summary>
    None,
    /// <summary>
    /// 信息
    /// </summary>
    Information,
    /// <summary>
    /// 成功
    /// </summary>
    Success,
    /// <summary>
    /// 警告
    /// </summary>
    Warning,
    /// <summary>
    /// 错误
    /// </summary>
    Error,
    /// <summary>
    /// 通知
    /// </summary>
    Notification
}