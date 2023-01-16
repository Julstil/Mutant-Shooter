using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class door : MonoBehaviour
{
    public Animator DoorsOpen;
    public float AnimTimefps;
    float addAnimTime;
    bool stopAnim;

    computerinteraction computerinteraction;


    // Start is called before the first frame update
    void Start()
    {
        DoorsOpen = transform.GetComponentInParent<Animator>();
        computerinteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<computerinteraction>();

        stopAnim = false;
        DoorsOpen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (computerinteraction.doorsOpen)
        {
            addAnimTime += Time.deltaTime;
            print(computerinteraction.doorsOpen);
            DoorsOpen.enabled = true;
            if (addAnimTime >= AnimTimefps)
            {
                DoorsOpen.enabled = false;
                stopAnim = true;
                addAnimTime = 0;
            }
        }

        if (stopAnim)
        {
            computerinteraction.doorsOpen = false;
            stopAnim = false;
        }
    }
}
