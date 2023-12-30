using System.Numerics;
using Raylib_cs;
public class Context
{
    public int widowWidth;
    public int widowHeigth;
    public int baseSize;
    // ====Input====
    public InputEntity input;
    // ====Template====
    public Template template;
    // ====Service====
    public IDService iDService;
    // ====Assets====
    public AssetsContext assets;
    // ====Context====
    public LoginContext loginContext;
    public GameContext gameContext;
    public UIContext uIContext;
    // ====Camera====
    public Camera2D camera2D;

    public Context()
    {
        input=new InputEntity ();
        iDService = new IDService();
        assets = new AssetsContext();
        template = new Template();
        loginContext = new LoginContext();
        gameContext = new GameContext();
        uIContext=new UIContext ();
        camera2D=new Camera2D ();

    }
}
