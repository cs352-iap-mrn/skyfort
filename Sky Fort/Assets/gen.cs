﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen : MonoBehaviour {

    public GameObject tilePrefab;
    public GameObject towerPrefab;
    public GameObject enemyPrefab;

    public GameObject portalPrefab;

    public GameObject projectilePrefab;
    public GameObject arrowPrefab;
    public GameObject firePrefab;

    public GameObject baseModel;
    public GameObject arrowTowerModel;
    //public GameObject flamethrowerModel;
    public GameObject smallTree;
    public GameObject pineTree;
    //public GameObject largeTree;
    public GameObject arcaneUpgradeModel;


    Portals portals; 
    Enemies enemies;

    //public GameObject enemy;

    private readonly float COUNT_DOWN = 10.0f;

    public Canvas progressCanvas;
    public Canvas tilePurchaseCanvas;

	// Use this for initialization
	void Start () {
        Game.progressCanvas = progressCanvas;
        Game.tilePurchaseCanvas = tilePurchaseCanvas;

        Tiles tiles = new Tiles(tilePrefab);

        Tile center = tiles.GetTile(Tiles.SIZE / 2, Tiles.SIZE / 2);

        GameObject tower = Instantiate(towerPrefab, new Vector3(Tiles.SIZE / 2 * 15, 0f, Tiles.SIZE / 2 * 15), towerPrefab.transform.rotation);

        Tower baseTower = new Tower(0, "Base", 100, Enemy.FocusPriority.Highest, 0, baseModel);

        TowerInstance towerInstance = new TowerInstance(baseTower, center, tower);

        TowerScript script = tower.GetComponent<TowerScript>();
        script.tower = towerInstance;
        script.tile = center;

        center.SetUsed(true);
        center.Hold(towerInstance);

        Game.baseTower = towerInstance;

        TechTree.AddTower(false, new AttackTower(10, "Basic Tower", 10, Enemy.FocusPriority.Low, 20, 2, 200, projectilePrefab, arrowPrefab, arrowTowerModel));
        TechTree.AddTower(false, new AttackTower(30, "Flamethrower", 20, Enemy.FocusPriority.Low, 20, 1, 2000, projectilePrefab, firePrefab));
        TechTree.AddTower(false, new ResourceTower(10, "Small Tree", 10, Enemy.FocusPriority.Low, 200, 1));
        TechTree.AddTower(false, new UpgradeTower(25, "Upgrade Tower", 35, Enemy.FocusPriority.Medium, 400));

        TechTree.AddTower(true, new AttackTower(25, "Better Tower", 15, Enemy.FocusPriority.Medium, 50, 10, 50, projectilePrefab, arrowPrefab));
        TechTree.AddTower(true, new ResourceTower(50, "Big Tree", 75, Enemy.FocusPriority.Medium, 50, 10));

        TechTree.AddUpgrade(false, new Upgrade(Upgrade.UpgradeType.Damage, .5, 15, "Minor Damage Bonus"));

        TechTree.AddUpgrade(true, new Upgrade(Upgrade.UpgradeType.Damage, 2, 35, "Damage Bonus"));
        TechTree.AddUpgrade(true, new Upgrade(Upgrade.UpgradeType.Damage, 4, 50, "Major Damage Bonus"));

        TechTree.researchCompleted = true;
    }
	
	// Update is called once per frame
	void Update () {
         // test (remove later)

        // if (!Countdown.IsWaveTime()) {
        //     Portals portals = new Portals(portalPrefab, 4);
        //     enemy = Instantiate(enemyPrefab, new Vector3(150, 7, 90), enemyPrefab.transform.rotation);
        //     enemy = Instantiate(enemyPrefab, new Vector3(0, 7, 90), enemyPrefab.transform.rotation);
        //     enemy = Instantiate(enemyPrefab, new Vector3(90, 7, 150), enemyPrefab.transform.rotation);
        //     enemy = Instantiate(enemyPrefab, new Vector3(90, 7, 0), enemyPrefab.transform.rotation);

            // Portals portals = new Portals(1);
        //     // portals.CreateAll();
        //     // Instantiate(portalPrefab, new Vector3(90, 7, 90), portalPrefab.transform.rotation);
        //     // Instantiate(portalPrefab, new Vector3(60, 7, 90), portalPrefab.transform.rotation);
        //     // waveTime = true;
        //     Countdown.SetWaveTime(true);

        // } 


        if (Countdown.IsWaveTime()) 
        {
            // They are all in initial position (triggered off together with IsAllDead all dead)
            // if (enemies.InInitPosition())
            // {
            // This will trigger when portals are still active
            // if (portals.GetEnable())
            // {
            //     // This destroys portals
            //     portals.RemoveAll();
            //     // This is set now
            //     portals.SetEnable(false);
            // }

            // This will trigger when all enemies die
            if (enemies.IsAllDead())
            {
                portals.RemoveAll();
                // waveTime = false;
                Countdown.SetWaveTime(false);
                // QUESTION: Maybe add before game start?
                // Game.AddWaveNumber();
            }

            // Move towards nexus & calculate range(when in range, change state to attack, otherwise moving state) & calculate priorities according to speed)
            // enemies.Act();
            // }
            // else
            // {
            //     if (!portals.GetEnable())
            //     {
            //         portals.SetEnable(true);
            //     }
            // This will trigger InitPositionSet to true after done ()
            // enemies.MoveToInitPos();
            // }
        } 
        else 
        {
            Countdown.SetTimer(Countdown.GetTimer() + Time.deltaTime);
            if (Countdown.GetTimer() > COUNT_DOWN) 
            {
                // waveTime = true;
                Countdown.SetWaveTime(true);
                Game.AddWaveNumber();
                portals = new Portals(portalPrefab, 4);
                enemies = new Enemies(enemyPrefab, portals.GetPositions());

                enemies.UpdateEnemies();
                enemies.SpawnEnemies();
                // Set back to original time
                // timer = timer - COUNT_DOWN;
                Countdown.SetTimer(Countdown.GetTimer() - COUNT_DOWN);
            }
        }

        TechTree.Update();
	}

    void CancelBuild()
    {
        Game.Select(null);
    }

    void CancelUpgrades()
    {
        Game.SelectTower(null);
    }
}
