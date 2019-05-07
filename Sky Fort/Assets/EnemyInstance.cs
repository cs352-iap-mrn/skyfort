using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : HealthScript.IHealthable
{
    private Enemy enemy;
    private GameObject gameObject;
    private int cooldown;
    private int health;
    private bool attackState;
    private int detectRange;

    public EnemyInstance(Enemy enemy, GameObject gameObject)
    {
        this.enemy = enemy;
        this.gameObject = gameObject;

        cooldown = 0;

        health = GetMaxHealth();
    }

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

    public bool IsDead() {
        if (health <= 0) 
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
}