using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public enum FocusPriority
    {
        None = 0,
        Low = 25,
        Medium = 50,
        High = 75,
        Highest = 100
    }

    private GameObject gameObject;

    // private int z;
    // Increase on update
    private int damage;
    // Increase on update
    private int health;
    // current level
    private int level;
    // Constant for each enemy Type
    private int speed;
    // Nexus for basic
    private int attackPriority;
    // Constant for each enemy type
    private int attackSpeed;
    // Constant for each enemy type (radius of locus)
    private int attackRange;
    private int detectRange;
    // Changes as level increases
    //private int cooldown;
    // Attack State
    //private bool attackState;

    // QUESTION: Is upgrade type temporary implementation?
    public enum EnemyType
    {
        Base,
        Destroyer,
        Tank,
        Boomer,
        Boss
    }

    private EnemyType currentEnemyType;
    //private Tower.ModelType targetTower;

    // QUESTION: What is name for?
    // Constructor
    public Enemy(int level, int damage, int health, int speed, int attackPriority, int attackSpeed, int attackRange, int detectRange, EnemyType currentEnemyType)
    {
        // this.x = x;
        // this.y = y;
        this.damage = damage;
        // this.health = health;
        this.health = health;
        this.level = level;
        this.speed = speed;
        this.currentEnemyType = currentEnemyType;
        this.attackPriority = attackPriority;
        this.attackSpeed = attackSpeed;
        this.attackRange = attackRange;
        this.detectRange = detectRange;
        //this.cooldown = 0;
        //this.targetTower = targetTower;
    }


    private int LevelModify(int baseStat)
    {
        double levelMod = Math.Pow(level, 1.3) / 20.0 + .05;
        return baseStat + (int)Math.Round(baseStat * levelMod);
    }

   public int GetDamage()
    {
        return LevelModify(damage);
    }

    public int GetHealth()
    {
        return LevelModify(health);
    }

    public int GetLevel()
    {
        return level;
    }

    public void IncrementLevel()
    {
        level++;
    }

    public void AddHealth(int added)
    {
        health += added;
    }

    public int GetSpeed()
    {
        return LevelModify(speed);
    }

    public int GetAttackPriority()
    {
        return attackPriority;
    }

    public int GetAttackSpeed()
    {
        return LevelModify(attackSpeed);
    }

    public int GetAttackRange()
    {
        return attackRange;
    }

    public int GetDetectRange()
    {
        return detectRange;
    }

    public EnemyType GetEnemyType() {
        return currentEnemyType;
    }

    public virtual void Act(EnemyInstance t)
    {

    }

    //Override so that priorities work
    public virtual double GetPriority(TowerInstance ti, Vector3 pos)
    {
        return ti.GetPriority() * 20 / Math.Pow(Vector3.Distance(ti.GetPosition(), pos), 2);
    }
}
