using Raylib_cs;
using System.Numerics;
public static class InfraController{
    public static void Init(Context con){
        con.assets.Init();
        con.template.Init(con.assets);
        

    }
}