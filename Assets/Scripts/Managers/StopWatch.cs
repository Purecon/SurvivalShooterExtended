using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StopWatch : MonoBehaviour
{
    bool stopwatchActive = true;
    float currentTime;
    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeText = GetComponent<Text>();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartStopWatch()
    {
        stopwatchActive = true;
    }

    public void StopStopWatch()
    {
        stopwatchActive = false;
    }
}
