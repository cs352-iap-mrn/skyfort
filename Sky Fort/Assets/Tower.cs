﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    private int cost;
    private string name;
    private int health;
    private Enemy.FocusPriority focusPriority;
    private int attackSpeed;

    public string tag;

    public GameObject model;

    private bool researched = false;

    public Tower(string tag, int cost, string name, int health, Enemy.FocusPriority focusPriority, int attackSpeed, GameObject model)
    {
        this.tag = tag;
        this.cost = cost;
        this.name = name;
        this.health = health;
        this.focusPriority = focusPriority;
        this.attackSpeed = attackSpeed;

        this.model = model;
    }

    public void Research()
    {
        researched = true;
    }

    public bool IsAvailable()
    {
        return researched;
    }

    public int GetCost()
    {
        return cost;
    }

    public void SetResearched(bool r)
    {
        researched = r;
    }

    public string GetName()
    {
        return name;
    }

    public int GetHealth()
    {
        return health;
    }

    public Enemy.FocusPriority GetPriority()
    {
        return focusPriority;
    }

    public int GetAttackSpeed()
    {
        return attackSpeed;
    }

   public void AddHealth(int amount)
    {
        health += amount;
    }

    public virtual void Act(TowerInstance t)
    {

    }

    public virtual bool IsCompatible(Upgrade u)
    {
        return (u.GetUpType() == Upgrade.UpgradeType.Health);
    }

    public List<Upgrade> GetCompatibleUpgrades()
    {
        List<Upgrade> compUpgrades = new List<Upgrade>();

        foreach (Upgrade u in TechTree.GetAvailableUpgrades())
        {
            if (IsCompatible(u))
            {
                compUpgrades.Add(u);
            }
        }

        return compUpgrades;
    }
}
