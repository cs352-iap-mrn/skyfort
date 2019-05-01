using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : HealthScript.Healthable
{
    // instantiate things

    private Enemy enemy;
    private GameObject gameObject;
    // private int spawnLocation;
    private int cooldown;
    private int health;
    //private int speed;
    //private int damage;
    // should depend on wave length per enemy
    //private int attackRange;

    private bool attackState;

    // Radius
    private int detectRange;

    // Get it somehow
    //private Vector3 currentTarget = new Vector3(90, 0, 90);

    public EnemyInstance(Enemy enemy, GameObject gameObject)
    {
        this.enemy = enemy;
        this.gameObject = gameObject;

        cooldown = 0;

        health = GetMaxHealth();
    }

    // public void EnemySpawn() 
    // {
    //     // GameObject thing = GameObject.Instantiate(gameObject, currentPosition, gameObject.transform.rotation);
        // thing.transform.position = new Vector3(thing.transform.position.x + UnityEngine.Random.Range(0, 10), thing.transform.position.y + UnityEngine.Random.Range(0, 10), thing.transform.position.z);
    // }

    public void AddHealth(int amount)
    {
        health += amount;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetSpeed()
    {
        return enemy.GetSpeed();
    }

    public int GetAttackSpeed()
    {
        return enemy.GetAttackSpeed();
    }

    public int GetCooldown()
    {
        return cooldown;
    }

    public void SetCooldown(int amount)
    {
        cooldown = amount;
    }

    public int GetMaxHealth()
    {
        return enemy.GetHealth();
    }

    // public Tower.ModelType GetTargetTower() 
    // {
    //     return targetTower;
    // }

    // public void SetTargetTower(Tower.ModelType tower) 
    // {
    //     targetTower = tower;
    // }


    public bool GetAttackState() 
    {
        return attackState;
    }

    public int GetDamage() 
    {
        return enemy.GetDamage();
    }

    public void SetAttackState(bool r)
    {
        attackState = r;
    }

    // public int GetProximity(Tower)
    // {
    //     return Distance between GetPosition() Tower.position();
    // }

    public bool IsDead() {
        if (health == 0) 
        {
            return true;
        }
        return false;
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.localPosition;
    }

    internal float GetAttackRange()
    {
        return enemy.GetAttackRange();
    }

    internal float GetDetectionRange()
    {
        return enemy.GetDetectRange();
    }

    // public void DetectTargets()
    // {
    //     rotate around GetCurrentPosition() and + discoveryRange;
    //     if (tower in location) {
    //         if (CalculateWeight(tower) > CalculateWeight(currentTarget))
    //         {
    //             SetCurrentTarget(tower);
    //         }
    //     }
    // }

    // public int CalculateWeight(Tower)
    // {
    //     GetProximity(Tower) / CurrentTarget.getPriority();
    // }

    public Enemy.EnemyType GetTypeName()
    {
        return enemy.GetEnemyType();
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Update()
    {
        cooldown = Math.Max(0, cooldown - 1);
    }

    public double GetPriority(TowerInstance ti, Vector3 pos)
    {
        return enemy.GetPriority(ti, pos);
    }

    public double GetAttackPriority()
    {
        return enemy.GetAttackPriority();
    }

    // // Change level based on tint
    // public UpdateLevel() {

    // }


    // Called in the beginning to move to initial position
    // public void MoveToInit(edge) 
    // {
    //     enemyprefab.transformTowards(edge);
    // }

    // public void Attack(tower)
    // {
    //     Tower.health - 1 * Enemy.attackspeed;
    // }
}