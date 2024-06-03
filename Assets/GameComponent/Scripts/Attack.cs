using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackDamage = 20.0f;
    public Vector2 Knockback = new Vector2(2, 1);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            Vector2 delivererdKnockback = transform.parent.localScale.x > 0 ? Knockback : new Vector2(-Knockback.x, Knockback.y);
            bool gothit = damageable.Hit(attackDamage, delivererdKnockback);
            if (gothit) Debug.Log(collision.name + "hiting" + attackDamage);
        }
    }
}
