using System.Numerics;
using Raylib_cs;
public class Program {
    public static void Main() {
        Raylib.InitWindow(720, 1080, "PlaneGame");
        Raylib.SetTargetFPS(60);
        Raylib.SetExitKey(KeyboardKey.KEY_NULL);

        Context con = new Context();
        // Init
        Init(con);
        // Enter
        LoginController.Enter(con);
        while (!Raylib.WindowShouldClose()) {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DARKGRAY);
            float dt = Raylib.GetFrameTime();
            ref Camera2D cam = ref con.camera2D;

            // 全局输入
            Input(con);
            // =====Tick=====
            InfraController.Tick(con, dt);//包含相机初始化
            LoginController.Tick(con);
            GameController.InBattle_Tick(con.gameContext, dt);
            GameController.IsFailed(con);


            // =====Draw World=====
            Raylib.BeginMode2D(cam);
            LoginController.Draw(con);
            GameController.Draw(con.gameContext);
            Raylib.EndMode2D();

            // =====Draw UI=====
            LoginController.DrawUI(con);
            GameController.DrawUI(con.gameContext);

            Raylib.EndDrawing();
        }
        con.assets.UnloadTexture();
        Raylib.CloseWindow();
    }
    static void Init(Context con) {
        InfraController.Init(con);
        LoginController.Init(con);
    }
    static void Input(Context con) {
        con.gameContext.input.Process();
    }
}