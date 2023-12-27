using System.Numerics;
using Raylib_cs;
public class Context
{
    public RoleRepository roleRepository;
    public InputEntity input;
    public sbyte gameStatus;
    
    public void Initialize()
    {
        roleRepository = new RoleRepository();

    }
}
