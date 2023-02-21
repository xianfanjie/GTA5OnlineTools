using System;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GTA5HotKey;

public static class HotKeys
{
    [DllImport("user32.dll")]
    public static extern int GetAsyncKeyState(int vKey);

    [DllImport("user32.dll", EntryPoint = "keybd_event")]
    public static extern void Keybd_Event(WinVK bVk, uint bScan, uint dwFlags, uint dwExtraInfo);

    [DllImport("user32.dll")]
    public static extern uint MapVirtualKey(WinVK uCode, uint uMapType);

    public const int KEY_PRESSED = 0x8000;

    /// <summary>
    /// 热键字典集合
    /// </summary>
    private static readonly Dictionary<int, WinKey> HotKeyDirts = new();

    /// <summary>
    /// 按键弹起事件
    /// </summary>
    public static event Action<WinVK> KeyUpEvent;
    /// <summary>
    /// 按键按下事件
    /// </summary>
    public static event Action<WinVK> KeyDownEvent;

    /// <summary>
    /// 初始化
    /// </summary>
    static HotKeys()
    {
        new Thread(UpdateHotKeyThread)
        {
            Name = "UpdateHotKeyThread",
            IsBackground = true
        }.Start();
    }

    /// <summary>
    /// 增加快捷按键（自动过滤重复按键）
    /// </summary>
    /// <param name="key"></param>
    public static void AddKey(WinVK key)
    {
        var keyId = (int)key;
        if (!HotKeyDirts.ContainsKey(keyId))
        {
            HotKeyDirts.Add(keyId, new WinKey() { Key = key });
        }
    }

    /// <summary>
    /// 移除快捷键
    /// </summary>
    /// <param name="key"></param>
    public static void RemoveKey(WinVK key)
    {
        var keyId = (int)key;
        if (HotKeyDirts.ContainsKey(keyId))
        {
            HotKeyDirts.Remove(keyId);
        }
    }

    /// <summary>
    /// 清空快捷键
    /// </summary>
    public static void ClearKeys()
    {
        HotKeyDirts.Clear();
    }

    /// <summary>
    /// 按键按下
    /// </summary>
    /// <param name="vK"></param>
    private static void OnKeyDown(WinVK vK)
    {
        KeyDownEvent?.Invoke(vK);
    }

    /// <summary>
    /// 按键弹起
    /// </summary>
    /// <param name="vK"></param>
    private static void OnKeyUp(WinVK vK)
    {
        KeyUpEvent?.Invoke(vK);
    }

    /// <summary>
    /// 按键监听线程
    /// </summary>
    /// <param name="sender"></param>
    private static void UpdateHotKeyThread(object sender)
    {
        while (true)
        {
            if (HotKeyDirts.Count > 0)
            {
                var keysData = new List<WinKey>(HotKeyDirts.Values);
                if (keysData != null && keysData.Count > 0)
                {
                    foreach (WinKey key in keysData)
                    {
                        if (Convert.ToBoolean(GetAsyncKeyState((int)key.Key) & KEY_PRESSED))
                        {
                            if (!key.IsKeyDown)
                            {
                                key.IsKeyDown = true;
                                OnKeyDown(key.Key);
                            }
                        }
                        else
                        {
                            if (key.IsKeyDown)
                            {
                                key.IsKeyDown = false;
                                OnKeyUp(key.Key);
                            }
                        }
                    }
                }
            }

            Thread.Sleep(20);
        }
    }
}
