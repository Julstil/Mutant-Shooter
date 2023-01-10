using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    /*Av Edvin
     * Kod för att röra sig
     */

    [Header("Movement Power")]
    public float speed = 6;
    public float jumpheight = 12;

    [Header("Jump checks")]
    bool isgrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 jump;

    Rigidbody Rb;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        jump = transform.up * jumpheight;
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

        if (Input.GetButtonDown("Jump") && isgrounded) //om isground är sann och man trycker på hopp knappen hoppar man - EN
        {
            Rb.AddForce(jump, ForceMode.Impulse); //Hoppar lika högt som jump variabeln säger (som lyssnar på jumpheight variabeln)- EN
            isgrounded = false;
        }
        
    }

}
