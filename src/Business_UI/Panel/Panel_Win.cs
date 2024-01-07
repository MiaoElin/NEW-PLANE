using System.Numerics;
using Raylib_cs;
public class Panel_Win {
    public GUIButton btn_Continue;
    public bool isOpen;
    public void Ctor() {
        btn_Continue = new GUIButton();
        // Raylib.ClearBackground(Color.DARKGRAY);
        btn_Continue.colorBg = Color.BLACK;
        btn_Continue.colorMouseIN = Color.GREEN;
        btn_Continue.colorText = Color.WHITE;
        btn_Continue.pos = new Vector2(-50, 250);
        btn_Continue.size = new Vector2(100, 30);
        btn_Continue.text = "CONTINUE";
    }
    public void Init() {
        isOpen = true;
    }
    public bool IsClickContinue() {
        return btn_Continue.isClick();
    }
    public void Draw() {
        btn_Continue.Draw();
    }


}