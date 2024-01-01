using System.Numerics;
using Raylib_cs;
public static class GameController {
    public static void Init() {

    }
    public static void EnterGame(Context con) {
        // 生成我方飞机
        PlaneEntity player = PlaneDomain.SpawnPlane(con, con.template, con.iDService, 1, new Vector2(0, 0), Ally.player);
        con.gameContext.isInGame = true;
        player = con.gameContext.player;
        // 初始化敌机（选择关卡）
    }
    public static void Tick(Context con, float dt) {
        GameContext game = con.gameContext;
        if (game.isEnteringGame) {
            game.isEnteringGame = false;
            EnterGame(con);
        }
        if (!game.isInGame || game.isPause) {
            return;
        }
        AssetsContext assets = con.assets;
        Rectangle src = new Rectangle(0, 0, assets.map1.Width, assets.map1.Height);
        Rectangle dest = new Rectangle(-360, 540, 720, 1080);
        Raylib.DrawTexturePro(assets.map1, src, dest, new(-360, 540), 0, Color.WHITE);
        // 生成敌人

        // 飞机移动
        int Length = con.gameContext.planeRepo.TakeAll(out PlaneEntity[] all);
        for (int i = 0; i < Length; i++) {
            var plane = all[i];
            PlaneDomain.Move(con, plane, dt);
        }
    }
    public static void Draw(Context con) {
        GameContext game = con.gameContext;
        if (!game.isInGame) {
            return;
        }
        int Length = con.gameContext.planeRepo.TakeAll(out PlaneEntity[] nowAll);
        for (int i = 0; i < Length; i++) {
            var tem = nowAll[i];
            tem.Draw();

        }



    }
    public static void DrawUI(Context con) {
        GameContext game = con.gameContext;
        if (!game.isInGame) {
            // PLog.LogError("not ingame");
            return;
        }
        // Raylib.DrawRectangleV(new Vector2 (0,0),new Vector2 (100,30),Color.BLACK);
    }
}