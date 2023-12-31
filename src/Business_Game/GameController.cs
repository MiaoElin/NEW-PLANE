using System.Numerics;
using Raylib_cs;
public static class GameController
{
    public static void Init()
    {

    }
    public static void EnterGame(Context con)
    {
        // 生成我方飞机
        ref var player = ref con.player;
        player = Factory.CreatPlane(con.template, con.iDService, 1, new Vector2(0, 0), Ally.player);
        System.Console.WriteLine(player.entityID + " " + player.hp);
        con.gameContext.isInGame = true;
        // 初始化敌机（选择关卡）
    }
    public static void Tick(Context con)
    {
        GameContext game = con.gameContext;
        if (game.isEnteringGame)
        {
            game.isEnteringGame = false;
            EnterGame(con);
        }
        if (!game.isInGame || game.isPause)
        {
            return;
        }


        // 生成敌人

    }
    public static void Draw(Context con)
    {
        GameContext game = con.gameContext;
        if (!game.isInGame)
        {
            return;
        }
        PlaneEntity player = con.player;
        player.Draw();
        AssetsContext assets = con.assets;
        Rectangle src = new Rectangle(0, 0, assets.map.Width, assets.map.Height);
        Rectangle dest = new Rectangle(0, 0, 720, 1080);
        Raylib.DrawTexturePro(assets.map, src, dest, new(360, 540), 0, Color.WHITE);

    }
    public static void DrawUI(Context con)
    {
        GameContext game = con.gameContext;
        if (!game.isInGame)
        {
            return;
        }
    }
}