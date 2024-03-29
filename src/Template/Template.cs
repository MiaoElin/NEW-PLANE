using System.Numerics;
using Raylib_cs;
public class Template {
    Dictionary<int, PlaneTM> planeTMs;
    Dictionary<int, FoodTM> foodTMs;
    Dictionary<int, BulTM> bulTMs;
    Dictionary<int, WaveTM> waveTMs;
    Dictionary<int, SkillTM> skillTMs;


    public Template() {
        planeTMs = new Dictionary<int, PlaneTM>();
        foodTMs = new Dictionary<int, FoodTM>();
        bulTMs = new Dictionary<int, BulTM>();
        waveTMs = new Dictionary<int, WaveTM>();
        skillTMs = new Dictionary<int, SkillTM>();

    }
    public void Init(AssetsContext assets) {
        SkillLevelTM[] skillLevelTMs1 = new SkillLevelTM[1];
        SkillLevelTM s1_1 = CreateSKillLevelTM(1, 0.6f, 0.3f, ShooterType.threebul, 1);
        skillLevelTMs1[0] = s1_1;
        SkillTM s1 = new SkillTM();
        s1.typeID = 1;
        s1.skillLevel = 1;
        s1.hasbul = true;
        s1.skillLevelTMs = skillLevelTMs1;
        skillTMs.Add(1, s1);

        SkillLevelTM[] skillLevelTMs2 = new SkillLevelTM[1];
        SkillLevelTM s2_1 = CreateSKillLevelTM(1, 0.3f, 0.3f, ShooterType.twobul, 2);
        skillLevelTMs2[0] = s2_1;
        SkillTM s2 = new SkillTM();
        s2.typeID = 2;
        s2.skillLevel = 1;
        s2.hasbul = true;
        s2.skillLevelTMs = skillLevelTMs2;
        skillTMs.Add(2, s2);

        SkillLevelTM[] skillLevelTMs3 = new SkillLevelTM[1];
        SkillLevelTM s3_1 = CreateSKillLevelTM(1, 0.4f, 0.4f, ShooterType.onebul, 3);
        skillLevelTMs3[0] = s3_1;
        SkillTM s3 = new SkillTM();
        s3.typeID = 3;
        s3.skillLevel = 1;
        s3.hasbul = true;
        s3.skillLevelTMs = skillLevelTMs3;
        skillTMs.Add(3, s3);

        SkillLevelTM[] skillLevelTMs4 = new SkillLevelTM[1];
        SkillLevelTM s4_1 = CreateSKillLevelTM(0, 0.2f, 0.2f, ShooterType.onebul, 4);
        skillLevelTMs4[0] = s4_1;
        System.Console.WriteLine(skillLevelTMs1[0].cdMax);
        SkillTM s4 = new SkillTM();
        s4.typeID = 4;
        s4.skillLevel = 1;
        s4.hasbul = true;
        s4.skillLevelTMs = skillLevelTMs4;
        skillTMs.Add(4, s4);

        SkillLevelTM[] skillLevelTMs5 = new SkillLevelTM[2];
        SkillLevelTM s5_1 = CreateSKillLevelTM(0, 0.2f, 0.2f, ShooterType.twobul, 5);
        SkillLevelTM s5_2 = CreateSKillLevelTM(0, 0.2f, 0.2f, ShooterType.threebul, 5);
        skillLevelTMs5[0] = s5_1;
        skillLevelTMs5[1] = s5_2;
        SkillTM s5 = new SkillTM();
        s5.typeID = 5;
        s5.skillLevel = 1;
        s5.hasbul = true;
        s5.skillLevelTMs = skillLevelTMs5;
        skillTMs.Add(5, s5);

        SkillLevelTM[] skillLevelTMs6 = new SkillLevelTM[2];
        SkillLevelTM s6_1 = CreateSKillLevelTM(0, 0.2f, 0.2f, ShooterType.twobul, 6);
        SkillLevelTM s6_2 = CreateSKillLevelTM(0, 0.2f, 0.2f, ShooterType.threebul, 6);
        skillLevelTMs6[0] = s6_1;
        skillLevelTMs6[1] = s6_2;
        SkillTM s6 = new SkillTM();
        s6.typeID = 5;
        s6.skillLevel = 1;
        s6.hasbul = true;
        s6.skillLevelTMs = skillLevelTMs6;
        skillTMs.Add(6, s6);

        // 飞机
        SkillTM[] ps1 = new SkillTM[] { s1, s3 };
        planeTMs.Add(1, CreatePlaneTM(typeID: 1, hp: 20, moveSpeed: 300, assets.boss1, size: new Vector2(100, 100), SharpType.circle, MoveType.RightLeft, 0.5f, SpawnPos.TopMiddle, skillTMs: ps1));
        SkillTM[] ps2 = new SkillTM[] { s2 };
        PlaneTM p2 = CreatePlaneTM(2, 20, 60, assets.enemy1, new Vector2(40, 40), SharpType.circle, MoveType.ByTrack, 0, SpawnPos.RandomPosOn_Top, ps2);
        planeTMs.Add(2, p2);
        SkillTM[] ps3 = new SkillTM[] { s3 };
        planeTMs.Add(3, CreatePlaneTM(3, 20, 0, assets.enemy2, new Vector2(40, 40), SharpType.circle, MoveType.DontMove, 0, SpawnPos.RandomPosOn_UpperHalf, ps3));
        SkillTM[] ps4 = new SkillTM[] { s4 };
        planeTMs.Add(4, CreatePlaneTM(4, 100, 300, assets.player1, new Vector2(30, 30), SharpType.circle, MoveType.ByInput, 0, SpawnPos.BottomMiddle, ps4));

        // 食物
        foodTMs.Add(1, CreateFoodTM(1, assets.food1, new Vector2(30, 30), SharpType.rectangle, MoveType.DontMove, FoodType.HpFood, -1));
        foodTMs.Add(2, CreateFoodTM(2, assets.food2, new Vector2(30, 30), SharpType.rectangle, MoveType.DontMove, FoodType.TwoBulFood, 5));
        foodTMs.Add(3, CreateFoodTM(2, assets.food3, new Vector2(30, 30), SharpType.rectangle, MoveType.DontMove, FoodType.ThreeBulFood, 6));
        // 子弹 4号是player的初始子弹
        bulTMs.Add(4, CreateBulTM(4, assets.bullet1, new Vector2(30, 30), 800, SharpType.circle, MoveType.StaticDirection, ShooterType.onebul, 10));
        bulTMs.Add(2, CreateBulTM(2, assets.bullet2, new Vector2(30, 30), 300, SharpType.circle, MoveType.StaticDirection, ShooterType.twobul, 5));
        bulTMs.Add(3, CreateBulTM(3, assets.bullet3, new Vector2(30, 30), 200, SharpType.circle, MoveType.ByLine, ShooterType.onebul, 10));
        bulTMs.Add(1, CreateBulTM(1, assets.bullet4, new Vector2(40, 40), 600, SharpType.circle, MoveType.StaticDirection, ShooterType.threebul, 10));
        bulTMs.Add(5, CreateBulTM(5, assets.bullet1, new Vector2(30, 30), 800, SharpType.circle, MoveType.StaticDirection, ShooterType.twobul, 5));
        bulTMs.Add(6, CreateBulTM(6, assets.bullet5, new Vector2(30, 30), 800, SharpType.circle, MoveType.StaticDirection, ShooterType.twobul, 5));


        // Wave 波次
        WaveInit(assets);

    }
    void WaveInit(AssetsContext assets) {
        WaveInit_W1(assets);
    }
    void WaveInit_W1(AssetsContext assets) {
        // 第一波
        WaveTM w1 = new WaveTM();
        w1.typeID = 1;
        w1.map = assets.map1;
        w1.level = 1;
        w1.spawnMaintainSec = 31;
        w1.waveSpawnTMs = new WaveSpawnTM[6];
        ref WaveSpawnTM[] w1_all = ref w1.waveSpawnTMs;
        // 第一波的第一种 敌人飞机
        WaveSpawnTM w1_s1 = new WaveSpawnTM();
        w1_s1.entityType = EntityType.Plane;
        w1_s1.entityTypeID = 2;
        w1_s1.beginTime = 1;
        w1_s1.endTime = 30;
        w1_s1.interval = 6f;
        w1_s1.timer = 0;
        w1_s1.spawnPos = SpawnPos.RandomPosOn_Top;
        w1_s1.ally = Ally.enemy;
        w1_all[0] = w1_s1;
        // 第二种   敌人飞机
        WaveSpawnTM w1_s2 = new WaveSpawnTM();
        w1_s2.entityType = EntityType.Plane;
        w1_s2.entityTypeID = 3;
        w1_s2.beginTime = 2;
        w1_s2.endTime = 30;
        w1_s2.interval = 5f;
        w1_s2.timer = 0;
        w1_s2.spawnPos = SpawnPos.RandomPosOn_UpperHalf;
        w1_s2.ally = Ally.enemy;
        w1_all[1] = w1_s2;
        // 第一种食物
        WaveSpawnTM w1_s3 = new WaveSpawnTM();
        w1_s3.entityType = EntityType.Food;
        w1_s3.entityTypeID = 1;
        w1_s3.beginTime = 10f;
        w1_s3.endTime = 30;
        w1_s3.interval = 12f;
        w1_s3.timer = 0;
        w1_s3.spawnPos = SpawnPos.RandomPosOn_LowerHalf;
        w1_s3.ally = Ally.player;
        w1_all[2] = w1_s3;
        // 第二种食物
        WaveSpawnTM w1_s4 = new WaveSpawnTM();
        w1_s4.entityType = EntityType.Food;
        w1_s4.entityTypeID = 2;
        w1_s4.beginTime = 5;
        w1_s4.endTime = 30;
        w1_s4.interval = 5f;
        w1_s4.timer = 0;
        w1_s4.spawnPos = SpawnPos.RandomPosOn_LowerHalf;
        w1_s4.ally = Ally.player;
        w1_all[3] = w1_s4;
        // boss
        WaveSpawnTM w1_boss = new WaveSpawnTM();
        w1_boss.entityType = EntityType.Plane;
        w1_boss.entityTypeID = 1;
        w1_boss.beginTime = 30;
        w1_boss.endTime = 31;
        w1_boss.interval = float.MaxValue;
        w1_boss.timer = 0;
        w1_boss.spawnPos = SpawnPos.TopMiddle;
        w1_boss.ally = Ally.enemy;
        w1_all[4] = w1_boss;
        // 第三种食物
        WaveSpawnTM w1_s5 = new WaveSpawnTM();
        w1_s5.entityType = EntityType.Food;
        w1_s5.entityTypeID = 3;
        w1_s5.beginTime = 25;
        w1_s5.endTime = 30;
        w1_s5.interval = 15f;
        w1_s5.timer = 0;
        w1_s5.spawnPos = SpawnPos.RandomPosOn_LowerHalf;
        w1_s5.ally = Ally.player;
        w1_all[5] = w1_s5;
        waveTMs.Add(1, w1);

        // 第二波
        WaveTM w2 = new WaveTM();
        w2.typeID = 2;
        w2.map = assets.map2;
        w2.level = 2;
        w2.spawnMaintainSec = 31;
        w2.waveSpawnTMs = new WaveSpawnTM[6];
        ref WaveSpawnTM[] w2_all = ref w2.waveSpawnTMs;
        // 第二波的第一种 敌人飞机
        WaveSpawnTM w2_s1 = new WaveSpawnTM();
        w2_s1.entityType = EntityType.Plane;
        w2_s1.entityTypeID = 2;
        w2_s1.beginTime = 1;
        w2_s1.endTime = 30;
        w2_s1.interval = 6f;
        w2_s1.timer = 0;
        w2_s1.spawnPos = SpawnPos.RandomPosOn_Top;
        w2_s1.ally = Ally.enemy;
        w2_all[0] = w2_s1;
        // 第二种   敌人飞机
        WaveSpawnTM w2_s2 = new WaveSpawnTM();
        w2_s2.entityType = EntityType.Plane;
        w2_s2.entityTypeID = 3;
        w2_s2.beginTime = 2;
        w2_s2.endTime = 30;
        w2_s2.interval = 5f;
        w2_s2.timer = 0;
        w2_s2.spawnPos = SpawnPos.RandomPosOn_UpperHalf;
        w2_s2.ally = Ally.enemy;
        w2_all[1] = w2_s2;
        // 第一种食物
        WaveSpawnTM w2_s3 = new WaveSpawnTM();
        w2_s3.entityType = EntityType.Food;
        w2_s3.entityTypeID = 1;
        w2_s3.beginTime = 10f;
        w2_s3.endTime = 30;
        w2_s3.interval = 12f;
        w2_s3.timer = 0;
        w2_s3.spawnPos = SpawnPos.RandomPosOn_LowerHalf;
        w2_s3.ally = Ally.player;
        w2_all[2] = w2_s3;
        // 第二种食物
        WaveSpawnTM w2_s4 = new WaveSpawnTM();
        w2_s4.entityType = EntityType.Food;
        w2_s4.entityTypeID = 2;
        w2_s4.beginTime = 15;
        w2_s4.endTime = 30;
        w2_s4.interval = 16f;
        w2_s4.timer = 0;
        w2_s4.spawnPos = SpawnPos.RandomPosOn_LowerHalf;
        w2_s4.ally = Ally.player;
        w2_all[3] = w2_s4;
        // boss
        WaveSpawnTM w2_boss = new WaveSpawnTM();
        w2_boss.entityType = EntityType.Plane;
        w2_boss.entityTypeID = 1;
        w2_boss.beginTime = 30;
        w2_boss.endTime = 31;
        w2_boss.interval = float.MaxValue;
        w2_boss.timer = 0;
        w2_boss.spawnPos = SpawnPos.TopMiddle;
        w2_boss.ally = Ally.enemy;
        w2_all[4] = w2_boss;
        WaveSpawnTM w2_s5 = new WaveSpawnTM();
        w2_s5.entityType = EntityType.Food;
        w2_s5.entityTypeID = 3;
        w2_s5.beginTime = 25;
        w2_s5.endTime = 30;
        w2_s5.interval = 15f;
        w2_s5.timer = 0;
        w2_s5.spawnPos = SpawnPos.RandomPosOn_LowerHalf;
        w2_s5.ally = Ally.player;
        w2_all[5] = w2_s5;
        waveTMs.Add(2, w2);

    }
    PlaneTM CreatePlaneTM(int typeID, int hp, float moveSpeed, Texture2D texture2D, Vector2 size, SharpType sharpType, MoveType moveType, float moveInterval, SpawnPos spawnPos, SkillTM[] skillTMs) {
        PlaneTM tm = new PlaneTM();
        tm.typeID = typeID;
        tm.hp = hp;
        tm.moveSpeed = moveSpeed;
        tm.texture2D = texture2D;
        tm.size = size;
        tm.sharpType = sharpType;
        // tm.shooterType = shooterType;
        // tm.bulTypeID = bulTypeID;
        tm.moveType = moveType;
        tm.spawnPos = spawnPos;
        tm.skillTMs = skillTMs;
        tm.moveInterval = moveInterval;
        return tm;
    }
    FoodTM CreateFoodTM(int typeID, Texture2D texture2D, Vector2 size, SharpType sharpType, MoveType moveType, FoodType foodType, int skillTypeID) {
        FoodTM tm = new FoodTM();
        tm.texture2D = texture2D;
        tm.typeID = typeID;
        tm.size = size;
        tm.sharpType = sharpType;
        tm.moveType = moveType;
        tm.foodType = foodType;
        tm.skillTypeID = skillTypeID;
        return tm;
    }
    BulTM CreateBulTM(int typeID, Texture2D texture2D, Vector2 size, float moveSpeed, SharpType sharpType, MoveType moveType, ShooterType shooterType, int lethality) {
        BulTM tm = new BulTM();
        tm.texture2D = texture2D;
        tm.typeID = typeID;
        tm.size = size;
        tm.sharpType = sharpType;
        tm.moveType = moveType;
        tm.moveSpeed = moveSpeed;
        tm.lethality = lethality;
        tm.shooterType = shooterType;
        return tm;
    }
    SkillLevelTM CreateSKillLevelTM(int cdMax, float shootMaintainSec, float bulSpawnInterval, ShooterType shooterType, int bulTypeID) {
        SkillLevelTM tm = new SkillLevelTM();
        tm.cdMax = cdMax;
        tm.shooterType = shooterType;
        tm.bulTypeID = bulTypeID;
        tm.bulSpawnInterval = bulSpawnInterval;
        tm.shootMaintainSec = shootMaintainSec;
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
    public bool TryGetSkillTM(int typeID, out SkillTM tm) {
        return skillTMs.TryGetValue(typeID, out tm);
    }
}