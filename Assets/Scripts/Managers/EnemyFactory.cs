using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour,IFactory
{
    [SerializeField]
    public GameObject[] enemyPrefab;
    public int[] enemyWeight;

    public GameObject FactoryMethod(int tag)
    {
        //Note changeable
        //GameObject enemy = Instantiate(enemyPrefab[tag]);
        GameObject enemy = enemyPrefab[tag];
        return enemy;
    }

    public GameObject[] getArray()
    {
        return enemyPrefab;
    }

    public int getWeight(int i)
    {
        return enemyWeight[i];
    }
}
