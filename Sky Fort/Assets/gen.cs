using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen : MonoBehaviour {

    public GameObject tilePrefab;
    public GameObject towerPrefab;
    public GameObject enemyPrefab;

    public GameObject boomerEnemyPrefab;
    public GameObject bossEnemyPrefab;
    public GameObject destroyerEnemyPrefab;
    public GameObject tankEnemyPrefab;


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
        Tower baseTower = new Tower("none", 0, "Base", 100, Enemy.FocusPriority.Highest, 0, baseModel);

        TowerInstance towerInstance = new TowerInstance(baseTower, center, tower);

        TowerScript script = tower.GetComponent<TowerScript>();
        script.tower = towerInstance;
        script.tile = center;


        portals = new Portals(portalPrefab, 4);
        enemies = new Enemies(enemyPrefab, tankEnemyPrefab, destroyerEnemyPrefab, boomerEnemyPrefab, bossEnemyPrefab);


        center.SetUsed(true);
        center.Hold(towerInstance);

        Game.baseTower = towerInstance;

        TechTree.AddTower(false, new AttackTower("none", 10, "Arrow Tower", 10, Enemy.FocusPriority.Low, 20, 5, 200, projectilePrefab, arrowPrefab, arrowTowerModel));
        TechTree.AddTower(false, new AttackTower("none", 30, "Flamethrower", 20, Enemy.FocusPriority.Low, 10, 1, 1800, projectilePrefab, firePrefab, flamethrowerModel));
        TechTree.AddTower(false, new ResourceTower("none", 10, "Tree", 10, Enemy.FocusPriority.Low, 200, 1, smallTree));
        TechTree.AddTower(false, new UpgradeTower("none", 25, "Magical Archive", 35, Enemy.FocusPriority.Medium, 250, arcaneUpgradeModel));

        TechTree.AddTower(true, new AttackTower("Magical Archive", 25, "Javelin Tower", 40, Enemy.FocusPriority.Medium, 30, 10, 50, projectilePrefab, arrowPrefab, arrowTowerModel));
        TechTree.AddTower(true, new AttackTower("Magical Archive", 50, "Inferno Creator", 60, Enemy.FocusPriority.Medium, 25, 2, 2500, projectilePrefab, firePrefab, flamethrowerModel));
        TechTree.AddTower(true, new ResourceTower("Magical Archive", 50, "Large Tree", 75, Enemy.FocusPriority.Medium, 50, 10, pineTree));
        TechTree.AddTower(true, new UpgradeTower("Magical Archive", 50, "Forbidden Archive", 80, Enemy.FocusPriority.High, 1500, arcaneUpgradeModel));

        TechTree.AddUpgrade(false, new Upgrade("none", Upgrade.UpgradeType.Damage, .5, 12, "Minor Damage Bonus"));
        TechTree.AddUpgrade(false, new Upgrade("none", Upgrade.UpgradeType.Range, .25, 8, "Minor Range Bonus"));
        TechTree.AddUpgrade(false, new Upgrade("none", Upgrade.UpgradeType.Health, 2, 5, "Minor Health Bonus"));
        TechTree.AddUpgrade(false, new Upgrade("none", Upgrade.UpgradeType.AttackSpeed, .8, 15, "Minor Attack Speed Bonus"));

        TechTree.AddUpgrade(true, new Upgrade("Magical Archive", Upgrade.UpgradeType.Damage, 4, 30, "Major Damage Bonus"));
        TechTree.AddUpgrade(true, new Upgrade("Magical Archive", Upgrade.UpgradeType.AttackSpeed, 4, 25, "Major Attack Speed Bonus"));
        TechTree.AddUpgrade(true, new Upgrade("Magical Archive", Upgrade.UpgradeType.Gain, 2, 25, "Lumber Efficiency Bonus"));
        TechTree.AddUpgrade(true, new Upgrade("Magical Archive", Upgrade.UpgradeType.Health, 8, 30, "Major Health Bonus"));

        TechTree.AddUpgrade(true, new Upgrade("Forbidden Archive", Upgrade.UpgradeType.Health, 12, 75, "Extreme Health Bonus"));

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
                // enemies.UpdateEnemies();
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
