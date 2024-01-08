using System.Numerics;
using Raylib_cs;
public class Panel_Login {
    public GUIButton btn_start;
    public GUIButton btn_exit;
    public GUIButton btn_setting;
    public bool isOpen;
    public Panel_Login() {

    }
    public void Ctor() {
        
        btn_start = new GUIButton();
        btn_start.colorBg = Color.BLACK;
        btn_start.colorMouseIN = Color.GREEN;
        btn_start.colorText = Color.WHITE;
        btn_start.pos = new Vector2(310, 425);
        btn_start.size = new Vector2(100, 30);
        btn_start.font = "START GAME";

        btn_exit = new GUIButton();
        btn_exit.colorBg = Color.BLACK;
        btn_exit.pos = new Vector2(310, 525);
        btn_exit.size = new Vector2(100, 30);
        btn_exit.font = "  Exit GAME";
        btn_exit.colorMouseIN = Color.GREEN;
        btn_exit.colorText = Color.WHITE;

        btn_setting = new GUIButton();
        btn_setting.colorBg = Color.BLACK;
        btn_setting.pos = new Vector2(310, 625);
        btn_setting.size = new Vector2(100, 30);
        btn_setting.font = "   SETTING";
        btn_setting.colorMouseIN = Color.GREEN;
        btn_setting.colorText = Color.WHITE;


    }
    // Ctor 延迟构造的作用
    public void Init() {
        isOpen = true;
    }
    public bool IsClickStart() {
        return btn_start.isClick();
    }
    public bool IsClickExit() {
        return btn_exit.isClick();
    }
    public bool IsClickSetting() {
        return btn_setting.isClick();
    }
    public void Draw() {
        btn_start.Draw();
        btn_exit.Draw();
        btn_setting.Draw();

    }

}