using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class door : MonoBehaviour
{
    public Animator DoorsOpen;
    public AnimationClip DoorAnim;
    [HideInInspector] public bool doorsOpen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (doorsOpen)
        {
            DoorsOpen.SetTrigger("IsOpen");
            doorsOpen = false;
        }
    }
}
