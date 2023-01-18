using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWin : MonoBehaviour
{
    public int heartAmount;
    public GameObject[] hearts;
    public GameObject finnishVein;

    private void Start()
    {
        hearts = new GameObject[heartAmount];
    }

    private void Update()
    {
        if(hearts.Length <= 0)
        {
            finnishVein.SetActive(false);
        }
    }
}
