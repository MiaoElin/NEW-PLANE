using System.Numerics;
using Raylib_cs;
public class GameEntity {
    // =====player====
    public int playerEntityID;
    // =====Wave=====
    public int WaveEntityID;
    // ====boss====
    public int bossEntityID;
    public GameStage gameStage;
    public GameEntity() {
    }
}