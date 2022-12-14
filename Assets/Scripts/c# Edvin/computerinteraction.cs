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

    // Start is called before the first frame update
    void Start()
    {
        pressButtenText.text = "press " + openDoor + " to open the door";
    }

    // Update is called once per frame
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
                    GetComponent<door>().doorsOpen = true;
                }
            }
            else
            {
                img.enabled = false;
                pressButtenText.enabled = false;
            }
        }
    }
}
