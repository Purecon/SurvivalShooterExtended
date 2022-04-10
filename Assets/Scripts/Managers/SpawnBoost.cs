using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoost : MonoBehaviour
{
    public GameObject boost;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnOrb", spawnTime, spawnDelay);
    }

    public void SpawnOrb()
    {
        Instantiate(boost, transform.position, transform.rotation);



        if (stopSpawning)
        {
            CancelInvoke("SpawnOrb");
        }
    }

}
