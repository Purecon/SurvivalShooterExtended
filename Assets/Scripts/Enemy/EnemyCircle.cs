using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircle : MonoBehaviour
{
    public int attackDamage = 5;

    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    public EnemyAttack enemyAttack;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && other.isTrigger == false)
        {
            Attack();
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        enemyAttack.playerInRange = true;
    }

    void Attack()
    {
        playerHealth.TakeDamage(attackDamage);
    }
}
