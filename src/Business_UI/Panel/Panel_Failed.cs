using System.Numerics;
using Raylib_cs;
public class Panel_Failed {
    public string text_Defeat;
    public GUIButton btn_Rebirth;
    public GUIButton btn_Exit;
    public bool isOpen;
    public void Ctor() {
        text_Defeat = "Game Failed";
        btn_Rebirth = new GUIButton();
        btn_Rebirth.colorBg = Color.BLACK;
        btn_Rebirth.colorMouseIN = Color.GREEN;
        btn_Rebirth.colorText = Color.WHITE;
        btn_Rebirth.pos = new Vector2(310, 490);
        btn_Rebirth.font = "  REBIRTH";
        btn_Rebirth.size = new Vector2(100, 30);
        btn_Rebirth.fontSize=12;

        btn_Exit = new GUIButton();
        btn_Exit.colorBg = Color.BLACK;
        btn_Rebirth.colorBg = Color.BLACK;
        btn_Rebirth.colorMouseIN = Color.GREEN;
        btn_Rebirth.colorText = Color.WHITE;
        btn_Exit.pos = new Vector2(310, 690);
        btn_Exit.font = "  ExitGame";
        btn_Exit.fontSize=12;

    }
    public void Init() {
        isOpen = true;
    }
    public bool IsClickRebirth() {
        return btn_Rebirth.isClick();
    }
    public bool IsClickExit() {
        return btn_Exit.isClick();
    }
    public void Draw() {
        btn_Rebirth.Draw();
        Raylib.DrawText(text_Defeat, 310, 390, 50, Color.BLACK);
    }
}