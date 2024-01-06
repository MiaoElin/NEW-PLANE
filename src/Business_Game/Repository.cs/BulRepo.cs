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
    public void Remove(BulletEntity bul) {
        all.Remove(bul.entityID);
    }
    public int TakeAll(out BulletEntity[] nowAll) {
        if (all.Count > tempArray.Length) {
            tempArray = new BulletEntity[all.Count * 2];
        }
        all.Values.CopyTo(tempArray, 0);
        nowAll = tempArray;
        return all.Count;
    }
}