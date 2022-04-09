using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public bool isZenMode = true;
    public GameObject bossPrefab;
    public bool isStaticManager = false;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    public int enemyTypeNumber = 3;

    void Start ()
    {
        if (isZenMode)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, enemyTypeNumber);

        //Random enemy type
        Instantiate(Factory.FactoryMethod(spawnEnemy), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    public int spawnWave(int weight, int maxId)
    {
        if (playerHealth.currentHealth <= 0f || Factory.getMinWeight() > weight)
        {
            return -1;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, maxId+1);
        while (Factory.getWeight(spawnEnemy) > weight)
        {
            spawnEnemy = Random.Range(0, enemyTypeNumber);
        }
        

        Instantiate(Factory.FactoryMethod(spawnEnemy), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        return Factory.getWeight(spawnEnemy);
    }

    public void spawnBoss()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(bossPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
