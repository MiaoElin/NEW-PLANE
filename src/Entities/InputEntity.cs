using System.Numerics;
using Raylib_cs;
public class InputEntity
{
    public Vector2 moveAxis;
    public bool isSpaceDown;
    public void Process()
    {
        float x = 0;
        float y = 0;
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

    }
}