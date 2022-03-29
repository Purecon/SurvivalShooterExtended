using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombAttack : EnemyAttack
{
    //Bomb Attack
    public ParticleSystem explosionParticles;
    
    protected override void Attack()
    {
        base.Attack();
        //Dead
        explosionParticles.Play();
        //Lakukan Take Damage
        enemyHealth.TakeDamage(999, transform.position);
        //enemyHealth.currentHealth = 0;
    }
}
