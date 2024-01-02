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
        planeTMs.Add(1, CreatePlaneTM(1, 100, 300, BulType.threebul, assets.boss1, new Vector2(60, 60), SharpType.circle, MoveType.RightLeft, Ally.enemy));
        planeTMs.Add(2, CreatePlaneTM(2, 20, 60, BulType.twobul, assets.enemy1, new Vector2(30, 30), SharpType.circle, MoveType.ByTrack, Ally.enemy));
        planeTMs.Add(3, CreatePlaneTM(3, 20, 0, BulType.onebul, assets.enemy2, new Vector2(20, 20), SharpType.circle, MoveType.DontMove, Ally.enemy));
        planeTMs.Add(TypeIDConst.PLAYER_PLANE_TYPEID, CreatePlaneTM(1, 100, 300, BulType.onebul, assets.player1, new Vector2(30, 30), SharpType.circle, MoveType.ByInput, Ally.player));

        // 食物
        foodTMs.Add(1, CreateFoodTM(1, assets.food1, new Vector2(30, 30), SharpType.rectangle, MoveType.DontMove));
        foodTMs.Add(2, CreateFoodTM(2, assets.food2, new Vector2(30, 30), SharpType.rectangle, MoveType.DontMove));
        // 子弹
        bulTMs.Add(1, CreateBulTM(1, assets.bullet1, new Vector2(5, 5), SharpType.circle, BulType.onebul, MoveType.StaticDirection, Ally.player));
        bulTMs.Add(2, CreateBulTM(2, assets.bullet2, new Vector2(5, 5), SharpType.circle, BulType.twobul, MoveType.StaticDirection, Ally.enemy));
        bulTMs.Add(3, CreateBulTM(3, assets.bullet3, new Vector2(5, 5), SharpType.circle, BulType.onebul, MoveType.ByLine, Ally.enemy));
        bulTMs.Add(4,CreateBulTM(4,assets.bullet4,new Vector2 (7,7),SharpType.circle,BulType.threebul,MoveType.StaticDirection,Ally.enemy));

        // Wave 波次
        WaveInit(assets);

    }
    void WaveInit(AssetsContext assets) {
        // 第一波
        WaveTM w1 = new WaveTM();
        w1.typeID = 1;
        w1.map = assets.map1;
        w1.level = 1;
        w1.spawnMaintainSec = float.MaxValue;
        WaveSpawnTM[] w1_all = new WaveSpawnTM[6];
        // 第一波的第一种 敌人飞机
        WaveSpawnTM w1_s1 = new WaveSpawnTM();
        w1_s1.entityType = EntityType.plane;
        w1_s1.entityTypeID = 2;
        w1_s1.beginTime = 1;
        w1_s1.endTime = 60;
        w1_s1.interval = 6f;
        w1_s1.timer=0;
        w1_all[0] = w1_s1;
        // 第二种   敌人飞机
        WaveSpawnTM w1_s2 = new WaveSpawnTM();
        w1_s2.entityType = EntityType.plane;
        w1_s2.entityTypeID = 3;
        w1_s2.beginTime = 2;
        w1_s2.endTime = 60;
        w1_s2.interval = 5f;
        w1_s2.timer=0;
        w1_all[1] = w1_s2;
        // 第一种敌人的子弹  
        WaveSpawnTM w1_s3 = new WaveSpawnTM();
        w1_s3.entityType = EntityType.bullet;
        w1_s3.entityTypeID = 2;
        w1_s3.beginTime = 0;
        w1_s3.endTime = float.MaxValue;
        w1_s3.interval = 2;
        w1_s3.timer=0;
        w1_all[2] = w1_s3;
        // 第二种敌人的子弹
        WaveSpawnTM w1_s4 = new WaveSpawnTM();
        w1_s4.entityType = EntityType.bullet;
        w1_s4.entityTypeID = 3;
        w1_s4.beginTime = 0;
        w1_s4.endTime = float.MaxValue;
        w1_s4.interval = 3;
        w1_s4.timer=0;
        w1_all[3] = w1_s4;
        // 第一种食物
        WaveSpawnTM w1_s5 = new WaveSpawnTM();
        w1_s5.entityType = EntityType.food;
        w1_s5.entityTypeID = 1;
        w1_s5.beginTime = 10f;
        w1_s5.endTime = float.MaxValue;
        w1_s5.interval = 8f;
        w1_s5.timer=0;
        w1_all[4] = w1_s5;
        // 第二种食物
        WaveSpawnTM w1_s6 = new WaveSpawnTM();
        w1_s6.entityType = EntityType.food;
        w1_s6.entityTypeID = 2;
        w1_s6.beginTime = 15;
        w1_s6.endTime = float.MaxValue;
        w1_s6.interval = 12f;
        w1_s6.timer=0;
        w1_all[5] = w1_s6;
        // boss
        WaveSpawnTM w1_boss = new WaveSpawnTM();
        w1_boss.entityType = EntityType.plane;
        w1_boss.entityTypeID = 1;
        w1_boss.beginTime = 60f;
        w1_boss.endTime = float.MaxValue;
        w1_boss.interval = float.MaxValue;
        w1_boss.timer=0;
        w1_all[6] = w1_boss;
        // boss
        WaveSpawnTM w1_s7 = new WaveSpawnTM();
        w1_s7.entityType=EntityType.bullet;
        w1_s7.entityTypeID=4;
        w1_s7.beginTime=60f;
        w1_s7.endTime=float.MaxValue;
        w1_s7.interval=float.MaxValue;
        w1_s7.timer=0;
        w1_all[7]=w1_s7;
    }
    PlaneTM CreatePlaneTM(int typeID, int hp, float moveSpeed, BulType bulType, Texture2D texture2D, Vector2 size, SharpType sharpType, MoveType moveType, Ally ally) {
        PlaneTM tm = new PlaneTM();
        tm.typeID = typeID;
        tm.hp = hp;
        tm.moveSpeed = moveSpeed;
        tm.texture2D = texture2D;
        tm.size = size;
        tm.sharpType = sharpType;
        tm.bulType = bulType;
        tm.moveType = moveType;
        tm.ally = ally;
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
    BulTM CreateBulTM(int typeID, Texture2D texture2D, Vector2 size, SharpType sharpType, BulType bulType, MoveType moveType, Ally ally) {
        BulTM tm = new BulTM();
        tm.texture2D = texture2D;
        tm.typeID = typeID;
        tm.size = size;
        tm.sharpType = sharpType;
        tm.moveType = moveType;
        tm.ally = ally;
        tm.bulType = bulType;
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