using System.Numerics;
using Raylib_cs;
public class RoleRepository
{

    Dictionary<int, PlaneEntity> all;
    PlaneEntity[] tempArray;
    public RoleRepository()
    {
        all = new Dictionary<int, PlaneEntity>();
        tempArray = new PlaneEntity[2000];
    }
    public void Add(PlaneEntity role)
    {
        all.Add(role.entityID, role);

    }
    public  void Remove(PlaneEntity role){
        all.Remove(role.entityID);

    }
    
}