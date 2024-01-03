using System.Numerics;
using Raylib_cs;

public static class BulletDomain {

    public static void SpawnBulletByBulCount(Context ctx, int typeID, ShooterType perCount, Vector2 planePos, Vector2 planeDir, Vector2 targetPos, Ally ally) {
        if (perCount == ShooterType.onebul) {
            SpawnBullet(ctx, typeID, planePos, planeDir, targetPos, ally);
        } else if (perCount == ShooterType.twobul) {
            BulletEntity b1 = SpawnBullet(ctx, typeID, planePos, planeDir, targetPos, ally);
            b1.pos.X -= 0.5f * b1.size.X;
            BulletEntity b2 = SpawnBullet(ctx, typeID, planePos, planeDir, targetPos, ally);
            b2.pos.X += 0.5f * b2.size.X;
        } else if (perCount == ShooterType.threebul) {
            System.Console.WriteLine("TODO 3bul");
        }
    }

    public static BulletEntity SpawnBullet(Context ctx, int typeID, Vector2 planePos, Vector2 planeDir, Vector2 targetPos, Ally ally) {
        BulletEntity bul = Factory.CreateBul(ctx.template, ctx.iDService, typeID, planePos, planeDir, ally);
        MoveType moveType = bul.moveType;
        if (moveType == MoveType.ByLine_Shooter) {
            bul.firstDir = planeDir;
        } else if (moveType == MoveType.ByLine_FaceTarget) {
            bul.firstDir = targetPos - planePos;
        } else if (moveType == MoveType.StaticDirection) {
            // Do Nothing
        }
        ctx.gameContext.bulRepo.Add(bul);
        return bul;
    }

    public static void SpawnBul(Context con, PlaneEntity plane, float dt) {
        PlaneEntity player = con.gameContext.GetPlayer();
        if (plane.ally == Ally.enemy) {
            if (plane.bulPerCount == ShooterType.onebul) {
                ref float timer = ref plane.bulTimer;
                timer -= dt;
                if (timer <= 0) {
                    Vector2 firstDir = player.pos - plane.pos;
                    BulletEntity bul = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, firstDir, Ally.enemy);
                    con.gameContext.bulRepo.Add(bul);
                    timer = bul.spawnInterval;
                    System.Console.WriteLine(timer);
                }

            } else if (plane.bulPerCount == ShooterType.twobul) {
                ref float timer = ref plane.bulTimer;
                timer -= dt;
                if (timer <= 0) {
                    BulletEntity bul1 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, Vector2.Zero, Ally.enemy);
                    bul1.pos.X -= 0.5f * bul1.size.X;
                    bul1.firstDir = player.pos - plane.pos;
                    con.gameContext.bulRepo.Add(bul1);
                    BulletEntity bul2 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, Vector2.Zero, Ally.enemy);
                    bul2.pos.X += 0.5f * bul2.size.X;
                    bul2.firstDir = player.pos - plane.pos;
                    con.gameContext.bulRepo.Add(bul2);
                    timer = bul2.spawnInterval;
                }
            } else if (plane.bulPerCount == ShooterType.threebul) {
                ref float timer = ref plane.bulTimer;
                timer -= dt;
                if (timer <= 0) {
                    Vector2 firstDir = player.pos - plane.pos;
                    BulletEntity bul1 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, firstDir, Ally.enemy);
                    con.gameContext.bulRepo.Add(bul1);
                    BulletEntity bul2 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, firstDir, Ally.enemy);
                    con.gameContext.bulRepo.Add(bul2);
                    BulletEntity bul3 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, firstDir, Ally.enemy);
                    con.gameContext.bulRepo.Add(bul3);
                    timer = bul1.spawnInterval;
                }
            }
        }
        if (plane.ally == Ally.player) {
            if (plane.bulPerCount == ShooterType.onebul) {
                ref float timer = ref plane.bulTimer;
                timer -= dt;
                if (timer <= 0) {
                    BulletEntity bul = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, Vector2.Zero, Ally.player);
                    if (bul.moveType == MoveType.ByLine_Shooter) {
                        // 找此刻最近的敌人 敌人pos-子弹pos=dir，记住这个dir为firstDir;
                        // 只有byline的情况要用到firstDir
                    }
                    con.gameContext.bulRepo.Add(bul);
                    timer = bul.spawnInterval;
                }
            } else if (plane.bulPerCount == ShooterType.twobul) {
                ref float timer = ref plane.bulTimer;
                timer -= dt;
                if (timer <= 0) {
                    BulletEntity bul1 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, Vector2.Zero, Ally.player);
                    bul1.pos.X -= 1f * bul1.size.X;
                    bul1.firstDir = player.pos - plane.pos;
                    con.gameContext.bulRepo.Add(bul1);
                    BulletEntity bul2 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, Vector2.Zero, Ally.player);
                    bul2.pos.X += 1f * bul2.size.X;
                    bul2.firstDir = player.pos - plane.pos;
                    con.gameContext.bulRepo.Add(bul2);
                    timer = bul1.spawnInterval;
                }
            } else if (plane.bulPerCount == ShooterType.threebul) {
                ref float timer = ref plane.bulTimer;
                timer -= dt;
                if (timer <= 0) {
                    BulletEntity bul1 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, Vector2.Zero, Ally.player);
                    con.gameContext.bulRepo.Add(bul1);
                    BulletEntity bul2 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, Vector2.Zero, Ally.player);
                    con.gameContext.bulRepo.Add(bul2);
                    BulletEntity bul3 = Factory.CreateBul(con.template, con.iDService, plane.bulTypeID, plane.pos, Vector2.Zero, Ally.player);
                    con.gameContext.bulRepo.Add(bul3);
                    timer = bul1.spawnInterval;
                }

            }
        }


    }
    public static void Move(Context con, float dt, BulletEntity bul) {
        // if (bul.ally == Ally.player) {
        //     if (bul.moveType == MoveType.StaticDirection) {
        //         Vector2 dir = new Vector2(0, -1);
        //         bul.Move(dir, dt);
        //     }
        //     if (bul.moveType == MoveType.ByTrack) {
        //         // 找此刻最近的敌人，追踪

        //     }
        //     if (bul.moveType == MoveType.ByLine) {
        //         // 找此刻最近的敌人 记住那个dir，保持这个dir移动
        //     }
        // }
        if (bul.ally == Ally.enemy) {
            if (bul.moveType == MoveType.StaticDirection) {
                Vector2 dir = new Vector2(0, 1);
                bul.Move(dir, dt);
            }
            if (bul.moveType == MoveType.ByTrack) {
                Vector2 dir = con.gameContext.GetPlayer().pos - bul.pos;
                bul.Move(dir, dt);
            }
            if (bul.moveType == MoveType.ByLine_Shooter) {
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