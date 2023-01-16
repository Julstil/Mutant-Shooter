using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public string movable;

    [HideInInspector]
    public float nextTimeToFire = 0;

    [Header("Camera")]
    public Camera myCam;

    [Header("Bullet Flashes")]
    public GameObject impactEffect;
    public ParticleSystem muzzleFlash;

    [Header("Reload")]
    public int extraAmmo;
    public int maxExtraAmmo = 50;
    public KeyCode Reload;
    public int maxAmmo = 6;
    int Ammo = 6;
    public Text textAmmo;
    public float reloadTime = 5;
    //float[] reloadPoints = new float[reloadTime];
    bool canShoot;
    float adTime = 0;
    float shootsFired;
    bool startReload;
    public float offset = 2;
    float negReloadPosZ;
    public float posReloadPosZ;
    int shootCounter;


    [HideInInspector]
    public RaycastHit hit;

    [HideInInspector]
    public GameObject Enemy;

    private void Start()
    {
        canShoot = true;
        Ammo = maxAmmo;
        reloadTime = reloadTime / maxAmmo;
        negReloadPosZ = transform.localPosition.z - offset;
        posReloadPosZ = transform.localPosition.z;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        textAmmo.text = "Ammo " + Ammo + "/" + extraAmmo;
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && Ammo > 0 && canShoot)
        {
            nextTimeToFire = Time.time + 1 / fireRate; //Skapar en timer på hur långt tid mellan varje skott - EN

            shootsFired = shootsFired + reloadTime;
            Shoot();
            muzzleFlash.Play();
            Ammo--;
            shootCounter++;
        }

        if (extraAmmo > 0)
        {
            if (Ammo <= 0 || Input.GetKeyDown(Reload))
            {
                //StartCoroutine(Reaload());
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, negReloadPosZ);
                canShoot = false;
                startReload = true;
            }
        }

        if (startReload)
        {
            if (extraAmmo < maxAmmo)
            {
                shootsFired = reloadTime * extraAmmo;
            }
            adTime += Time.deltaTime;
            if (adTime > shootsFired)
            {
                if (extraAmmo < maxAmmo)
                {
                    Ammo = extraAmmo;
                }
                else
                {
                    Ammo = maxAmmo;
                }

                adTime = 0;
                shootsFired = 0;
                canShoot = true;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, posReloadPosZ);
                extraAmmo = extraAmmo -= shootCounter;
                if (extraAmmo < 0)
                {
                    extraAmmo = 0;
                }
                shootCounter = 0;

                startReload = false;
            }
        }
    }

    public virtual void Shoot()
    {
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, range))//skapar en raycast som kommer ut ifrån kameran - EN
        {
            print(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null && hit.transform.tag == Enemy.tag)
            {
                enemy.TakeDamage(damage);
            }
            else { }

            if (hit.rigidbody != null && hit.transform.tag == movable)
            {
                hit.rigidbody.AddForce(-hit.normal, ForceMode.Impulse);
            }

            GameObject ImpactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)); //skapar paticlesystem - EN
            ImpactGO.transform.parent = hit.transform; //Parent av paticlesystemet blir samma som det man träffar så att ifall det flyttar på sig följer paticlesystemet med - EN
            Destroy(ImpactGO, 8);
        }
    }

    public void OutsideAmmo(int outsideAmmo)
    {
        extraAmmo += outsideAmmo;

        if (extraAmmo > maxExtraAmmo)
        {
            extraAmmo = maxExtraAmmo;
        }
    }

    IEnumerator Reaload()
    {
        /*float reloadPointsTime = reloadPoints.Length / maxAmmo;
        float adReloadTime = 0;
        float adTime = 0; 
        adTime += Time.deltaTime;
        if (adTime < reloadTime)
        {
            canShoot = false;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 1);
            for (int i = 0; i < maxAmmo;)
            {
                adReloadTime += Time.deltaTime;
                if (adReloadTime >= reloadPointsTime)
                {
                    Ammo++;
                    adReloadTime = 0;
                }
            }
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1);
            canShoot = true;
        }*/
        yield return new WaitForSeconds(shootsFired);
    }
}