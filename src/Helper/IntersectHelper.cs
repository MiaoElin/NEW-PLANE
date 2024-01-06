using System.Numerics;
using Raylib_cs;
public static class IntersectHelper {
    public static bool IscircleIntersect(Vector2 pos1, float r1, Vector2 pos2, float r2) {
        float distace = Vector2.Distance(pos2, pos1);
        if (distace <= r2 + r1) {
            return true;
        }
        return false;
    }
    public static bool IsRectCircleIntersect(Vector2 circlePos, Vector2 circleSize, Vector2 rectPos, Vector2 rectSize) {
        Vector2 leftTop = rectPos - rectSize / 2 - circleSize;
        Vector2 rightBottom = rectPos + rectSize / 2 + circleSize;
        if (circlePos.X >= leftTop.X && circlePos.X <= rightBottom.X && circlePos.Y >= leftTop.Y && circlePos.Y <= rightBottom.Y) {
            return true;
        }
        return false;
    }
}