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

    public Animator anim;

    //Edvin lägger in damage - EN
    public int health = 200;
    public int DoDamage = 20;
    Player Player; //Glöm inte att referera den (lägga in det objekt som har den koden) -Saga
    [Range(0, 100)]public float dropAmmoChance = 80;
    //public GameObject GODropAmmo;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //speed = agent.speed;
    }
    void Update()
    {
        //agent.SetDestination(patroling[currentPoint].position);

        distancePlayer = Vector3.Distance(transform.position, player.transform.position);


        //Eftersom den ska kunna gå tillbaka till att jaga, aka att speed inte ska vara 0 så har vi gjort den här if-satsen
        if (chasing == true)
        {
            agent.speed = 6;
        }
        else
        {
            agent.speed = 1;
        }

        if (distancePlayer < normalDistance)
        {
            //Om avståndet mellan spelaren och enemyn är mindre än enemyns räckhåll så ska den börja jaga playern
            
            print("jaga");

            chasing = true;
            //anim.SetBool("", true);
            agent.SetDestination(player.transform.position);

        }
        else if (distancePlayer > normalDistance)
        {
            chasing = false;
            //Här ska den gå mot positionen listan patroling är på
            agent.SetDestination(patroling[currentPoint].position);

            print("Patrullering");
        }

        if (distancePlayer <= attackDistance)
        {
            //Om attackDistance är mindre än räckhållet mellan enemyn och playern så 
            print("attack");

            anim.SetBool("Attack", true);

            chasing = true;
            Player.TakeDamage(DoDamage);
            agent.SetDestination(player.transform.position);

        }else if(distancePlayer > attackDistance && distancePlayer < normalDistance)
        {
            //Om man inte är i attack distance men ändå nära nog för att jaga ska animationen kunna gå tillbaka till att jaga
            anim.SetBool("Attack", false);
            anim.SetBool("Run", true);
            print("running again");
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
    /*private void OnCollisionEnter(Collider collider)
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
            //print("point nr: " + currentPoint);

            if(currentPoint > patroling.Length -1)
            {//Om den nuvarande positionen är lika mycket som patrull listan (är på position 3) så ska den gå om
                currentPoint = 0;
            }
        }
    } */
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //speed = 0; Den skrivs över av annan kod
            //Lägga till skada vid playern här? 
        }
        else
        {
            speed = 5f;
        }

        if (collision.gameObject.tag == "PatrolPoints")
        {
            currentPoint++;
            //print("point nr: " + currentPoint);

            if (currentPoint > patroling.Length - 1)
            {//Om den nuvarande positionen är lika mycket som patrull listan (är på position 3) så ska den gå om
                currentPoint = 0;
            }
        }
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;
        anim.SetBool("Damage", true);
        print("pang pang");

        if (health <= 0)
        {
            Die(); //Sätter igång die funktionen - EN
        }

        if (!anim.IsInTransition(0))
        {
            print("Its done");
        }
    }

    public void LoopEnd()
    {
        anim.SetBool("Damage", false);
    }

    public void Die()
    {
        print("Enemy Dead");

        var dropAmmo = Random.Range(0, 100);
        if (dropAmmo <= dropAmmoChance)
        {
            //Instantiate(GODropAmmo, transform);
        }
        //Ni får fylla i mer här sen - EN
    }
}
