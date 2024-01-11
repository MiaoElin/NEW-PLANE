using System.Numerics;
using Raylib_cs;
public static class UIApp {
    #region Login:Panel
    public static void Login_Open(UIContext con) {
        ref Panel_Login Panel = ref con.panel_Login;
        if (Panel == null) {
            Panel = new Panel_Login();
            Panel.Ctor(); //构造函数，延迟构造，可以先new。把初始的参数放这里，这样不会重复初始化赋值
        }
        con.panel_Login.Init();

    }
    public static void Login_Closed(UIContext con) {
        con.panel_Login.isOpen = false;
    }
    public static bool Login_IsClickStart(UIContext con) {
        if (con.panel_Login.isOpen && con.panel_Login.IsClickStart()) {
            return true;
        }
        return false;
    }
    public static bool Login_IsClickExit(UIContext con) {
        if (con.panel_Login.isOpen && con.panel_Login.IsClickExit()) {
            return true;
        }
        return false;
    }
    public static bool Login_IsClickSetting(UIContext con) {
        if (con.panel_Login.isOpen && con.panel_Login.IsClickSetting()) {
            return true;
        }
        return false;
    }
    public static void Login_Draw(UIContext con) {
        if (con.panel_Login.isOpen) {
            con.panel_Login.Draw();
        }
    }
    #endregion Login:Panel
    #region Pause:Panel
    public static void Pause_Open(UIContext con) {
        ref Panel_Pause panel = ref con.panel_Pause;
        if (panel == null) {
            panel = new Panel_Pause();
            panel.Ctor();
        }
        panel.Init();
    }
    // public static bool Pause_IsKeyDownEsc(UIContext con) {
    //         return con.panel_Pause.IsKeyDown;
    // }
    public static void Pause_Closed(UIContext con) {
        if (con.panel_Pause!=null&&con.panel_Pause.isOpen) {
            con.panel_Pause.isOpen = false;
        }
    }
    public static void Pause_Draw(UIContext con) {
        Panel_Pause panel = con.panel_Pause;
        if (panel != null && panel.isOpen) {
            con.panel_Pause.Draw();
        }
    }
    #endregion Pause:Panel
    #region Failed:Panel
    public static void Failed_Open(UIContext uic) {
        ref Panel_Failed panel = ref uic.panel_Failed;
        if (panel == null) {
            panel = new Panel_Failed();
            panel.Ctor();
        }
        panel.Init();
    }
    public static void Failed_Closed(UIContext uic) {
        if (uic.panel_Failed == null) {
            return;
        }
        uic.panel_Failed.isOpen = false;
    }
    public static bool Failed_IsClickRebirth(UIContext uic) {
        return uic.panel_Failed.IsClickRebirth();
    }
    public static bool Failed_isClickExit(UIContext uic) {
        if (uic.panel_Failed.isOpen && uic.panel_Failed.IsClickExit()) {
            return true;
        }
        return false;
    }
    public static void Failed_Draw(UIContext uic) {
        if (uic.panel_Failed != null && uic.panel_Failed.isOpen) {
            uic.panel_Failed.Draw();
        }
    }
    #endregion Failed:Panel
    #region Win:Panel
    public static void Win_Open(UIContext uic,int waveTypeID) {
        ref Panel_Win panel = ref uic.panel_Win;
        if (panel == null) {
            panel = new Panel_Win();
            panel.Ctor();
        }
        panel.Init(waveTypeID);
    }
    public static void Win_Closed(UIContext uic) {
        if (uic.panel_Win == null) {
            return;
        }
        uic.panel_Win.isOpen = false;
    }
    public static bool Win_IsClickContinue(UIContext uic) {
        if (uic.panel_Win != null && uic.panel_Win.isOpen && uic.panel_Win.IsClickContinue()) {
            return true;
        }
        return false;
    }
    public static void Win_Draw(UIContext uic) {
        if (uic.panel_Win != null && uic.panel_Win.isOpen) {
            uic.panel_Win.Draw();
        }
    }
    #endregion Win:Panel
}