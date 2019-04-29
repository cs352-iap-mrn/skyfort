using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour
{
    // public Text countdownText;
    public Text countdownText;

    void Start()
    {
    }

    void Update()
    {
        if (!Countdown.IsWaveTime())
        {

            countdownText.gameObject.SetActive(true);
            countdownText.text = (10.0f - Countdown.GetTimer()).ToString("0");
            
        } 
        else {
            countdownText.gameObject.SetActive(false);
        }

    }
}