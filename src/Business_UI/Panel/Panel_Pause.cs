using System.Numerics;
using Raylib_cs;
public class Panel_Pause{
    public string tip;
    public bool isOpen;
    public bool IsKeyDown;
    public void Ctor(){
        tip="Press the 'ESC' to continue";
    }
    public void Init(){
        isOpen=true;
        IsKeyDown=Raylib.IsKeyDown(KeyboardKey.KEY_ESCAPE);
    }
    public void Draw(){
        Raylib.DrawText(tip,250,500,16,Color.WHITE);
    }
}