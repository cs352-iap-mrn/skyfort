using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public Tower tower;

    private int cooldown;
    private int health = 25;


    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tower.Update();
    }
}
