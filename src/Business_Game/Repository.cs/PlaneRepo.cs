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
    public void Remove(PlaneEntity player) {
       int planeLen= TakeAll(out PlaneEntity[]temp);
        for(int i=0;i<planeLen;i++){
            var plane=temp[i];
            if(plane.isDead){
                if(plane==player){
                    continue;
                }
                all.Remove(plane.entityID);
            }
        }    
        // all.Remove(role.entityID);
    }
    public int TakeAll(out PlaneEntity[] temp) {
        if (tempArray.Length < all.Count) {
            tempArray = new PlaneEntity[all.Count * 2];
        }
        all.Values.CopyTo(tempArray, 0);
        temp = tempArray;
        return all.Count;
    }
    public PlaneEntity  FindNearlyEnemy( Vector2 pos, float radius) {
        float nearlyDistance = radius*radius;
        PlaneEntity  nearlyenemy = null;
        foreach(PlaneEntity plane in all.Values) {
            if (plane == null) {
                continue;
            }
            if (plane.ally == Ally.enemy) {
                float distance = Vector2.DistanceSquared(plane.pos, pos);
                if (distance < nearlyDistance) {
                    nearlyDistance = distance;
                    nearlyenemy = plane;
                }
            }
        }
        return nearlyenemy;
    }
    public bool IsAllEnemyDead(){
        foreach(PlaneEntity plane in all.Values){
            if(plane.ally==Ally.player){
                continue;
            }
            if(plane.isDead==false){
                return false;
            }
        }
        return true;
    }
}