using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    //Camera movemant
    private float movingSpeed = 3f;

    // timer
    public static float timer;
    public static bool timeStarted = true;

    // level time in seconds
    float levelTimeInSec = 40;

    void Update()
    {
        float seconds = Mathf.RoundToInt(timer % 60);
        if (seconds < levelTimeInSec)
        {
            transform.position += Vector3.up * Time.deltaTime * movingSpeed;
            timer += Time.deltaTime;
        }
        if (seconds > levelTimeInSec)
        {
            timeStarted = false;
        }
    }

    void OnGUI()
    {
        float minutes = Mathf.Floor(timer / 60);
        float seconds = timer % 60;

        if (seconds >= levelTimeInSec - 1)
        {
            GUI.contentColor = Color.yellow;
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(10, 10, 250, 100), "boss fight");
        }
        else {
            GUI.Label(new Rect(10, 10, 250, 100), minutes + ":" + (levelTimeInSec - Mathf.RoundToInt(seconds)) + "s");
        }
    }
}

