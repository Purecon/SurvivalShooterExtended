using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    Text text;
    public bool isZenMode = false; 

    public StopWatch stopWatch;

    public static String playerName = "defaultName";

    void Awake ()
    {
        stopWatch = GetComponent<StopWatch>();
        if (isZenMode && stopWatch)
        {
            stopWatch.StartStopWatch();
        }
        text = GetComponent<Text>();
        score = 0;
    }


    void Update ()
    {
        if (!isZenMode)
        {
            text.text = "Score: " + score.ToString();
        }
        else
        {
            TimeSpan time = TimeSpan.FromSeconds(stopWatch.currentTime);
            if (stopWatch.currentTime < 60)
            {
                text.text = "Time: " + time.ToString(@"ss\:ff");
            }
            else
            {
                text.text = "Time: " + time.ToString(@"mm\:ss\:ff");
            }
            //Debug.Log(time.ToString(@"mm\:ss\:ff"));
        }
        //Debug.Log("Score: " + score);
    }
}
