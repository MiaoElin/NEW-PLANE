using System.Numerics;
using Raylib_cs;
public static class FoodDomain{
    public static FoodEntity SpawnFood(Context con,int typeID,Vector2 pos){
        FoodEntity food=Factory.CreateFood(con.template,con.iDService,typeID,pos);
        con.gameContext.foodRepo.Add(food);
        return food;
    }
}