using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeManager : MonoBehaviour
{
    public GameObject gunBarrel;
    public GameObject upgradePanel;
    public GameObject score;
    public bool isZenMode = true;
    public float timeInterval = 60;
    public float intervalMultiplier = 1;
    public bool endwave;
    float lastUpgradeTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        upgradePanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isZenMode) {
            float time = score.GetComponent<StopWatch>().currentTime;

            if (time - lastUpgradeTime >= timeInterval)
            {
                lastUpgradeTime = time;
                timeInterval = timeInterval * intervalMultiplier;
                enableOption();
            }

        }
    }

    public void enableOption()
    {
        Time.timeScale = 0;
        upgradePanel.SetActive(true);
    }

    void disableOption()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void upgradeSpeed()
    {
        gunBarrel.GetComponent<PlayerShooting>().upgradeSpeed();
        disableOption();
    }

    public void upgradeDiagonal()
    {
        gunBarrel.GetComponent<PlayerShooting>().upgradeDiagonal();
        disableOption();
    }
}
