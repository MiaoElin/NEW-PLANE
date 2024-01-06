using System.Numerics;
using Raylib_cs;
public class PlaneSkillComponent {
   public List<SkillModel> all;
    public PlaneSkillComponent(){
        all= new List<SkillModel>();
    }
    public void Add(SkillModel skill){
        all.Add(skill);
    }
    public void Remove(SkillModel skill){
        all.Remove(skill);
    }
    public void Replace(int oldeTypeID,SkillModel newModel){
        int index=all.FindIndex(skill=>skill.typeID==oldeTypeID);
        all[index]=newModel;
    }
    public void ForEach(Action<SkillModel>action){
        all.ForEach(action);
    }
}