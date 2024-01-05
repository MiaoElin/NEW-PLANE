using System.Numerics;
using Raylib_cs;
public static class BulletDomain {
    public static BulletEntity SpawnBul(Context con, PlaneEntity plane, float dt) {
        BulletEntity bul = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, plane.ally);
        con.gameContext.bulRepo.Add(bul);
        if (bul.moveType == MoveType.ByLine) {
            bul.firstDir = con.gameContext.TryGetPlayer().pos - bul.pos;
        }
        return bul;
    }
    public static void SpawnBulByBulType(Context con, PlaneEntity plane, float dt) {
            if (plane.ally == Ally.enemy) {
                if (plane.shooterType == ShooterType.onebul) {
                    BulletEntity bul = SpawnBul(con, plane, dt);
                } else if (plane.shooterType == ShooterType.twobul) {
                    BulletEntity bul1 = SpawnBul(con, plane, dt);
                    bul1.pos.X -= 0.5f * bul1.size.X;
                    BulletEntity bul2 = SpawnBul(con, plane, dt);
                    bul2.pos.X += 0.5f * bul2.size.X;
                } else if (plane.shooterType == ShooterType.threebul) {
                    BulletEntity bul1 = SpawnBul(con, plane, dt);
                    BulletEntity bul2 = SpawnBul(con, plane, dt);
                    BulletEntity bul3 = SpawnBul(con, plane, dt);
                }
            }
        if (plane.ally == Ally.player) {
            if (!con.input.isSpaceDown) {
                return;
            }
            
            if (plane.shooterType == ShooterType.onebul) {
                SpawnBul(con, plane, dt);
            } else if (plane.shooterType == ShooterType.twobul) {
                BulletEntity bul1 = SpawnBul(con, plane, dt);
                bul1.pos.X -= 0.5f * bul1.size.X;
                BulletEntity bul2 = SpawnBul(con, plane, dt);
                bul2.pos.X += 0.5f * bul2.size.X;
            } else if (plane.shooterType == ShooterType.threebul) {
                BulletEntity bul1 = SpawnBul(con, plane, dt);
                BulletEntity bul2 = SpawnBul(con, plane, dt);
                BulletEntity bul3 = SpawnBul(con, plane, dt);
            }
        }
    }
    public static void Move(Context con, float dt, BulletEntity bul) {
        PlaneEntity player = con.gameContext.TryGetPlayer();
        if (bul.ally == Ally.player) {
            if (bul.moveType == MoveType.StaticDirection) {
                Vector2 dir = new Vector2(0, -1);
                bul.Move(dir, dt);
            }
            if (bul.moveType == MoveType.ByTrack) {
                // 找此刻最近的敌人，追踪

            }
            if (bul.moveType == MoveType.ByLine) {
                // 找此刻最近的敌人 记住那个dir，保持这个dir移动
            }
        }
        if (bul.ally == Ally.enemy) {
            if (bul.moveType == MoveType.StaticDirection) {
                Vector2 dir = new Vector2(0, 1);
                bul.Move(dir, dt);
            }
            if (bul.moveType == MoveType.ByTrack) {
                Vector2 dir = player.pos - bul.pos;
                bul.Move(dir, dt);
            }
            if (bul.moveType == MoveType.ByLine) {
                bul.Move(bul.firstDir, dt);
            }
        }

    }
    public static void Draw(Context con) {
        int bulLen = con.gameContext.bulRepo.TakeAll(out BulletEntity[] all_Buls);
        for (int i = 0; i < bulLen; i++) {
            var bul = all_Buls[i];
            bul.Draw();
        }
    }
}