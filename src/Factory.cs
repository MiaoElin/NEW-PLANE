using System.Numerics;
using Raylib_cs;
public static class Factory {
    public static PlaneEntity CreatePlane(Template template, IDService iDService, int typeID, Vector2 pos, Ally ally) {
        bool has = template.TryGetPlaneTM(typeID, out PlaneTM tm);
        if (!has) {
            PLog.LogError("Factory.Createplane: typeID{typeID} not found");
            return null;
        }
        PlaneEntity plane = new PlaneEntity();
        plane.ally = ally;
        plane.typeID = typeID;
        plane.pos = pos;
        plane.entityID = iDService.planeIDRecord++;
        plane.bulType = tm.bulType;
        plane.hp = tm.hp;
        plane.moveSpeed = tm.moveSpeed;
        plane.texture2D = tm.texture2D;
        plane.size = tm.size;
        plane.sharpType = tm.sharpType;
        return plane;
    }
    public static FoodEntity CreateFood(Template template, IDService iDService, int typeID, Vector2 pos) {
        bool has = template.TryGetFoodTM(typeID, out FoodTM tm);
        if (!has) {
            PLog.LogError("Factory.CreateFood: typeID{typeID} not found");
            return null;
        }
        FoodEntity food = new FoodEntity();
        food.entityID = iDService.foodIDRecord++;
        food.pos = pos;
        food.typeID = typeID;
        food.texture2D = tm.texture2D;
        food.size = tm.size;
        food.sharpType = tm.sharpType;
        return food;
    }
    public static BulletEntity CreateBul(Template template, IDService iDService, int typeID, Vector2 pos, Ally ally) {
        bool has = template.TryGetBulTM(typeID, out BulTM tm);
        if (!has) {
            PLog.LogError($"Factory.CreateBul: typeID{typeID} not found");
            return null;
        }
        BulletEntity bullet = new BulletEntity();
        bullet.ally = ally;
        bullet.pos = pos;
        bullet.typeID = typeID;
        bullet.entityID = iDService.bulIDRecord++;
        bullet.size = tm.size;
        bullet.texture2D = tm.texture2D;
        bullet.sharpType = tm.sharpType;
        return bullet;
    }
    public static WaveEntity CreateWave(Template template, IDService iDService, int typeID) {
        bool has = template.tryGetWaveTM(1, out WaveTM tm);
        if (!has) {
            PLog.LogError($"Factory.CreateWava: typeID{typeID} not found");
        }
        WaveEntity wave = new WaveEntity();
        wave.entityID = iDService.waveIDRecord++;
        wave.time = 0;
        wave.level = tm.level;
        wave.map = tm.map;
        wave.spawnMaintainSec = tm.spawnMaintainSec;
        wave.waveSpawnTMs = tm.waveSpawnTMs;
        return wave;
    }
}