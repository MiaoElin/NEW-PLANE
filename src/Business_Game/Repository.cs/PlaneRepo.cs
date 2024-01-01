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
    public void TryGetPlane(int entityID, out PlaneEntity plane) {
        all.TryGetValue(entityID, out plane);
    }
    public void Remove(PlaneEntity role) {
        all.Remove(role.entityID);

    }
    public int TakeAll(out PlaneEntity[] nowAll) {
        if (tempArray.Length < all.Count) {
            tempArray = new PlaneEntity[all.Count * 2];
        }
        all.Values.CopyTo(tempArray, 0);
        nowAll = tempArray;
        return all.Count;
    }

}