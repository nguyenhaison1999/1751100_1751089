using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScipt : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; 
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
        if (enemy.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage); 
        }
        Destroy(gameObject);
    }

}
