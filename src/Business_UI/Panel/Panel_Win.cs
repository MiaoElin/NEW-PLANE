using System.Numerics;
using Raylib_cs;
public class Panel_Win {
    public GUIButton btn_Continue;
    public bool isOpen;
    public string waveTypeID;
    public void Ctor() {
        btn_Continue = new GUIButton();
        btn_Continue.colorBg = Color.BLACK;
        btn_Continue.colorMouseIN = Color.GREEN;
        btn_Continue.colorText = Color.WHITE;
        btn_Continue.pos = new Vector2(285, 800);
        btn_Continue.size = new Vector2(150, 45);
        btn_Continue.font = " CONTINUE";
        btn_Continue.fontSize=20;
    }
    public void Init(int waveTypeID) {
        isOpen = true;
        this.waveTypeID=waveTypeID.ToString();
    }
    public bool IsClickContinue() {
        return btn_Continue.isClick();
    }
    public void Draw() {
        Raylib.DrawRectangle(0,0,720,1080,Color.BLACK);
        Raylib.DrawText("LEVEL "+waveTypeID+"  COMPLETE",225,400,30,Color.WHITE);
        btn_Continue.Draw();
    }


}