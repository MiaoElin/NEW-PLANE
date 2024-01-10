using System.Numerics;
using Raylib_cs;
public static class PlaneDomain {
    public static PlaneEntity SpawnPlane(GameContext con, int typeID, Vector2 pos, Ally ally) {
        PlaneEntity plane = Factory.CreatePlane(con.template, con.iDService, typeID, pos, ally);
        // System.Console.WriteLine(plane.planeSkillComponent.all[0].cd);
        con.planeRepo.Add(plane);
        return plane;
    }
    public static void Move(GameContext con, PlaneEntity plane, float dt) {
        if (plane.ally == Ally.player) {
            plane.Move(con.input.moveAxis, dt);
        }
        if (plane.ally == Ally.enemy) {
            if (plane.moveType == MoveType.ByTrack) {
                Vector2 dir = con.TryGetPlayer().pos - plane.pos;
                plane.Move(dir, dt);
            }
            if (plane.moveType == MoveType.DontMove) {
                plane.Move(new(0, 0), dt);
            }

        }
    }
    public static void TryShootBul(GameContext con, PlaneEntity plane, float dt) {
        if (plane.isDead) {
            return;
        }
        plane.planeSkillComponent.ForEach((SkillModel skill) => {
            if (skill.shooterType != plane.shooterType) {
                return;
            }
            skill.cd -= dt;
            if (skill.cd > 0) {
                return;
            }
            skill.shootMaintainTimer -= dt;
            skill.bulSpawntimer -= dt;
            if (skill.shootMaintainTimer <= 0) {
                skill.shootMaintainTimer = skill.shootMaintainSec;
                skill.cd = skill.cdMax;
                return;
            }
            if (skill.bulSpawntimer > 0) {
                return;
            }
            skill.bulSpawntimer = skill.bulSpawnInterval;
            if (plane.ally == Ally.enemy) {
                BulletDomain.SpawnBulShooterType(con, plane, dt);
            }
            if (plane.ally == Ally.player) {
                if (con.input.isSpaceDown) {
                    BulletDomain.SpawnBulShooterType(con, plane, dt);
                }
            }
        });

    }
    public static void EatFood(GameContext con, PlaneEntity player, FoodEntity food) {
        if (IntersectHelper.IsRectCircleIntersect(player.pos, player.size, food.pos, food.size)) {
            if (food.foodType == FoodType.TwoBulFood) {
                player.shooterType = ShooterType.twobul;

            }
            if (food.foodType == FoodType.ThreeBulFood) {
                player.shooterType = ShooterType.threebul;
            }
            if (food.foodType == FoodType.HpFood) {
                player.hp += 10;
                if (player.hp >= 100) {
                    player.hp = 100;
                }
            }
            food.isDead = true;
        }
    }
    public static void Draw(GameContext con) {
        int PlaneLen = con.planeRepo.TakeAll(out PlaneEntity[] nowAll);
        for (int i = 0; i < PlaneLen; i++) {
            var tem = nowAll[i];
            if (tem.isDead) {
                return;
            }
            tem.Draw();
        }
    }
}