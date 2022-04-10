using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestructs());
    }
    
    IEnumerator SelfDestructs()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}

