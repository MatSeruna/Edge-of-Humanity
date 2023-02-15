using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTaran : Unit
{
    Animator anim;
    public GameObject player;
    float speedRoll = 10f;
    bool isRolling = false;
    bool isStunned = false;
    bool isPreparing = false;
    bool isWakingUp = true;

    Rigidbody2D rb;
    CircleCollider2D collider2D;
    public GameManager gameManager;
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager.GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collider2D= GetComponent<CircleCollider2D>();
        maxHealth = 200;
        health = maxHealth;
        damage = 10;
        speed = 2f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isRolling)
        {
            Move();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            
            gameManager.healthBarBoss.SetActive(false);
        }

        if (transform.position.x < player.transform.position.x && isPreparing)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if(transform.position.x > player.transform.position.x && isPreparing)
            transform.localRotation = Quaternion.Euler(0, 0, 0);


    }

    public void GetPrepared()
    {
        anim.SetBool("isPreparing", true);
        anim.SetBool("isStunned", false);
        isPreparing = true;
        isStunned= false;
        isWakingUp= false;
    }
    public void GetStunned()
    {
        anim.SetBool("isAttacking", false);
        anim.SetBool("isStunned", true);
        collider2D.isTrigger = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        isStunned = true;
        isRolling = false;
    }

    public override void Move()
    {      
        collider2D.isTrigger = true;
        //rb.isKinematic= true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.Translate(new Vector2( -1f * speedRoll * Time.deltaTime, 0f));             
    }

    public override void Attack()
    {
        anim.SetBool("isPreparing", false);
        anim.SetBool("isAttacking", true);
        isPreparing = false;
        isRolling= true;
    }

    public override void TakeDamage(int damage)
    {
        if(isStunned && !isRolling && !isPreparing)
        {
            health -= damage;
        }     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().TakeDamage(damage);
        }

        if (collision.gameObject.tag == "Wall")
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isStunned", true);
            collider2D.isTrigger = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            isStunned = true;
            isRolling = false;
            Debug.Log("i hit the wall");
        }
    }   
}
