using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour {

    public Material baseMat;
    public Material selectedMat;

    public Canvas canvas;
    public GameObject panel;
    private int x;
    private int y;
    private MeshRenderer localRenderer;
    private Light localLight;

    private Tile tile;

    public void OnMouseUpAsButton()
    {
        if (tile.Exists() && !tile.Used())
        {
            Game.Select(tile);
        }
        
        if (!tile.Exists() && localRenderer.enabled)
        {
            if (Game.GetLumber() >= 10)
            {
                Game.AddLumber(-10);
                tile.SetExists(true);
                canvas.enabled = false;
            }
        } 
    }

    public void OnMouseOver()
    {
        tile.hover = true;

        // if it doesn't exist, show purchase option
        if (!tile.Exists() && Tiles.GetInstance().HasAdjacentExist(x, y))
        {
            localRenderer.enabled = true;
            canvas.enabled = true;
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
