using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {
        Tiles tiles = new Tiles(prefab);

        TechTree.AddTower(false, new AttackTower(10, "Basic Tower", 35, 5, 10));

        TechTree.AddTower(true, new AttackTower(25, "Better Tower", 50, 10, 15));

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CancelBuild()
    {
        Game.Select(null);
    }
}
