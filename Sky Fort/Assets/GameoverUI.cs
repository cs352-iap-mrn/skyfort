using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverUI : MonoBehaviour
{
    public Text gameoverText;
    public Text scoreText;

    void Start()
    {
    }

    void Update()
    {
        if (Game.GetGameover())
        {
            GetComponent<Canvas>().enabled = true;
            scoreText.text = "Final Score: " + Game.GetScore();
        } 
        else {
            GetComponent<Canvas>().enabled = false;
        }

    }
}