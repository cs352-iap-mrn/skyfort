using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies {

    private GameObject baseEnemyFab;
    private GameObject boomerEnemyFab;
    private GameObject bossEnemyFab;
    private GameObject destroyerEnemyFab;
    private GameObject tankEnemyFab;

    // EnemyType and amount
    private Dictionary<Enemy.EnemyType, int> enemyList = new Dictionary<Enemy.EnemyType, int>();

    // List of enemy instancs
    private static List<EnemyInstance> enemyInstanceList = new List<EnemyInstance>();

    Vector3[] posList;

    // Constructor
    public Enemies(GameObject fab, Vector3[] posList)
    {
        // this.waveNumber = waveNumber;
        this.posList = posList;
        baseEnemyFab = fab;
    }

    // public void MoveToInitPos() {
    //     foreach (EnemyInstance e in enemyInstanceList) 
    //     {
    //         e.MoveToInit(init);
    //     }
    // }

    // public bool InInitPosition() {
    //     foreach (EnemyInstance e in enemyInstanceList)
    //     {
    //         if (!e.IsInitPosition())
    //         {
    //             return false;
    //         }
    //     }
    //     return true;
    // }

    // Update based on wave number
    // Series-based
    public void UpdateEnemies() {
        if (Game.GetWaveNumber() == 0)
        {
            enemyList[Enemy.EnemyType.Base] = 0;
            enemyList[Enemy.EnemyType.Tank] = 0;
            enemyList[Enemy.EnemyType.Destroyer] = 0;
            enemyList[Enemy.EnemyType.Boomer] = 0;
            enemyList[Enemy.EnemyType.Boss] = 0;
        }

        if (Game.GetWaveNumber() == 1)
        {
            enemyList[Enemy.EnemyType.Base] = 5;
            enemyList[Enemy.EnemyType.Tank] = 0;
            enemyList[Enemy.EnemyType.Destroyer] = 0;
            enemyList[Enemy.EnemyType.Boomer] = 0;
            enemyList[Enemy.EnemyType.Boss] = 0;
        }
        else
        {
            enemyList[Enemy.EnemyType.Base] += 1;

            if (Game.GetWaveNumber() > 2)
            {
                enemyList[Enemy.EnemyType.Destroyer] += 1;
            }
            if (Game.GetWaveNumber() > 5)
            {
                
                enemyList[Enemy.EnemyType.Tank] += 1;
            }
            if (Game.GetWaveNumber() > 10)
            {
                enemyList[Enemy.EnemyType.Boomer] += 2;

                if (Game.GetWaveNumber() % 5 == 0)
                {
                    enemyList[Enemy.EnemyType.Boss] += 1;
                }
            }
        }
    }

    // Break this into actual enemy types
    public void SpawnEnemies() {
        // Fix
        if (this.enemyList == null)
        {
            return;
        }

        foreach (var e in enemyList)
        {
            if (e.Key == Enemy.EnemyType.Base)
            {
                for (int i = 0; i < e.Value; i++)
                {
                    GameObject baseEnemy = GameObject.Instantiate(baseEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], baseEnemyFab.transform.rotation);
                    baseEnemy.transform.position = new Vector3(baseEnemy.transform.position.x + UnityEngine.Random.Range(0, 10), baseEnemy.transform.position.y + UnityEngine.Random.Range(0, 10), baseEnemy.transform.position.z);
                    EnemyInstance newEnemy = new EnemyInstance(new Enemy(Game.GetWaveNumber(), 2, 10, 3, 3, 35, 2, 15, Enemy.EnemyType.Boss, Tower.ModelType.Base), baseEnemy);
                    baseEnemy.GetComponent<EnemyScript>().enemy = newEnemy;
                    enemyInstanceList.Add(newEnemy);
                }
            }
            // else if (e.Key == Enemy.EnemyType.Tank)
            // {
            //     for (int i = 0; i < e.Value; i++)
            //     {
            //         GameObject tankEnemy = GameObject.Instantiate(baseEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], baseEnemyFab.transform.rotation);
            //         // enemyInstanceList.Add(new EnemyInstance(new Enemy(30, 2, 3, 3, 10, 10, 10, 10, Enemy.EnemyType.Boss, Tower.ModelType.Base), tankEnemy, posList[UnityEngine.Random.Range(0, posList.Length)]));
            //     }
            // }
            // else if (e.Key == Enemy.EnemyType.Boomer)
            // {
            //     for (int i = 0; i < e.Value; i++)
            //     {
            //         GameObject boomerEnemy = GameObject.Instantiate(baseEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], baseEnemyFab.transform.rotation);
            //         // enemyInstanceList.Add(new EnemyInstance(new Enemy(30, 2, 3, 3, 10, 10, 10, 10, Enemy.EnemyType.Boss, Tower.ModelType.Base), boomerEnemy, posList[UnityEngine.Random.Range(0, posList.Length)]));
            //     }
            // }
            // else if (e.Key == Enemy.EnemyType.Destroyer)
            // {
            //     for (int i = 0; i < e.Value; i++)
            //     {
            //         GameObject destroyerEnemy = GameObject.Instantiate(baseEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], baseEnemyFab.transform.rotation);
            //         // enemyInstanceList.Add(new EnemyInstance(new Enemy(30, 2, 3, 3, 10, 10, 10, 10, Enemy.EnemyType.Boss, Tower.ModelType.Base), destroyerEnemy, posList[UnityEngine.Random.Range(0, posList.Length)]));
            //     }
            // }
            // else if (e.Key == Enemy.EnemyType.Boss)
            // {
            //     for (int i = 0; i < e.Value; i++)
            //     {
            //         GameObject bossEnemy = GameObject.Instantiate(baseEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], baseEnemyFab.transform.rotation);
            //         // enemyInstanceList.Add(new EnemyInstance(new Enemy(30, 2, 3, 3, 10, 10, 10, 10, Enemy.EnemyType.Boss, Tower.ModelType.Base), bossEnemy, posList[UnityEngine.Random.Range(0, posList.Length)]));
            //     }
            // }
        }
    }

    public bool IsAllDead() {
        // if (enemyInstanceList.Count == 0) {
        if (enemyList.Count == 0) {
            return true;
        } 
        return false;
    }

    public static void KillEnemy(EnemyInstance ei)
    {
        enemyInstanceList.Remove(ei);
    }

    // public void Act() {
    //     foreach (EnemyInstance e in enemyInstanceList) 
    //     {
    //         e.Act();
    //     }
    // }

}