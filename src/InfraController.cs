using Raylib_cs;
using System.Numerics;
public static class InfraController {
    public static void Init(Context con) {
        con.assets.Init();
        con.gameContext.template.Init(con.assets);
        con.widowWidth = 720;
        con.widowHeigth = 1080;
        con.baseSize = 60;
        ref Camera2D cam = ref con.camera2D;
        cam.Zoom = 1.0f;
        cam.Rotation = 0;
        cam.Target = Vector2.Zero;
        cam.Offset = Vector2.Zero;


    }
    public static void Tick(Context con, float dt) {
        TickCamera(con, dt);
    }
    public static void TickCamera(Context con, float dt) {
        ref Camera2D cam = ref con.camera2D;
        float mouseWheel = Raylib.GetMouseWheelMove();
        if (mouseWheel != 0) {
            cam.Zoom += mouseWheel * dt;
        }
        cam.Offset = new Vector2(con.widowWidth, con.widowHeigth) / 2;

    }
}