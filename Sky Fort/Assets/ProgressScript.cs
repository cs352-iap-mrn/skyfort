using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressScript : MonoBehaviour
{
    public GameObject progressBar;
    public TowerInstance tower;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (tower.GetData() != null)
        {
            transform.localPosition = Camera.main.WorldToScreenPoint(tower.GetGameObject().transform.position + new Vector3(0, 12f, 0)) - new Vector3(533, 266, 0);

            if (tower.GetData() is Tower)
            {
                progressBar.transform.localScale = new Vector3((float)TechTree.GetProgress(tower.GetData() as Tower) /
                    ((tower.GetData() as Tower).GetCost()), 1f, 1f);
            } else
            {
                progressBar.transform.localScale = new Vector3((float)TechTree.GetProgress(tower.GetData() as Upgrade) /
                    ((tower.GetData() as Upgrade).GetCost()), 1f, 1f);
            }
            
        } else
        {
            transform.position = new Vector3(-1000f, -1000f, 0f);
        }
    }
}
