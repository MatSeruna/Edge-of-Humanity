using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool isGround;

    float axisX;

    Rigidbody2D rigid;

    public GameObject bullet;
    public Transform bulletSpawner;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            isGround = false;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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
        }
    }

    private void Jump()
    {
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
    private void Shoot()
    {

        Instantiate(bullet, new Vector2(bulletSpawner.position.x, bulletSpawner.position.y), bulletSpawner.rotation);
    }
}
