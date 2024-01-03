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
    public PlaneEntity player;
    public int playerEntityID;

    // =====Wave=====
    public WaveEntity wave1;

    public GameContext() {
        isEnteringGame = false;
        isInGame = false;
        isPause = false;
        planeRepo = new PlaneRepo();
        waveRepo = new WaveRepo();
        bulRepo = new BulRepo();
        foodRepo = new FoodRepo();
        wave1 = new WaveEntity();
    }

    public PlaneEntity GetPlayer() {
        bool has = planeRepo.TryGet(playerEntityID, out PlaneEntity plane);
        return plane;
    }

}