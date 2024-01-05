using System.Numerics;
using Raylib_cs;
public class SkillTM{
    public int typeID;
    public int cdMax;
    public bool hasbul;
    // public ShooterType shooterType;
    // public int bulTypeID;
    public float shootMaintainSec;
    public float bulSpawnInterval;
    public SkillTM(int typeID,int cdMax,bool hasbul,float shootMaintainSec,float bulSpawnInterval){
        this.typeID=typeID;
        this.cdMax=cdMax;
        this.hasbul=hasbul;
        // this .shooterType=shooterType;
        // this.bulTypeID=bulTypeID;
        this.shootMaintainSec=shootMaintainSec;
        this.bulSpawnInterval=bulSpawnInterval;
    }
}