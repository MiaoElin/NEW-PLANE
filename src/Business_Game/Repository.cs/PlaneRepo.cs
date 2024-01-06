using System.Numerics;
using Raylib_cs;
public class PlaneRepo {

    Dictionary<int, PlaneEntity> all;
    PlaneEntity[] tempArray;
    public PlaneRepo() {
        all = new Dictionary<int, PlaneEntity>();
        tempArray = new PlaneEntity[2000];
    }
    public void Add(PlaneEntity role) {
        all.Add(role.entityID, role);

    }
    public bool TryGet(int entityID, out PlaneEntity plane) {
        return  all.TryGetValue(entityID, out plane);
    }
    public void Remove(PlaneEntity role) {
        all.Remove(role.entityID);

    }
    public int TakeAll(out PlaneEntity[] temp) {
        if (tempArray.Length < all.Count) {
            tempArray = new PlaneEntity[all.Count * 2];
        }
        all.Values.CopyTo(tempArray, 0);
        temp = tempArray;
        return all.Count;
    }
}