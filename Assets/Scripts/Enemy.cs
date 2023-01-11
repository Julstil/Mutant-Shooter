﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy pathfinding - Saga & Luva
    public GameObject player;

    float distancePlayer;
    public float normalDistance;

    public float speed;

    bool chasing;
    public Transform[] patroling;
    int currentPoint;

    void Update()
    {
        distancePlayer = Vector3.Distance(transform.position, player.transform.position);

        //Eftersom den ska kunna gå tillbaka till att jaga, aka att speed inte ska vara 0 så har vi gjort den här if-satsen
        if (chasing == true)
        {
            //print("Tjena");
            speed = 3;
        }
        else
        {
            //print("stilla");
            speed = 1;
        }

        if(distancePlayer < normalDistance)
        {
            //Om avståndet mellan spelaren och enemyn är mindre än enemyns räckhåll så ska den börja jaga playern
            chasing = true;
            transform.LookAt(player.transform.position);
            transform.Translate(0, 0, speed * Time.deltaTime);

        }else if(distancePlayer > normalDistance)
        {
            //Här ändras speed till 2 och man börjar patrullera
            chasing = false;
            //Här ska den gå mot positionen listan patroling är på
            transform.LookAt(patroling[currentPoint].position);
            transform.Translate(0, 0, speed * Time.deltaTime);
            print("Patrullering");
            
        }
    }
    private void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            speed = 0;
        }
        else
        {
            speed = 5f;
        }

        if(obj.gameObject.tag == "PatrolPoints")
        {
            currentPoint++;
            print("point nr: " + currentPoint);

            if(currentPoint > patroling.Length -1)
            {//Om den nuvarande positionen är lika mycket som patrull listan (är på position 3) så ska den gå om
                currentPoint = 0;
            }
        }
    }
}