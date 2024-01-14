using System.Numerics;
using Raylib_cs;
public static class Factory {
    public static SkillModel CreateSkillModel(Template template, int typeID, int level) {
        bool has = template.TryGetSkillTM(typeID, out SkillTM tm);
        if (!has) {
            PLog.LogError($"Factory.CreateSkillModel: typeID{typeID} not found");
            return null;
        }
        SkillModel skill = new SkillModel();
        skill.typeID = typeID;
        skill.skillLevel = level;
        skill.hasBul = tm.hasbul;
        SkillLevelTM[]levelTMs=tm.skillLevelTMs;
        if(level>levelTMs.Length){
            skill.skillLevel=level-1;  // 当前等级超过可升级数的时候，skill减去一级
        }
        // System.Console.WriteLine("当前的等级是"+skill.skillLevel);
        SkillLevelTM levelTM = tm.skillLevelTMs[skill.skillLevel-1];// 数组下标要减一
        skill.cd = levelTM.cdMax;
        skill.cdMax = levelTM.cdMax;
        skill.bulTypeID = levelTM.bulTypeID;
        skill.shooterType = levelTM.shooterType;
        skill.bulSpawnInterval = levelTM.bulSpawnInterval;
        skill.bulSpawntimer = levelTM.bulSpawnInterval;
        skill.shootMaintainSec = levelTM.shootMaintainSec;
        skill.shootMaintainTimer = levelTM.shootMaintainSec;
        return skill;

    }
    public static PlaneEntity CreatePlane(Template template, IDService iDService, int typeID, Vector2 pos, Ally ally) {
        bool has = template.TryGetPlaneTM(typeID, out PlaneTM tm);
        if (!has) {
            PLog.LogError($"Factory.Createplane: typeID{typeID} not found");
            return null;
        }
        PlaneEntity plane = new PlaneEntity();
        plane.ally = ally;
        if (ally == Ally.enemy) {
            plane.dir = new Vector2(0, 1);
        }
        if (ally == Ally.player) {
            plane.dir = new Vector2(0, -1);
        }
        plane.typeID = typeID;
        plane.pos = pos;
        plane.entityID = iDService.planeIDRecord++;
        plane.hp = tm.hp;
        plane.moveSpeed = tm.moveSpeed;
        plane.texture2D = tm.texture2D;
        plane.size = tm.size;
        plane.sharpType = tm.sharpType;
        plane.moveType = tm.moveType;
        plane.moveInterval = tm.moveInterval;
        plane.moveTimer = tm.moveInterval;
        // plane.shooterType = tm.shooterType;
        // plane.bulTypeID = tm.bulTypeID;
        plane.isDead = false;
        SkillTM[] skillTMs = tm.skillTMs;
        if (skillTMs != null) {
            for (int i = 0; i < skillTMs.Length; i++) {
                var skillTM = skillTMs[i];
                SkillModel skill = new SkillModel();
                skill.typeID = skillTM.typeID;
                skill.hasBul = skillTM.hasbul;
                skill.skillLevel = skillTM.skillLevel;
                SkillLevelTM level = skillTM.skillLevelTMs[skill.skillLevel-1];//当前的等级的模版
                skill.cdMax = level.cdMax;
                skill.cd = level.cdMax;
                skill.bulTypeID = level.bulTypeID;
                skill.shooterType = level.shooterType;
                skill.shootMaintainSec = level.shootMaintainSec;
                skill.shootMaintainTimer = level.shootMaintainSec;
                skill.bulSpawnInterval = level.bulSpawnInterval;
                skill.bulSpawntimer = level.bulSpawnInterval;
                plane.planeSkillComponent.Add(skill);
                plane.planeSkillComponent.firstSkill = skill;
            }
        }
        return plane;
    }
    public static FoodEntity CreateFood(Template template, IDService iDService, int typeID, Vector2 pos) {
        bool has = template.TryGetFoodTM(typeID, out FoodTM tm);
        if (!has) {
            PLog.LogError($"Factory.CreateFood: typeID{typeID} not found");
            return null;
        }
        FoodEntity food = new FoodEntity();
        food.entityID = iDService.foodIDRecord++;
        food.pos = pos;
        food.typeID = typeID;
        food.texture2D = tm.texture2D;
        food.size = tm.size;
        food.sharpType = tm.sharpType;
        food.ally = tm.ally;
        food.foodType = tm.foodType;
        food.skillTypeID = tm.skillTypeID;
        food.isDead = false;
        return food;
    }
    public static BulletEntity CreateBul(Template template, IDService iDService, int typeID, Vector2 pos, Vector2 firstDir, Ally ally) {
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
        bullet.firstDir = firstDir;
        bullet.size = tm.size;
        bullet.texture2D = tm.texture2D;
        bullet.sharpType = tm.sharpType;
        bullet.moveSpeed = tm.moveSpeed;
        bullet.moveType = tm.moveType;
        bullet.sharpType = tm.sharpType;
        bullet.lethality = tm.lethality;
        bullet.shooterType = tm.shooterType;
        bullet.isDead = false;
        return bullet;
    }
    public static WaveEntity CreateWave(Template template, IDService iDService, int typeID) {
        bool has = template.tryGetWaveTM(typeID, out WaveTM tm);
        if (!has) {
            PLog.LogError($"Factory.CreateWava: typeID{typeID} not found");
        }
        WaveEntity wave = new WaveEntity();
        wave.entityID = iDService.waveIDRecord++;
        wave.time = 0;
        wave.isDead = false;
        wave.level = tm.level;
        wave.map = tm.map;
        wave.spawnMaintainSec = tm.spawnMaintainSec;
        wave.waveSpawnTMs = tm.waveSpawnTMs;
        wave.typeID = tm.typeID;
        return wave;
    }
}