using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpAmmo : MonoBehaviour
{
    private Gun gun;
    public int addAmmo;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gun.extraAmmo < gun.maxExtraAmmo)
            {
                gun.OutsideAmmo(addAmmo);
                Destroy(gameObject);
            }      
        }
    }
}
