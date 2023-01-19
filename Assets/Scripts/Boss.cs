using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    int currentDeadHearts;
    int maxDeadHearts = 4;
    public AnimationClip hurtHeartAnimC;
    
    public override void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void Update()
    {
        if(currentDeadHearts <= maxDeadHearts)
        {
            print("Win :)");
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
