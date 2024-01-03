using System.Numerics;
using Raylib_cs;

public static class PlaneDomain {

    public static PlaneEntity SpawnPlane(Context con, int typeID, Vector2 pos, Ally ally) {
        PlaneEntity plane = Factory.CreatePlane(con.template, con.iDService, typeID, pos, ally);
        con.gameContext.planeRepo.Add(plane);
        if (ally == Ally.enemy) {
            plane.dir = new Vector2(0, 1);
        } else {
            plane.dir = new Vector2(0, -1);
        }
        return plane;
    }

    public static void Move(Context con, PlaneEntity plane, float dt) {
        if (plane.ally == Ally.player) {
            plane.Move(con.input.moveAxis, dt);
        }
        if (plane.ally == Ally.enemy) {
            if (plane.moveType == MoveType.ByTrack) {
                Vector2 playerPos = con.gameContext.GetPlayer().pos;
                Vector2 dir =  playerPos- plane.pos;
                plane.Move(dir, dt);
                // plane.LookAt(playerPos);
            }
            if (plane.moveType == MoveType.DontMove) {
                plane.Move(new(0, 0), dt);
            }

        }
    }

    public static void EnemyTryShoot(Context ctx, PlaneEntity plane, float dt) {
        if (plane.bulTimer <= 0) {
            plane.bulTimer = plane.bulInterval;
            // 发射
            PlaneEntity playerPlane = ctx.gameContext.GetPlayer();
            BulletDomain.SpawnBulletByBulCount(ctx, plane.bulTypeID, plane.bulPerCount, plane.pos, plane.dir, playerPlane.pos, plane.ally);
        } else {
            plane.bulTimer -= dt;
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