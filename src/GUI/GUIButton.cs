using System.Numerics;
using Raylib_cs;
public class GUIButton {
    public Vector2 pos;
    public Vector2 linePos;
    public Vector2 size;
    public Color colorBg;
    public Color colorMouseIN;
    public string font;
    public Color colorText;
    public int fontSize;
    public GUIButton() {

    }
    public void Ctor(Vector2 panelPos, Vector2 space) {
        float pos_X = panelPos.X + linePos.X * (size.X + space.X);
        float pos_Y = panelPos.Y + linePos.Y * (size.Y + space.Y);
        pos.X = pos_X;
        pos.Y = pos_Y;
    }

    public bool isClick() {
        if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), new Rectangle(pos.X, pos.Y, size.X, size.Y))) {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) {
                return true;
            }
        }
        return false;
    }
    public bool IsMOuseInBtn() {
        return Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), new Rectangle(pos.X, pos.Y, size.X, size.Y));
    }
    public void Draw() {
        if (IsMOuseInBtn()) {
            Raylib.DrawRectangleV(pos, size, colorMouseIN);
            Raylib.DrawText(font, (int)pos.X + 10, (int)pos.Y + 8, fontSize, colorText);
            return;
        }
        Raylib.DrawRectangleV(pos, size, colorBg);
        Raylib.DrawText(font, (int)pos.X + 10, (int)pos.Y + 8, fontSize, colorText);

    }
}