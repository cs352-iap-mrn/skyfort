using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public GameObject towerContent;
    public GameObject upgradeContent;
    public Canvas canvas;

    public GameObject selectionButtonPrefab;

    int value = 0;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        canvas.enabled = (Game.GetSelectedTower() != null && Game.GetSelectedTower().GetTower() is UpgradeTower);

        if (TechTree.researchCompleted)
        {
            Refresh();
        }
    }

    public void Refresh()
    {
        foreach (Transform child in towerContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in upgradeContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Tower t in TechTree.GetLockedTowers())
        {
            GameObject button = Instantiate(selectionButtonPrefab);
            button.transform.SetParent(towerContent.transform);
            SelectionButtonScript script = button.GetComponent<SelectionButtonScript>();
            script.tower = t;
            script.Initialize();
        }

        foreach (Upgrade t in TechTree.GetLockedUpgrades())
        {
            GameObject button = Instantiate(selectionButtonPrefab);
            button.transform.SetParent(upgradeContent.transform);
            SelectionButtonScript script = button.GetComponent<SelectionButtonScript>();
            script.upgrade = t;
            script.Initialize();
        }
    }
}
