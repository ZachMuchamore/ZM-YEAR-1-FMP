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

    public LayerMask whatIsGround, whatIsPlayer;

    Rigidbody rb;


   
    private void Awake()
    {
        player = GameObject.Find("player").transform;
        Rigidbody rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

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
        Gizmos.DrawWireSphere(transform.position, 70f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 80f);
    }


}
