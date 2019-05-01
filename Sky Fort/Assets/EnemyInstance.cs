using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance
{
    // instantiate things

    private Enemy enemy;
    private GameObject gameObject;
    // private int spawnLocation;
    private int cooldown;
    private static int health;
    private int speed;
    private int damage;
    // should depend on wave length per enemy
    private int level;
    private int attackRange;

    private bool attackState;

    // Radius
    private int discoveryRange;

    private Vector3 currentPosition;

    // Get it somehow
    private Vector3 currentTarget = new Vector3(90, 0, 90);

    public EnemyInstance(Enemy enemy, GameObject gameObject, Vector3 currentPosition)
    {
        this.enemy = enemy;
        this.gameObject = gameObject;
        this.currentPosition = currentPosition;

        cooldown = 0;

        health = enemy.GetHealth();
        speed = enemy.GetSpeed();
        damage = enemy.GetDamage();
        level = enemy.GetLevel();
        level = enemy.GetAttackRange();
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
        return damage;
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
        return currentPosition;
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