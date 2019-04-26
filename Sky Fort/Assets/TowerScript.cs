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
                    model = Instantiate(attackPrefab, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
                    model.transform.Rotate(new Vector3(1, 0, 0), 270);
                    model.transform.parent = transform;
                }
                else if (tower.GetModelName() == Tower.ModelType.Resource)
                {
                    model = Instantiate(resourcePrefab, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
                    model.transform.parent = transform;
                }
                else if (tower.GetModelName() == Tower.ModelType.Base)
                {
                    model = Instantiate(basePrefab, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
                    model.transform.Rotate(new Vector3(1, 0, 0), 270);
                    model.transform.parent = transform;
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
