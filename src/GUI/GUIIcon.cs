using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;
public class GUIIcon {

    public Texture2D texture;
    public Vector2 pos;
    public Vector2 size;

    Dictionary<int, Vector2[]> lines;
    int index_x;
    int index_y;

    public GUIIcon() {
        lines = new Dictionary<int, Vector2[]>();
        // →0,0      1,0
        //  0,1      1,1     2,1
        //  0,2
        lines.Add(0 /* 第0行 */, new Vector2[] { new Vector2(0, 0), new Vector2(1, 0) });
        lines.Add(1 /* 第1行 */, new Vector2[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1) });
        lines.Add(2 /* 第2行 */, new Vector2[] { new Vector2(0, 2) });

        index_x = 0;
        index_y = 0;
    }

    public void Move(int axis_x, int axis_y) {

        // 左右移动
        if (axis_x != 0) {
            Vector2[] line;
            lines.TryGetValue(index_y, out line);

            index_x += axis_x; // 尝试向左移动
            if (index_x < 0) {
                index_x = line.Length - 1;
            } else {
                index_x %= line.Length;
            }
            return;
        }

        // 上下移动
        if (axis_y != 0) {

            // 尝试找下一行
            int next = index_y + axis_y;
            if (next < 0) {
                next = lines.Count - 1;
            } else {
                next %= lines.Count;
            }

            Vector2[] nextLine;
            lines.TryGetValue(next, out nextLine);

            // index_x
            bool isFound = false;
            for (int i = 0; i < nextLine.Length; i++) {
                if (nextLine[i].X == index_x) {
                    isFound = true;
                    break;
                }
            }

            // 正式移动
            index_y = next;
            if (!isFound) {
                index_x = nextLine.Length - 1;
            }
        }

    }

    public void DrawUI() {

        Vector2 btnSize = new Vector2(160, 30);
        Vector2 panelPos = new Vector2(100, 100);
        int linesCount = lines.Count;
        for (int y = 0; y < linesCount; y++) {

            Vector2[] line; // 一行按钮
            lines.TryGetValue(y, out line);

            // y1: x1 x2 x3
            // y2: x1 x2
            for (int x = 0; x < line.Length; x++) {
                Vector2 btnPos = new Vector2(line[x].X * btnSize.X + x * 20, line[x].Y * btnSize.Y + y * 20);
                if (y == index_y && x == index_x) {
                    Raylib.DrawRectangleV(btnPos + panelPos, btnSize, Color.GREEN);
                } else {
                    Raylib.DrawRectangleV(btnPos + panelPos, btnSize, Color.BLACK);
                }
            }

        }

    }

}