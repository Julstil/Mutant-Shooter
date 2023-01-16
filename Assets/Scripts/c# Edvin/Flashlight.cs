using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light light;
    public KeyCode flashlight;
    // Start is called before the first frame update
    void Start()
    {
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(flashlight))
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }
}
