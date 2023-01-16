using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class door : MonoBehaviour
{
    public Animator LeftDoor;
    public Animator RightDoor;

    computerinteraction computerinteraction;


    // Start is called before the first frame update
    void Start()
    {
        LeftDoor = transform.GetComponentInChildren<Animator>();
        RightDoor = transform.GetComponentInChildren<Animator>();
        computerinteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<computerinteraction>();

        LeftDoor.enabled = false;
        RightDoor.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (computerinteraction.doorsOpen)
        {
            print(computerinteraction.doorsOpen);
            LeftDoor.enabled = true;
            RightDoor.enabled = true;
            computerinteraction.doorsOpen = false;
        }
        
    }
}
