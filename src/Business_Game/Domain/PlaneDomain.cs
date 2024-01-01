using System.Numerics;
using Raylib_cs;
public static class PlaneDomain {
    public static void SpawnPlane(Context con, Template template, IDService iDService, int typeID, Vector2 pos, Ally ally) {
        PlaneEntity plane = Factory.CreatPlane(template, iDService, typeID, pos, ally);
        con.gameContext.planeRepo.Add(plane);
    }
}