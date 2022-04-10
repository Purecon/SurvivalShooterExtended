using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleAttack : EnemyAttack
{
    //Range attack
    public float rotateSpeedRanged;
    public float timeBetweenRangeAttacks = 2f;
    public float bulletSpeed = 10;
    float rangeAttacktimer;
    public Transform spawnBullet;
    public GameObject bullet;
    public ParticleSystem ParticleSystem;
    public Vector3 defaultScale;
    public int numberOfIncreased = 0;

    protected override void Attack()
    {
        var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        // Smoothly rotate 
        float time = 0f;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, time);
            time += Time.deltaTime * rotateSpeedRanged;
        }
        //Attack with object bullet
        if (rangeAttacktimer >= timeBetweenRangeAttacks)
        {
            if (numberOfIncreased >= 3)
            {
                bullet.transform.localScale = defaultScale;
                numberOfIncreased = 0;
            }
            else
            {
                IncreaseBulletSize();
            }
            rangeAttacktimer = 0f;
        }
    }

    void IncreaseBulletSize()
    {
        ParticleSystem.Play();
        var scaleChange = new Vector3(1f, 0, 1f);
        bullet.transform.localScale += scaleChange;
        numberOfIncreased +=1;
    }

    protected override void FixedUpdate()
    {
        rangeAttacktimer += Time.deltaTime;
        if (playerInRange)
        {
            anim.SetTrigger("PlayerInRange");
        }
        else
        {
            anim.ResetTrigger("PlayerInRange");
        }
        if (enemyHealth.currentHealth <= 0)
        {
            Destroy(bullet, 2f);
        }
        base.FixedUpdate();
    }
}
