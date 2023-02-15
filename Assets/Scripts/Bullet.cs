using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Weapon weapon;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    void Start()
    {
        /*if(weapon != null && weapon.nameWeapon == "Bolter")
        speed = 30f;
        damage = 2;*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        roboRaptor robo = collision.gameObject.GetComponent<roboRaptor>();      
        if (collision.gameObject.tag == "Enemy")
        {
            if (robo != null)           
                robo.TakeDamage(damage);        

            if(collision.gameObject.name == "Boss_Taran")
                collision.gameObject.GetComponent<BossTaran>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
