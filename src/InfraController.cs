using Raylib_cs;
using System.Numerics;
public static class InfraController{
    public static void Init(Context con){
        con.assets.Init();
        con.template.Init(con.assets);
        con.widowWidth=720;
        con.widowHeigth=1080;
        con.baseSize=60; 
        

    }
    public static void Tick(Context con,float dt){
        TickCamera(con,dt);
    }
    public static void TickCamera(Context con,float dt){
        ref Camera2D cam=ref con.camera2D;
        cam.Offset=new Vector2(con.widowWidth,con.widowHeigth)/2;
        float mouseWeel=Raylib.GetMouseWheelMove();
        if(mouseWeel!=0){
            cam.Zoom+=mouseWeel*dt;
        }
    }
}