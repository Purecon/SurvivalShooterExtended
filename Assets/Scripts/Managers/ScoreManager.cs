using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    //scores : zenmode
    public List<Score> scores;
    //scores2 : wave
    public List<Score> scores2;

    Text text;
    public bool isZenMode = false;
    public bool isMainMenuMode = false;

    public StopWatch stopWatch;

    public static String playerName = "default";
    //Singleton
    public static ScoreManager Instance { get; private set; }

    void Awake ()
    {
        var json = PlayerPrefs.GetString("scores","{}");
        scores = JsonUtility.FromJson<List<Score>>(json);
        var json2 = PlayerPrefs.GetString("scores2", "{}");
        scores2 = JsonUtility.FromJson<List<Score>>(json2);

        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

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
        if (!isMainMenuMode)
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

    public IEnumerable<Score> GetHighScores(bool isZen)
    {
        if (isZen)
        {
            return scores.OrderByDescending(x => x.score);
        }
        else
        {
            return scores2.OrderByDescending(x => x.score);
        }
    }

    public void AddScore(Score score, bool isZen = true)
    {
        if (isZen)
        {
            scores.Add(score);
        }
        else
        {
            scores2.Add(score);
        }
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("scores",json);
        var json2 = JsonUtility.ToJson(scores2);
        PlayerPrefs.SetString("scores2", json);
    }
}
