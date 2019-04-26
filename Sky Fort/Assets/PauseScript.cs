using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    //public Button button;
    public Text text;

    public void OnPointerClick()
    {
        Time.timeScale = (Time.timeScale == 1f) ? 0f : 1f;
        text.text = (text.text == "Pause") ? "Resume" : "Pause";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
