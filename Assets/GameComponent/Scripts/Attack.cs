using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackDamage = 20.0f;
    public  Vector2 knockback = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null) 
        {
            bool gothit = damageable.Hit(attackDamage, knockback);
            if (gothit) Debug.Log(collision.name + "hiting" + attackDamage);
        }
    }
}
