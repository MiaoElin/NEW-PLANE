using System.Numerics;
using Raylib_cs;
public class GUIButton
{
    public Vector2 pos;
    public Vector2 size;
    public Color color;
    public string text;
    public GUIButton()
    {

    }

    public bool isClick()
    {
        if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), new Rectangle(pos.X, pos.Y, size.X, size.Y)))
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                return true;
            }
        }
        return false;
    }
    public bool IsMOuseInBtn()
    {
        return Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), new Rectangle(pos.X, pos.Y, size.X, size.Y));
    }
    public void Draw()
    {
        if (IsMOuseInBtn())
        {
            System.Console.WriteLine("0000");
            Raylib.DrawRectangleV(pos, size, Color.GREEN);
            Raylib.DrawText(text, (int)pos.X + 10, (int)pos.Y + 8, 12, Color.WHITE);
        }
        else
        {
            Raylib.DrawRectangleV(pos, size, color);
            Raylib.DrawText(text, (int)pos.X + 10, (int)pos.Y + 8, 12, Color.WHITE);
        }

    }
}