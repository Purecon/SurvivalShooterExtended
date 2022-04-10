using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static int currentWave;
    public int maxWave;
    public int weight;
    public float weightMultiplier = 1.5f;
    public GameObject enemyManager;
    public GameObject weaponUpgradeManager;
    public GameObject winPanel;
    public float spawnTime;
    public int spawnPerTime;
    public static int enemyCount = 0;
    public int maxEnemyID = 2;
    public int maxStaticEnemyID = -1;

    EnemyManager[] enemyManagers;
    int tempWeight;
    float timer;
    int w = -1;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 1;
        timer = 0f;
        tempWeight = weight;
        enemyManagers = enemyManager.GetComponents<EnemyManager>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            int count = 0;
            while (count < spawnPerTime && tempWeight > 0)
            {
                w = -1;
                int emId = Random.Range(0, enemyManagers.Length);
                if (enemyManagers[emId].isStaticManager && maxStaticEnemyID >= 0)
                {
                    w = enemyManagers[emId].spawnWave(tempWeight, maxStaticEnemyID);
                }
                else if (!enemyManagers[emId].isStaticManager)
                {
                    w = enemyManagers[emId].spawnWave(tempWeight, maxEnemyID);
                }
                
                if (w != -1)
                {
                    tempWeight -= w;
                    enemyCount++;
                    count++;
                }
            }
            timer = 0f;
        }

        if (tempWeight == 0 && enemyCount == 0 && currentWave < maxWave)
        {
            currentWave++;
            timer = 0f;
            if (currentWave > maxWave)
            {
                //menang, jangan lupa tambah skor
            }
            nextWave();
        }

        if (tempWeight == 0 && enemyCount == 0 && currentWave == maxWave)
        {
            ScoreManager scoreManager = ScoreManager.Instance;
            scoreManager.AddScore(new Score(ScoreManager.playerName, ScoreManager.score,currentWave), false);
            scoreManager.SaveScore();
            winPanel.SetActive(true);
        }
    }

    void nextWave()
    {
        //update weight
        weight += Mathf.CeilToInt(currentWave * weightMultiplier);
        tempWeight = weight;

        //update spawtime and spawnpertime??

        //tambah skeleton enemy
        if (currentWave == 4)
        {
            maxStaticEnemyID++;
        }

        //tambah bomber enemy
        if (currentWave == 7)
        {
            maxEnemyID++;
        }

        //tambah skeleton band enemy
        if (currentWave == 10)
        {
            maxStaticEnemyID++;
        }

        if (currentWave % 3 == 0)
        {
            spawnBoss();
        }

        if (currentWave % 3 == 1)
        {
            weaponUpgradeManager.GetComponent<WeaponUpgradeManager>().enableOption();
        }
    }

    void spawnBoss()
    {
        int emId = Random.Range(0, enemyManagers.Length);
        enemyManagers[emId].spawnBoss();
        enemyCount++;
    }

}
