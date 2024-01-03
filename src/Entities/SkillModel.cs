public class SkillModel {

    public int typeID;

    public float cd;                // 5s
    public float cdMax;

    public bool hasShootBullet;
    public ShooterType shooterType;
    public int shootBulletTypeID;
    public float shootMaintainSec;  // 总持续多久       1s
    public float shootMaintainTimer;
    public float shootInterval;     // 每间隔多久发一颗 0.2s
    public float shootIntervalTimer;

}