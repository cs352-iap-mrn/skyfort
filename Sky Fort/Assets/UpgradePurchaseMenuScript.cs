using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePurchaseMenuScript : MonoBehaviour, TechTree.ITechtreeable
{
    public Canvas canvas;
    public GameObject content;
    public GameObject buttonPrefab;

    private TowerInstance selectedMemory;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;

        if (!TechTree.callbacks.Contains(this))
        {
            TechTree.callbacks.Add(this);
        }

        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.GetSelectedTower() != null && Game.GetSelectedTower() != selectedMemory)
        {
            selectedMemory = Game.GetSelectedTower();
            Refresh();
        }

        if (Game.GetSelectedTower() != null)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }

    public void Refresh()
    {
        if (Game.GetSelectedTower() != null)
        {
            foreach (Transform child in content.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            foreach (Upgrade u in Game.GetSelectedTower().GetTower().GetCompatibleUpgrades())
            {
                if (!Game.GetSelectedTower().HasUpgrade(u)) {
                    GameObject button = Instantiate(buttonPrefab);
                    UpgradePurchaseScript ups = button.GetComponent<UpgradePurchaseScript>();
                    ups.upgrade = u;
                    ups.upms = this;

                    button.transform.SetParent(content.transform);
                }
            }
        }
    }

    void OnDestroy()
    {
        if (TechTree.callbacks.Contains(this))
        {
            TechTree.callbacks.Remove(this);
        }
    }
}