using System.Numerics;
using Raylib_cs;
public static class WaveDomain {
    public static WaveEntity SpawnWave(Context con, int typeID) {
        // 生成波次
        WaveEntity wave = Factory.CreateWave(con.template, con.iDService, typeID);
        con.gameContext.waveRepo.Add(wave);
        return wave;
    }
    public static void SpwanEntities(Context con, WaveEntity wave, float dt) {
        ref float time = ref wave.time;
        time += dt;
        if (time >= wave.spawnMaintainSec) {
            return;
            // 不再生成entity
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
    static void SpwanEntity(Context con, WaveSpawnTM tm) {
        SpwanEntity_Enemy(con, tm);
        SpwanEntity_Player(con, tm);
    }
    static void SpwanEntity_Player(Context con, WaveSpawnTM tm) {
        if (tm.ally == Ally.player) {
            if (tm.entityType == EntityType.Food) {
                FoodDomain.SpawnFood(con, tm.entityTypeID, con.r.GetRandomPosOn_LowerHalf());
            }
        }
    }

    static void SpwanEntity_Enemy(Context con, WaveSpawnTM tm) {
        if (tm.ally == Ally.enemy) {
            if (tm.entityType == EntityType.Plane) {
                if (tm.spawnPos == SpawnPos.RandomPosOn_Top) {
                    PlaneDomain.SpawnPlane(con, tm.entityTypeID, con.r.GetRandomPosOn_Top(), Ally.enemy);
                }
                if (tm.spawnPos == SpawnPos.RandomPosOn_UpperHalf) {
                    PlaneDomain.SpawnPlane(con, tm.entityTypeID, con.r.GetRandomPosOn_Upperhalf(), Ally.enemy);
                }
                if (tm.spawnPos == SpawnPos.TopMiddle) {
                    PlaneDomain.SpawnPlane(con, tm.entityTypeID, new Vector2(0, 460), Ally.enemy);
                }
            }
        }
    }

}