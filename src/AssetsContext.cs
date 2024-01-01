using System.Diagnostics;
using System.Numerics;
using Raylib_cs;
public class AssetsContext {
    public Texture2D map1;
    public Texture2D player1;
    public Texture2D enemy1;
    public Texture2D enemy2;
    public Texture2D food1;
    public Texture2D food2;
    public Texture2D bullet1;
    public Texture2D bullet2;
    public Texture2D bullet3;
    public void Init() {
        map1 = LoadTexture("Assets/map1.png");
        player1 = LoadTexture("Assets/player1.png");
        enemy1 = LoadTexture("Assets/enemy1.png");
        enemy2 = LoadTexture("Assets/enemy2.png");
        food1 = LoadTexture("Assets/food1.png");
        food2 = LoadTexture("Assets/food2.png");
        bullet1 = LoadTexture("Assets/bullet1.png");
        bullet2 = LoadTexture("Assets/bullet2.png");
        bullet3 = LoadTexture("Assets/bullet3.png");

    }
    public Texture2D LoadTexture(String filepath) {
        Texture2D tex = Raylib.LoadTexture(filepath);
        Debug.Assert(tex.Width != 0);
        return tex;
    }
    public void UnloadTexture() {
        Raylib.UnloadTexture(map1);
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