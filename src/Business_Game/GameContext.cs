using System.Numerics;
using Raylib_cs;
public class GameContext {

    // =====Repository====
    public PlaneRepo planeRepo;
    public WaveRepo waveRepo;
    public BulRepo bulRepo;
    public FoodRepo foodRepo;
    //=====Entity===
    public GameEntity gameEntity;
    public InputEntity input;
    // =====Context====
    public UIContext uIContext;


    // ====Template====
    public Template template;
    // ====Service====
    public IDService iDService;
    public RandomService r;
    // ====Assets====
    public AssetsContext assets;

    public GameContext() {

        planeRepo = new PlaneRepo();
        waveRepo = new WaveRepo();
        bulRepo = new BulRepo();
        foodRepo = new FoodRepo();
        uIContext = new UIContext();
        template = new Template();
        iDService = new IDService();
        r = new RandomService();
        assets = new AssetsContext();
        gameEntity = new GameEntity();
    }

    public void Inject(InputEntity input) {
        this.input = input;
    }

    public PlaneEntity TryGetPlayer() {
        planeRepo.TryGet(gameEntity.playerEntityID, out PlaneEntity player);
        return player;
    }
    public WaveEntity TtyGetWave() {
        waveRepo.TryGet(gameEntity.WaveEntityID, out WaveEntity wave);
        return wave;
    }
    public PlaneEntity TryGetBoss() {
        planeRepo.TryGet(gameEntity.bossEntityID, out PlaneEntity boss);
        return boss;
    }
}