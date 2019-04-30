using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTower : Tower
{
    private int gain;

    public ResourceTower(int cost, string name, int health, int focusPriority, int attackSpeed, int gain) : base(cost, name, health, focusPriority, attackSpeed)
    {
        modelName = ModelType.Resource;

        this.gain = gain;
    }

    public int GetGain()
    {
        return gain;
    }

    override
    public void Act(TowerInstance t)
    {
        GameObject obj = t.GetGameObject();
        if (obj != null)
        {
            ParticleSystem[] psArray = obj.GetComponentsInChildren<ParticleSystem>();
            if (psArray.Length > 0)
            {
                psArray[0].Emit(15);
            }
        }

        Game.AddLumber(gain);
    }
}
    