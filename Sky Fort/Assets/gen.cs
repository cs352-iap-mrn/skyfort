using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen : MonoBehaviour {

    public GameObject tilePrefab;
    public GameObject towerPrefab;
    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
        Tiles tiles = new Tiles(tilePrefab);

        Tile center = tiles.GetTile(Tiles.SIZE / 2, Tiles.SIZE / 2);

        center.SetUsed(true);

        Tower baseTower = new Tower(0, "Base", 100, 100, 0);
        TowerInstance towerInstance = new TowerInstance(baseTower, center);
        center.Hold(towerInstance);
        GameObject tower = Instantiate(towerPrefab, new Vector3(Tiles.SIZE / 2 * 15, 0f, Tiles.SIZE / 2 * 15), towerPrefab.transform.rotation);
        TowerScript script = tower.GetComponent<TowerScript>();
        script.tower = towerInstance;
        script.tile = center;

        TechTree.AddTower(false, new AttackTower(10, "Basic Tower", 10, 0, 35, 5, 10));
        TechTree.AddTower(false, new ResourceTower(10, "Small Tree", 10, 10, 20, 1));

        TechTree.AddTower(true, new AttackTower(25, "Better Tower", 15, 0, 50, 10, 15));

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CancelBuild()
    {
        Game.Select(null);
    }
}
