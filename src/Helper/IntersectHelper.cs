using System.Numerics;
using Raylib_cs;
public static class IntersectHelper{
    public static bool IscircleIntersect(Vector2 bulPos,float bulR,Vector2 planePos,float planeR){
            float distace= Vector2.Distance(planePos,bulPos);
            if(distace<=planeR+bulR){
                return true;
            }
            return false;
    }
}