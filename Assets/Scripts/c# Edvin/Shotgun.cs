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
            if (Physics.Raycast(myCam.transform.position, myCam.transform.forward + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread)), out headBob.hit, headBob.range))
            {
                Enemy enemy = headBob.hit.transform.GetComponent<Enemy>();

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

                GameObject ImpactGO = Instantiate(impactEffect, headBob.hit.point, Quaternion.LookRotation(headBob.hit.normal)); //skapar paticlesystem - EN
                ImpactGO.transform.parent = headBob.hit.transform; //Parent av paticlesystemet blir samma som det man träffar så att ifall det flyttar på sig följer paticlesystemet med - EN
                Destroy(ImpactGO, 8);
            }
        }
    }
}
