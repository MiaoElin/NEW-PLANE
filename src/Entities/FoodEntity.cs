using System.Numerics;
using Raylib_cs;
public class FoodEntity {
    public Vector2 pos;
    public int entityID;
    public int typeID;
    public Ally ally;
    public int skillTypeID;
    // draw
    public Texture2D texture2D;
    public Vector2 size;
    public SharpType sharpType;
    public MoveType moveType;
    public FoodType foodType;
    public bool isDead;

    public void Draw() {
        Rectangle src = new Rectangle(0, 0, texture2D.Width, texture2D.Height);
        Rectangle dest = new Rectangle(pos.X, pos.Y, size.X, size.Y);
        Vector2 center = new Vector2(size.X, size.Y) / 2;
        Raylib.DrawTexturePro(texture2D, src, dest, center, 0, Color.WHITE);
    }
}