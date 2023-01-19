using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public int pellets = 12;
    [SerializeField, Range(0, 0.1f)] 
    float spread;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Shoot()
    {
        shotFired.Play();
        for (int i = 0; i < pellets; i++)
        {
            if (Physics.Raycast(myCam.transform.position, myCam.transform.forward + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread)), out hit, range))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    //Playern träffar sin egna collider när den inte är på trigger
                    print("hit enemy");
                    enemy.TakeDamage(damage);
                }

                if (hit.rigidbody != null && hit.transform.tag == movable)
                {
                    hit.rigidbody.AddForce(-hit.normal, ForceMode.Impulse);
                }

                GameObject ImpactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)); //skapar paticlesystem - EN
                ImpactGO.transform.parent = hit.transform; //Parent av paticlesystemet blir samma som det man träffar så att ifall det flyttar på sig följer paticlesystemet med - EN
                Destroy(ImpactGO, 8);
            }
        }
    }
}
