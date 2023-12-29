using System.Numerics;
using Raylib_cs;
public class Context
{
    public RoleRepository roleRepository;
    public InputEntity input;
    public Template template;
    public IDService iDService;
    public AssetsContext assets;
    public LoginContext loginContext;
    public GameContext gameContext;

    public Context()
    {
        roleRepository = new RoleRepository();
        iDService = new IDService();
        assets = new AssetsContext();
        template = new Template();
        loginContext = new LoginContext();
        gameContext = new GameContext();

    }
}
