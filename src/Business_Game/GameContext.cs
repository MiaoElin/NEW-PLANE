using System.Numerics;
using Raylib_cs;
public class GameContext {
    public bool isInGame;
    public bool isEnteringGame;
    public bool isPause;
    // =====Repository====
    public PlaneRepo planeRepo;
    public WaveRepo waveRepo;
    public BulRepo bulRepo;
    public FoodRepo foodRepo;
    // =====player====
    public int playerEntityID;
    // =====Wave=====
    public int WaveEntityID;
    // ====boss====
    public int bossEntityID;

    public GameContext() {
        isEnteringGame = false;
        isInGame = false;
        isPause = false;
        planeRepo = new PlaneRepo();
        waveRepo = new WaveRepo();
        bulRepo = new BulRepo();
        foodRepo = new FoodRepo();
        WaveEntityID=0;//先默认一，以后应该是以加载的游戏进程和登入选择的关卡为主
    }
    public PlaneEntity TryGetPlayer() {
        planeRepo.TryGet(playerEntityID, out PlaneEntity  player);
        return player;
    }
    public WaveEntity TtyGetWave(){
        waveRepo.TryGet(WaveEntityID,out WaveEntity wave);
        return wave;
    }
    public PlaneEntity TryGetBoss(){
        planeRepo.TryGet(bossEntityID,out PlaneEntity boss);
        return boss;
    }
}