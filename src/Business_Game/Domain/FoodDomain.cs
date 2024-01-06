using System.Numerics;
using Raylib_cs;
public static class FoodDomain {
    public static FoodEntity SpawnFood(Context con, int typeID, Vector2 pos) {
        FoodEntity food = Factory.CreateFood(con.template, con.iDService, typeID, pos);
        con.gameContext.foodRepo.Add(food);
        return food;
    }
    public static void EatFood(Context con,PlaneEntity player,FoodEntity food){
        if(IntersectHelper.IsRectCircleIntersect(player.pos,player.size,food.pos,food.size)){
            if(food.foodType==FoodType.TwoBulFood){
                player.shooterType=ShooterType.twobul;
            }if(food.foodType==FoodType.ThreeBulFood){
                // "to do"
            }if(food.foodType==FoodType.HpFood){
                System.Console.WriteLine("hphphp");
                player.hp+=10;
                if(player.hp>=100){
                    player.hp=100;
                }
            }
            con.gameContext.foodRepo.Remove(food);
        }
    }
    public static void Draw(Context con) {
        int foodLen = con.gameContext.foodRepo.TakeAll(out FoodEntity[] allFoods);
        for (int i = 0; i < foodLen; i++) {
            var fo = allFoods[i];
            fo.Draw();
        }
    }
}