using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {
    public float lookRadius = 7f;
    SphereCollider myCollider;
    Collider hitTower;
    public EnemyInstance enemy;
    private Transform towerTarget = null;
    float speed = 1.7f;

    public void AddHealth(int amount)
    {
        enemy.AddHealth(amount);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "tower") 
        {
            towerTarget = other.transform;
            hitTower = other;
        }
    }
 
    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "tower") 
        {
            towerTarget = null;
            hitTower = null;
        }
    }

    void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.radius = 7;
    }

    void Update() 
    {
        Debug.Log("Health is: " + enemy.GetHealth());
        // if (enemy.GetHealth() < 0)
        // {
        //     Destroy(enemy.GetGameObject());

        // }
       if (enemy.GetAttackState()) 
       {
           if (hitTower == null) {
               enemy.SetAttackState(false);
           }

           hitTower.SendMessage("AddHealth", -enemy.GetDamage(), SendMessageOptions.DontRequireReceiver);
        //    hitTower.SendMessage("AddHealth", -enemy.GetDamage());
       }
       else
       {
           float step =  speed * Time.deltaTime; // calculate distance to move
           if (towerTarget != null) {
               float distance = Vector3.Distance(transform.position, towerTarget.position);
               if (distance < 4.0f) 
               {
                   enemy.SetAttackState(true);
               }
               transform.position = Vector3.MoveTowards(transform.position, towerTarget.position, step);
           }
           else
           {
               transform.position = Vector3.MoveTowards(transform.position, new Vector3(90, 7, 90), step);
           }
       }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}