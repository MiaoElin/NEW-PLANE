using System.Numerics;
using Raylib_cs;
public class Program
{
    public static void Main()
    {
        int scale = 6;
        Raylib.InitWindow(scale * 720 / 6, scale * 1080 / 6, "PlaneGame");
        Raylib.SetTargetFPS(60);

        // 初始化
        Context con = new Context();
        con.Initialize();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            float dt = Raylib.GetFrameTime();
            // 全局输入
            con.input.Process();
            // =====行为=====
            // 登入页
            if (con.gameStatus == 1)
            {
                Login_Tick();
            }
            // 游戏中
            if (con.gameStatus == 2)
            {
                Game_Tick();
            }
            // 退出页
            if (con.gameStatus == 3)
            {
                Logout_Tick();
            }
            // =====绘制=====
            // 登入页
            if (con.gameStatus == 1)
            {
                Login_Draw();
            }
            // 游戏中
            if (con.gameStatus == 2)
            {
                Game_Draw();
            }
            // 退出页
            if (con.gameStatus == 3)
            {
                Logout_Draw();
            }
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();



    }
    // 登入页
    public static void Login_Tick()
    {

    }
    public static void Login_Draw()
    {

    }
    // 游戏中
    public static void Game_Tick()
    {

    }
    public static void Game_Draw()
    {

    }
    // 退出页
    public static void Logout_Tick()
    {

    }
    public static void Logout_Draw()
    {

    }

}