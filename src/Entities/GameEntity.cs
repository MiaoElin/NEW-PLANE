using System.Numerics;
using Raylib_cs;
public class GameEntity {
    public bool isInGame;
    public bool isEnteringGame;
    public bool isPause;
    // =====player====
    public int playerEntityID;
    // =====Wave=====
    public int WaveEntityID;
    // ====boss====
    public int bossEntityID;
    public GameEntity() {
        isEnteringGame = false;
        isInGame = false;
        isPause = false;
    }
}