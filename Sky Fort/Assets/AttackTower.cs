using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : Tower
{
    private int range;
    private int damage;

    public AttackTower(int cost, string name, int health, int focusPriority, int range, int damage, int attackSpeed) : base(cost, name, health, focusPriority, attackSpeed)
    {
        modelName = ModelType.Attack;

        this.range = range;
        this.damage = damage;
    }

    override
    public void Act(TowerInstance t)
    {
        int[] tilePos = t.GetPosition();

        Vector3 center = new Vector3(tilePos[0], 2.5f, tilePos[1]);

        Collider[] hitColliders = Physics.OverlapSphere(center, range);

        for(int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].SendMessage("AddHealth", -damage);
        }
    }
}
