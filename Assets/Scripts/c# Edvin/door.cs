using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class door : MonoBehaviour
{
    public Animator DoorsOpen;

    computerinteraction computerinteraction;


    // Start is called before the first frame update
    void Start()
    {
        DoorsOpen = transform.GetComponentInParent<Animator>();
        computerinteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<computerinteraction>();

        DoorsOpen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (computerinteraction.doorsOpen)
        {
            print(computerinteraction.doorsOpen);
            DoorsOpen.enabled = true;
            computerinteraction.doorsOpen = false;
        }
        
    }
}
