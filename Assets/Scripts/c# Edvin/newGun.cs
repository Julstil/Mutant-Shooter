using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newGun : MonoBehaviour
{
    public Image crosshairBlue;
    public Image crosshairRed;
    public GameObject Revolver;
    public GameObject Shotgun;
    public string revolver;
    public string shotgun;
    [HideInInspector] public static bool weHaveRevolver;
    [HideInInspector] public static bool weHaveShotgun;

    movement movement;
    // Start is called before the first frame update
    void Start()
    {
        weHaveRevolver = false;
        weHaveShotgun = false;
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        crosshairBlue.enabled = false;
        crosshairRed.enabled = false;
        Revolver.SetActive(false);
        Shotgun.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && Revolver.name == revolver)
        {
            crosshairBlue.enabled = true;
            Revolver.SetActive(true);
            movement.Gun = Revolver;
            movement.gun = movement.gameObject.GetComponentInChildren<Gun>();
            weHaveRevolver = true;
            weHaveShotgun = false;
            movement.gunSaveScaleY = movement.Gun.transform.localScale.y;
            movement.Gun.transform.localRotation = Quaternion.Euler(movement.Gun.transform.localRotation.x, 90, movement.Gun.transform.localRotation.z);
            Destroy(gameObject);
        }
        else if (collision.transform.CompareTag("Player") && Shotgun.name == shotgun)
        {
            crosshairRed.enabled = true;
            Shotgun.SetActive(true);
            crosshairBlue.enabled = false;
            Revolver.SetActive(false);
            movement.Gun = Shotgun;
            movement.gun = movement.gameObject.GetComponentInChildren<Shotgun>();
            weHaveRevolver = false;
            weHaveShotgun = true;
            movement.gunSaveScaleY = movement.Gun.transform.localScale.y;
            movement.Gun.transform.localRotation = Quaternion.Euler(movement.Gun.transform.localRotation.x, 180, movement.Gun.transform.localRotation.z);
            Destroy(gameObject);
        }
    }
}
