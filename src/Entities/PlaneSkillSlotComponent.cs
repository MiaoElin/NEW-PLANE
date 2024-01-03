using System;
using System.Collections.Generic;

public class PlaneSkillSlotComponent {

    List<SkillModel> all; // 很多技能

    public PlaneSkillSlotComponent() {
        all = new List<SkillModel>();
    }

    public void Add(SkillModel model) {
        all.Add(model);
    }

    public void Replace(int oldTypeID, SkillModel newModel) {
        int index = all.FindIndex(skill => skill.typeID == oldTypeID);
        if (index != -1) {
            all[index] = newModel;
        }
    }

    public void Remove(SkillModel model) {
        all.Remove(model);
    }

    // `委托`
    // Action 函数指针
    public void Foreach(Action<SkillModel> action) {
        all.ForEach(action);
    }

}