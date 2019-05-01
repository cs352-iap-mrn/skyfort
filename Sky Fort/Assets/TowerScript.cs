using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerScript : MonoBehaviour
{
    public TowerInstance tower;
    public Tile tile;

    public GameObject attackPrefab;
    public GameObject resourcePrefab;
    public GameObject basePrefab;
    public GameObject upgradePrefab;

    public MeshRenderer selectRenderer;
    public MeshRenderer attackRenderer;

    public GameObject attackRing;

    public GameObject upgradeBarPrefab;
    private GameObject upgradeBar;

    private bool run = false;

    // Start is called before the first frame update
    public void AddHealth(int amount)
    {
        tower.AddHealth(amount);
    }


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
                    model = Instantiate(attackPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    model.transform.Rotate(new Vector3(1, 0, 0), 270);
                    model.transform.SetParent(transform);
                }
                else if (tower.GetModelName() == Tower.ModelType.Resource)
                {
                    model = Instantiate(resourcePrefab, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
                    model.transform.SetParent(transform);
                }
                else if (tower.GetModelName() == Tower.ModelType.Base)
                {
                    model = Instantiate(basePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    model.transform.Rotate(new Vector3(1, 0, 0), 270);
                    model.transform.SetParent(transform);
                }
                else if (tower.GetModelName() == Tower.ModelType.Upgrade)
                {
                    model = Instantiate(upgradePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    model.transform.SetParent(transform);
                }
                run = true;
            }
        }

        if (selectRenderer != null)
        {
            if (Game.GetSelectedTower() == tower)
            {
                selectRenderer.enabled = true;
            } else
            {
                selectRenderer.enabled = false;
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

    public void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            tower.Click();
        }
    }

    public void OnMouseOver()
    {
        if (tower.GetTower() is AttackTower) {
            if (attackRenderer != null)
            {
                if (attackRing != null)
                {
                    int range = (tower.GetTower() as AttackTower).GetRange();
                        attackRing.transform.localScale = new Vector3(range, range, range);
                }

                attackRenderer.enabled = true;
            }
        } else if (tower.GetTower() is UpgradeTower && upgradeBar == null)
        {
            upgradeBar = Instantiate(upgradeBarPrefab, Game.progressCanvas.transform);
            upgradeBar.GetComponent<ProgressScript>().tower = tower;
        }
    }

    public void OnMouseExit()
    {
        if (tower.GetTower() is AttackTower)
        {
            if (attackRenderer != null)
            {
                attackRenderer.enabled = false;
            }
        }

        if (upgradeBar != null)
        {
            Destroy(upgradeBar);
            upgradeBar = null;
        }
    }
}
