using System.Numerics;
using Raylib_cs;
public class RandomService {
    public Random r;
    public RandomService() {
        r = new Random();
    }
    public Vector2 GetRandomPosOn_Top() {
        float x = r.Next(-4, 4);
        return new Vector2(80*x, -540);

    }
    public Vector2 GetRandomPosOn_Upperhalf() {
        int x = r.Next(-4, 5);
        int y = r.Next(-6,0);
        return  new Vector2(x *80 , y *80);
    }
    public Vector2 GetRandomPosOn_LowerHalf(){
        int x=r.Next(-4,5);
        int y=r.Next(0,6);
        return new Vector2 (x*80,y*80);
    }
}