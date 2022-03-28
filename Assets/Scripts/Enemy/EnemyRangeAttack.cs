using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : EnemyAttack
{
    //Range attack
    public float rotateSpeedRanged;
    public float timeBetweenRangeAttacks = 2f;
    public float bulletSpeed = 10;
    float rangeAttacktimer;
    public Transform spawnBullet;

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
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = spawnBullet.position;
                bullet.transform.Rotate(0,transform.rotation.y,0);
                //bullet.GetComponent<Rigidbody>().AddForce(spawnBullet.forward * bulletSpeed, ForceMode.VelocityChange);
                bullet.GetComponent<Rigidbody>().velocity = spawnBullet.forward * bulletSpeed;

                bullet.SetActive(true);
            }
            rangeAttacktimer = 0f;
        }
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
        base.FixedUpdate();
    }
}
