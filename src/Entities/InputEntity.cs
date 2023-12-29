using System.Numerics;
using Raylib_cs;
public class InputEntity
{
    public Vector2 moveAxis;
    public bool isSpaceDown;
    public Vector2 mosPos;
    public void Process()
    {
        float x = moveAxis.X;
        float y = moveAxis.Y;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            y = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            y = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            x = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            x = 1;
        }
        moveAxis = new Vector2(x, y);
        isSpaceDown=Raylib.IsKeyDown(KeyboardKey.KEY_SPACE);
        mosPos=Raylib.GetMousePosition();

    }
}