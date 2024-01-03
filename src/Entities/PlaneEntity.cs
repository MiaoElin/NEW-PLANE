using System.Numerics;
using Raylib_cs;

public class PlaneEntity {

    public Texture2D texture2D;
    public Vector2 size;
    public Vector2 dir;
    public SharpType sharpType;
    public MoveType moveType;
    public Ally ally;
    public Vector2 pos;
    public int entityID;
    public int typeID;

    public int hp;
    public int hpMax;
    public float moveSpeed;

    // ==== Shooter ====
    public int bulTypeID; // REMOVE
    public ShooterType bulPerCount; // REMOVE
    public float bulTimer; // REMOVE
    public float bulInterval; // REMOVE
    public PlaneSkillSlotComponent skillSlotComponent;

    public PlaneEntity() {
        skillSlotComponent = new PlaneSkillSlotComponent();
    }

    public void Move(Vector2 dir, float dt) {
        pos += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
    }

    public void LookAt(Vector2 target) {
        Vector2 d = target - pos;
        if (d != Vector2.Zero) {
            dir = d;
        }
    }

    public void Draw() {

        Rectangle src = new Rectangle(0, 0, texture2D.Width, texture2D.Height);
        Rectangle dest = new Rectangle(pos.X, pos.Y, size.X * 2, size.X * 2);
        Vector2 center = new Vector2(size.X, size.X);

        // 顺时针
        float rotation = Raymath.Vector2LineAngle(new Vector2(0, -1), dir);
        rotation = rotation / (float)Math.PI * 180;
        Raylib.DrawTexturePro(texture2D, src, dest, center, rotation, Color.WHITE);

        // Raylib.DrawCircleV(pos,size.X,Color.RED);

    }
}