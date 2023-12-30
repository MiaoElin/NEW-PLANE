using System.Numerics;
using Raylib_cs;
public static class LoginController
{
    public static void Init(Context con)
    {
        // 委托
    }
    public static void Enter(Context con)
    {
        UIApp.Login_Open(con.uIContext);
    }

    public static void Tick(Context con)
    {
        if(UIApp.Login_IsClickStart(con.uIContext)){
            UIApp.Login_Closed(con.uIContext);
            con.gameContext.isEnteringGame=true;
        }
        if(UIApp.Login_IsClickExit(con.uIContext)){
            Raylib.CloseWindow();
        }
        if(UIApp.Login_IsClickSetting(con.uIContext)){
            UIApp.Login_Closed(con.uIContext);
            UIApp.Setting_Open(con.uIContext);
        }
    }
    public static void Draw(Context con)
    {
    }
    public static void DrawUI(Context con)
    {
        UIApp.Draw(con.uIContext);

    }

}