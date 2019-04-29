using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileScript : MonoBehaviour {

    public Material baseMat;
    public Material selectedMat;

    public Canvas canvas;
    public GameObject panel;
    public Text text;

    private int x;
    private int y;
    private MeshRenderer localRenderer;
    private Light localLight;



    private Tile tile;

    public void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (tile.Exists() && !tile.Used())
            {
                Game.Select(tile);
            }

            if (!tile.Exists() && localRenderer.enabled)
            {
                int cost = 5 * (int)Math.Round(Math.Pow(Game.GetNumTiles() - 9, 1.2)) + 10;
                if (Game.GetLumber() >= cost)
                {
                    Game.AddLumber(-cost);
                    tile.SetExists(true);
                    canvas.enabled = false;
                    Game.AddTile(1);
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
                // text.text = "Purchase\n(" + cost + ")";

                localRenderer.enabled = true;
                canvas.enabled = true;
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
            canvas.enabled = false;
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
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update () {

        panel.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);

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
	}

    public void SetXY(int[] coords)
    {
        this.x = coords[0];
        this.y = coords[1];
    }
}
