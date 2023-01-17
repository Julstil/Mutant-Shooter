using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator[] animatorList;
    public int currentAnim;

    public bool[] boolList;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            currentAnim++;
            animatorList[0].SetBool("Press", true);
            animatorList[0].SetBool("Idle", false);

        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            //animatorList[0].SetBool("Press", true);
            animatorList[currentAnim].SetBool("Idle", true);
        }
    }

    public void LoopEnd()
    {
        //animatorList[0].SetBool("LalA", isSinging) kan ändras med update
    }
}
