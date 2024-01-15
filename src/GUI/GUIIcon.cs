using System.Numerics;
using Raylib_cs;
public class GUIIcon {
    public Texture2D texture;
    public Vector2 pos;
    public Vector2 size;
    public int[] x1;
    public int[] x2;
    public int[] x3;
    public int[] y;
    public int indexX;
    public int indexY;

    public GUIIcon() {

    }
    public void Move() {
        for (int i = 0; i < y.Length; i++) {
            var a = y[i];
            if (a == pos.Y) {
                if (pos.Y == y[0]) {
                    FindPosY(i, x3, x2);
                    FindPosX(x1);
                }
                if (pos.Y == y[1]) {
                    FindPosX(x2);
                    FindPosY(i, x1, x3);
                }
                if (pos.Y == y[2]) {
                    FindPosX(x3);
                    FindPosY(i, x2, x1);
                }
                return;
            }
        }
    }
    void FindPosY(int i, int[] xUp, int[] xDown) {

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP)) {
            for (int j = 0; j < xUp.Length; j++) {
                var b = xUp[j];
                if (b != pos.X) {
                    continue;
                }
                indexY = i - 1;
            }
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)) {
            for (int j = 0; j < xDown.Length; j++) {
                var b = xDown[j];
                if (b != pos.X) {
                    continue;
                }
                indexY = i + 1;
            }
        }
        if (indexY < 0) {
            indexY = y.Length - 1;
        }
        pos.Y = y[indexY % y.Length];
        return;
    }
    void FindPosX(int[] x) {
        for (int j = 0; j < x.Length; j++) {
            var b = x[j];
            if (b == pos.X) {
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT)) {
                    indexX = j - 1;
                } else if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT)) {
                    indexX = j + 1;
                }
                if (indexX < 0) {
                    indexX = x.Length - 1;
                }
                pos.X = x[indexX % x.Length];
                return; // return很重要 不然后移动x以后，遍历继续，会第二次进入（b==pos.x)，同一帧内会自动判定isKeyPressed,这时候icon会在一帧内一直判定向左或者向右
            }
        }
    }

}