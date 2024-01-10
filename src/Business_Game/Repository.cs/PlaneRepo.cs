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
        return all.TryGetValue(entityID, out plane);
    }
    public void Remove(PlaneEntity role) {
        // System.Console.WriteLine(role.entityID);
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
    public bool FindNearlyEnemy( Vector2 pos, float radius, out PlaneEntity nearlyenemy) {
        float nearlyDistance = radius*radius;
        float index = -1;
        nearlyenemy = default;
        int length= TakeAll(out PlaneEntity[]temp);
        for (int i = 0; i < length; i++) {
            var plane = temp[i];
            if (plane == null) {
                continue;
            }
            if (plane.ally == Ally.enemy) {
                float distance = Vector2.DistanceSquared(plane.pos, pos);
                if (distance < nearlyDistance) {
                    nearlyDistance = distance;
                    nearlyenemy = plane;
                    index = i;
                }
            }
        }
        if (index == -1) {
            return false;
        }
        return true;
    }
}