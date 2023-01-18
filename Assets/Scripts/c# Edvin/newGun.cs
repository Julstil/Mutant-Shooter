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
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(gameObject);
        }
        else if (collision.transform.CompareTag("Player") && Shotgun.name == shotgun)
        {
            crosshairRed.enabled = true;
            Shotgun.SetActive(true);
            crosshairBlue.enabled = false;
            Revolver.SetActive(false);
            Destroy(gameObject);
        }
    }
}
