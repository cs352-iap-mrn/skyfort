using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public GameObject content;
    public Dropdown dropDown;
    public Canvas canvas;

    public GameObject selectionButtonPrefab;

    int value = 0;

    // Start is called before the first frame update
    void Start()
    {
        dropDown.onValueChanged.AddListener(delegate {
            TypeChanged(dropDown);
        });

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

    public void TypeChanged(Dropdown changed)
    {
        value = changed.value;
        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform child in content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
        // 0 is Towers
        if (value == 0)
        {
            foreach (Tower t in TechTree.GetLockedTowers())
            {
                GameObject button = Instantiate(selectionButtonPrefab);
                button.transform.SetParent(content.transform);
                SelectionButtonScript script = button.GetComponent<SelectionButtonScript>();
                script.tower = t;
                script.Initialize();
            }
        } else
        {
            foreach (Upgrade t in TechTree.GetLockedUpgrades())
            {
                GameObject button = Instantiate(selectionButtonPrefab);
                button.transform.parent = content.transform;
                SelectionButtonScript script = button.GetComponent<SelectionButtonScript>();
                script.upgrade = t;
                script.Initialize();
            }
        }
    }
}
