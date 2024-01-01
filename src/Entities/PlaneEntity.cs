using System.Numerics;
using Raylib_cs;
public class PlaneEntity {
    public Texture2D texture2D;
    public Vector2 size;
    public SharpType sharpType;
    public MoveType moveType;
    public Ally ally;
    public BulType bulType;
    public Vector2 pos;
    public int entityID;
    public int typeID;

    public int hp;
    public int hpMax;
    public float moveSpeed;
    public void Move(Vector2 dir, float dt) {
        pos += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
    }
    public void Draw() {
        Rectangle src = new Rectangle(0, 0, texture2D.Width, texture2D.Height);
        Rectangle dest = new Rectangle(pos.X, pos.Y, size.X * 2, size.X * 2);
        Vector2 center = new Vector2(size.X, size.X);
        if (ally == Ally.enemy) {
            float rotation = 180;
            Raylib.DrawTexturePro(texture2D, src, dest, center, rotation, Color.WHITE);
        }
        if (ally == Ally.player) {
            float rotation = 0;
            Raylib.DrawTexturePro(texture2D, src, dest, center, rotation, Color.WHITE);
        }

        // Raylib.DrawCircleV(pos,size.X,Color.RED);

    }
}