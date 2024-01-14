using System.Diagnostics;
using System.Numerics;
using Raylib_cs;
public class AssetsContext {
    public Texture2D map1;
    public Texture2D map2;
    // ====plane===
    public Texture2D player1;
    public Texture2D enemy1;
    public Texture2D enemy2;
    // food
    public Texture2D food1;
    public Texture2D food2;
    public Texture2D food3;
    // bullet
    public Texture2D bullet1;
    public Texture2D bullet2;
    public Texture2D bullet3;
    public Texture2D bullet4;
    public Texture2D bullet5;
    public Texture2D boss1;
    public void Init() {
        map1 = LoadTexture("Assets/map1.png");
        map2 = LoadTexture("Assets/map2.png");
        // plane
        player1 = LoadTexture("Assets/player1.png");
        enemy1 = LoadTexture("Assets/enemy1.png");
        enemy2 = LoadTexture("Assets/enemy2.png");
        // food
        food1 = LoadTexture("Assets/food1.png");
        food2 = LoadTexture("Assets/food2.png");
        food3 = LoadTexture("Assets/food3.png");
        // bullet
        bullet1 = LoadTexture("Assets/bullet1.png");
        bullet2 = LoadTexture("Assets/bullet2.png");
        bullet3 = LoadTexture("Assets/bullet3.png");
        bullet4 = LoadTexture("Assets/bullet4.png");
        bullet5 = LoadTexture("Assets/bullet5.png");
        boss1 = LoadTexture("Assets/boss1.png");

    }
    public Texture2D LoadTexture(String filepath) {
        Texture2D tex = Raylib.LoadTexture(filepath);
        Debug.Assert(tex.Width != 0);
        return tex;
    }
    public void UnloadTexture() {
        Raylib.UnloadTexture(map1);
        Raylib.UnloadTexture(map2);
        // plane
        Raylib.UnloadTexture(player1);
        Raylib.UnloadTexture(enemy1);
        Raylib.UnloadTexture(enemy2);
        // food
        Raylib.UnloadTexture(food1);
        Raylib.UnloadTexture(food2);
        Raylib.UnloadTexture(food3);
        // bullet
        Raylib.UnloadTexture(bullet1);
        Raylib.UnloadTexture(bullet2);
        Raylib.UnloadTexture(bullet3);
        Raylib.UnloadTexture(bullet4);
        Raylib.UnloadTexture(bullet5);
        Raylib.UnloadTexture(boss1);
    }
}