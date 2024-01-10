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
    public void Remove() {
        int foodLen = TakeAll(out FoodEntity[] temp);
        for (int i = 0; i < foodLen; i++) {
            var fo = temp[i];
            if (fo.isDead) {
                all.Remove(fo.entityID);
            }
        }
    }
    public void AllToDead(){
        foreach(FoodEntity food in all.Values){
            food.isDead=true;
        }
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