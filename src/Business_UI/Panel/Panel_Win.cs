using System.Numerics;
using Raylib_cs;
public class Panel_Win {
    public GUIButton btn_Continue;
    public bool isOpen;
    public string waveTypeID;
    public GUIGrid gUIGrid;
    public void Ctor() {
        gUIGrid = new GUIGrid();
        gUIGrid.panelPos = new Vector2(285, 800);
        gUIGrid.space = new Vector2(0, 0);

        btn_Continue = new GUIButton();
        btn_Continue.colorBg = Color.BLACK;
        btn_Continue.colorMouseIN = Color.GREEN;
        btn_Continue.colorText = Color.WHITE;
        btn_Continue.linePos = new Vector2(0, 0);
        btn_Continue.size = new Vector2(150, 45);
        btn_Continue.font = " CONTINUE";
        btn_Continue.fontSize = 20;
        btn_Continue.Ctor(gUIGrid.panelPos, gUIGrid.space);

    }
    public void Init(int waveTypeID) {
        isOpen = true;
        this.waveTypeID = waveTypeID.ToString();
    }
    public bool IsClickContinue() {
        return btn_Continue.isClick();
    }
    public void Draw() {
        Raylib.DrawRectangle(0, 0, 720, 1080, Color.BLACK);
        Raylib.DrawText("LEVEL " + waveTypeID + "  COMPLETE", 225, 400, 30, Color.WHITE);
        btn_Continue.Draw();
    }


}