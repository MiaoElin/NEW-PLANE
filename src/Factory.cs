using System.Numerics;
using Raylib_cs;
public static class Factory
{
    public static PlaneEntity CreatPlane(Template template, IDService iDService, int typeID, Vector2 pos, Ally ally)
    {
        bool has = template.TryGetPlaneTM(typeID, out PlaneTM tm);
        if (!has)
        {
            return null;
        }
        PlaneEntity plane = new PlaneEntity();
        plane.ally = ally;
        plane.typeID = typeID;
        plane.pos = pos;
        plane.entityID = iDService.planeIDRecord++;
        plane.bulType = tm.bulType;
        plane.hp = tm.hp;
        plane.moveSpeed = tm.moveSpeed;
        plane.texture2D = tm.texture2D;
        plane.size = tm.size;
        plane.sharpType = tm.sharpType;
        return plane;
    }
    public static FoodEntity CreateFood(Template template, IDService iDService,int typeID, Vector2 pos)
    {
        bool has = template.TryGetFoodTM(typeID, out FoodTM tm);
        if (!has)
        {
            return null;
        }
        FoodEntity food = new FoodEntity();
        food.entityID = iDService.foodIDRecord++;
        food.pos = pos;
        food.typeID=typeID;
        food.texture2D=tm.texture2D;
        food.size=tm.size;
        food.sharpType=tm.sharpType;
        return food;
    }
    public static BulletEntity CreateBul(Template template,IDService iDService,int typeID, Vector2 pos,Ally ally){
        bool has=template.TryGetBulTM(typeID,out BulTM tm);
        if(!has){
            return null;
        }
        BulletEntity bullet=new BulletEntity ();
        bullet.ally=ally;
        bullet.pos=pos;
        bullet.typeID=typeID;
        bullet.entityID=iDService.bulIDRecord++;
        bullet.size=tm.size;
        bullet.texture2D=tm.texture2D;
        bullet.sharpType=tm.sharpType;
        return bullet;
    }

}