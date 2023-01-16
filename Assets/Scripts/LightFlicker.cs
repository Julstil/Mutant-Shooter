using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public GameObject[] lamp;
    public GameObject[] metalRoof;
    public GameObject[] lightRoof;

    private void Start()
    {
        StartCoroutine(LightFlick());
    }


    
    IEnumerator LightFlick() //Startar och stänger av lampor i ett mönster
    {
        while (true)
        {
           
            for (int i = 0; i < 4; i++)
            {
                LampOff();

                yield return new WaitForSeconds(0.04f);

                LampOn();

                yield return new WaitForSeconds(0.04f);

                LampOff();
            }

            yield return new WaitForSeconds(1f);
        }
       
    }

    private void LampOn() //Sätter på alla lampor
    {
        for (int i = 0; i < lamp.Length; i++)
        {
            lamp[i].gameObject.SetActive(true);
            metalRoof[i].gameObject.SetActive(false);
            lightRoof[i].gameObject.SetActive(true);
        }
    }

    private void LampOff() //Stänger av alla lampor
    {
        for (int i = 0; i < lamp.Length; i++)
        {
            lamp[i].gameObject.SetActive(false);
            metalRoof[i].gameObject.SetActive(true);
            lightRoof[i].gameObject.SetActive(false);
        }
    }

}
