using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileScript : MonoBehaviour {

    public Material baseMat;
    public Material selectedMat;

    //public Canvas canvas;
    //public GameObject panel;
    //public Text text;

    private int x;
    private int y;
    private MeshRenderer localRenderer;
    private Light localLight;

    private Tile tile;

    public GameObject purchasePrefab;
    private GameObject purchase;

    public void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (tile.Exists() && !tile.Used())
            {
                Game.Select(tile);
                Game.SelectTower(null);
            }

            if (!tile.Exists() && localRenderer.enabled)
            {
                int cost = 2 * (int)Math.Round(Math.Pow(Game.GetNumTiles() - 9, 1.2)) + 10;
                if (Game.GetLumber() >= cost)
                {
                    Game.AddLumber(-cost);
                    tile.SetExists(true);
                    Game.AddTile(1);

                    Destroy(purchase);
                    purchase = null;
                }
            }
        }
    }

    public void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            tile.hover = true;

            // if it doesn't exist, show purchase option
            if (!tile.Exists() && Tiles.GetInstance().HasAdjacentExist(x, y))
            { 
                int cost = 5 * (int)Math.Round(Math.Pow(Game.GetNumTiles() - 9, 1.2)) + 10;

                if (purchase == null)
                {
                    purchase = Instantiate(purchasePrefab, Game.tilePurchaseCanvas.transform);
                    Text[] texts = purchase.GetComponentsInChildren<Text>();
                    if (texts.Length > 0)
                    {
                        texts[0].text = "Purchase\n(" + cost + ")";
                    }
                }

                localRenderer.enabled = true;
            }
        } else
        {
            tile.hover = false;
        }
    }

    public void OnMouseExit()
    {
        tile.hover = false;

        if (!tile.Exists())
        {
            localRenderer.enabled = false;

            Destroy(purchase);
            purchase = null;
        }
    }


    // Use this for initialization
    void Start()
    {
        tile = Tiles.GetInstance().GetTile(x, y);

        localRenderer = GetComponent<MeshRenderer>();
        localRenderer.enabled = tile.Exists();
        localLight = GetComponent<Light>();
        localLight.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (purchase != null)
        {
            purchase.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
        }

        if (tile == Game.GetSelected() || (tile.hover && tile.Exists()))
        {
            localRenderer.material = selectedMat;
            localLight.enabled = true;
        }
        else
        {
            localRenderer.material = baseMat;
            localLight.enabled = false;
        }

        if (tile.Killed())
        {
            localRenderer.enabled = false;
        }

        tile.SetKilled(false);
	}

    public void SetXY(int[] coords)
    {
        this.x = coords[0];
        this.y = coords[1];
    }
}
