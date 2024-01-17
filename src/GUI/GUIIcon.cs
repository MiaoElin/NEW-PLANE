using System.Numerics;
using Raylib_cs;
public class GUIGrid {
    public Texture2D texture;
    public Vector2 iconPos;
    public Vector2 iconSize;
    public Vector2 panelPos;// 网格在窗口的起始坐标
    public Vector2 space;// 网格间隔
    public Dictionary<int, Vector2[]> lines;
    // public int[] x1;
    // public int[] x2;
    // public int[] x3;
    // public int[] y;
    public int index_X;
    public int index_Y;


    public GUIGrid() {
        // lines = new Dictionary<int, Vector2[]>();
        // lines.Add(0, new Vector2[] { new Vector2(0.5f, 0) });
        // lines.Add(1, new Vector2[] { new Vector2(0, 1), new Vector2(1, 1) });
        // lines.Add(2, new Vector2[] { new Vector2(0, 2), new Vector2(1, 2) });
        // index_X = 0;
        // index_Y = 0;

    }
    public void Move(int axis_X, int axis_Y) {
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
        // 尝试上下移动
        bool isFound = false;
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
    public void Draw(Vector2 btnSize) {
        // Vector2 btnPos = new Vector2();
        // // 画按钮
        // for (int y = 0; y < lines.Count; y++) {
        //     lines.TryGetValue(y, out Vector2[] line);
        //     for (int x = 0; x < line.Length; x++) {

        //         btnPos.X = panelPos.X + (space.X + btnSize.X) * line[x].X;
        //         btnPos.Y = panelPos.Y + (space.Y + btnSize.Y) * y;
        //         if (index_X == x && index_Y == y) {
        //             Raylib.DrawRectangle((int)btnPos.X, (int)btnPos.Y, (int)btnSize.X, (int)btnSize.Y, Color.GREEN);
        //         } else {
        //             Raylib.DrawRectangle((int)btnPos.X, (int)btnPos.Y, (int)btnSize.X, (int)btnSize.Y, Color.BLACK);
        //         }
        //     }
        // }
        // 画icon
        lines.TryGetValue(index_Y, out Vector2[] lineNow);
        iconPos.X = panelPos.X + (btnSize.X + space.X) * lineNow[index_X].X - 40;
        iconPos.Y = panelPos.Y + (btnSize.Y + space.Y) * index_Y;
        Rectangle src = new Rectangle(0, 0, texture.Width, texture.Height);
        Rectangle dest = new Rectangle(iconPos.X, iconPos.Y, iconSize.X, iconSize.Y);
        Raylib.DrawTexturePro(texture, src, dest, new Vector2(0, 0), 0, Color.WHITE);

    }

}
