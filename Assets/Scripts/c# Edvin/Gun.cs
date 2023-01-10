using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /*Av Edvin
     * Kod för att kunna skjuta och skapa effekter när man skjuter och där man skjutit
     */

    [Header("Bullet stats")]
    public int damage = 10;
    public float range = 100;
    public float fireRate = 15;
    public float bulletSpeed = 100;
    public float impactForce = 50;

    [HideInInspector]
    public float nextTimeToFire = 0;

    [Header("Camera")]
    public Camera myCam;

    [Header("Bullet Flashes")]
    public GameObject impactEffect;
    public ParticleSystem muzzleFlash;

    [HideInInspector]
    public RaycastHit hit;



    [HideInInspector]
    public GameObject Enemy;

    private void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate; //Skapar en timer på hur långt tid mellan varje skott - EN

            Shoot();
            muzzleFlash.Play();
        }
    }

    public virtual void Shoot()
    {
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, range))//skapar en raycast som kommer ut ifrån kameran - EN
        {
            print(hit.transform.name);

            /*Player player = hit.transform.GetComponent<Player>();

            if (hit.transform != null && hit.transform.tag == Enemy.tag)
            {
                EnemyScript.TakeDamage(damage);
            }
            else { }*/

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal, ForceMode.Impulse);
            }

            GameObject ImpactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)); //skapar paticlesystem - EN
            ImpactGO.transform.parent = hit.transform; //Parent av paticlesystemet blir samma som det man träffar så att ifall det flyttar på sig följer paticlesystemet med - EN
            Destroy(ImpactGO, 8);
        }
    }
}