using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {
    SphereCollider myCollider;
    Collider hitTower;
    public EnemyInstance enemy;
    private Transform towerTarget = null;

    public GameObject healthBarPrefab;
    private GameObject healthBar;

    private static double chance = 0.25;

    public void AddHealth(int amount)
    {
        enemy.AddHealth(amount);

        if (enemy.GetHealth() < enemy.GetMaxHealth() && healthBar == null)
        {
            healthBar = Instantiate(healthBarPrefab, Game.progressCanvas.transform);
            healthBar.GetComponent<HealthScript>().healthable = enemy;
        }
    }

    void FixedUpdate() 
    {
        if (enemy.GetHealth() <= 0)
        {
            Destroy(healthBar);
            Destroy(enemy.GetGameObject());
            Destroy(this.gameObject);
        }

        if (enemy.IsDead())
        {
            System.Random r = new System.Random();
            if (r.NextDouble() < chance)
            {
                Game.AddMP((int)Math.Round(enemy.GetHealth() / 5.0));
            }

            Enemies.KillEnemy(enemy);

            Destroy(healthBar);

            GameObject.Destroy(gameObject);

            // Make this dependent on enemy type
            Game.IncreaseScore(1);
        }

        enemy.Update();

        if (enemy.GetAttackState())
        {
            if (hitTower == null)
            {
                enemy.SetAttackState(false);
            }
            else if (enemy.GetCooldown() <= 0)
            {
                    enemy.SetCooldown((int)Math.Round(120 / ((30 + enemy.GetAttackSpeed() / 3) * 0.01)));
                    hitTower.SendMessageUpwards("AddHealth", -enemy.GetDamage());
            }
        } 
        else
        {
            float step = enemy.GetSpeed() * Time.deltaTime; // calculate distance to move
            if (towerTarget != null)
            {
                float distance = Vector3.Distance(transform.position, towerTarget.position + new Vector3(0, 8f, 0));
                if (distance < enemy.GetAttackRange())
                {
                    enemy.SetAttackState(true);
                }
                transform.position = Vector3.MoveTowards(transform.position, towerTarget.position + new Vector3(0, 8f, 0), step);
            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, Game.baseTower.GetPosition() + new Vector3(0, 8f, 0), step);
            }

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, enemy.GetDetectionRange());

            double highest = -9999;
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].tag == "tower" || hitColliders[i].tag == "base")
                {
                    TowerInstance ti = hitColliders[i].GetComponentInParent<TowerScript>().tower;
                    if (ti != null)
                    {
                        double thisValue = enemy.GetPriority(ti, enemy.GetPosition());
                        if (thisValue > highest)
                        {
                            towerTarget = ti.GetGameObject().transform;
                            highest = thisValue;
                            hitTower = hitColliders[i];
                        }
                    }
                }
            }
        }
    }
}