using System.Numerics;
using Raylib_cs;
public class GameContext {
    public bool isInGame;
    public bool isEnteringGame;
    public bool isPause;
    public PlaneRepo planeRepo;
    // =====player====
    public PlaneEntity player;

    public GameContext() {
        isEnteringGame = false;
        isInGame = false;
        isPause = false;
        planeRepo = new PlaneRepo();
        player = new PlaneEntity();
    }
}