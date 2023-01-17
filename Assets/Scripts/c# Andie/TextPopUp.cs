using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour
{
    public Text text;
    public GameObject trigger;
    public float timer;

    private void Start()
    {
        text.gameObject.SetActive(false);
        timer = -6;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = 0;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < -5)
        {
            text.gameObject.SetActive(false);
        }
        else if(timer > -5)
        {
            text.gameObject.SetActive(true);
        }
        else if (timer < -20)
        {
            trigger.SetActive(false);
        }
    }
}
