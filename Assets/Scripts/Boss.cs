using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    int currentDeadHearts;
    int maxDeadHearts = 3;
    public AnimationClip hurtHeartAnimC;
    public GameObject vein;
    public GameObject[] hearts = new GameObject[3];
    public int[] healths = new int[3];
    
    public override void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        for (int i = 0; i < hearts.Length; i++)
        {
            healths[i] = 300;
            hearts[i].GetComponent<Enemy>().health = healths[i];
        }
    }

    public override void Update()
    {
        if(currentDeadHearts >= maxDeadHearts)
        {
            Destroy(vein);
        }


    }

    public override void TakeDamage(int Damage)
    {
        base.TakeDamage(Damage);
        
    }

    public override IEnumerator Hurt()
    {
        //Lägg till skada-animationer här - Saga
        
        yield return new WaitForSeconds(hurtHeartAnimC.length);
    }

    public override void Die()
    {
        //Lägg till döds animationer här - Saga
        
        Destroy(gameObject);
        currentDeadHearts++;
    }

}
