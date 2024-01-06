using System.Numerics;
using Raylib_cs;
public struct PlaneTM{
    public int typeID;
    public int hp;
    public float moveSpeed;
    public ShooterType shooterType;
    public int bulTypeID;
    public MoveType moveType;
    
    // draw
    public Texture2D texture2D;
    public Vector2 size;
    public  SharpType sharpType;
    public SpawnPos spawnPos;
    public SkillTM[]skillTMs;

}