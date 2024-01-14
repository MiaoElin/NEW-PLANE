using System.Numerics;
using Raylib_cs;
public class SkillTM {
    public bool hasbul;
    public int typeID;
    public int cdMax;
    // public bool hasbul;
    public ShooterType shooterType;
    public int bulTypeID;
    public float shootMaintainSec;
    public float bulSpawnInterval;
    public int nextLevelSkillTypeID;
    public SkillTM(int typeID,int nextLevelSkillTypeID,bool hasbul, int cdMax, float shootMaintainSec, float bulSpawnInterval,ShooterType shooterType,int bulTypeID) {
        this.typeID = typeID;
        this.nextLevelSkillTypeID=nextLevelSkillTypeID;
        this.hasbul=hasbul;
        this.cdMax = cdMax;
        this.shooterType = shooterType;
        this.bulTypeID = bulTypeID;
        this.shootMaintainSec = shootMaintainSec;
        this.bulSpawnInterval = bulSpawnInterval;
    }
}