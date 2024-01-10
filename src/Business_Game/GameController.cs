using System.Numerics;
using Raylib_cs;
public static class GameController {
    public static void Init() {

    }
    public static void EnterGame(GameContext con) {

        // 生成我方飞机
        PlaneEntity player = PlaneDomain.SpawnPlane(con, 4, new Vector2(0, 460), Ally.player);
        con.gameEntity.playerEntityID = player.entityID;
        con.gameEntity.gameStage = GameStage.Ingame;
        // 初始化所有波次
        WaveDomain.SpawnWave(con);
    }
    public static void InGame_Tick(GameContext con, float dt) {
        PlaneEntity player = con.TryGetPlayer();
        // 获取当前波次
        WaveEntity wave = con.TtyGetWave();
        // System.Console.WriteLine("当前是第"+wave.typeID+"波");
        // 生成波次里的entity
        WaveDomain.SpwanEntities(con, wave, dt);
        // 飞机移动
        int planeLen = con.planeRepo.TakeAll(out PlaneEntity[] all_Plane);
        System.Console.WriteLine(planeLen);
        for (int i = 0; i < planeLen; i++) {
            var plane = all_Plane[i];
            PlaneDomain.Move(con, plane, dt);
            // 发射子弹
            PlaneDomain.TryShootBul(con, plane, dt);
        }
        // 子弹移动
        int bulLen = con.bulRepo.TakeAll(out BulletEntity[] all_Bullets);
        for (int i = 0; i < bulLen; i++) {
            var bul = all_Bullets[i];
            BulletDomain.Move(con, dt, bul);
            // 碰撞检测 移除死亡的子弹 和死亡的飞机
            if (bul.ally == Ally.enemy) {
                PlaneEntity nearlyEnemy = con.TryGetPlayer();
                BulletDomain.Remove(con, bul, nearlyEnemy);
            }
            if (bul.ally == Ally.player) {
                PlaneEntity nearlyEnemy = con.planeRepo.FindNearlyEnemy(bul.pos, bul.size.X);
                if (nearlyEnemy != null) {
                    BulletDomain.Remove(con, bul, nearlyEnemy);
                }
            }
        }

        // 食物移动
        // 吃食物
        int foodLen = con.foodRepo.TakeAll(out FoodEntity[] all_foods);
        for (int i = 0; i < foodLen; i++) {
            var food = all_foods[i];
            PlaneDomain.EatFood(con, player, food);
        }
        // 飞机移除
        con.planeRepo.Remove(player);
        // 子弹移除
        con.bulRepo.Remove();
        // 食物移除
        con.foodRepo.Remove();
        ApplyResult(con);
    }
    public static void Tick(GameContext con, float dt) {
        GameEntity game = con.gameEntity;
        UIContext uic = con.uIContext;
        WaveEntity wave = con.TtyGetWave();
        if (game.gameStage == GameStage.EnteringGame) {
            EnterGame(con);
        }
        if (game.gameStage == GameStage.Ingame) {
            InGame_Tick(con, dt);
        }
        if (game.gameStage == GameStage.Win) {
            UIApp.Win_Open(uic);
            if (UIApp.Win_IsClickContinue(uic)) {
                game.WaveEntityID += 1;
                if (wave.entityID > 5) {
                    // 总共5关
                    //通关
                }
                // 清除剩余的子弹食物
                con.foodRepo.AllToDead();
                con.foodRepo.Remove();
                con.bulRepo.AllToDead();
                con.bulRepo.Remove();
                UIApp.Win_Closed(uic);
                game.gameStage = GameStage.Ingame;
            }
        }
        if (game.gameStage == GameStage.Failed) {
            UIApp.Failed_Open(uic);
            if (UIApp.Failed_IsClickRebirth(uic)) {
                con.TryGetPlayer().isDead = false;
                con.TryGetPlayer().hp = 100;
                game.gameStage=GameStage.Ingame;
                UIApp.Failed_Closed(uic);
            }
            if (UIApp.Failed_isClickExit(uic)) {
                Raylib.CloseWindow();
            }
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE)) {
            game.gameStage = GameStage.Pause;
            UIApp.Pause_Open(uic);
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE) && game.gameStage == GameStage.Pause) {
            game.gameStage = GameStage.Ingame;
            UIApp.Pause_Closed(uic);
        }
    }
    public static void ApplyResult(GameContext con) {
        // 判定是否过关
        WaveEntity wave = con.TtyGetWave();
        UIContext uic = con.uIContext;
        GameEntity game = con.gameEntity;
        if (wave.isDead) {
            game.gameStage = GameStage.Win;
        }
        // 判定是否过关失败
        if (con.TryGetPlayer().isDead == true) {
            game.gameStage = GameStage.Failed;

        }

    }
    public static void Draw(GameContext con) {
        GameEntity game = con.gameEntity;
        if (game.gameStage != GameStage.Ingame) {
            return;
        }
        // 生成地图
        WaveEntity wave = con.TtyGetWave();
        Rectangle src = new Rectangle(0, 0, wave.map.Width, wave.map.Height);
        Rectangle dest = new Rectangle(0, 0, 720, 1080);
        Raylib.DrawTexturePro(wave.map, src, dest, new(360, 540), 0, Color.WHITE);
        // 飞机绘制
        PlaneDomain.Draw(con);
        // 子弹绘制
        BulletDomain.Draw(con);
        // 食物绘制
        FoodDomain.Draw(con);



    }
    public static void DrawUI(GameContext con) {
        GameEntity game = con.gameEntity;
        if (game.gameStage != GameStage.Ingame && game.gameStage != GameStage.Win&&game.gameStage!=GameStage.Failed) {
            return;
        }
        float hpInsGreen = con.TryGetPlayer().hp;
        Raylib.DrawRectangleV(new Vector2(0, 0), new Vector2(200, 30), Color.RED);
        Raylib.DrawRectangleV(new Vector2(0, 0), new Vector2(hpInsGreen * 2, 30), Color.GREEN);
        string hp = hpInsGreen.ToString();
        Raylib.DrawText(hp + "/100", 95, 10, 15, Color.WHITE);

        //panel 绘制
        UIApp.Win_Draw(con.uIContext);
        UIApp.Failed_Draw(con.uIContext);

    }
}