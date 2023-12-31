using System.Numerics;
using Raylib_cs;
public static class UIApp
{
    #region Login:Panel
    public static void Login_Open(UIContext con)
    {
        ref Panel_Login Panel = ref con.panel_Login;
        if (Panel == null)
        {
            Panel = new Panel_Login();
            Panel.Ctor(); //构造函数，延迟构造，可以先new。把初始的参数放这里，这样不会重复初始化赋值
        }
        con.panel_Login.Init();

    }
    public static void Login_Closed(UIContext con)
    {
        con.panel_Login.isOpen = false;
    }
    public static bool Login_IsClickStart(UIContext con)
    {
        if (con.panel_Login.isOpen && con.panel_Login.IsClickStart())
        {
            return true;
        }
        return false;
    }
    public static bool Login_IsClickExit(UIContext con)
    {
        if (con.panel_Login.isOpen && con.panel_Login.IsClickExit())
        {
            return true;
        }
        return false;
    }
    public static bool Login_IsClickSetting(UIContext con)
    {
        if (con.panel_Login.isOpen && con.panel_Login.IsClickSetting())
        {
            return true;
        }
        return false;
    }
    public static void Draw(UIContext con)
    {
        if (con.panel_Login.isOpen)
        {
            con.panel_Login.Draw();
        }
    }
    #endregion Login:Panel
    #region Setting:Panel
    public static void Setting_Open(UIContext con)
    {

    }
    #endregion Setting:Panel
}