using System.Numerics;
using Raylib_cs;
public static class BulletDomain {
    public static BulletEntity SpawnBul(GameContext con, PlaneEntity plane,SkillModel skill, float dt, Vector2 firstDir) {
        BulletEntity bul = Factory.CreateBul(con.template, con.iDService, skill.bulTypeID, plane.pos, firstDir, plane.ally);
        con.bulRepo.Add(bul);
        if (bul.moveType == MoveType.ByLine) {
            bul.firstDir = con.TryGetPlayer().pos - bul.pos;
        }
        return bul;
    }
    public static void SpawnBulShooterType(GameContext con, PlaneEntity plane,SkillModel skill, float dt) {
        if (skill.shooterType == ShooterType.onebul) {
            SpawnBul(con, plane,skill, dt, plane.dir);
        } else if (skill.shooterType == ShooterType.twobul) {
            BulletEntity bul1 = SpawnBul(con, plane,skill, dt, plane.dir);
            bul1.pos.X -= 0.25f * bul1.size.X;
            BulletEntity bul2 = SpawnBul(con, plane,skill, dt, plane.dir);
            bul2.pos.X += 0.25f * bul2.size.X;
        } else if (skill.shooterType == ShooterType.threebul) {
            float x=plane.dir.X;
            float y=plane.dir.Y;
            Vector2 dir1 = new Vector2(x*MathF.Cos(MathF.PI/-45)-y*MathF.Sin(MathF.PI / -45),x*MathF.Sin(MathF.PI/-45)+y*MathF.Cos(MathF.PI / -45));
            Vector2 dir3 = new Vector2(x*MathF.Cos(MathF.PI/45)-y*MathF.Sin(MathF.PI / 45),x*MathF.Sin(MathF.PI/45)+y*MathF.Cos(MathF.PI / 45));
            BulletEntity bu1 = SpawnBul(con, plane,skill, dt, dir1);
            bu1.pos.X -=-y*0.25f * bu1.size.X;
            BulletEntity bu2 = SpawnBul(con, plane,skill, dt, plane.dir);
            BulletEntity bu3 = SpawnBul(con, plane,skill,dt, dir3);
            bu3.pos.X +=-y*0.25f * bu3.size.X;
        }
    }
    public static void Move(GameContext con, float dt, BulletEntity bul) {
        PlaneEntity player = con.TryGetPlayer();
        if (bul.ally == Ally.player) {
            if (bul.moveType == MoveType.StaticDirection) {
                bul.Move(bul.firstDir, dt);
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
                bul.Move(bul.firstDir, dt);
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
    public static void Remove(GameContext con, BulletEntity bul,PlaneEntity nearlyEnemy) {
                if (IntersectHelper.IscircleIntersect(bul.pos, bul.size.X, nearlyEnemy.pos, nearlyEnemy.size.X)) {
                    nearlyEnemy.hp -= bul.lethality;
                    if (bul.ally == Ally.enemy){
                       SkillModel current= nearlyEnemy.planeSkillComponent.TryGetCurrent();
                       if(current.skillLevel==1){
                       nearlyEnemy.planeSkillComponent.Replace(current.typeID,nearlyEnemy.planeSkillComponent.firstSkill);
                       }
                       else{
                        int skillLevel=current.skillLevel-1;
                        SkillModel skill=Factory.CreateSkillModel(con.template,current.typeID,skillLevel);
                        nearlyEnemy.planeSkillComponent.Replace(current.typeID,skill);
                       }
                    }
                    // System.Console.WriteLine(nearlyEnemy.hp);
                    if (nearlyEnemy.hp <= 0) {
                        nearlyEnemy.isDead = true;
                    }
                    bul.isDead = true;
                }
    }
    public static void Draw(GameContext con) {
        int bulLen = con.bulRepo.TakeAll(out BulletEntity[] all_Buls);
        for (int i = 0; i < bulLen; i++) {
            var bul = all_Buls[i];
            bul.Draw();
        }
    }
}