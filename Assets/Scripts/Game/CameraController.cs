﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    //Camera movemant
    private float movingSpeed = 2f;

    // timer
    public static float timer;
    public static bool timeStarted = true;

    // level time in seconds
    public float levelTimeInSec = 20;

    void Update()
    {
        if (timer < levelTimeInSec)
        {
            transform.position += Vector3.up * Time.deltaTime * movingSpeed;
        }
        if (timer > levelTimeInSec)
        {
            timeStarted = false;
        }
        if (timeStarted == true)
        {
            timer += Time.deltaTime;
        }
    }

    void OnGUI()
    {
        float minutes = Mathf.Floor(timer / 60);
        float seconds = timer % 60;

        if (timer >= levelTimeInSec)
        {
            GUI.contentColor = Color.yellow;
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(10, 10, 250, 100), "boss fight");
        }
        else {
            GUI.Label(new Rect(10, 10, 250, 100), minutes + ":" + (60 - Mathf.RoundToInt(seconds)) + "s");
        }
    }
}

