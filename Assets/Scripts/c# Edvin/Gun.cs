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
    public float fireRate = 1.5f;
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
    public int extraAmmo = 18;
    public int maxExtraAmmo = 50;
    public KeyCode Reload;
    public int maxAmmo = 6;
    [HideInInspector] public int Ammo = 6;
    public Text textAmmo;
    public float reloadTime = 5;
    //float[] reloadPoints = new float[reloadTime];
    bool canShoot;
    float adTime = 0;
    float shootsFired;
    bool startReload;
    public float offset = 2;
    float negReloadPosZ;
    float posReloadPosZ;
    int shootCounter;
    float nextCock;
    public float saveNextCock = 0.25f;
    bool canCock;

    [HideInInspector]
    public GameObject Enemy;

    public AudioSource shotFired;
    public AudioSource revolverCock;

    [HideInInspector] public headBobController headBob;

    public virtual void Start()
    {
        headBob = GetComponentInParent<headBobController>();
        canShoot = true;
        Ammo = maxAmmo;
        reloadTime = reloadTime / maxAmmo;
        negReloadPosZ = transform.localPosition.z - offset;
        posReloadPosZ = transform.localPosition.z;
        nextCock = 0;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
        textAmmo.text = Ammo + "/" + extraAmmo;
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && Ammo > 0 && canShoot)
        {
            nextTimeToFire = Time.time + 1 / fireRate; //Skapar en timer på hur långt tid mellan varje skott - EN
            print(gameObject.name);

            shootsFired = shootsFired + reloadTime;
            Shoot();
            canCock = true;
            muzzleFlash.Play(true);
            Ammo--;
            shootCounter++;
        }

        if (canCock)
        {
            nextCock += Time.deltaTime;        
            if (saveNextCock <= nextCock && revolverCock.isPlaying == false)
            {
                print("boom");

                revolverCock.Play();
                nextCock = 0;
                canCock = false;
            }
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
                revolverCock.Play();
                startReload = false;
            }
        }
    }

    public virtual void Shoot()
    {
        shotFired.Play();
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out headBob.hit, headBob.range))//skapar en raycast som kommer ut ifrån kameran - EN
        {
            print(headBob.hit.transform.name);

            Enemy enemy = headBob.hit.transform.GetComponent<Enemy>();
            Boss boss = headBob.hit.transform.GetComponent<Boss>();

            if (enemy != null)
            {
                //Playern träffar sin egna collider när den inte är på trigger
                print("hit enemy");
                enemy.TakeDamage(damage);
            }

            if (headBob.hit.rigidbody != null && headBob.hit.transform.tag == movable)
            {
                headBob.hit.rigidbody.AddForce(-headBob.hit.normal, ForceMode.Impulse);
            }

            if (enemy == null)
            {
                GameObject ImpactGO = Instantiate(impactEffect, headBob.hit.point, Quaternion.LookRotation(headBob.hit.normal)); //skapar paticlesystem - EN
                ImpactGO.transform.parent = headBob.hit.transform; //Parent av paticlesystemet blir samma som det man träffar så att ifall det flyttar på sig följer paticlesystemet med - EN
                Destroy(ImpactGO, 8);
            }

            if (boss != null)
            {

            }
        }
    }

    public virtual void OutsideAmmo(int outsideAmmo)
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