using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour, TechTree.ITechtreeable
{
    public GameObject towerContent;
    public GameObject upgradeContent;
    public Canvas canvas;

    public GameObject selectionButtonPrefab;

    private TowerInstance selectedMemory;

    // Start is called before the first frame update
    void Start()
    {

        if (!TechTree.callbacks.Contains(this))
        {
            TechTree.callbacks.Add(this);
        }

        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        canvas.enabled = (Game.GetSelectedTower() != null && Game.GetSelectedTower().GetTower() is UpgradeTower);

        if (Game.GetSelectedTower() != null && Game.GetSelectedTower() != selectedMemory && Game.GetSelectedTower().GetTower() is UpgradeTower)
        {
            selectedMemory = Game.GetSelectedTower();
            Refresh();
        }
    }

    public void Refresh()
    {
        if (selectedMemory != null)
        {
            string tag = (selectedMemory as TowerInstance).GetTower().tag;
            string name = (selectedMemory as TowerInstance).GetName();

            foreach (Transform child in towerContent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            foreach (Transform child in upgradeContent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            foreach (Tower t in TechTree.GetLockedTowers(name))
            {
                GameObject button = Instantiate(selectionButtonPrefab);
                button.transform.SetParent(towerContent.transform);
                SelectionButtonScript script = button.GetComponent<SelectionButtonScript>();
                script.tower = t;
                script.Initialize();
            }

            foreach (Upgrade t in TechTree.GetLockedUpgrades(name))
            {
                GameObject button = Instantiate(selectionButtonPrefab);
                button.transform.SetParent(upgradeContent.transform);
                SelectionButtonScript script = button.GetComponent<SelectionButtonScript>();
                script.upgrade = t;
                script.Initialize();
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
