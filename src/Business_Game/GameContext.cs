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
    // =====Wave=====
    public WaveEntity wave1;

    public GameContext() {
        isEnteringGame = false;
        isInGame = false;
        isPause = false;
        planeRepo = new PlaneRepo();
        player = new PlaneEntity();
        waveRepo=new WaveRepo ();
        bulRepo=new BulRepo ();
        foodRepo=new FoodRepo ();
        wave1=new WaveEntity ();
    }
}