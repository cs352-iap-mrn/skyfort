using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePurchaseScript : MonoBehaviour
{
    public Upgrade upgrade;
    public Text text;

    public UpgradePurchaseMenuScript upms;

    // Start is called before the first frame update
    void Start()
    {
        text.text = upgrade.GetName() + " (" + upgrade.GetCost() + ")";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        TowerInstance selectedTower = Game.GetSelectedTower();
        if (selectedTower != null)
        {
            if (Game.GetLumber() >= upgrade.GetCost())
            {
                selectedTower.AddUpgrade(upgrade);

                upms.Refresh();

                Game.AddLumber(-upgrade.GetCost()); 
            }
        }
    }
}
