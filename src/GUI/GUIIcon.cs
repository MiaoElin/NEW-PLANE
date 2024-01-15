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

    public GUIIcon(AssetsContext assets) {
        texture = assets.player1;
        pos = new Vector2(260, 425);
        size = new Vector2(40, 40);
        indexX=0;
        indexY=0;
        x1 = new int[] { 260 };
        x2 = new int[] { 260, 500,600};
        x3 = new int[] { 260 };
        y = new int[] { 425, 525, 625 };
    }
    public void Move() {
        for (int i = 0; i < y.Length; i++) {
            var a = y[i];
            if (a == pos.Y) {
                FindPosY(i);
                if (pos.Y == 425) {
                    FindPosX(x1);
                }
                if (pos.Y == 525) {
                    FindPosX(x2);
                }
                if (pos.Y == 625) {
                    FindPosX(x3);
                }
                return;
            }

        }

    }
    void FindPosY(int i) {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP)) {
            indexY = i - 1;
        } else if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)) {
            indexY = i + 1;
        }
        if (indexY < 0) {
            indexY = y.Length - 1;
        }
        pos.Y = y[indexY % y.Length];
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