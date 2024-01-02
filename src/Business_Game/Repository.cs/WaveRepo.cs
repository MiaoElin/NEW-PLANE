using System.Numerics;
using Raylib_cs;
public class WaveRepo{
    Dictionary<int,WaveEntity>all;
    WaveEntity[] tempArray;
    public WaveRepo(){
        all=new Dictionary<int, WaveEntity>();
        tempArray=new WaveEntity[100];
    }
    public void Add(WaveEntity wave){
        all.Add(wave.entityID,wave);
    }
    public bool TryGet(int entityID,out WaveEntity wave){
        return all.TryGetValue(entityID,out wave);
    }
    public void remove(int entityID){
        all.Remove(entityID);
    }
    public int TakeAll(out WaveEntity []nowAll){
        if(all.Count>tempArray.Length){
            tempArray=new WaveEntity[all.Count*2];
        }
        all.Values.CopyTo(tempArray,0);
        nowAll=tempArray;
        return all.Count;
    }
}