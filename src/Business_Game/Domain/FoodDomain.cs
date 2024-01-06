using System.Numerics;
using Raylib_cs;
public static class FoodDomain {
    public static FoodEntity SpawnFood(Context con, int typeID, Vector2 pos) {
        FoodEntity food = Factory.CreateFood(con.template, con.iDService, typeID, pos);
        con.gameContext.foodRepo.Add(food);
        return food;
    }
    public static void EatFood(Context con,PlaneEntity player,FoodEntity food){
        
    }
    public static void Draw(Context con) {
        int foodLen = con.gameContext.foodRepo.TakeAll(out FoodEntity[] allFoods);
        for (int i = 0; i < foodLen; i++) {
            var fo = allFoods[i];
            fo.Draw();
        }
    }
}