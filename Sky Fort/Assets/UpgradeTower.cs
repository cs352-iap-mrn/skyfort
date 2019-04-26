﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : Tower
{
    private Tower researching;
    private int gain;

    public UpgradeTower(int cost, string name, int health, int focusPriority, int attackSpeed, int gain) : base(cost, name, health, focusPriority, attackSpeed)
    {
        modelName = ModelType.Upgrade;

        this.gain = gain;
    }

    override
    public void Act(TowerInstance t)
    {
        if (researching != null)
        {
            bool finished = TechTree.Research(researching);
            if (finished)
            {
                researching = null;
            }
        }
    }
}
