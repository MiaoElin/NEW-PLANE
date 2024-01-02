using System.Numerics;
using Raylib_cs;
public static class GameController {
    public static void Init() {

    }
    public static void EnterGame(Context con) {

        // 生成波次
        WaveEntity wave = WaveDomain.SpawnWave(con, 1);
        // 生成我方飞机
        PlaneEntity player = PlaneDomain.SpawnPlane(con, TypeIDConst.PLAYER_PLANE_TYPEID, new Vector2(0, 0), Ally.player);
        con.gameContext.player=player;
        con.gameContext.isInGame = true;

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

        // 生成敌人
        int WaveLen = con.gameContext.waveRepo.TakeAll(out WaveEntity[] all_Wave);
        for (int i = 0;i < WaveLen; i++){
            var wave=all_Wave[i];
            WaveDomain.SpwanEntities()

        }

        // 飞机移动
        int planeLen = con.gameContext.planeRepo.TakeAll(out PlaneEntity[] all_Plane);
        for (int i = 0; i < planeLen; i++) {
            var plane = all_Plane[i];
            PlaneDomain.Move(con, plane, dt);
        }
    }
    public static void Draw(Context con) {
        GameContext game = con.gameContext;
        if (!game.isInGame) {
            return;
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