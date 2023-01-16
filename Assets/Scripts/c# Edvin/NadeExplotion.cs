using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadeExplotion : MonoBehaviour
{
    /*Av Edvin
     * Kod för att kasta en healing granat till sina teammates
     */

    [Header("Nade explotion")]
    public float delay = 3;
    public float explotianRadius = 3;
    public int NadeDamage = 60;
    public GameObject explosionEffect;
    public float dissapear = 0.01f;
    
    [Header("Explotion force")]
    public float explotionForce;
    public float explosionDissapear = 1;
    
    Enemy enemy;
    bool hasExploded = false;

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0 && !hasExploded)
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            Explode();
        }
    }

    void Explode()
    {
        GameObject sys = Instantiate(explosionEffect, transform.position, Quaternion.Euler(Vector3.up));//skapar particlesystem - EN
        sys.GetComponent<ParticleSystem>().Play(); //spelar particlesystem - EN

        Collider[] colliders = Physics.OverlapSphere(transform.position, explotianRadius); //skapar en erray av colliders inom explotions radien - EN

        foreach (var insideBlastRadius in colliders)
        {
            var RigidBody = insideBlastRadius.transform.GetComponent<Rigidbody>();

            if (insideBlastRadius.transform.GetComponent<Enemy>())
            {
                enemy.TakeDamage(NadeDamage);
            }
            else { }
            if (RigidBody && RigidBody.transform.tag != "pickUp")
            {
                RigidBody.AddExplosionForce(explotionForce, transform.position, explotianRadius);
            }
        }
        //För varje colliders spelare som har samma tag som spelaren som kastade granaten ska healas med inten healThisMutch - EN

        hasExploded = true;
        Destroy(sys, explosionDissapear);
        Destroy(gameObject, dissapear);
    }
}