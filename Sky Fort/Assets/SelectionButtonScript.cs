using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionButtonScript : MonoBehaviour
{
    public GameObject rowPrefab;

    public Text title;

    public Upgrade upgrade;
    public Tower tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Initialize()
    {
        if (upgrade != null)
        {
            title.text = upgrade.GetName();

            GameObject button = Instantiate(rowPrefab);
            button.GetComponent<ButtonRowScript>().label.text = upgrade.GetDescription();
            Destroy(button.GetComponent<ButtonRowScript>().value);
            button.transform.parent = transform;
        }

        if (tower != null)
        {
            title.text = tower.GetName();

            string[] labels;
            string[] values;
            if (tower is AttackTower)
            {
                labels = new string[] {
                    "Cost:", "Health:", "Range:", "Damage:", "Attack Speed:"
                };

                values = new string[]
                {
                    tower.GetCost().ToString(),
                    tower.GetHealth().ToString(),
                    (tower as AttackTower).GetRange().ToString(),
                    (tower as AttackTower).GetDamage().ToString(),
                    tower.GetAttackSpeed().ToString()
                };
            }
            else if (tower is ResourceTower)
            {
                labels = new string[] {
                    "Cost:", "Health:", "Gain:", "Harvest Speed:"
                };

                values = new string[]
                {
                    tower.GetCost().ToString(),
                    tower.GetHealth().ToString(),
                    (tower as ResourceTower).GetGain().ToString(),
                    tower.GetAttackSpeed().ToString()
                };
            }
            else if (tower is UpgradeTower)
            {
                labels = new string[] {
                    "Cost:", "Health:", "Research Speed:"
                };

                values = new string[]
                {
                    tower.GetCost().ToString(),
                    tower.GetHealth().ToString(),
                    tower.GetAttackSpeed().ToString()
                };
            }
            else
            {
                labels = new string[0];
                values = new string[0];
            }

            for (int i = 0; i < labels.Length; i++)
            {
                GameObject button = Instantiate(rowPrefab);
                button.GetComponent<ButtonRowScript>().label.text = labels[i];
                button.GetComponent<ButtonRowScript>().value.text = values[i];
                button.transform.SetParent(transform);
            }
        }
    }

    public void Clicked()
    {
        TowerInstance instance = Game.GetSelectedTower();
        if (instance != null && instance.GetTower() is UpgradeTower)
        {
            System.Object data;
            if (upgrade != null)
            {
                data = upgrade;
            }
            else
            {
                data = tower;
            }
            instance.SetData(data);
        }

        Game.SelectTower(null);
    }
}
