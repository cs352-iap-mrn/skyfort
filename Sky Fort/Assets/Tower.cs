using System;
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

    public enum ModelType
    {
        Attack,
        Base,
        Resource,
        Upgrade
    }

    public ModelType modelName = ModelType.Base;

    private bool researched = false;

    public Tower(int cost, string name, int health, Enemy.FocusPriority focusPriority, int attackSpeed)
    {
        this.cost = cost;
        this.name = name;
        this.health = health;
        this.focusPriority = focusPriority;
        this.attackSpeed = attackSpeed;
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
}
