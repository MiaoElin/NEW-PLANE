using System.Numerics;
using Raylib_cs;
public class InputEntity {
    public Vector2 moveAxis;
    public Vector2 uiMoveAxis;
    public bool isSpaceDown;
    public bool isEscPressed;
    public void Process() {
        float x = 0;
        float y = 0;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {
            y = -1;
        } else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {
            y = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
            x = -1;
        } else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
            x = 1;
        }
        moveAxis = new Vector2(x, y);

        float ui_x = 0;
        float ui_y = 0;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP)) {
            ui_y = -1;
        } else if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)) {
            ui_y = 1;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT)) {
            ui_x = -1;
        } else if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT)) {
            ui_x = 1;
        }
        uiMoveAxis = new Vector2(ui_x, ui_y);

        isSpaceDown = Raylib.IsKeyDown(KeyboardKey.KEY_SPACE);
        isEscPressed = Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE);

    }
}