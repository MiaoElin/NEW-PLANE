using System.Numerics;
using Raylib_cs;
public static class FoodDomain {
    public static FoodEntity SpawnFood(GameContext con, int typeID, Vector2 pos) {
        FoodEntity food = Factory.CreateFood(con.template, con.iDService, typeID, pos);
        con.foodRepo.Add(food);
        return food;
    }
    public static void Draw(GameContext con) {
        int foodLen = con.foodRepo.TakeAll(out FoodEntity[] allFoods);
        for (int i = 0; i < foodLen; i++) {
            var fo = allFoods[i];
            fo.Draw();
        }
    }
}