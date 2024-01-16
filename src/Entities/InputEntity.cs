using System.Numerics;
using Raylib_cs;
public class InputEntity {
    public Vector2 moveAxis;
    public bool isSpaceDown;
    public bool isEscPressed;
    public Vector2 iconMoveAxis;
    public void Process() {
        float x = 0;
        float y = 0;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {
            y = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {
            y = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
            x = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
            x = 1;
        }
        moveAxis = new Vector2(x, y);
        isSpaceDown = Raylib.IsKeyDown(KeyboardKey.KEY_SPACE);
        isEscPressed = Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE);

        float axis_X = 0;
        float axis_Y = 0;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP)) {
            axis_Y = -1;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)) {
            axis_Y = 1;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT)) {
            axis_X = -1;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT)) {
            axis_X = 1;
        }
        iconMoveAxis=new Vector2 (axis_X,axis_Y);
    }
}