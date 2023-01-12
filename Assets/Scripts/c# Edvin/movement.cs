using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    /*Av Edvin
     * Kod för att röra sig
     */

    [Header("Movement")]
    public float speed = 6;
    public float jumpheight = 12;
    float saveSpeed;

    [Header("Crouching")]
    public KeyCode crouch;
    public GameObject Gun;
    public float crouchSpeed;
    bool cancrouch;

    [Header("Sprint")]
    public KeyCode sprint;
    public float sprintSpeed;
    Gun gun;
    throwNade throwNade;

    [Header("Jump checks")]
    bool isgrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 jump;
    Rigidbody Rb;

    float saveScaleY;
    float gunSaveScaleY;

    // Start is called before the first frame update
    void Start()
    {
        throwNade = GetComponentInChildren<throwNade>();
        gun = GetComponentInChildren<Gun>();
        Rb = GetComponent<Rigidbody>();
        jump = transform.up * jumpheight;
        cancrouch = true;
        saveSpeed = speed;
        saveScaleY = transform.localScale.y;
        gunSaveScaleY = Gun.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {           
        isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //skapar en area som runt ett obijekt (i dett fall en empty) som kollar om den träffar den layer mas som jag skrivit in - EN

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; // Skapar två grid axlar som går i playerns x led och z led då origo är spelaren - EN
        move *= speed; // multiplicerar sen med speed då x och z variablarna är lika med 1 (får den att föras fortarre i dessa led) - EN
        move.y = Rb.velocity.y; //hastigheten i y axeln är lika stor som den får frå rigidbodyns "insatta kod" - EN
        Rb.velocity = move; // rigidbodyns hastighet är lika med move variabeln - EN

        if (Input.GetButtonDown("Jump") && isgrounded && !Input.GetKeyDown(crouch)) //om isground är sann och man trycker på hopp knappen hoppar man - EN
        {
            Rb.AddForce(jump, ForceMode.Impulse); //Hoppar lika högt som jump variabeln säger (som lyssnar på jumpheight variabeln)- EN
            isgrounded = false;
        }

        if (Input.GetKeyDown(sprint))
        {
            cancrouch = false;
            speed = sprintSpeed;
            Gun.transform.localRotation = Quaternion.Euler(Gun.transform.localRotation.x, 90, -80.367f);
            gun.enabled = false;
            throwNade.enabled = false;
        }
        else if (Input.GetKeyUp(sprint))
        {
            cancrouch = true;
            speed = saveSpeed;
            Gun.transform.localRotation = Quaternion.Euler(Gun.transform.localRotation.x, 90, 0);
            gun.enabled = true;
            throwNade.enabled = true;
        }

        if (cancrouch)
        {
            if (Input.GetKeyDown(crouch))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
                Gun.transform.localScale = new Vector3(Gun.transform.localScale.x, Gun.transform.localScale.y * 2, Gun.transform.localScale.z);
                speed = crouchSpeed;
            }
            else if (Input.GetKeyUp(crouch))
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
                Gun.transform.localScale = new Vector3(Gun.transform.localScale.x, Gun.transform.localScale.y / 2, Gun.transform.localScale.z);
                speed = saveSpeed;
            }
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, saveScaleY, transform.localScale.z);
            Gun.transform.localScale = new Vector3(Gun.transform.localScale.x, gunSaveScaleY, Gun.transform.localScale.z);
        }
    }
}
