using System.Collections;
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
    public GameObject flamethrowerModel;
    public GameObject smallTree;
    public GameObject pineTree;
    //public GameObject largeTree;
    public GameObject arcaneUpgradeModel;

    Portals portals; 
    Enemies enemies;

    GameObject tower;

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

        tower = Instantiate(towerPrefab, new Vector3(Tiles.SIZE / 2 * 15, 0f, Tiles.SIZE / 2 * 15), towerPrefab.transform.rotation);

        // Tower baseTower = new Tower(0, "Base", 100, Enemy.FocusPriority.Highest, 0, baseModel);
        Tower baseTower = new Tower(0, "Base", 100, Enemy.FocusPriority.Highest, 0, baseModel);

        TowerInstance towerInstance = new TowerInstance(baseTower, center, tower);

        TowerScript script = tower.GetComponent<TowerScript>();
        script.tower = towerInstance;
        script.tile = center;


        portals = new Portals(portalPrefab, 4);
        enemies = new Enemies(enemyPrefab);


        center.SetUsed(true);
        center.Hold(towerInstance);

        Game.baseTower = towerInstance;

        TechTree.AddTower(false, new AttackTower(10, "Basic Tower", 10, Enemy.FocusPriority.Low, 20, 2, 200, projectilePrefab, arrowPrefab, arrowTowerModel));
        TechTree.AddTower(false, new AttackTower(30, "Flamethrower", 20, Enemy.FocusPriority.Low, 20, 1, 2000, projectilePrefab, firePrefab, flamethrowerModel));
        TechTree.AddTower(false, new ResourceTower(10, "Small Tree", 10, Enemy.FocusPriority.Low, 200, 1, smallTree));
        TechTree.AddTower(false, new UpgradeTower(25, "Upgrade Tower", 35, Enemy.FocusPriority.Medium, 400, arcaneUpgradeModel));

        TechTree.AddTower(true, new AttackTower(25, "Better Tower", 15, Enemy.FocusPriority.Medium, 50, 10, 50, projectilePrefab, arrowPrefab, arrowTowerModel));
        TechTree.AddTower(true, new ResourceTower(50, "Pine Tree", 75, Enemy.FocusPriority.Medium, 50, 10, pineTree));

        TechTree.AddUpgrade(false, new Upgrade(Upgrade.UpgradeType.Damage, .5, 15, "Minor Damage Bonus"));

        TechTree.AddUpgrade(true, new Upgrade(Upgrade.UpgradeType.Damage, 2, 35, "Damage Bonus"));
        TechTree.AddUpgrade(true, new Upgrade(Upgrade.UpgradeType.Damage, 4, 50, "Major Damage Bonus"));

        TechTree.researchCompleted = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (tower == null)
        {
            Game.SetGameover(true);
            Time.timeScale = 0;
        }

        if (Countdown.IsWaveTime()) 
        {
            if (enemies.IsAllDead())
            {
                portals.RemoveAll();
                Countdown.SetWaveTime(false);
                Game.IncreaseScore(10);
            }
        } 
        else 
        {
            Countdown.SetTimer(Countdown.GetTimer() + Time.deltaTime);
            if (Countdown.GetTimer() > COUNT_DOWN) 
            {
                Countdown.SetWaveTime(true);
                Game.AddWaveNumber();

                // Spawn portals
                // NOTE: Must come before enemy spawn for getposition
                portals.SpawnPortals();

                // Update Enemy types based on waveNumber(static var in Game.cs) 
                // Then Spawn enemies
                enemies.UpdateEnemies();
                enemies.SpawnEnemies(portals.GetPositions());

                // Set back to original time
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
