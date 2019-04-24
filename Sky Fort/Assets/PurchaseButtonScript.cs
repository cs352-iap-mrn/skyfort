using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButtonScript : MonoBehaviour
{
    public Tower tower;
    public Text text;

    public GameObject towerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        text.text = tower.GetName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        if (Game.GetLumber() >= tower.GetCost())
        {
            Game.AddLumber(-tower.GetCost());

            int[] pos = Game.GetSelected().GetPosition();
            GameObject towerInstance = Instantiate(towerPrefab, new Vector3(pos[0] * 15, 2.5f, pos[1] * 15), towerPrefab.transform.rotation);

            towerInstance.GetComponent<TowerScript>().tower = tower;

            Game.GetSelected().SetUsed(true);

            Game.Select(null);
        }
    }
}
