using System.Numerics;
using Raylib_cs;
public class GUIIcon {
    public Texture2D texture;
    public Vector2 pos;
    public Vector2 size;
    Dictionary<int, Vector2[]> lines;
    // public int[] x1;
    // public int[] x2;
    // public int[] x3;
    // public int[] y;
    int index_X;
    int index_Y;


    public GUIIcon() {
        lines = new Dictionary<int, Vector2[]>();
        lines.Add(0, new Vector2[] { new Vector2(0, 0) });
        lines.Add(1, new Vector2[] { new Vector2(0, 1), new Vector2(1, 1) });
        lines.Add(2, new Vector2[] { new Vector2(0, 2), new Vector2(1, 2) });
        index_X = 0;
        index_Y = 0;
        // icon = new GUIIcon();
        // icon.texture = assets.player1;
        // icon.pos = new Vector2(260, 425);
        // icon.size = new Vector2(40, 40);
        // icon.index_X = 0;
        // icon.index_Y = 0;
        // icon.x1 = new int[] { 260 };
        // icon.x2 = new int[] { 260, 420, 570 };
        // icon.x3 = new int[] { 260 };
        // icon.y = new int[] { 425, 525, 625 };

    }
    public void Move(int axis_X, int axis_Y) {
        bool isFound = false;
        if (axis_X != 0) {
            // 尝试左右移动
            lines.TryGetValue(index_Y, out Vector2[] line);
            index_X += axis_X;
            if (index_X < 0) {
                index_X = line.Length - 1;
            }
            index_X = index_X % line.Length;
            return;
        }
        if (axis_Y != 0) {
            int nextLine_Y = index_Y + axis_Y;
            if (nextLine_Y < 0) {
                nextLine_Y = lines.Count - 1;
            }
            nextLine_Y = nextLine_Y % lines.Count;
            lines.TryGetValue(nextLine_Y, out Vector2[] nextLine);
            for (int i = 0; i < nextLine.Length; i++) {
                if (nextLine[i].X == index_X) {
                    index_Y = nextLine_Y;
                    isFound = true;
                    break;
                }
            }
            if (!isFound) {
                index_Y = nextLine_Y;
                index_X = nextLine.Length - 1;
            }
        }

    }
    public void Draw() {
        Vector2 btnSize = new Vector2(100, 30);
        Vector2 panelPos = new Vector2(215, 325);
        Vector2 space = new Vector2(50, 100);
        Vector2 btnPos = new Vector2();
        for (int y = 0; y < lines.Count; y++) {
            lines.TryGetValue(y, out Vector2[] line);
            for (int x = 0; x < line.Length; x++) {
                if (y == 0) {
                    btnPos.X = panelPos.X + (space.X + btnSize.X) * (x + 0.5f);
                    btnPos.Y = panelPos.Y + (space.Y + btnSize.Y) * y;
                } else if (y != 0) {
                    btnPos.X = panelPos.X + (space.X + btnSize.X) * x;
                    btnPos.Y = panelPos.Y + (space.Y + btnSize.Y) * y;
                }
                if (index_X == x && index_Y == y) {
                    Raylib.DrawRectangle((int)btnPos.X, (int)btnPos.Y, (int)btnSize.X, (int)btnSize.Y, Color.GREEN);
                } else {
                    Raylib.DrawRectangle((int)btnPos.X, (int)btnPos.Y, (int)btnSize.X, (int)btnSize.Y, Color.BLACK);

                }
            }
        }
        if (index_Y == 0) {
            pos.X = panelPos.X + (btnSize.X + space.X) * (index_X + 0.5f) - 40;
            pos.Y = panelPos.Y + (btnSize.Y + space.Y) * index_Y;
        } else {
            pos.X = panelPos.X + (btnSize.X + space.X) * index_X - 40;
            pos.Y = panelPos.Y + (btnSize.Y + space.Y) * index_Y;
        }

        Rectangle src = new Rectangle(0, 0, texture.Width, texture.Height);
        Rectangle dest = new Rectangle(pos.X, pos.Y, size.X, size.Y);
        Raylib.DrawTexturePro(texture, src, dest, new Vector2(0, 0), 0, Color.WHITE);

    }

}
