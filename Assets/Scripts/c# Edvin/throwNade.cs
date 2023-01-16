using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class throwNade : MonoBehaviour
{
    /*Av Edvin
     * This script is made to be able to throw the grenade - EN
     */

    public float throwRate = 1.5f;
    float throwRateTime;
    float savethrowRate;
    public float throwForce = 40;
    public float farFromPlayer = -1;
    public GameObject grenadePrefab;

    int currentAmountNade;
    public int maxNadeAmount = 2;
    bool newNade;
    public Text Nade;

    private void Start()
    {
        savethrowRate = throwRate;
        currentAmountNade = 1;
    }
    // Update is called once per frame
    void Update()
    {
        Nade.text = currentAmountNade + "/" + maxNadeAmount;

        if (Input.GetButtonDown("Fire2") &&  currentAmountNade > 0)
        {
            currentAmountNade--;
            ThrowGrenade();
            newNade = true;
        }

        if (newNade)
        {
            throwRateTime += Time.deltaTime;
            if (throwRate <= throwRateTime)
            {
                throwRateTime = throwRate;
                throwRate = throwRate + savethrowRate;
                if (currentAmountNade <= 0 && maxNadeAmount > 0)
                {
                    currentAmountNade++;
                    maxNadeAmount--;
                }

                newNade = false;
            }
        }
    }


    public void OutsideNade(int outsideNade)
    {
        maxNadeAmount += outsideNade;
        if (currentAmountNade <= 0)
        {
            currentAmountNade++;
            maxNadeAmount--;
        }
    }

    void ThrowGrenade()
    {
        GameObject granade = Instantiate(grenadePrefab, transform.position + transform.forward, transform.rotation); // skapar granaten från prefabs - EN
        Rigidbody rb = granade.GetComponent<Rigidbody>(); //hämtar granatens rigidbody - EN
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange); //Granaten kastas framåt - EN
    }
}
