using System.Numerics;
using Raylib_cs;
public static class WaveDomain {
    public static void SpawnWave(Context con) {
        // 生成波次
        WaveEntity wave1= Factory.CreateWave(con.template, con.iDService,1);
        con.gameContext.waveRepo.Add(wave1);
        WaveEntity wave2=Factory.CreateWave(con.template,con.iDService,2);
        con.gameContext.waveRepo.Add(wave2);

    }
    public static void SpwanEntities(Context con, WaveEntity wave, float dt) {
        ref float time = ref wave.time;
        time += dt;
        if (time >=wave.spawnMaintainSec) {
            // 判定boss是否死亡
            PlaneEntity boss=con.gameContext.TryGetBoss();
            if(boss.isDead==true){
                wave.isDead=true;
            }
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
                    PlaneDomain.SpawnPlane(con, tm.entityTypeID, con.r.GetRandomPosOn_Top(), tm.ally);
                }
                if (tm.spawnPos == SpawnPos.RandomPosOn_UpperHalf) {
                    PlaneDomain.SpawnPlane(con, tm.entityTypeID, con.r.GetRandomPosOn_Upperhalf(), tm.ally);
                }
                if (tm.spawnPos == SpawnPos.TopMiddle) {
                    PlaneEntity boss = PlaneDomain.SpawnPlane(con, tm.entityTypeID, new Vector2(0, -460), tm.ally);
                    con.gameContext.bossEntityID=boss.entityID;
                }
            }
        }
    }

}