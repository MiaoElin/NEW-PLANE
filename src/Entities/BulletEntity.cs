using System.Numerics;
using Raylib_cs;
public class BulletEntity {
    public Vector2 pos;
    public Vector2 size;
    public float moveSpeed;
    public SharpType sharpType;
    public Texture2D texture2D;
    public int typeID;
    public Ally ally;
    public int entityID;
    public MoveType moveType;
    public BulPerCount bulType;
    public Vector2 firstDir;
    public float spawnInterval;
    public float timer;
    public void Move(Vector2 dir, float dt) {
        pos += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
        
    }
    public void Draw() {
        Rectangle src = new Rectangle(0, 0, texture2D.Width, texture2D.Height);
        Rectangle dest = new Rectangle(pos.X, pos.Y, size.X, size.Y);
        Vector2 center = new Vector2(size.X, size.Y) / 2;
        if (ally == Ally.enemy) {
            float rotation = 180;
            Raylib.DrawTexturePro(texture2D, src, dest, center, rotation, Color.WHITE);
        }
        if (ally == Ally.player) {
            float rotation = 0;
            Raylib.DrawTexturePro(texture2D, src, dest, center, rotation, Color.WHITE);
        }
    }
}