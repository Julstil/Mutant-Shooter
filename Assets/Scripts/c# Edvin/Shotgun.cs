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
        print("träsktroll");
        //var pellets = 12;
        //var points = new Vector2[pellets];
        //var gd = new GaussianDistribution(); //maybe send a Random state through the ctor? I don't really use Unity's random any more
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
            //points[i] = new Vector2(gd.Next(0f, 1f, -1f, 1f), gd.Next(0f, 1f, -1f, 1f)); // y component is practically for free, check the code
        }

        /*var rays = new Ray[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            // do a transformation/move points forward to fix them a certain distance from your ray origin,
            // like in target practice, so that you have control over the actual spread size; say 6 meters
            var p3d = new Vector3(points[i].x, points[i].y, 6f); // oh we need to make them 3D anyway
            rays[i] = new Ray(Vector3.zero, p3d.normalized); // use a ray origin of zero, make everything gun-centric
        }*/
    }
}
