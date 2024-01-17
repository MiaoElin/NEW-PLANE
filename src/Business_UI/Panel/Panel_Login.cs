using System.Numerics;
using Raylib_cs;
public class Panel_Login {
    public GUIButton btn_start;
    public GUIButton btn_exit;
    public GUIButton btn_setting;
    public GUIButton btn_Test1;
    public GUIButton btn_Test2;
    public GUIGrid grid;
    public bool isOpen;
    Dictionary<Vector2, GUIButton> allBtn;
    public Panel_Login() {

    }
    public void Ctor(AssetsContext assets) {
        grid = new GUIGrid();
        grid.texture = assets.player1;
        grid.iconSize = new Vector2(40, 40);
        grid.lines = new Dictionary<int, Vector2[]>();
        grid.lines.Add(0, new Vector2[] { new Vector2(0.5f, 0) });
        grid.lines.Add(1, new Vector2[] { new Vector2(0, 1), new Vector2(1, 1) });
        grid.lines.Add(2, new Vector2[] { new Vector2(0, 2), new Vector2(1, 2) });
        grid.index_X = 0;
        grid.index_Y = 0;
        grid.panelPos = new Vector2(215, 325);
        grid.space = new Vector2(50, 100);
        allBtn = new Dictionary<Vector2, GUIButton>();

        btn_start = new GUIButton();
        btn_start.colorBg = Color.BLACK;
        btn_start.colorMouseIN = Color.GREEN;
        btn_start.colorText = Color.WHITE;
        btn_start.linePos = new Vector2(0.5f, 0);
        btn_start.size = new Vector2(100, 30);
        btn_start.font = "START GAME";
        btn_start.fontSize = 12;
        btn_start.Ctor(grid.panelPos, grid.space);
        allBtn.Add(btn_start.linePos, btn_start);

        btn_exit = new GUIButton();
        btn_exit.colorBg = Color.BLACK;
        btn_exit.linePos = new Vector2(0, 1);
        btn_exit.size = new Vector2(100, 30);
        btn_exit.font = "  Exit GAME";
        btn_exit.colorMouseIN = Color.GREEN;
        btn_exit.colorText = Color.WHITE;
        btn_exit.fontSize = 12;
        btn_exit.Ctor(grid.panelPos, grid.space);
        allBtn.Add(btn_exit.linePos, btn_exit);

        btn_setting = new GUIButton();
        btn_setting.colorBg = Color.BLACK;
        btn_setting.linePos = new Vector2(1, 1);
        btn_setting.size = new Vector2(100, 30);
        btn_setting.font = "   SETTING";
        btn_setting.colorMouseIN = Color.GREEN;
        btn_setting.colorText = Color.WHITE;
        btn_setting.fontSize = 12;
        btn_setting.Ctor(grid.panelPos, grid.space);
        allBtn.Add(btn_setting.linePos, btn_setting);

        btn_Test1 = new GUIButton();
        btn_Test1.colorBg = Color.BLACK;
        btn_Test1.linePos = new Vector2(0, 2);
        btn_Test1.size = new Vector2(100, 30);
        btn_Test1.font = "  test1";
        btn_Test1.colorMouseIN = Color.GREEN;
        btn_Test1.colorText = Color.WHITE;
        btn_Test1.fontSize = 12;
        btn_Test1.Ctor(grid.panelPos, grid.space);
        allBtn.Add(btn_Test1.linePos, btn_Test1);

        btn_Test2 = new GUIButton();
        btn_Test2.colorBg = Color.BLACK;
        btn_Test2.linePos = new Vector2(1, 2);
        btn_Test2.size = new Vector2(100, 30);
        btn_Test2.font = "  test2";
        btn_Test2.colorMouseIN = Color.GREEN;
        btn_Test2.colorText = Color.WHITE;
        btn_Test2.fontSize = 12;
        btn_Test2.Ctor(grid.panelPos, grid.space);
        allBtn.Add(btn_Test2.linePos, btn_Test2);


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
    public void Move(int axis_X, int axis_Y) {
        grid.Move(axis_X, axis_Y);
    }
    public void Draw() {
        // 画按钮
        btn_start.Draw();
        btn_exit.Draw();
        btn_setting.Draw();
        btn_Test1.Draw();
        btn_Test2.Draw();
        // 找到当前按钮
        grid.lines.TryGetValue(grid.index_Y, out Vector2[] line);
        Vector2 btnLinePos = line[grid.index_X];
        allBtn.TryGetValue(btnLinePos, out GUIButton btn);
        //画图标
        grid.Draw(btn.size);
    }

}