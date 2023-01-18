using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    /*public Animator[] animatorList;
    public int currentAnim;*/
    public Animator animator;
    public AnimationClip animationClip;

    //public bool[] boolList;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //currentAnim++;
            animator.SetBool("Press", true);
            animator.SetBool("Idle", false);
            StartCoroutine(LoopEnd());
        }
        /*if (Input.GetKeyDown(KeyCode.N))
        {
            animatorList[0].SetBool("Press", true);
            animatorList[currentAnim].SetBool("Idle", true);
        }*/
    }

    IEnumerator LoopEnd()
    {
        //animatorList[0].SetBool("LalA", isSinging) kan ändras med update
        animator.SetBool("Press", true);
        yield return new WaitForSeconds(animationClip.length);
        animator.SetBool("Press", false);
        animator.SetBool("Idle", true);
        print("press");
    }
}
