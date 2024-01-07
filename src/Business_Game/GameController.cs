using System.Numerics;
using Raylib_cs;
public static class GameController {
    public static void Init() {

    }
    public static void EnterGame(Context con) {

        // 生成我方飞机
        PlaneEntity player = PlaneDomain.SpawnPlane(con, 4, new Vector2(0, 460), Ally.player);
        con.gameContext.playerEntityID = player.entityID;
        con.gameContext.isInGame = true;
        // 生成波次
        WaveEntity wave = WaveDomain.SpawnWave(con, 1);
        con.gameContext.WaveEntityID = wave.entityID;

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
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE)) {
            con.gameContext.isPause = true;
            UIApp.Setting_Open(con.uIContext);
        }
        if (con.gameContext.isPause == true) {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE)) {
                con.gameContext.isPause = false;
                UIApp.Setting_Closed(con.uIContext);

            }
        }
        // 生成地图
        WaveEntity wave = con.gameContext.TtyGetWave();
        Rectangle src = new Rectangle(0, 0, wave.map.Width, wave.map.Height);
        Rectangle dest = new Rectangle(0, 0, 720, 1080);
        Raylib.DrawTexturePro(wave.map, src, dest, new(0, 0), 0, Color.WHITE);

        // 生成波次里的entity
        WaveDomain.SpwanEntities(con, wave, dt);
        // 飞机移动
        int planeLen = con.gameContext.planeRepo.TakeAll(out PlaneEntity[] all_Plane);
        for (int i = 0; i < planeLen; i++) {
            var plane = all_Plane[i];
            PlaneDomain.Move(con, plane, dt);
            // 发射子弹
            PlaneDomain.TryShootBul(con, plane, dt);
        }
        // 子弹移动
        int bulLen = con.gameContext.bulRepo.TakeAll(out BulletEntity[] all_Bullets);
        for (int i = 0; i < bulLen; i++) {
            var bul = all_Bullets[i];
            BulletDomain.Move(con, dt, bul);
            // 碰撞检测 移除死亡的子弹 和死亡的飞机
            BulletDomain.Remove(con, bul);

        }
        // 食物移动
        // 吃食物
        int foodLen = con.gameContext.foodRepo.TakeAll(out FoodEntity[] all_foods);
        for (int i = 0; i < foodLen; i++) {
            var food = all_foods[i];
            FoodDomain.EatFood(con, con.gameContext.TryGetPlayer(), food);
        }
        // 判定是否过关
        if (con.gameContext.TryGetBoss().isDead == true) {
            wave.isDead = true;
            UIApp.Win_Open(con.uIContext);
            if (UIApp.Win_IsClickContinue(con.uIContext)) {
                con.gameContext.WaveEntityID += 1;
                if (con.gameContext.WaveEntityID > 2) {
                    // todo通关页
                }
            }
        }


    }
    public static void Draw(Context con) {
        GameContext game = con.gameContext;
        if (!game.isInGame) {
            return;
        }
        // 飞机绘制
        PlaneDomain.Draw(con);
        // 子弹绘制
        BulletDomain.Draw(con);
        // 食物绘制
        FoodDomain.Draw(con);



    }
    public static void DrawUI(Context con) {
        GameContext game = con.gameContext;
        if (!game.isInGame) {
            // PLog.LogError("not ingame");
            return;
        }
        float hpInsGreen = con.gameContext.TryGetPlayer().hp;
        Raylib.DrawRectangleV(new Vector2(0, 0), new Vector2(200, 30), Color.RED);
        Raylib.DrawRectangleV(new Vector2(0, 0), new Vector2(hpInsGreen * 2, 30), Color.GREEN);
        string hp = hpInsGreen.ToString();
        Raylib.DrawText(hp + "/100", 95, 10, 15, Color.WHITE);

        // Panel 绘制
        UIApp.Win_Draw(con.uIContext);
    }
}