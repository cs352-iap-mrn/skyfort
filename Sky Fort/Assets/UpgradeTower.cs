using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : Tower
{

    public UpgradeTower(int cost, string name, int health, int focusPriority, int attackSpeed) : base(cost, name, health, focusPriority, attackSpeed)
    {
        modelName = ModelType.Upgrade;
    }

    override
    public void Act(TowerInstance t)
    {
        System.Object data = t.GetData();
        if (data != null && data is Tower)
        {
            

            if (TechTree.researchCompleted && TechTree.GetAvailableTowers().Contains(data as Tower))
            {
                t.SetData(null);
            }

            TechTree.ResearchTower(data as Tower);
        }

        if (data != null && data is Upgrade)
        {
            

            if (TechTree.researchCompleted && TechTree.GetAvailableUpgrades().Contains(data as Upgrade))
            {
                t.SetData(null);
            }

            TechTree.ResearchUpgrade(data as Upgrade);
        }
    }
}
