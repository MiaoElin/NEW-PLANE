using System.Numerics;
using Raylib_cs;
public class Template {
    Dictionary<int, PlaneTM> planeTMs;
    Dictionary<int, FoodTM> foodTMs;
    Dictionary<int, BulTM> bulTMs;
    Dictionary<int, WaveTM> waveTMs;


    public Template() {
        planeTMs = new Dictionary<int, PlaneTM>();
        foodTMs = new Dictionary<int, FoodTM>();
        bulTMs = new Dictionary<int, BulTM>();
        waveTMs = new Dictionary<int, WaveTM>();

    }
    public void Init(AssetsContext assets) {
        // 飞机
        planeTMs.Add(1, CreatePlaneTM(1, 100, 300, BulType.onebul, assets.player1, new Vector2(30, 30), SharpType.circle, MoveType.ByInput));
        planeTMs.Add(2, CreatePlaneTM(2, 20, 60, BulType.onebul, assets.enemy1, new Vector2(30, 30), SharpType.circle, MoveType.ByTrack));
        planeTMs.Add(3, CreatePlaneTM(3, 20, 0, BulType.twobul, assets.enemy2, new Vector2(20, 20), SharpType.circle, MoveType.DontMove));
        // 食物
        foodTMs.Add(1, CreateFoodTM(1, assets.food1, new Vector2(30, 30), SharpType.rectangle, MoveType.DontMove));
        foodTMs.Add(2, CreateFoodTM(2, assets.food2, new Vector2(30, 30), SharpType.rectangle, MoveType.DontMove));
        // 子弹
        bulTMs.Add(1, CreateBulTM(1, assets.bullet1, new Vector2(5, 5), SharpType.circle, MoveType.StaticDirection));
        bulTMs.Add(2, CreateBulTM(2, assets.bullet2, new Vector2(5, 5), SharpType.circle, MoveType.StaticDirection));
        bulTMs.Add(3, CreateBulTM(3, assets.bullet3, new Vector2(5, 5), SharpType.circle, MoveType.ByLine));

        // Wave 波次

    }
    void WaveInit(AssetsContext assets) {
        // 第一关
        WaveTM w1 = new WaveTM();
        w1.typeID = 1;
        w1.map = assets.map1;
        w1.level = 1;
        w1.spawnMaintainSec = 60f;
        WaveSpawnTM[] w1_all = new WaveSpawnTM[6];
        // 第一关的第一种
        WaveSpawnTM w1_s1=new WaveSpawnTM ();
        w1_s1.entityType=EntityType.plane;
        w1_s1.entityTypeID=2;
        w1_s1.count=1;
        w1_s1.beginTime=0;
        w1_s1.endTime=20;
        w1_s1.interval=5f;
        






    }
    PlaneTM CreatePlaneTM(int typeID, int hp, float moveSpeed, BulType bulType, Texture2D texture2D, Vector2 size, SharpType sharpType, MoveType moveType) {
        PlaneTM tm = new PlaneTM();
        tm.typeID = typeID;
        tm.hp = hp;
        tm.moveSpeed = moveSpeed;
        tm.texture2D = texture2D;
        tm.size = size;
        tm.sharpType = sharpType;
        tm.bulType = bulType;
        tm.moveType = moveType;
        return tm;
    }
    FoodTM CreateFoodTM(int typeID, Texture2D texture2D, Vector2 size, SharpType sharpType, MoveType moveType) {
        FoodTM tm = new FoodTM();
        tm.texture2D = texture2D;
        tm.typeID = typeID;
        tm.size = size;
        tm.sharpType = sharpType;
        tm.moveType = moveType;
        return tm;
    }
    BulTM CreateBulTM(int typeID, Texture2D texture2D, Vector2 size, SharpType sharpType, MoveType moveType) {
        BulTM tm = new BulTM();
        tm.texture2D = texture2D;
        tm.typeID = typeID;
        tm.size = size;
        tm.sharpType = sharpType;
        tm.moveType = moveType;
        return tm;
    }
    WaveTM CreateWaveTM(int typeID, int level, Texture2D map, WaveSpawnTM[] waveSpawnTMs) {
        WaveTM tm = new WaveTM();
        tm.typeID = typeID;
        tm.level = level;
        tm.waveSpawnTMs = waveSpawnTMs;
        return tm;

    }
    public bool TryGetPlaneTM(int typeID, out PlaneTM tm) {
        bool has = planeTMs.TryGetValue(typeID, out tm);
        return has;
    }
    public bool TryGetFoodTM(int typeID, out FoodTM tm) {
        bool has = foodTMs.TryGetValue(typeID, out tm);
        return has;
    }
    public bool TryGetBulTM(int typeID, out BulTM tm) {
        bool has = bulTMs.TryGetValue(typeID, out tm);
        return has;
    }
    public bool tryGetWaveTM(int typeID, out WaveTM tm) {
        bool has = waveTMs.TryGetValue(typeID, out tm);
        return has;
    }
}