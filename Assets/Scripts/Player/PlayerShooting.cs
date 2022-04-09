using UnityEngine;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float speedMultiplier = 1.1f;
    public float range = 100f;
    public int diagonalUpgrade = 1;
    public float maxAngle = 45f;
    public GameObject weaponLineRenderer;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    RaycastHit shootFloor;
    int shootableMask;
    int floorMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    List<GameObject> lineRenderers;
    public Light gunLight;
    public Light pointLight;
    float effectsDisplayTime = 0.2f;
    float shootAngle;
    float floordist;
    float enemydist;


    void Awake()
    {
        //GetMask
        shootableMask = LayerMask.GetMask("Shootable");
        floorMask = LayerMask.GetMask("Floor");

        //Mendapatkan Reference component
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        //pointLight = GetComponent<Light>();
        //gunLight = GetComponentInChildren<Light>();
        shootAngle = maxAngle;

		lineRenderers = new List<GameObject>
		{
			Instantiate(weaponLineRenderer, transform.position, Quaternion.identity)
		};

        //upgradeDiagonal();
        //upgradeSpeed();
        //upgradeSpeed();
        //upgradeSpeed();
        //upgradeDiagonal();
        //upgradeDiagonal();
        //upgradeDiagonal();
    }


    void Update()
    {

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        //disable line renderer
        gunLine.enabled = false;
        foreach (GameObject lr in lineRenderers)
        {
            lr.GetComponent<LineRenderer>().enabled = false;
        }
        //disable light
        gunLight.enabled = false;

        pointLight.enabled = false;
    }


    public void Shoot()
    {
        timer = 0f;

        //Play audio
        gunAudio.Play();

        //enable Light
        gunLight.enabled = true;
        pointLight.enabled = true;

        //Play gun particle
        gunParticles.Stop();
		gunParticles.Play();

        //enable Line renderer dan set first position
        //gunLine.enabled = true;
        //gunLine.SetPosition(0, transform.position);

        int count = 0;
        int positiveAngle = 1;
        foreach (GameObject lr in lineRenderers) { 
            

            lr.GetComponent<LineRenderer>().enabled = true;
            lr.GetComponent<LineRenderer>().SetPosition(0, transform.position);



            //Set posisi ray shoot dan direction
            shootRay.origin = transform.position;
            shootRay.direction = Quaternion.AngleAxis((count*positiveAngle*shootAngle), transform.up) * transform.forward;
            if (count == 0 || positiveAngle == -1)
            {
                count += 1;
                positiveAngle = 1;
            }
            else
            {
                positiveAngle = -1;
            }

            Debug.DrawRay(shootRay.origin, shootRay.direction * range, Color.red);

            //cek nabrak objek lain
            floordist = -1f;
            if (Physics.Raycast(shootRay, out shootFloor, range, floorMask))
            {
                //lr.GetComponent<LineRenderer>().SetPosition(1, shootFloor.point);
                floordist = Vector3.Distance(transform.position, shootFloor.point);
            }
            //Lakukan raycast jika mendeteksi id nemy hit apapun
            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                
                enemydist = Vector3.Distance(transform.position, shootHit.point); ;

                if (floordist == -1f || enemydist < floordist)
                {

                    //Lakukan raycast hit hace component Enemyhealth
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        //Lakukan Take Damage
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    //Set line end position ke hit position
                    //gunLine.SetPosition(1, shootHit.point);
                    lr.GetComponent<LineRenderer>().SetPosition(1, shootHit.point);
                }
                else
                {
                    lr.GetComponent<LineRenderer>().SetPosition(1, shootFloor.point);
                }
            }
            else if (floordist != -1f)
            {
                lr.GetComponent<LineRenderer>().SetPosition(1, shootFloor.point);
            }
            else
            {
                //set line end position ke range freom barrel
                //gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                lr.GetComponent<LineRenderer>().SetPosition(1, shootRay.origin + shootRay.direction * range);
            }

        }
    }

    public void upgradeSpeed()
    {
        timeBetweenBullets = timeBetweenBullets / speedMultiplier;
    }

    public void upgradeDiagonal()
    {
        lineRenderers.Add(Instantiate(weaponLineRenderer, transform.position, Quaternion.identity));
        lineRenderers.Add(Instantiate(weaponLineRenderer, transform.position, Quaternion.identity));
        diagonalUpgrade += 1;
        shootAngle = maxAngle / diagonalUpgrade;
    }

}