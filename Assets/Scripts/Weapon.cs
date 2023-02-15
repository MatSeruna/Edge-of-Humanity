using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{   
    [SerializeField] public string nameWeapon;
    [SerializeField] public int ammoCount;
    [SerializeField] public float fireRate;

    public Weapon(string name, int ammoCount, float fireRate)
    {
        nameWeapon= name;
        this.ammoCount = ammoCount;
        this.fireRate = fireRate;
    }
    //[SerializeField] public GameObject bullet;
}
