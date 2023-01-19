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
    [HideInInspector] public bool weHaveRevolver;
    [HideInInspector] public bool weHaveShotgun;

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
            movement.gun = GetComponentInChildren<Gun>();
            weHaveRevolver = true;
            weHaveShotgun = false;
            Destroy(gameObject);
        }
        else if (collision.transform.CompareTag("Player") && Shotgun.name == shotgun)
        {
            crosshairRed.enabled = true;
            Shotgun.SetActive(true);
            crosshairBlue.enabled = false;
            Revolver.SetActive(false);
            movement.Gun = Shotgun;
            weHaveRevolver = false;
            weHaveShotgun = true;
            Destroy(gameObject);
        }
    }
}
