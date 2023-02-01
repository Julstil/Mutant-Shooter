using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    /*Av Edvin
    * kod för att kunna kolla runt
    */

    public float mouseSens = 100f;
    float xRotation = 0f;

    //pb = playerBody - Edvin N
    public Transform pb;

    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        // gör så att musen tas bort och sätts i spel kamerans mitt - Edvin N
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        /*Använder sig av redan existerande kod för att kolla med musen, mouseSens = hur känslig musen ska vara och
        Time.deltaTime gör så att koden är inriktad med tiden och inte frameraten, 
        alltså att oavsett vilken framerate du har så kommer det inte påverka hur snabbt du roterar dig - Edvin N*/
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        //minus istället för plus eftersom plus flippar - Edvin N
        xRotation -= mouseY;
        // Mathf.Clamp eller Clamping sätter ett stopp för hur långt du kan titta så att du inte böjer spelgubbens nacke 180 grader - Edvin N
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //användning av xrotation - Edvin N
        cam.transform.rotation = Quaternion.Euler(xRotation, transform.eulerAngles.y, 0);
        //gör så att hela kroppen rör sig när man kollar runt y-axeln - Edvin N
        pb.Rotate(Vector3.up * mouseX);
        
    }
}
