using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstance
{
    private Tower tower;
    private Tile tile;
    private GameObject gameObject;

    private int cooldown;
    private int health;

    // used to refund upgrade cost
    private int upgradesSum = 0;

    public TowerInstance(Tower tower, Tile tile, GameObject gameObject)
    {
        this.tower = tower;
        this.tile = tile;
        this.gameObject = gameObject;

        cooldown = 0;
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

    public int[] GetPosition()
    {
        return tile.GetPosition();
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

    public void Update()
    {
        //update cooldown
        cooldown = Math.Max(0, cooldown - 1);

        //then act
        if (cooldown <= 0)
        {
            tower.Act(this);
            cooldown = (int)Math.Round(120 / ((30 + tower.GetAttackSpeed() / 3) * 0.01));
        }

        //check for death
        if (health <= 0)
        {
            tile.Hold(null);
            tile.SetUsed(false);
        }
    }

    public void Click()
    {
        Game.Select(null);
        Game.SelectTower(this);
    }
}