using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light light;
    bool onOrOff = false;
    public KeyCode flashlight;
    // Start is called before the first frame update
    void Start()
    {
        light.enabled = false;
        onOrOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(flashlight) && !onOrOff)
        {
            light.enabled = true;
            onOrOff = true;
        }
        else if (Input.GetKeyDown(flashlight) && onOrOff)
        {
            light.enabled = false;
            onOrOff = false;
        }
    }
}
