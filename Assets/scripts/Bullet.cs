using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int bulletDamage;

    private void OnCollisionEnter(Collision objectWeHit)
    {
        if (objectWeHit.gameObject.CompareTag("Target"))
        {
            print("hit " + objectWeHit.gameObject.name + " !");
            Destroy(gameObject);
        }

        if (objectWeHit.gameObject.CompareTag("Wall"))
        {
            print("hit a wall");
            Destroy(gameObject);
        }

        if (objectWeHit.gameObject.CompareTag("Enemy"))
        {
            objectWeHit.gameObject.GetComponent<EnemyAI>().TakeDamage(bulletDamage);

            Destroy(gameObject);
        }
    }
}
