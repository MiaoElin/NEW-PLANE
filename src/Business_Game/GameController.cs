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
        con.gameContext.wave1 = WaveDomain.SpawnWave(con, 1);

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
        // 生成地图
        ref WaveEntity wave1 = ref con.gameContext.wave1;
        Rectangle src = new Rectangle(0, 0, wave1.map.Width, wave1.map.Height);
        Rectangle dest = new Rectangle(0, 0, 720, 1080);
        Raylib.DrawTexturePro(wave1.map, src, dest, new(0, 0), 0, Color.WHITE);

        // 生成波次里的entity
        int WaveLen = con.gameContext.waveRepo.TakeAll(out WaveEntity[] all_Wave);
        for (int i = 0; i < WaveLen; i++) {
            var wave = all_Wave[i];
            WaveDomain.SpwanEntities(con, wave, dt);
        }
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
    }
}