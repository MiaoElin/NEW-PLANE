using System.Numerics;
using Raylib_cs;
public static class FindUtil {
    public static bool FindNearlyEnemy(PlaneEntity[] allPlane, BulletEntity bul, out PlaneEntity nearlyenemy) {
        float nearlyDistance = float.MaxValue;
        float index = -1;
        nearlyenemy = default;
        for (int i = 0; i < allPlane.Length; i++) {
            var plane = allPlane[i];

            if (plane == null) {
                continue;
            }
            // if (plane.isDead) {
            //     continue;
            // }
            if (plane.ally == Ally.enemy) {
                float distance = Vector2.Distance(plane.pos, bul.pos);
                if (distance < nearlyDistance) {
                    nearlyDistance = distance;
                    nearlyenemy = plane;
                    index = i;
                }
            }
        }
        if (index == -1) {
            return false;
        }
        return true;
    }
}