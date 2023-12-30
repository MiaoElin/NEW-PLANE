using System.Numerics;
using Raylib_cs;
public class Template
{
    Dictionary<int, PlaneTM> planeTMs;
    Dictionary<int, FoodTM> foodTMs;
    Dictionary<int, BulTM> bulTMs;


    public Template()
    {
        planeTMs = new Dictionary<int, PlaneTM>();
        foodTMs = new Dictionary<int, FoodTM>();
        bulTMs = new Dictionary<int, BulTM>();

    }
    public void Init(AssetsContext assets)
    {
        // 飞机
        planeTMs.Add(1, CreatePlaneTM(1, 100, 800, BulType.onebul, assets.player1, new Vector2(30, 30), SharpType.circle));
        planeTMs.Add(2, CreatePlaneTM(2, 20, 300, BulType.onebul, assets.enemy1, new Vector2(30, 30), SharpType.circle));
        planeTMs.Add(3, CreatePlaneTM(3, 20, 200, BulType.twobul, assets.enemy2, new Vector2(20, 20), SharpType.circle));
        // 食物
        foodTMs.Add(1, CreateFoodTM(1, assets.food1, new Vector2(30, 30), SharpType.rectangle));
        foodTMs.Add(2, CreateFoodTM(2, assets.food2, new Vector2(30, 30), SharpType.rectangle));
        // 子弹
        bulTMs.Add(1, CreateBulTM(1, assets.bullet1, new Vector2(5, 5), SharpType.circle));
        bulTMs.Add(2, CreateBulTM(2, assets.bullet2, new Vector2(5, 5), SharpType.circle));
        bulTMs.Add(3, CreateBulTM(3, assets.bullet3, new Vector2(5, 5), SharpType.circle));

    }
    PlaneTM CreatePlaneTM(int typeID, int hp, float moveSpeed, BulType bulType, Texture2D texture2D, Vector2 size, SharpType sharpType)
    {
        PlaneTM tm = new PlaneTM();
        tm.typeID = typeID;
        tm.hp = hp;
        tm.moveSpeed = moveSpeed;
        tm.texture2D = texture2D;
        tm.size = size;
        tm.sharpType = sharpType;
        tm.bulType = bulType;
        return tm;
    }
    FoodTM CreateFoodTM(int typeID, Texture2D texture2D, Vector2 size, SharpType sharpType)
    {
        FoodTM tm = new FoodTM();
        tm.texture2D = texture2D;
        tm.typeID = typeID;
        tm.size = size;
        tm.sharpType = sharpType;
        return tm;
    }
    BulTM CreateBulTM(int typeID, Texture2D texture2D, Vector2 size, SharpType sharpType)
    {
        BulTM tm = new BulTM();
        tm.texture2D = texture2D;
        tm.typeID = typeID;
        tm.size = size;
        tm.sharpType = sharpType;
        return tm;
    }
    public bool TryGetPlaneTM(int typeID, out PlaneTM tm)
    {
        bool has = planeTMs.TryGetValue(typeID, out tm);
        return has;
    }
    public bool TryGetFoodTM(int typeID, out FoodTM tm)
    {
        bool has = foodTMs.TryGetValue(typeID, out tm);
        return has;
    }
    public bool TryGetBulTM(int typeID, out BulTM tm)
    {
        bool has = bulTMs.TryGetValue(typeID, out tm);
        return has;
    }
}