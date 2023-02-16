using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboRaptor : Unit
{
    Animator anim;
    public GameObject player;
    public bool isTraining;
    
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        maxHealth = 10;
        health = maxHealth;
        damage = 5;
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking && !isTraining)
        {
            Move();           
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if(transform.position.x < player.transform.position.x)      
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 0, 0);

    }
    
    public override void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        anim.SetBool("isRunning", true);
    }

    public override void Attack()
    {      
        player.GetComponent<Player>().TakeDamage(damage);
    }
   
    public override void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (collision.gameObject.tag == "Player")
        {
            //player = collision.gameObject;
            anim.SetBool("isAttacking", true);
            anim.SetBool("isRunning", false);
            isAttacking = true;
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("isAttacking", false);          
            isAttacking = false;
            
        }
    }
}
