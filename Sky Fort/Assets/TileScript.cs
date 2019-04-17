using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class TileScript : MonoBehaviour {

    public Canvas canvas;
    public GameObject panel;
    private int x;
    private int y;
    private MeshRenderer localRenderer;

    public void OnMouseUpAsButton()
    {
        if (!Tiles.GetInstance().GetTile(x, y).Exists() && localRenderer.enabled)
        {
            if (Game.GetLumber() >= 10)
            {
                Game.AddLumber(-10);
                Tiles.GetInstance().GetTile(x, y).SetExists(true);
                canvas.enabled = false;
            }
        } 
    }

    public void OnMouseOver()
    {
        // show purchase option
        if (!Tiles.GetInstance().GetTile(x, y).Exists() && Tiles.GetInstance().HasAdjacentExist(x, y))
        {
            localRenderer.enabled = true;
            canvas.enabled = true;
        }
    }

    public void OnMouseExit()
    {
        if (!Tiles.GetInstance().GetTile(x, y).Exists())
        {
            localRenderer.enabled = false;
            canvas.enabled = false;
        }
    }


    // Use this for initialization
    void Start()
    {
        localRenderer = GetComponent<MeshRenderer>();
        localRenderer.enabled = Tiles.GetInstance().GetTile(x, y).Exists();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        panel.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);


	}

    public void SetXY(int[] coords)
    {
        this.x = coords[0];
        this.y = coords[1];
    }
}
