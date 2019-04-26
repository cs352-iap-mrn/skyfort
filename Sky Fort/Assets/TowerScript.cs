using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public TowerInstance tower;
    public Tile tile;

    public GameObject attackPrefab;
    public GameObject resourcePrefab;
    public GameObject basePrefab;
    public GameObject upgradePrefab;

    private bool run = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (tower != null)
        {
            if (!run)
            {
                GameObject model;
                if (tower.GetModelName() == Tower.ModelType.Attack)
                {
                    model = Instantiate(attackPrefab, transform);
                    model.transform.parent = transform.parent;
                    model.transform.Translate(new Vector3(0, 2.5f, 0));
                }
                else if (tower.GetModelName() == Tower.ModelType.Resource)
                {
                    model = Instantiate(resourcePrefab, transform);
                    model.transform.parent = transform.parent;
                }
                else if (tower.GetModelName() == Tower.ModelType.Base)
                {
                    model = Instantiate(basePrefab, transform);
                    model.transform.parent = transform.parent;
                }
                else if (tower.GetModelName() == Tower.ModelType.Upgrade)
                {

                }
                run = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (tower != null)
        {
            tower.Update();
        }
    }
}
