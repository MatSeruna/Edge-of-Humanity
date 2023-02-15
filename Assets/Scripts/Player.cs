using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool isGround;

    float axisX;

    Rigidbody2D rigid;

    public Transform handGunTransform;
    public HandGun handGun;
    
    public Animator anim;
    public bool isFacingRight = true;
    public bool isGunFacingRight = true;

    Vector3 pos;
    public Camera main;

    public GameManager gameManager;

    public Image BarImage;
    public Text BarText;
    public Gradient Color;
    float value;

    void Start()
    {
        health = maxHealth;
        rigid = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        BarImage.color = Color.Evaluate(3);
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
        pos = main.WorldToScreenPoint(transform.position);

        BarText.text = health + "/" + maxHealth;
        value = ((health * 100f) / maxHealth) / 100f;
        BarImage.fillAmount = value;
        BarImage.color = Color.Evaluate(value);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            anim.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Trigger_BossTaran")
        {
            gameManager.StartBossBattle();
        }
    }

    private void Move()
    {
        //Flip2();
        if (Input.GetButton("Horizontal"))
        {
            axisX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            gameObject.transform.Translate(Vector2.right * axisX);
            if (isFacingRight && axisX < 0)
            {
                Flip();
                FlipHand();
                //gameObject.GetComponent<SpriteRenderer>().flipX= true;
            }
            else if(!isFacingRight && axisX >0)
            {
                Flip();
                FlipHand();
            }
                //gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isRunning", true);
        }
        else
            anim.SetBool("isRunning", false);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Jump()
    {
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetBool("isJumping", true);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void FlipHand()
    {
        isGunFacingRight = !isGunFacingRight;
        Vector3 Scaler2 = handGunTransform.localScale;
        Scaler2.x *= -1;
        Scaler2.y *= -1;
        handGunTransform.localScale = Scaler2;
    }

    private void Flip2()
    {
        if (Input.mousePosition.x < pos.x)
        {

        }
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (Input.mousePosition.x > pos.x)
        {

        }
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
