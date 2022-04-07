using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       
    public float restartDelay = 5f;            


    Animator anim;                          
    float restartTimer;

    public Text warningText;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

            //Stoptime
            ScoreManager scoreManager = ScoreManager.Instance;
            scoreManager.StopTime();

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                //Save score
                if (scoreManager.isZenMode)
                {
                    scoreManager.AddScore(new Score(ScoreManager.playerName, ScoreManager.stopWatch.currentTime));
                }
                else
                {
                    scoreManager.AddScore(new Score(ScoreManager.playerName, ScoreManager.score), false);
                }
                scoreManager.SaveScore();

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }
}