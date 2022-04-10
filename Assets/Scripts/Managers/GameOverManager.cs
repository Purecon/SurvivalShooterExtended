using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject gameOverPanel;
    //public float restartDelay = 5f;            


    Animator anim;                          
    //float restartTimer;

    public Text warningText;
    bool isGameOver = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0 && !isGameOver)
        {
            anim.SetTrigger("GameOver");
            isGameOver = true;

            //Stoptime
            ScoreManager scoreManager = ScoreManager.Instance;
            scoreManager.StopTime();


            //Save score
            if (scoreManager.isZenMode)
            {
                scoreManager.AddScore(new Score(ScoreManager.playerName, ScoreManager.stopWatch.currentTime));
                TimeSpan time = TimeSpan.FromSeconds(ScoreManager.stopWatch.currentTime);
                gameOverPanel.transform.Find("Score").GetComponent<Text>().text = "Time: " + time.ToString(@"mm\:ss\:ff");
            }
            else
            {
                scoreManager.AddScore(new Score(ScoreManager.playerName, ScoreManager.score, WaveManager.currentWave), false);
                gameOverPanel.transform.Find("Score").GetComponent<Text>().text = "Score: " +ScoreManager.score.ToString() + "\n" + "Wave: " + WaveManager.currentWave.ToString();
            }
            scoreManager.SaveScore();
            //gameOverPanel.SetActive(true);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }
}