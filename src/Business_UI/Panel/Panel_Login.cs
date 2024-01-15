using System.Numerics;
using Raylib_cs;
public class Panel_Login {
    public GUIButton btn_start;
    public GUIButton btn_exit;
    public GUIButton btn_setting;
    public GUIIcon icon;
    public bool isOpen;
    public Panel_Login() {

    }
    public void Ctor(AssetsContext assets) {
        
        btn_start = new GUIButton();
        btn_start.colorBg = Color.BLACK;
        btn_start.colorMouseIN = Color.GREEN;
        btn_start.colorText = Color.WHITE;
        btn_start.pos = new Vector2(310, 425);
        btn_start.size = new Vector2(100, 30);
        btn_start.font = "START GAME";
        btn_start.fontSize=12;

        btn_exit = new GUIButton();
        btn_exit.colorBg = Color.BLACK;
        btn_exit.pos = new Vector2(310, 525);
        btn_exit.size = new Vector2(100, 30);
        btn_exit.font = "  Exit GAME";
        btn_exit.colorMouseIN = Color.GREEN;
        btn_exit.colorText = Color.WHITE;
        btn_exit.fontSize=12;

        btn_setting = new GUIButton();
        btn_setting.colorBg = Color.BLACK;
        btn_setting.pos = new Vector2(310, 625);
        btn_setting.size = new Vector2(100, 30);
        btn_setting.font = "   SETTING";
        btn_setting.colorMouseIN = Color.GREEN;
        btn_setting.colorText = Color.WHITE;
        btn_setting.fontSize=12;
        icon=new GUIIcon (assets);



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
    public void Move(){
        icon.Move();
    }
    public void Draw() {
        // 画图标
        Rectangle src=new Rectangle (0,0,icon.texture.Width,icon.texture.Height);
        Rectangle dest=new Rectangle (icon.pos.X,icon.pos.Y,icon.size.X,icon.size.Y);
        Raylib.DrawTexturePro(icon.texture,src,dest,new Vector2(0,0),0,Color.WHITE);
        // 画按钮
        btn_start.Draw();
        btn_exit.Draw();
        btn_setting.Draw();

    }

}