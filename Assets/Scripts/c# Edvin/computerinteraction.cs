using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computerinteraction : MonoBehaviour
{
    [Header("Player variables")]
    public Camera playerCamera;
    public float distanceFromComputer = 2;
    public string cumputerTag;
    RaycastHit hitComputer;

    [Header("UI variables")]
    public Text pressButtenText;
    public Image img;
    public KeyCode openDoor;
    [HideInInspector]
    public bool doorsOpen = false;

    public Animator leftArmAnim;
    Animations animations;
    public AnimationClip animationClip;


    void Start()
    {
        doorsOpen = false;

        pressButtenText.text = "press " + openDoor + " to open the door";

        animations.GetComponent<Animations>();
    }

    
    void Update()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitComputer, distanceFromComputer))
        {
            if (hitComputer.transform.tag == cumputerTag)
            {

                img.enabled = true;
                pressButtenText.enabled = true;
                if (Input.GetKeyDown(openDoor))
                {
                    var door = hitComputer.transform.gameObject.GetComponent<door>();
                    door.doorsOpen = true;
                    //StartCoroutine(LoopEnd());
                }
            }
        }
        else
        {
            img.enabled = false;
            pressButtenText.enabled = false;
        }
    }
    IEnumerator LoopEnd()
    {
        //Lägg till en if-sats för att göra det snyggare
        leftArmAnim.SetBool("Press", true);
        yield return new WaitForSeconds(animationClip.length);
        leftArmAnim.SetBool("Press", false);
        leftArmAnim.SetBool("Idle", true);
        print("press");
    }
}
