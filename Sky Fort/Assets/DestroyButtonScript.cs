using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Clicked()
    {
        TowerInstance ti = Game.GetSelectedTower();
        if (ti != null)
        {
            //Tile tile = ti.GetTile();
            //if (tile.GetHeld() != null) {
            //    tile.SetUsed(false);
            //    Destroy(ti.GetGameObject());
            //    tile.Hold(null);
            //    Game.SelectTower(null);
            ti.AddHealth(-ti.GetHealth());
            Game.AddLumber((int)Math.Round((ti.GetCost() + ti.GetUpgradesSum()) / 3.0));
            //}
        }
    }
}
