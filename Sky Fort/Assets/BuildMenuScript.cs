using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuScript : MonoBehaviour
{
    public Canvas canvas;
    public GameObject content;
    public GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;

        foreach (Tower t in TechTree.GetAvailable())
        {
            GameObject button = Instantiate(buttonPrefab);
            PurchaseButtonScript pbs = button.GetComponent<PurchaseButtonScript>();
            pbs.tower = t;

            button.transform.SetParent(content.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.GetSelected() != null && !Game.GetSelected().Used())
        {
            canvas.enabled = true;
        } else
        {
            canvas.enabled = false;
        }

        if (TechTree.researchCompleted)
        {
            foreach (Transform child in content.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            foreach (Tower t in TechTree.GetAvailable())
            {
                GameObject button = Instantiate(buttonPrefab);
                PurchaseButtonScript pbs = button.GetComponent<PurchaseButtonScript>();
                pbs.tower = t;

                button.transform.SetParent(content.transform);
            }

            TechTree.researchCompleted = false;
        }
    }
}
