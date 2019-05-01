using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.GetSelectedTower() != null && !(Game.GetSelectedTower().GetTower().GetType() == typeof(Tower)))
        {
            transform.position = Camera.main.WorldToScreenPoint(Game.GetSelectedTower().GetGameObject().transform.position + new Vector3(0, 15f, 0));
        } else
        {
            transform.position = new Vector3(-100, -100, -100);
        }
    }

    public void Clicked()
    {
        TowerInstance ti = Game.GetSelectedTower();
        if (ti != null)
        {
            Tile tile = ti.GetTile();
            if (tile.GetHeld() != null) {
                tile.SetUsed(false);
                Destroy(ti.GetGameObject());
                tile.Hold(null);
                Game.SelectTower(null);

                Game.AddLumber((int)Math.Round((ti.GetCost() + ti.GetUpgradesSum()) / 3.0));
            }
        }
    }
}
