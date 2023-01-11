using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class throwNade : MonoBehaviour
{
    /*Av Edvin
     * This script is made to be able to throw the grenade - EN
     */

    public float throwRate = 10;
    float throwRateTime;
    public float throwForce = 40;
    public float farFromPlayer = -1;
    public GameObject grenadePrefab;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        throwRateTime += Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && throwRate <= throwRateTime)
        {
            ThrowGrenade();
            throwRateTime = throwRate;
            throwRate = throwRate + throwRate;
        }
    }

    void ThrowGrenade()
    {
        GameObject granade = Instantiate(grenadePrefab, transform.position + transform.forward, transform.rotation); // skapar granaten från prefabs - EN
        Rigidbody rb = granade.GetComponent<Rigidbody>(); //hämtar granatens rigidbody - EN
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange); //Granaten kastas framåt - EN
    }
}
