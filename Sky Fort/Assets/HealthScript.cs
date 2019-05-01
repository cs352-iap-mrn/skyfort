using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public interface Healthable
    {
        void AddHealth(int amount);
        int GetHealth();
        int GetMaxHealth();
        Vector3 GetPosition();
    }

    public GameObject healthBar;
    public Healthable healthable;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(healthable.GetHealth() + "; " + healthable.GetMaxHealth());

        transform.localPosition = Camera.main.WorldToScreenPoint(
            healthable.GetPosition() + new Vector3(0, 10f, 0)) - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        healthBar.transform.localScale = new Vector3((float)healthable.GetHealth() / (float)healthable.GetMaxHealth(), 1f, 1f);
    }
}
