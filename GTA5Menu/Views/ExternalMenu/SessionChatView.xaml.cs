using GTA5HotKey;
using GTA5Shared.API;
using GTA5Shared.Helper;
using GTA5Core.Native;
using GTA5Core.Features;
using GTA5Core.Offsets;

using WinFormLib;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// SessionChatView.xaml 的交互逻辑
/// </summary>
public partial class SessionChatView : UserControl
{
    public SessionChatView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        TextBox_InputMessage.Text = "测试文本: 请把游戏中聊天输入法调成英文,否则会漏掉文字.Hello1234,漏掉文字了吗?";

        long pCPlayerInfo = Globals.GetCPlayerInfo();
        TextBox_PlayerName.Text = Memory.ReadString(pCPlayerInfo + CPed.CPlayerInfo.Name, 20);
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        
    }

    /////////////////////////////////////////////////

    private void Button_Translate_Click(object sender, RoutedEventArgs e)
    {
        var message = TextBox_InputMessage.Text.Trim();

        if (!string.IsNullOrEmpty(message))
        {
            var btnContent = (e.OriginalSource as Button).Content.ToString();

            switch (btnContent)
            {
                case "中英互译":
                    YouDaoTranslation(message);
                    break;
                case "简转繁":
                    TextBox_InputMessage.Text = ChsHelper.ToTraditional(message);
                    break;
                case "繁转简":
                    TextBox_InputMessage.Text = ChsHelper.ToSimplified(message);
                    break;
                case "转拼音":
                    TextBox_InputMessage.Text = ChsHelper.ToPinyin(message);
                    break;
            }
        }
    }

    private void Button_SendTextToGTA5_Click(object sender, RoutedEventArgs e)
    {
        var msg = TextBox_InputMessage.Text.Trim();

        if (string.IsNullOrWhiteSpace(msg))
            return;

        msg = ToDBC(msg);

        Memory.SetForegroundWindow();
        SendMessageToGTA5(msg);

        TextBox_InputMessage.Text = msg;
    }

    /// <summary>
    /// 模拟键盘按键
    /// </summary>
    /// <param name="winVK"></param>
    private void KeyPress(WinVK winVK)
    {
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
        KeyHelper.Keybd_Event(winVK, KeyHelper.MapVirtualKey(winVK, 0), 0, 0);
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
        KeyHelper.Keybd_Event(winVK, KeyHelper.MapVirtualKey(winVK, 0), 2, 0);
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
    }

    /// <summary>
    /// 发送消息到GTA5游戏
    /// </summary>
    /// <param name="str"></param>
    private void SendMessageToGTA5(string str)
    {
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep1.Value));

        KeyPress(WinVK.RETURN);

        if (RadioButton_PressKeyT.IsChecked == true)
            KeyPress(WinVK.T);
        else
            KeyPress(WinVK.Y);

        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep1.Value));
        SendKeys.Flush();
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
        SendKeys.SendWait(str);
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
        SendKeys.Flush();
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep1.Value));

        KeyPress(WinVK.RETURN);
        KeyPress(WinVK.RETURN);
    }

    /// <summary>
    /// 调用有道翻译中英互译API
    /// </summary>
    /// <param name="message"></param>
    private async void YouDaoTranslation(string message)
    {
        try
        {
            TextBox_InputMessage.Text = await WebAPI.GetYouDaoContent(message);
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }

    private void TextBox_InputMessage_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            e.Handled = true;
            Button_SendTextToGTA5_Click(null, null);
        }
    }

    /// <summary>
    /// 全角字符转半角字符
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private string ToDBC(string input)
    {
        char[] inputChar = input.ToCharArray();

        for (int i = 0; i < inputChar.Length; i++)
        {
            if (inputChar[i] == 12288)
            {
                inputChar[i] = (char)32;
                continue;
            }

            if (inputChar[i] > 65280 && inputChar[i] < 65375)
            {
                inputChar[i] = (char)(inputChar[i] - 65248);
            }
        }

        return new string(inputChar);
    }

    private void Button_ReadPlayerName_Click(object sender, RoutedEventArgs e)
    {
        long pCPlayerInfo = Globals.GetCPlayerInfo();
        TextBox_PlayerName.Text = Memory.ReadString(pCPlayerInfo + CPed.CPlayerInfo.Name, 64);
    }

    private void CheckBox_IngnoreInputRule_Click(object sender, RoutedEventArgs e)
    {
        TextBox_PlayerName.MaxLength = CheckBox_IngnoreInputRule.IsChecked == true ? 64 : 20;
    }

    private void Button_WritePlayerName_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string playerName = TextBox_PlayerName.Text.Trim();
            TextBox_PlayerName.Text = playerName;

            if (CheckBox_IngnoreInputRule.IsChecked == false)
            {
                if (!Regex.IsMatch(playerName, "^[A-Za-z0-9_\\s-]{3,20}$"))
                {
                    NotifierHelper.Show(NotifierType.Warning, "玩家昵称不合法，规则：3到20位（字母，数字，下划线，减号，空格）");
                    return;
                }
            }

            long pCPlayerInfo = Globals.GetCPlayerInfo();
            string name = Memory.ReadString(pCPlayerInfo + CPed.CPlayerInfo.Name, 64);

            if (playerName.Equals(name))
            {
                NotifierHelper.Show(NotifierType.Information, "玩家昵称未改动，无需修改");
                return;
            }

            playerName += "\0";

            var pointers = Memory.FindPatterns(name);
            foreach (var item in pointers)
            {
                Memory.WriteString(item, playerName);
            }

            Memory.WriteString(pCPlayerInfo + CPed.CPlayerInfo.Name, playerName);

            NotifierHelper.Show(NotifierType.Success, "修改玩家昵称成功，切换战局生效");
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }
}
