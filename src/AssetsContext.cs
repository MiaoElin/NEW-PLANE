using System.Numerics;
using Raylib_cs;
public class AssetsContext
{
    public Texture2D map;
    public Texture2D player1;
    public Texture2D enemy1;
    public Texture2D enemy2;
    public Texture2D food1;
    public Texture2D food2;
    public Texture2D bullet1;
    public Texture2D bullet2;
    public Texture2D bullet3;
    public void Init()
    {
        map = Raylib.LoadTexture("Assets/map.npg");
        player1 = Raylib.LoadTexture("Assets/player1.npg");
        enemy1 = Raylib.LoadTexture("Assets/enemy1.npg");
        enemy2 = Raylib.LoadTexture("Assets/enemy2.npg");
        food1 = Raylib.LoadTexture("Assets/food1.npg");
        food2 = Raylib.LoadTexture("Assets/food2.npg");
        bullet1 = Raylib.LoadTexture("Assets/bullet1.npg");
        bullet2 = Raylib.LoadTexture("Assets/bullet2.npg");
        bullet3 = Raylib.LoadTexture("Assets/bullet3.npg");
    }
    public void Unload(){
        Raylib.UnloadTexture(map);
        Raylib.UnloadTexture(player1);
        Raylib.UnloadTexture(enemy1);
        Raylib.UnloadTexture(enemy2);
        Raylib.UnloadTexture(food1);
        Raylib.UnloadTexture(food2);
        Raylib.UnloadTexture(bullet1);
        Raylib.UnloadTexture(bullet2);
        Raylib.UnloadTexture(bullet3);
    }
}