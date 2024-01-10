using System.Numerics;
using Raylib_cs;
public class PlaneEntity {
    public Texture2D texture2D;
    public Vector2 size;
    public SharpType sharpType;
    public MoveType moveType;
    public Ally ally;
    public ShooterType shooterType;
    public int bulTypeID;
    public Vector2 pos;
    public Vector2 dir;
    public int entityID;
    public int typeID;

    public int hp;
    public int hpMax;
    public float moveSpeed;
    // public float bulTimer;
    public PlaneSkillComponent planeSkillComponent;
    public bool isDead;

    public PlaneEntity() {
        planeSkillComponent = new PlaneSkillComponent();
    }
    public void Move(Vector2 dir, float dt) {
        pos += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
    }
    public void LookAt(Vector2 target) {
        if (target != dir) {
            dir = target - pos;
        }
    }
    public void Draw() {
        Rectangle src = new Rectangle(0, 0, texture2D.Width, texture2D.Height);
        Rectangle dest = new Rectangle(pos.X, pos.Y, size.X * 2, size.X * 2);
        Vector2 center = new Vector2(size.X, size.X);
        //   我的朝向的角度                           目标的朝向，我的朝向
        float rotation =Raymath.Vector2LineAngle(new Vector2 (0,-1),dir); 
        rotation =rotation/(float)Math.PI*180;
        Raylib.DrawTexturePro(texture2D, src, dest, center, rotation, Color.WHITE);

    }
}