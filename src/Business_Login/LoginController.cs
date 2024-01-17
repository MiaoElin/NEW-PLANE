using System.Numerics;
using Raylib_cs;
public static class LoginController {
    public static void Init(Context con) {
        // 委托
    }
    public static void Enter(Context con) {
        UIApp.Login_Open(con.uIContext);
        System.Console.WriteLine("123");
    }

    public static void Tick(Context con) {
        GameEntity game = con.gameContext.gameEntity;
        if (UIApp.Login_IsClickStart(con.uIContext)) {
            UIApp.Login_Closed(con.uIContext);
            game.gameStage = GameStage.EnteringGame;

        }
        if (UIApp.Login_IsClickExit(con.uIContext)) {
            Raylib.CloseWindow();
        }
        if (UIApp.Login_IsClickSetting(con.uIContext)) {
            UIApp.Login_Closed(con.uIContext);
            // UIApp.Setting_Open(con.uIContext);
        }
        Vector2 axis =con.gameContext.input.iconMoveAxis;
        UIApp.Login_IconMove(con.uIContext,(int)axis.X,(int)axis.Y);
    }
    public static void Draw(Context con) {

    }
    public static void DrawUI(Context con) {
        UIApp.Login_Draw(con.uIContext);
    }

}