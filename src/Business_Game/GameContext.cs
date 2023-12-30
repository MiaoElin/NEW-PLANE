using System.Numerics;
using Raylib_cs;
public class GameContext{
    public bool isInGame;
    public bool isEnteringGame;
    public bool isPause;
    public GameContext(){
        isEnteringGame=false;
        isInGame=false;
        isPause=false;
    }
}