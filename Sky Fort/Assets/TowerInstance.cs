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
    private List<Upgrade> upgrades = new List<Upgrade>();

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

        health = Math.Min(GetMaxHealth(), health);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return (int)Math.Round(tower.GetHealth() * GetTotalUpgrades(Upgrade.UpgradeType.Health));
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
                    float angle = Vector3.SignedAngle(follow.forward, new Vector3(ac.transform.position.x - follow.transform.position.x, 0f,  ac.transform.position.z - follow.transform.position.z), Vector3.up);
                    //follow.RotateAround(follow.transform.position, Vector3.up, angle);
                    follow.rotation = Quaternion.AngleAxis(-90, Vector3.right) * Quaternion.AngleAxis(angle, Vector3.forward);

                    //Vector3 lookVec = ac.transform.position - follow.transform.position;
                    //lookVec.y = 0;

                    //follow.LookAt(lookVec);
                }
            }
        }

        //then act
        if (cooldown <= 0)
        {
            int attackSpeed = (int)Math.Round(tower.GetAttackSpeed() * GetTotalUpgrades(Upgrade.UpgradeType.AttackSpeed));
            cooldown = (int)Math.Round(120 / ((30 + attackSpeed / 3) * 0.01));
            tower.Act(this);
        }
    }

    public bool HasUpgrade(Upgrade u)
    {
        return upgrades.Contains(u);
    }
    
    public double GetTotalUpgrades(Upgrade.UpgradeType type)
    {
        double multSum = 1;

        foreach (Upgrade u in upgrades)
        {
            if (u.GetUpType() == type)
            {
                multSum += u.GetAmount();
            }
        }

        return multSum;
    }

    private Transform RecursiveFind(Transform t, string term)
    {
        if (t.Find(term) != null)
        {
            return t.Find(term);
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

    public void AddUpgrade(Upgrade u)
    {
        upgrades.Add(u);
        upgradesSum += u.GetCost();

        // ensure that the tower will now be fully healed (applying health upgrades)
        AddHealth(GetMaxHealth());
    }

    public void Click()
    {
        Game.Select(null);
        Game.SelectTower(this);
    }
}