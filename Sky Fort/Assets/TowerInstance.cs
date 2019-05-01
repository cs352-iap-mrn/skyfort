using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstance : HealthScript.Healthable
{
    private Tower tower;
    private Tile tile;
    private GameObject gameObject;

    private int cooldown;
    private int health;

    // used to refund upgrade cost
    private int upgradesSum = 0;

    public System.Object storedData;

    public TowerInstance(Tower tower, Tile tile, GameObject gameObject)
    {
        this.tower = tower;
        this.tile = tile;
        this.gameObject = gameObject;

        cooldown = (int)Math.Round(120 / ((30 + tower.GetAttackSpeed() / 3) * 0.01));
        health = tower.GetHealth();
    }

    public void AddHealth(int amount)
    {
        health += amount;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return tower.GetHealth();
    }

    public int[] GetPosition2D()
    {
        return tile.GetPosition();
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.localPosition;
    }

    public Tower.ModelType GetModelName()
    {
        return tower.modelName;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public string GetName()
    {
        return tower.GetName();
    }

    public int GetCost()
    {
        return tower.GetCost();
    }

    public Tile GetTile()
    {
        return tile;
    }

    public Tower GetTower()
    {
        return tower;
    }

    public void SetData(System.Object d)
    {
        storedData = d;
    }

    public System.Object GetData()
    {
        return storedData;
    }

    public int GetUpgradesSum()
    {
        return upgradesSum;
    }

    public int GetPriority()
    {
        return (int)tower.GetPriority();
    }

    public void SetCooldown(int cd) 
    {
        cooldown = cd;
    }

    public void Update()
    {
        //update cooldown
        cooldown = Math.Max(0, cooldown - 1);

        //then act
        if (cooldown <= 0)
        {
            cooldown = (int)Math.Round(120 / ((30 + tower.GetAttackSpeed() / 3) * 0.01));
            tower.Act(this);
        }
    }

    public void Click()
    {
        Game.Select(null);
        Game.SelectTower(this);
    }
}