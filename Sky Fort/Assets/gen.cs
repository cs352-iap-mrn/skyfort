using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {
        Tiles tiles = new Tiles(prefab);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
