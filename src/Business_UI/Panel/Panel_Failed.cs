using System.Numerics;
using Raylib_cs;
public class Panel_Failed {
    public string text_Defeat;
    public GUIButton btn_Rebirth;
    public GUIButton btn_Exit;
    public bool isOpen;
    public GUIGrid grid;
    public void Ctor() {
        text_Defeat = "Game Failed";
        btn_Rebirth = new GUIButton();
        btn_Rebirth.colorBg = Color.BLACK;
        btn_Rebirth.colorMouseIN = Color.GREEN;
        btn_Rebirth.colorText = Color.WHITE;
        btn_Rebirth.linePos = new Vector2(0, 0);
        btn_Rebirth.font = "  REBIRTH";
        btn_Rebirth.size = new Vector2(100, 30);
        btn_Rebirth.fontSize = 16;
        btn_Rebirth.Ctor(grid.panelPos, grid.space);

        btn_Exit = new GUIButton();
        btn_Exit.colorBg = Color.BLACK;
        btn_Exit.colorMouseIN = Color.GREEN;
        btn_Exit.colorText = Color.WHITE;
        btn_Exit.linePos = new Vector2(0, 1);
        btn_Exit.font = "  ExitGame";
        btn_Exit.size = new Vector2(100, 30);
        btn_Exit.fontSize = 16;
        btn_Exit.Ctor(grid.panelPos, grid.space);

        grid = new GUIGrid();
        grid.space = new Vector2(40, 100);
        grid.panelPos = new Vector2(310, 490);
        grid.iconSize = new Vector2(40, 40);
        grid.index_X = 0;
        grid.index_Y = 0;
        grid.lines = new Dictionary<int, Vector2[]>();
        grid.lines.Add(0, new Vector2[] { new Vector2(0, 0) });
        grid.lines.Add(1, new Vector2[] { new Vector2(0, 1) });

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
        // Raylib.DrawRectangle(0,0,720,1080,Color.BLACK);
        Raylib.DrawText(text_Defeat, 230, 390, 50, Color.WHITE);
        btn_Rebirth.Draw();
        btn_Exit.Draw();
    }
}