using System.Numerics;
using Raylib_cs;
public class Program
{
    public static void Main()
    {
        Raylib.InitWindow(720, 1080, "PlaneGame");
        Raylib.SetTargetFPS(60);

        Context con = new Context();
        // Init
        Init(con);
        // Enter
        LoginController.Enter(con);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            float dt = Raylib.GetFrameTime();
            ref Camera2D cam=ref con.camera2D;
            
            // 全局输入
            con.input.Process();
            // =====Tick=====
            InfraController.Tick(con,dt);//包含相机初始化
            LoginController.Tick(con);
            
            // =====Draw World=====
            Raylib.BeginMode2D(cam);
            LoginController.Draw(con);
            Raylib.EndMode2D();

            // =====Draw UI=====
                LoginController.DrawUI(con);

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
    static void Init(Context con){
        InfraController.Init(con);
        LoginController.Init(con);
    }
}