using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen : MonoBehaviour {

    public GameObject tileFab;

	// Use this for initialization
	void Start () {
        Tiles tiles = new Tiles(tileFab);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
