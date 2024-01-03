using System.Numerics;
using Raylib_cs;
public class FoodEntity{
    public Vector2 pos;
    public int entityID;
    public int typeID;
    // draw
    public Texture2D texture2D;
    public Vector2 size;
    public SharpType sharpType;
    public MoveType moveType;
    public FoodType foodType;

}