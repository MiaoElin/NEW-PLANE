using System.Numerics;
using Raylib_cs;
public static class UIApp_Login
{
    public static void Login_Open(UIContext con)
    {
        ref Panel_Login Panel = ref con.panel_Login;
        if (Panel == null)
        {
            Panel = new Panel_Login();
            Panel.Ctor();
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
}