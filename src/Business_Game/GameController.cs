using System.Numerics;
using Raylib_cs;
public static class GameController {
    public static void Init() {

    }
    public static void EnterGame(Context con) {

        // 生成我方飞机
        PlaneEntity player = PlaneDomain.SpawnPlane(con, TypeIDConst.PLAYER_PLANE_TYPEID, new Vector2(0, 460), Ally.player);
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
            if (plane.ally == Ally.enemy) {
                PlaneDomain.EnemyTryShoot(con, plane, dt);
            }
            // 子弹生成
            // BulletDomain.SpawnBul(con, plane, dt);
        }
        // 子弹移动
        int bulLen = con.gameContext.bulRepo.TakeAll(out BulletEntity[] all_Bullets);
        for (int i = 0; i < bulLen; i++) {
            var bul = all_Bullets[i];
            BulletDomain.Move(con, dt, bul);
        }


        // 食物移动
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