using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int HP = 100;

    public NavMeshAgent agent;

    public Transform player;

    private Animator anim;

    public LayerMask whatIsGround, whatIsPlayer;

    Rigidbody rb;


   
    private void Awake()
    {
        player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
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
            Destroy(gameObject);
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
        Gizmos.DrawWireSphere(transform.position, 35f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 30f);
    }


}
