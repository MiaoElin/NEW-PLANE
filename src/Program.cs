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
        InfraController.Init(con);
        // Enter
        LoginController.Enter();
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            float dt = Raylib.GetFrameTime();
            // 全局输入
            con.input.Process();
            // =====Tick=====

            // =====Draw World=====

            // =====Draw UI=====


            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}