using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : Tower
{
    private int range;
    private int damage;

    private Collider attackCollider;

    public AttackTower(int cost, string name, int health, Enemy.FocusPriority focusPriority, int range, int damage, int attackSpeed) : base(cost, name, health, focusPriority, attackSpeed)
    {
        modelName = ModelType.Attack;

        this.range = range;
        this.damage = damage;
    }

    public int GetRange()
    {
        return range;
    }

    public int GetDamage()
    {
        return damage;
    }

    override
    public void Act(TowerInstance t)
    {
        GetCollider(t);

        if (attackCollider != null)
        {
            attackCollider.SendMessageUpwards("AddHealth", -damage);
        }
        else
        {
            t.SetCooldown(0);
        }
    }

    private void GetCollider(TowerInstance t)
    {
        //int[] tilePos = t.GetPosition2D();

        Vector3 center = t.GetPosition() + new Vector3(0, 8f, 0);

        Collider[] hitColliders = Physics.OverlapSphere(center, range);
        Debug.Log(hitColliders.Length);

        double max = -9999;
        attackCollider = null;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "enemy")
            {
                EnemyInstance ei = hitColliders[i].GetComponentInParent<EnemyScript>().enemy;
                if (ei != null)
                {
                    double thisValue = Math.Pow(ei.GetAttackPriority(), 2);
                    if (thisValue > max)
                    {
                        max = thisValue;
                        attackCollider = hitColliders[i];
                    }
                }
            }
        }
    }
}
