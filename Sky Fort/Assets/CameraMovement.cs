using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public int speed = 5;
    public int buffer = 100;

    private int width;
    private int height;

	// Use this for initialization
	void Start () {
        width = Screen.width;
        height = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= width
            && Input.mousePosition.y >= 0 && Input.mousePosition.y <= height)
        {
            float deltaX = Math.Max(0, buffer - (width - Input.mousePosition.x)) - Math.Max(0, buffer - Input.mousePosition.x);
            float deltaY = Math.Max(0, buffer - (height - Input.mousePosition.y)) - Math.Max(0, buffer - Input.mousePosition.y);

            deltaX = Math.Min(50, Math.Max(-50, deltaX));
            deltaY = Math.Min(50, Math.Max(-50, deltaY));

            int speedX = 0;
            if (deltaX != 0)
            {
                speedX = (int)Math.Round(Math.Pow((deltaX / 12.5), 2) * (deltaX / Math.Abs(deltaX)));
            }

            int speedY = 0;
            if (deltaY != 0)
            {
                speedY = (int)Math.Round(Math.Pow((deltaY / 12.5), 2) * (deltaY / Math.Abs(deltaY)));
            }

            transform.position = new Vector3(transform.position.x + speedX * Time.deltaTime, transform.position.y, transform.position.z + speedY * Time.deltaTime);
        }
        
    }
}
