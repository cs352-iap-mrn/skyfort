using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour {

    public Canvas canvas;
    public Button button;
    private int x;
    private int y;
    private MeshRenderer localRenderer;

    public void OnMouseOver()
    {
        if (!Tiles.GetInstance().GetTile(x, y).Exists())
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
        button.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
	}

    public void SetXY(int[] coords)
    {
        this.x = coords[0];
        this.y = coords[1];
    }
}
