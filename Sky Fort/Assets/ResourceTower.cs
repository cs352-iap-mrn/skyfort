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

    override
    public void Act(TowerInstance t)
    {
        Game.AddLumber(gain);
    }
}
