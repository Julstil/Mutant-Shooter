using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    [Header("Ammo")]
    public int addAmmo;
    public bool Ammo = false;

    [Header("Nade")]
    public int addNade;
    public bool Nade = false;

    [Header("Health Pack")]
    public int addHealth;
    public bool HealthPack = false;

    private Gun gun;
    private throwNade throwNade;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
        throwNade = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<throwNade>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Ammo)
            {
                if (gun.extraAmmo < gun.maxExtraAmmo)
                {
                    gun.OutsideAmmo(addAmmo);
                    Destroy(gameObject);
                }      

            }

            if (Nade)
            {                
                if (addNade > throwNade.maxNadeAmount)
                {
                    Destroy(gameObject);
                }
             
                if (addNade >= throwNade.maxNadeAmount)
                {
                    int savePickUp = addNade - throwNade.maxNadeAmount;
                    throwNade.OutsideNade(savePickUp);

                }
                else
                {
                    throwNade.OutsideNade(addNade);
                    Destroy(gameObject);
                }
            }

            if (HealthPack)
            {
                player.TakeHealing(addHealth);
                Destroy(gameObject);
            }
        }
    }
}
