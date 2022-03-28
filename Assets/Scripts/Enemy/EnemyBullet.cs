using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int attackDamage = 5;
    public float expiredTime = 10f;

    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > expiredTime)
        {
            //Disable after expire
            gameObject.SetActive(false);
            timer = 0;
        }
        
        if (playerInRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        //Disable after attack
        gameObject.SetActive(false);
        playerHealth.TakeDamage(attackDamage);
        playerInRange = false;
    }
}
