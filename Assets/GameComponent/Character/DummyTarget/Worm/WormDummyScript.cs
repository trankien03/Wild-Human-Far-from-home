using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormDummyScrpit : MonoBehaviour
{

    // Start is called before the first frame update
    Damageable damageable;     
    Rigidbody2D rb;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
