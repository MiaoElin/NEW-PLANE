using System.Numerics;
using Raylib_cs;
public class SkillModel {
    public int typeID;
    public float cd;
    public float cdMax;
    public ShooterType shooterType;
    public int bulTypeID;
    public bool hasBul;
    public float shootMaintainSec;
    public float shootMaintainTimer;
    public float bulSpawnInterval;
    public float bulSpawntimer;
    public int nextLevelSkillTypeID;
}