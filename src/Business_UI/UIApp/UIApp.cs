using System.Numerics;
using Raylib_cs;
public static class UIApp
{
    // 登入页
    public static void Login_Open(UIContext con)
    {
        UIApp_Login.Login_Open(con);
    }
    public static void Login_Closed(UIContext con)
    {
        UIApp_Login.Login_Closed(con);
    }
    public static bool Login_IsClickStart(UIContext con)
    {
        return UIApp_Login.Login_IsClickStart(con);
    }
    public static bool Login_IsClickExit(UIContext con)
    {
        return UIApp_Login.Login_IsClickExit(con);
    }
        public static bool Login_IsClickSetting(UIContext con)
    {
        return UIApp_Login.Login_IsClickSetting(con);
    }
    public static void Draw(UIContext con)
    {
        UIApp_Login.Draw(con);
    }

    // 设置页
    public static void Setting_Open(UIContext con)
    {
        
    }
}