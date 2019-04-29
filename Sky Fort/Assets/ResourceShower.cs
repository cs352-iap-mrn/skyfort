using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceShower : MonoBehaviour
{
    public Text lumber;
    public Text monster;

    // Start is called before the first frame update
    void Start()
    {
        lumber.text = Game.GetLumber().ToString();
        monster.text = Game.GetMP().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        lumber.text = Game.GetLumber().ToString();
        monster.text = Game.GetMP().ToString();
    }
}
