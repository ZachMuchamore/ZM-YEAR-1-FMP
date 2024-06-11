using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int HP = 100;


    public Transform player;

    private Animator anim;
    public bool dead;

    public LayerMask whatIsGround, whatIsPlayer;


   
    private void Awake()
    {
        player = GameObject.Find("player").transform;
        anim = GetComponent<Animator>();
        GlobalReferences.instance.hasDied = false;
        dead = false;
    }
    private void Update()
    {


    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            anim.SetTrigger("Die");
            GlobalReferences.instance.hasDied = true;
            GlobalReferences.instance.zombieNumber++;
            dead = true;
            DestroyZombie();

        }
        else
        {
            anim.SetTrigger("Damage");
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 160f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 150f);
    }

    private IEnumerator DestroyZombie()
    {
        yield return new WaitForSeconds(3f);
            Destroy(gameObject); 
        
    }

    
    


}
