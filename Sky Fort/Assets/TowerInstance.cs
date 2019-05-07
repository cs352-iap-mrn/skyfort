using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstance : HealthScript.IHealthable
{
    private Tower tower;
    private Tile tile;
    private GameObject gameObject;

    private int cooldown;
    private int health;

    // used to refund upgrade cost
    private int upgradesSum = 0;
    private List<Upgrade> upgrades;

    public System.Object storedData;

    public TowerInstance(Tower tower, Tile tile, GameObject gameObject)
    {
        this.tower = tower;
        this.tile = tile;
        this.gameObject = gameObject;

        cooldown = (int)Math.Round(120 / ((30 + tower.GetAttackSpeed() / 3) * 0.01));
        health = tower.GetHealth();
    }

    public GameObject GetModel()
    {
        return tower.model;
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

        if (tower is AttackTower)
        {
            Collider ac = (tower as AttackTower).GetAttackCollider();
            if (ac != null)
            {
                Transform follow = RecursiveFind(gameObject.transform, "Follow");
                if (follow != null)
                {
                    follow.LookAt(ac.transform);
                }
            }
        }

        //then act
        if (cooldown <= 0)
        {
            cooldown = (int)Math.Round(120 / ((30 + tower.GetAttackSpeed() / 3) * 0.01));
            tower.Act(this);
        }
    }

    private Transform RecursiveFind(Transform t, string term)
    {
        if (t.Find(term) != null)
        {
            return t;
        } else
        {
            for(int i = 0; i < t.childCount; i++)
            {
                Transform childT = RecursiveFind(t.GetChild(i).transform, term);
                if(childT != null)
                {
                    return childT;
                }
            }
        }

        return null;
    }

    public void Click()
    {
        Game.Select(null);
        Game.SelectTower(this);
    }
}