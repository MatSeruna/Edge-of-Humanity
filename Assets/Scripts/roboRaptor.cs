using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboRaptor : Unit
{
    
    void Start()
    {
        maxHealth = 10;
        health = maxHealth;
        damage = 5;
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public override void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public override void Attack()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;
    }

}
