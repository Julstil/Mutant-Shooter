using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator[] animatorList;
    public int currentAnim;
    public Animator animator;
    public AnimationClip animationClip;

    public bool[] boolList;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //currentAnim++;
            LoopEnd();
            animatorList[0].SetBool("Press", true);
            animatorList[0].SetBool("Idle", false);
            //StartCoroutine(LoopEnd());
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            animatorList[0].SetBool("Press", true);
            animatorList[currentAnim].SetBool("Idle", true);
            /*LoopEnd();
            StartCoroutine(LoopEnd());*/
        }
    }

    IEnumerable LoopEnd()
    {
        //animatorList[0].SetBool("LalA", isSinging) kan ändras med update
        animator.SetBool("Press", true);
        yield return new WaitForSeconds(animationClip.length);
        animator.SetBool("Press", false);
        print("press");
    }
}
