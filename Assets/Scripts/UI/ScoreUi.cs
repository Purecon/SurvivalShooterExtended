using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ScoreUi : MonoBehaviour
{
    public RowUi rowUi;
    ScoreManager scoreManager;
    public int amountShown = 4;
    public bool isZen = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = ScoreManager.Instance;
        
        /*
        scoreManager.AddScore(new Score(ScoreManager.playerName,6));
        scoreManager.AddScore(new Score(ScoreManager.playerName,66));
        scoreManager.AddScore(new Score(ScoreManager.playerName, 86));
        scoreManager.AddScore(new Score(ScoreManager.playerName, 96));
        scoreManager.AddScore(new Score(ScoreManager.playerName, 99));

        scoreManager.AddScore(new Score(ScoreManager.playerName, 5),false);
        scoreManager.AddScore(new Score(ScoreManager.playerName, 66),false);
        scoreManager.AddScore(new Score(ScoreManager.playerName, 86),false);
        scoreManager.AddScore(new Score(ScoreManager.playerName, 55),false);
        scoreManager.AddScore(new Score(ScoreManager.playerName, 125),false);
        */

        if (isZen)
        {
            var scores = scoreManager.GetHighScores(isZen).ToArray();
            if(scores.Length < amountShown)
            {
                amountShown = scores.Length;
            }
            for (int i = 0; i < amountShown; i++)
            {
                var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
                row.rankText.text = (i + 1).ToString();
                row.nameText.text = scores[i].name;
                TimeSpan time = TimeSpan.FromSeconds(scores[i].score);
                row.scoreText.text = time.ToString(@"mm\:ss\:ff");
            }
        }
        else
        {
            var scores = scoreManager.GetHighScores(isZen).ToArray();
            if (scores.Length < amountShown)
            {
                amountShown = scores.Length;
            }
            for (int i = 0; i < amountShown; i++)
            {
                var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
                row.rankText.text = (i + 1).ToString();
                row.nameText.text = scores[i].name;
                row.scoreText.text = scores[i].score.ToString();
            }
        }
    }
}
