using System.Numerics;
using Raylib_cs;
public static class PlaneDomain {
    public static PlaneEntity SpawnPlane(Context con, int typeID, Vector2 pos, Ally ally) {
        PlaneEntity plane = Factory.CreatePlane(con.template, con.iDService, typeID, pos, ally);
        con.gameContext.planeRepo.Add(plane);
        return plane;
    }
    public static void Move(Context con, PlaneEntity plane, float dt) {
        if (plane.ally == Ally.player) {
            plane.Move(con.input.moveAxis, dt);
        }
        if (plane.ally == Ally.enemy) {
            if (plane.moveType == MoveType.ByTrack) {
                Vector2 dir = con.gameContext.player.pos - plane.pos;
                plane.Move(dir, dt);
            }
            if (plane.moveType == MoveType.DontMove) {
                plane.Move(new(0, 0), dt);
            }

        }
    }
    public static void Draw(Context con) {
        int PlaneLen = con.gameContext.planeRepo.TakeAll(out PlaneEntity[] nowAll);
        for (int i = 0; i < PlaneLen; i++) {
            var tem = nowAll[i];
            tem.Draw();
        }
    }
}