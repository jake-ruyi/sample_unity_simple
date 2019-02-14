using System;
using UnityEngine;

class InputMenu : IMenu
{
    Ruyi.SDK.UserServiceExternal.UserInfo_Public userInfo;

    public void OnGUI(Ruyi.SDK.InputManager.RuyiGamePadInput input)
    {
        GUILayout.BeginVertical();
        var str = String.Format(inputString(input));
        GUILayout.Label(str);
        GUILayout.EndVertical();
    }

    string inputString(Ruyi.SDK.InputManager.RuyiGamePadInput message)
    {
        return String.Format("{0} {1} {2} {3} {4} {5} {6}",
            dpadString(message),
            abxyString(message),
            stickString(message, true),
            stickString(message, false),
            triggerString(message, true),
            triggerString(message, false),
            userString(message)
            );
    }

    string dpadString(Ruyi.SDK.InputManager.RuyiGamePadInput message)
    {
        return string.Format("{0}{1}{2}{3}",
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_Left, "<"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_Up, "^"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_Down, "v"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_Right, ">")
            );
    }

    string abxyString(Ruyi.SDK.InputManager.RuyiGamePadInput message)
    {
        return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_A, "A"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_B, "B"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_X, "X"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_Y, "Y"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_LB, "LB", "__"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_RB, "RB", "__"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_L3, "L3", "__"),
            buttonString(message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_R3, "R3", "__")
            );
    }

    string buttonString(Ruyi.SDK.InputManager.RuyiGamePadInput message, Ruyi.SDK.CommonType.RuyiGamePadButtonFlags flag, string name, string none = "_")
    {
        return message != null && ((message.ButtonFlags & (int)flag) != 0) ? name : none;
    }


    string stickString(Ruyi.SDK.InputManager.RuyiGamePadInput message, bool isLeft)
    {
        return string.Format("{0}=X:{1,6}Y:{2,6}",
            isLeft ? "LS" : "RS",
            message == null ? 0 : (isLeft ? message.LeftThumbX : message.RightThumbX),
            message == null ? 0 : (isLeft ? message.LeftThumbY : message.RightThumbY)
            );
    }
    
    string triggerString(Ruyi.SDK.InputManager.RuyiGamePadInput message, bool isLeft)
    {
        return string.Format("{0}={1,3}",
            isLeft ? "LT" : "RT",
            message == null ? 0 : (byte)(isLeft ? message.LeftTrigger : message.RightTrigger)
            );
    }

    string userString(Ruyi.SDK.InputManager.RuyiGamePadInput message)
    {
        var res = string.Empty;
        if (userInfo == null)
        {
            res = "<NO USER>";
        }
        else
        {
            res = userInfo.Nickname;
        }
        if (message != null)
        {
            res += " " + message.UserId;
        }
        return res;
    }
}