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
        // 初始化所有波次
        WaveDomain.SpawnWave(con);
    }
    public static void Tick(Context con, float dt) {
        GameContext game = con.gameContext;
        UIContext uic = con.uIContext;
        PlaneEntity player = con.gameContext.TryGetPlayer();
        if (game.isEnteringGame) {
            game.isEnteringGame = false;
            EnterGame(con);
        }
        if (!game.isInGame || game.isPause) {
            return;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE)) {
            game.isPause = true;
            UIApp.Setting_Open(uic);
        }
        if (game.isPause == true) {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE)) {
                game.isPause = false;
                UIApp.Setting_Closed(uic);

            }
        }
        // 获取当前波次
        WaveEntity wave = con.gameContext.TtyGetWave();
        // System.Console.WriteLine("当前是第"+wave.typeID+"波");
        // 生成波次里的entity
        WaveDomain.SpwanEntities(con, wave, dt);
        // 飞机移动
        int planeLen = game.planeRepo.TakeAll(out PlaneEntity[] all_Plane);
        for (int i = 0; i < planeLen; i++) {
            var plane = all_Plane[i];
            PlaneDomain.Move(con, plane, dt);
            // 发射子弹
            PlaneDomain.TryShootBul(con, plane, dt);
        }
        // 子弹移动
        int bulLen = game.bulRepo.TakeAll(out BulletEntity[] all_Bullets);
        for (int i = 0; i < bulLen; i++) {
            var bul = all_Bullets[i];
            BulletDomain.Move(con, dt, bul);
            // 碰撞检测 移除死亡的子弹 和死亡的飞机
            if (bul.ally == Ally.enemy) {
                PlaneEntity nearlyEnemy = game.TryGetPlayer();
                BulletDomain.Remove(con, bul, nearlyEnemy);
            }
            if (bul.ally == Ally.player) {
                if (con.gameContext.planeRepo.FindNearlyEnemy(bul.pos, bul.size.X, out PlaneEntity nearlyEnemy)) {
                    BulletDomain.Remove(con, bul, nearlyEnemy);
                }
            }
        }
        // 食物移动
        // 吃食物
        int foodLen = game.foodRepo.TakeAll(out FoodEntity[] all_foods);
        for (int i = 0; i < foodLen; i++) {
            var food = all_foods[i];
            PlaneDomain.EatFood(con, player, food);
        }
        // 判定是否过关
        if (wave.isDead) {
            UIApp.Win_Open(uic);
            if (UIApp.Win_IsClickContinue(uic)) {
                con.gameContext.WaveEntityID += 1;
                System.Console.WriteLine(wave.entityID);
                if (wave.entityID > 5) {
                    // 总共5关
                    //通关页
                }
                UIApp.Win_Closed(uic);
            }
        }
        // 判定是否过关失败
    }
    public static void IsFailed(Context con) {
        // if(con.gameContext.TryGetPlayer()==null){
        //     return;
        // }
        // GameContext game=con.gameContext;
        // UIContext uic=con.uIContext;
        // if (game.TryGetPlayer().isDead) {
        //     game.isPause = true;
        //     UIApp.Failed_Open(uic);
        //     if (UIApp.Failed_IsClickRebirth(uic)) {
        //         game.TryGetPlayer().isDead = false;
        //         game.TryGetPlayer().hp = 100;
        //         UIApp.Failed_Closed(uic);
        //         game.isPause = false;
        //     }
        //     if (UIApp.Failed_isClickExit(uic)) {
        //         Raylib.CloseWindow();
        //     }
        // }
    }
    public static void Draw(Context con) {
        GameContext game = con.gameContext;
        if (!game.isInGame) {
            return;
        }
        // 生成地图
        WaveEntity wave = game.TtyGetWave();
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
    public static void DrawUI(Context con) {
        GameContext game = con.gameContext;
        if (!game.isInGame) {
            // PLog.LogError("not ingame");
            return;
        }
        float hpInsGreen = game.TryGetPlayer().hp;
        Raylib.DrawRectangleV(new Vector2(0, 0), new Vector2(200, 30), Color.RED);
        Raylib.DrawRectangleV(new Vector2(0, 0), new Vector2(hpInsGreen * 2, 30), Color.GREEN);
        string hp = hpInsGreen.ToString();
        Raylib.DrawText(hp + "/100", 95, 10, 15, Color.WHITE);
        //panel 绘制
        UIApp.Win_Draw(con.uIContext);

    }
}