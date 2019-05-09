using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : Tower
{
    public enum ProjectileModel
    {
        Arrow,
        Fire,
        None
    }

    private int range;
    private int damage;

    private Collider attackCollider;

    private GameObject projectilePrefab;
    private GameObject projectile;

    public AttackTower(string tag, int cost, string name, int health, Enemy.FocusPriority focusPriority, int range, int damage, int attackSpeed, GameObject projectilePrefab, GameObject projectileModel, GameObject towerModel) : base(tag, cost, name, health, focusPriority, attackSpeed, towerModel)
    {
        this.range = range;
        this.damage = damage;
        this.projectilePrefab = projectilePrefab;
        this.projectile = projectileModel;
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
            int damageWithBonus = (int)Math.Round(damage * t.GetTotalUpgrades(Upgrade.UpgradeType.Damage));

            GameObject proj = UnityEngine.Object.Instantiate(projectilePrefab, t.GetGameObject().transform);
            proj.transform.position += new Vector3(0, 8f, 0);
            GameObject bullet;
            if (projectile != null)
            {   
                bullet = UnityEngine.Object.Instantiate(projectile, proj.transform);
                proj.GetComponent<ProjectileScript>().bullet = bullet.transform;
            }
            proj.GetComponent<ProjectileScript>().target = attackCollider.transform;
            proj.GetComponent<ProjectileScript>().damage = damageWithBonus; 
        }
        else
        {
            t.SetCooldown(0);
        }
    }

    public Collider GetAttackCollider()
    {
        return attackCollider;
    }

    private void GetCollider(TowerInstance t)
    {
        float rangeWithBonus = range * (float)t.GetTotalUpgrades(Upgrade.UpgradeType.Range);

        Vector3 center = t.GetPosition() + new Vector3(0, 8f, 0);

        Collider[] hitColliders = Physics.OverlapSphere(center, rangeWithBonus);

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

    override
    public bool IsCompatible(Upgrade u)
    {
        return u.GetUpType() != Upgrade.UpgradeType.Gain;
    }
}
