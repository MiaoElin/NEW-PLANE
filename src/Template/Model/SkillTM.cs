public class SkillTM {

    public int typeID;

    public float cd;                    // 冷却时间

    public bool hasShootBullet;         // 是否有子弹
    public ShooterType shooterType;     // 射击类型
    public int shootBulletTypeID;       // 子弹TypeID
    public float shootMaintainSec;      // 持续时间
    public float shootInterval;         // 射击间隔

    public SkillTM(int typeID, float cd, bool hasShootBullet, ShooterType shooterType, int shootBulletTypeID, float shootMaintainSec, float shootInterval) {
        this.typeID = typeID;
        this.cd = cd;
        this.hasShootBullet = hasShootBullet;
        this.shooterType = shooterType;
        this.shootBulletTypeID = shootBulletTypeID;
        this.shootMaintainSec = shootMaintainSec;
        this.shootInterval = shootInterval;
    }

}