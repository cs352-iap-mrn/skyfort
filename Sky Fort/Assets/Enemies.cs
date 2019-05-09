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

    private int baseEnemyCount = 5;
    private int boomerEnemyCount = 1;
    private int bossEnemyCount = 1;
    private int destroyerEnemyCount = 1;
    private int tankEnemyCount = 1;

    // EnemyType and amount
    // private Dictionary<Enemy.EnemyType, int> enemyList = new Dictionary<Enemy.EnemyType, int>();

    // List of enemy instancs
    private static List<EnemyInstance> enemyInstanceList = new List<EnemyInstance>();


    public Enemies(GameObject baseFab, GameObject tankFab, GameObject destroyerFab, GameObject boomerFab, GameObject bossFab)
    {
        baseEnemyFab = baseFab;
        tankEnemyFab = tankFab;
        destroyerEnemyFab = destroyerFab;
        boomerEnemyFab = boomerFab;
        bossEnemyFab = bossFab;
    }

    // TODO: Actually make different enemy classes
    public void SpawnEnemies(Vector3[] posList) {
        for (int i = 0; i < baseEnemyCount; i++)
        {
            GameObject baseEnemy = GameObject.Instantiate(baseEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], baseEnemyFab.transform.rotation);
            baseEnemy.transform.position = new Vector3(baseEnemy.transform.position.x + UnityEngine.Random.Range(0, 10), baseEnemy.transform.position.y + UnityEngine.Random.Range(0, 10), baseEnemy.transform.position.z);
            EnemyInstance newEnemy = new EnemyInstance(new Enemy(Game.GetWaveNumber(), 2, 10, 3, 3, 35, 2, 15, Enemy.EnemyType.Base), baseEnemy);
            baseEnemy.GetComponent<EnemyScript>().enemy = newEnemy;
            enemyInstanceList.Add(newEnemy);
        }


        baseEnemyCount++;

        if (Game.GetWaveNumber() > 2)
        {
            for (int i = 0; i < tankEnemyCount; i++)
            {
                GameObject tankEnemy = GameObject.Instantiate(tankEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], tankEnemyFab.transform.rotation);
                tankEnemy.transform.position = new Vector3(tankEnemy.transform.position.x + UnityEngine.Random.Range(0, 10), tankEnemy.transform.position.y + UnityEngine.Random.Range(0, 10), tankEnemy.transform.position.z);
                EnemyInstance newEnemy = new EnemyInstance(new Enemy(Game.GetWaveNumber(), 2, 30, 2, 7, 20, 2, 15, Enemy.EnemyType.Tank), tankEnemy);
                tankEnemy.GetComponent<EnemyScript>().enemy = newEnemy;
                enemyInstanceList.Add(newEnemy);
            }

            tankEnemyCount++;
        }

        if (Game.GetWaveNumber() > 5)
        {
            for (int i = 0; i < destroyerEnemyCount; i++)
            {
                GameObject destroyerEnemy = GameObject.Instantiate(destroyerEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], destroyerEnemyFab.transform.rotation);
                destroyerEnemy.transform.position = new Vector3(destroyerEnemy.transform.position.x + UnityEngine.Random.Range(0, 10), destroyerEnemy.transform.position.y + UnityEngine.Random.Range(0, 10), destroyerEnemy.transform.position.z);
                EnemyInstance newEnemy = new EnemyInstance(new Enemy(Game.GetWaveNumber(), 5, 5, 7, 10, 50, 2, 15, Enemy.EnemyType.Destroyer), destroyerEnemy);
                destroyerEnemy.GetComponent<EnemyScript>().enemy = newEnemy;
                enemyInstanceList.Add(newEnemy);
            }

            destroyerEnemyCount++;
        }

        // has to destroy tiles
        if (Game.GetWaveNumber() > 10)
        {
            for (int i = 0; i < boomerEnemyCount; i++)
            {
                GameObject boomerEnemy = GameObject.Instantiate(boomerEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], boomerEnemyFab.transform.rotation);
                boomerEnemy.transform.position = new Vector3(boomerEnemy.transform.position.x + UnityEngine.Random.Range(0, 10), boomerEnemy.transform.position.y + UnityEngine.Random.Range(0, 10), boomerEnemy.transform.position.z);
                EnemyInstance newEnemy = new EnemyInstance(new Enemy(Game.GetWaveNumber(), 2, 10, 1, 3, 35, 2, 15, Enemy.EnemyType.Boomer), boomerEnemy);
                boomerEnemy.GetComponent<EnemyScript>().enemy = newEnemy;
                enemyInstanceList.Add(newEnemy);
            }

            boomerEnemyCount++;

            if (Game.GetWaveNumber() % 5 == 0)
            {
                for (int i = 0; i < bossEnemyCount; i++)
                {
                    GameObject bossEnemy = GameObject.Instantiate(bossEnemyFab, posList[UnityEngine.Random.Range(0, posList.Length)], bossEnemyFab.transform.rotation);
                    bossEnemy.transform.position = new Vector3(bossEnemy.transform.position.x + UnityEngine.Random.Range(0, 10), bossEnemy.transform.position.y + UnityEngine.Random.Range(0, 10), bossEnemy.transform.position.z);
                    EnemyInstance newEnemy = new EnemyInstance(new Enemy(Game.GetWaveNumber(), 5, 30, 2, 2, 35, 2, 15, Enemy.EnemyType.Boss), bossEnemy);
                    bossEnemy.GetComponent<EnemyScript>().enemy = newEnemy;
                    enemyInstanceList.Add(newEnemy);
                }
                tankEnemyCount++;
            }
        }
    }

    public bool IsAllDead() {
        // if (enemyInstanceList.Count == 0) {
        if (enemyInstanceList.Count == 0) {
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