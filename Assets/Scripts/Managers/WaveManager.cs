using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    public int maxWave;
    public int weight;
    public float weightMultiplier = 1.5f;
    public GameObject enemyManager;
    public GameObject weaponUpgradeManager;
    public float spawnTime;
    public int spawnPerTime;
    public static int enemyCount = 0;

    EnemyManager[] enemyManagers;
    int tempWeight;
    float timer;
    bool isFightingBoss;
    
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
                int emId = Random.Range(0, enemyManagers.Length);
                tempWeight -= enemyManagers[emId].spawnWave(tempWeight);
                enemyCount++;
            }
            timer = 0f;
        }

        if (tempWeight == 0 && enemyCount == 0 && currentWave < maxWave)
        {
            currentWave++;
            timer = 0f;
            nextWave();
        }
    }

    void nextWave()
    {
        //update weight
        weight += Mathf.CeilToInt(currentWave * weightMultiplier);
        tempWeight = weight;

        //update spawtime and spawnpertime??
        
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
