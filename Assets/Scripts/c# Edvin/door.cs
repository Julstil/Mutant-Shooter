using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class door : MonoBehaviour
{
    [HideInInspector]
    public bool doorsOpen = false;
    public Animator LeftDoor;
    public Animator RightDoor;

    // Start is called before the first frame update
    void Start()
    {
        doorsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorsOpen)
        {
            LeftDoor.enabled = true;
            RightDoor.enabled = true;
            doorsOpen = false;
        }
        
    }
}
