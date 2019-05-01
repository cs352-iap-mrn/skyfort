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
        text.text = tower.GetName() + " (" + tower.GetCost() + ")";
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
            GameObject towerObject = Instantiate(towerPrefab, new Vector3(pos[0] * 15, 0f, pos[1] * 15), towerPrefab.transform.rotation);
            TowerInstance towerInstance = new TowerInstance(tower, Game.GetSelected(), towerObject);

            towerObject.GetComponent<TowerScript>().tower = towerInstance;
            towerObject.GetComponent<TowerScript>().tile = Game.GetSelected();

            Game.GetSelected().SetUsed(true);
            Game.GetSelected().Hold(towerInstance);

            Game.Select(null);
        }
    }
}
