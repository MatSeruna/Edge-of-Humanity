using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    public float speed;

    public bool isAttacking;
    
    
    public abstract void Move();
    
    public abstract void Attack();
    public abstract void TakeDamage(int damage);
    
}
