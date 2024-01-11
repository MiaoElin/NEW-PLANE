using System.Numerics;
using Raylib_cs;
public static class WaveDomain {
    public static void SpawnWave(GameContext con) {
        // 生成波次
        WaveEntity wave1 = Factory.CreateWave(con.template, con.iDService, 1);
        con.waveRepo.Add(wave1);
        WaveEntity wave2 = Factory.CreateWave(con.template, con.iDService, 2);
        con.waveRepo.Add(wave2);

    }
    public static void SpwanEntities(GameContext con, WaveEntity wave, float dt) {
        ref float time = ref wave.time;
        time += dt;
        if (time > wave.spawnMaintainSec) {
            // 不再生成entity
            if (con.planeRepo.IsAllEnemyDead()) {
                wave.isDead = true;
            }
            return;
        }
        WaveSpawnTM[] waveSpawnTMs = wave.waveSpawnTMs;
        for (int i = 0; i < waveSpawnTMs.Length; i++) {
            var entity = waveSpawnTMs[i];
            if (time < entity.beginTime || time > entity.endTime) {
                continue;
            }
            entity.timer -= dt;
            if (entity.timer <= 0) {
                entity.timer = entity.interval;
                SpwanEntity(con, entity);
            }
        }

    }
    static void SpwanEntity(GameContext con, WaveSpawnTM tm) {
        SpwanEntity_Enemy(con, tm);
        SpwanEntity_Player(con, tm);
    }
    static void SpwanEntity_Player(GameContext con, WaveSpawnTM tm) {
        if (tm.ally == Ally.player) {
            if (tm.entityType == EntityType.Food) {
                FoodDomain.SpawnFood(con, tm.entityTypeID, con.r.GetRandomPosOn_LowerHalf());
            }
        }
    }

    static void SpwanEntity_Enemy(GameContext con, WaveSpawnTM tm) {
        if (tm.ally == Ally.enemy) {
            if (tm.entityType == EntityType.Plane) {
                if (tm.spawnPos == SpawnPos.RandomPosOn_Top) {
                    PlaneDomain.SpawnPlane(con, tm.entityTypeID, con.r.GetRandomPosOn_Top(), tm.ally);
                }
                if (tm.spawnPos == SpawnPos.RandomPosOn_UpperHalf) {
                    PlaneDomain.SpawnPlane(con, tm.entityTypeID, con.r.GetRandomPosOn_Upperhalf(), tm.ally);
                }
                if (tm.spawnPos == SpawnPos.TopMiddle) {
                    PlaneEntity boss = PlaneDomain.SpawnPlane(con, tm.entityTypeID, new Vector2(0, -460), tm.ally);
                    boss.timer = 0.5f;
                    // boss.x = boss.pos.X;

                }
            }
        }
    }

}