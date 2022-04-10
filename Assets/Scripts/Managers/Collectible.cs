using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{


    GameObject player;
    PlayerShooting playerDmg;
    PlayerHealth playerHP;
    PlayerMovement playerSpeed;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = player.GetComponent<PlayerHealth>();
        playerDmg = player.GetComponentInChildren<PlayerShooting>();
        playerSpeed = player.GetComponent<PlayerMovement>();
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().CompareTag("PlayerChar"))
        {
            if (gameObject.CompareTag("HP"))
            {
                //Panggil ubah HP
                playerHP.HealthUpgrade();
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Power"))
            {
                //Panggil ubah Power
                playerDmg.PowerUpgrade();
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Speed"))
            {
                //Panggil ubah Speed
                playerSpeed.SpeedUpgrade();
                Destroy(gameObject);
            }
        }
        
    }

}