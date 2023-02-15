using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool isGround;

    float axisX;

    Rigidbody2D rigid;

    public HandGun handGun;
    public Animator anim;
    void Start()
    {
        health = maxHealth;
        rigid = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            isGround = false;     
        }
        
        
        if (Input.GetMouseButton(0))
        {
            handGun.Shoot();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            axisX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            gameObject.transform.Translate(Vector2.right * axisX);
            if (axisX < 0)           
                gameObject.GetComponent<SpriteRenderer>().flipX= true;
            else
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isRunning", true);
        }
        else
            anim.SetBool("isRunning", false);
    }

    private void Jump()
    {
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);        
    }
    
}
