using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public GameObject content;
    public Dropdown dropDown;

    // Start is called before the first frame update
    void Start()
    {
        dropDown.onValueChanged.AddListener(delegate {
            TypeChanged(dropDown);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void TypeChanged(Dropdown changed)
    {
        Debug.Log(changed.value);
    }
}
