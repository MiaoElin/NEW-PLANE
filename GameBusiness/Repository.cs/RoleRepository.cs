using System.Numerics;
using Raylib_cs;
public class RoleRepository
{

    Dictionary<int, RoleEntity> all;
    Dictionary<int, RoleEntity> playerRoles;
    Dictionary<int, RoleEntity> enemies;
    RoleEntity[] roles;
    public RoleRepository()
    {
        all = new Dictionary<int, RoleEntity>();
        playerRoles = new Dictionary<int, RoleEntity>(100);
        enemies = new Dictionary<int, RoleEntity>(1000);
        roles = new RoleEntity[2000];
    }
    public void Add(RoleEntity role)
    {
        all.Add(role.entityID, role);
        if (role.typeID == (int)RoleType.player)
        {
            playerRoles.Add(role.entityID, role);
        }
        else if (role.typeID == (int)RoleType.enemy)
        {
            playerRoles.Add(role.entityID, role);
        }
    }
    public  void Remove(int roleEntityID){
        all.Remove(roleEntityID);
        if(roleEntityID==(int)RoleType.player){
            playerRoles.Remove(roleEntityID);
        }else if(roleEntityID ==(int)RoleType.enemy){
            enemies.Remove(roleEntityID);
        }
    }
    
}