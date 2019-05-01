using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
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
    private int cooldown;
    // Attack State
    private bool attackState;

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
    private Tower.ModelType targetTower;

    // QUESTION: What is name for?
    // Constructor
    public Enemy(int damage, int health, int level, int speed, int attackPriority, int attackSpeed, int attackRange, int detectRange, EnemyType currentEnemyType, Tower.ModelType targetTower)
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
        this.cooldown = 0;
        this.targetTower = targetTower;
    }


   public int GetDamage()
    {
        return damage;
    }

    public int GetHealth()
    {
        return health;
    }

    public void AddHealth(int added)
    {
        health += added;
    }

    public int GetLevel()
    {
        return level;
    }

    public void IncreaseLevel()
    {
        level += 1;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public int GetAttackPriority()
    {
        return attackPriority;
    }

    public int GetAttackSpeed()
    {
        return attackSpeed;
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
}
