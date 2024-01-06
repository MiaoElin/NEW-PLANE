using System.Numerics;
using Raylib_cs;
public class FoodRepo {
    Dictionary<int, FoodEntity> all;
    FoodEntity[] tempArray;
    public FoodRepo() {
        all = new Dictionary<int, FoodEntity>();
        tempArray = new FoodEntity[1000];
    }
    public void Add(FoodEntity food) {
        all.Add(food.entityID, food);
    }
    public bool TryGetFood(int entityID, out FoodEntity food) {
        return all.TryGetValue(entityID, out food);
    }
    public void Remove(FoodEntity food) {
        all.Remove(food.entityID);
    }
    public int TakeAll(out FoodEntity[] temp) {
        if (all.Count > tempArray.Length) {
            tempArray = new FoodEntity[all.Count * 2];
        }
        all.Values.CopyTo(tempArray, 0);
        temp = tempArray;
        return all.Count;
    }

}