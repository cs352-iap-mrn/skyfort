﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public int speed;
    public int buffer;

    private int width;
    private int height;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        width = Screen.width;
        height = Screen.height;

        if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= width
            && Input.mousePosition.y >= 0 && Input.mousePosition.y <= height)
        {
            float deltaX = Math.Max(0, buffer - (width - Input.mousePosition.x)) - Math.Max(0, buffer - Input.mousePosition.x);
            float deltaY = Math.Max(0, buffer - (height - Input.mousePosition.y)) - Math.Max(0, buffer - Input.mousePosition.y);

            deltaX = Math.Min(buffer, Math.Max(-buffer, deltaX));
            deltaY = Math.Min(buffer, Math.Max(-buffer, deltaY));

            int speedX = 0;
            if (deltaX != 0)
            {
                speedX = speed * (int)Math.Round(Math.Pow((deltaX / (buffer / 4.0)), 2) * (deltaX / Math.Abs(deltaX)));
            }

            int speedY = 0;
            if (deltaY != 0)
            {
                speedY = speed * (int)Math.Round(Math.Pow((deltaY / (buffer / 4.0)), 2) * (deltaY / Math.Abs(deltaY)));
            }

            transform.position = new Vector3(transform.position.x + speedX * Time.unscaledDeltaTime, transform.position.y, transform.position.z + speedY * Time.unscaledDeltaTime);
        }

        float change = Input.mouseScrollDelta.y;
        change *= 1.5f;

        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Mathf.Clamp(Camera.main.transform.position.y - Mathf.Clamp(change, -8f, 8f), 20f, 80f), Camera.main.transform.position.z);

    }
}
