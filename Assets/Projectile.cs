using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public Vector2 moveSpeed = new Vector2(3f,0);
    Rigidbody2D rb;

    public Vector2 Knockback = new Vector2(0, 0);
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //if you want the projectile to be effected by gravity by default, make it dynamic mode rigidbody
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            {
                Vector2 delivererdKnockback = transform.localScale.x > 0 ? Knockback : new Vector2(-Knockback.x, Knockback.y);
                bool gothit = damageable .Hit(damage, delivererdKnockback);
                if (gothit)
                {
                    Debug.Log(collision.name + "hiting" + damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
