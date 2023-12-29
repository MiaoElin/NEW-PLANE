using System.Numerics;
using Raylib_cs;
public struct PlaneTM{
    public int typeID;
    public int hp;
    public float moveSpeed;
    public BulType bulType;
    
    // draw
    public Texture2D texture2D;
    public Vector2 size;
    public  SharpType sharpType;

}