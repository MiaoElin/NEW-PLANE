using System.Numerics;
using Raylib_cs;
public class BulRepo {
    Dictionary<int, BulletEntity> all;
    BulletEntity[] tempArray;
    public BulRepo() {
        all = new Dictionary<int, BulletEntity>();
        tempArray = new BulletEntity[2000];
    }
    public void Add(BulletEntity bul) {
        all.Add(bul.entityID, bul);
    }
    public bool TryGetBul(int entityID, out BulletEntity bul) {
        return all.TryGetValue(entityID, out bul);
    }
    public void Remove() {
        int bulLen = TakeAll(out BulletEntity[] temp);
        for (int i = 0; i < bulLen; i++) {
            var bul = temp[i];
            if (bul.isDead) {
                all.Remove(bul.entityID);
            }
        }
    }
    public void AllToDead() {
        foreach (BulletEntity bul in all.Values) {
            bul.isDead = true;
        }
    }
    public int TakeAll(out BulletEntity[] temp) {
        if (all.Count > tempArray.Length) {
            tempArray = new BulletEntity[all.Count * 2];
        }
        all.Values.CopyTo(tempArray, 0);
        temp = tempArray;
        return all.Count;
    }
}