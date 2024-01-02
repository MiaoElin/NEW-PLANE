using System.Numerics;
using Raylib_cs;
public static class WaveDomain {
    public static WaveEntity SpawnWave(Context con, int typeID) {
        // 生成波次
        WaveEntity wave = Factory.CreateWave(con.template, con.iDService, typeID);
        // 生成地图
        Rectangle src = new Rectangle(0, 0, wave.map.Width, wave.map.Height);
        Rectangle dest = new Rectangle(-360, 540, 720, 1080);
        Raylib.DrawTexturePro(wave.map, src, dest, new(-360, 540), 0, Color.WHITE);
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
            if (time > entity.beginTime && time < entity.endTime) {
                entity.timer -= dt;
                if (time <= entity.interval) {
                    entity.timer = entity.interval;
                    SpwanEntity();
                }
            }

        }

    }
    public static void SpwanEntity(Context con, WaveSpawnTM tm){
        if(tm.entityType==EntityType.plane){
            if()
            Factory.CreatePlane(con.template,con.iDService,tm.entityTypeID,)
        }
    }

}