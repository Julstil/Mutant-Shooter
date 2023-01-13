using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Enemy pathfinding - Saga & Luva
    public GameObject player;

    float distancePlayer;
    public float normalDistance;
    public float attackDistance;

    public float speed;

    bool chasing;
    public Transform[] patroling;
    int currentPoint;

    //Edvin lägger in damage - EN
    public int health = 200;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //speed = agent.speed;
    }
    void Update()
    {
        //agent.SetDestination(patroling[currentPoint].position);

        distancePlayer = Vector3.Distance(transform.position, player.transform.position);

        //Eftersom den ska kunna gå tillbaka till att jaga, aka att speed inte ska vara 0 så har vi gjort den här if-satsen
        if (chasing == true)
        {
            /*print("Tjena");*/
            agent.speed = 6;
        }
        else
        {
            /*print("stilla");*/
            agent.speed = 1;
        }

        if (distancePlayer < normalDistance)
        {
            print("attack");

            chasing = true;

            agent.SetDestination(player.transform.position);
            

        }
        else if (distancePlayer > normalDistance)
        {
            chasing = false;
            agent.SetDestination(patroling[currentPoint].position);
            print("Patrullering");
        }

#if false
        distancePlayer = Vector3.Distance(transform.position, player.transform.position);

        //Eftersom den ska kunna gå tillbaka till att jaga, aka att speed inte ska vara 0 så har vi gjort den här if-satsen
        if (chasing == true)
        {
            /*print("Tjena");*/
            speed = 3;
        }
        else
        {
            /*print("stilla");*/
            speed = 1;
        }

        if(distancePlayer < normalDistance)
        {
            //Om avståndet mellan spelaren och enemyn är mindre än enemyns räckhåll så ska den börja jaga playern
            chasing = true;
            //transform.LookAt(player.transform.position);
            //transform.Translate(0, 0, speed * Time.deltaTime);

        }else if(distancePlayer > normalDistance)
        {
            //Här ändras speed till 2 och man börjar patrullera
            chasing = false;
            //Här ska den gå mot positionen listan patroling är på
            //transform.LookAt(patroling[currentPoint].position);
            //transform.Translate(0, 0, speed * Time.deltaTime);
            print("Patrullering");
            /*print("Patrullering");*/
            
        }
        
        /*if(attackDistance > normalDistance || attackDistance < 2) //|
        {//Om attackDistance är större än normaldistance så ska den göra det här
            chasing = true;
            print("Attack");
        }*/

#endif
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //speed = 0; Den skrivs över av annan kod
            //Lägga till skada vid playern här? 
        }
        else
        {
            speed = 5f;
        }

        if(collider.gameObject.tag == "PatrolPoints")
        {
            currentPoint++;
            print("point nr: " + currentPoint);

            if(currentPoint > patroling.Length -1)
            {//Om den nuvarande positionen är lika mycket som patrull listan (är på position 3) så ska den gå om
                currentPoint = 0;
            }
        }
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            Die(); //Sätter igång die funktionen - EN
        }
    }

    public void Die()
    {
        print("Enemy Dead");
        //Ni får fylla i mer här sen - EN
    }
}
