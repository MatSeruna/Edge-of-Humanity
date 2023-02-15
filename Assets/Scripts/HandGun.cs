using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private int currentWeaponIndex;
    public Transform bulletSpawner;
    private float lastShoottime = 0;
    void Start()
    {
        weapons[0].nameWeapon = "Bolter";
        weapons[0].fireRate = 0.25f;
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        if(weapons[currentWeaponIndex].ammoCount > 0)
        {
            if(Time.time > lastShoottime + weapons[currentWeaponIndex].fireRate)
            {
                Instantiate(weapons[currentWeaponIndex].bullet, new Vector2(bulletSpawner.position.x, bulletSpawner.position.y), bulletSpawner.rotation);
                weapons[currentWeaponIndex].ammoCount--;
                lastShoottime= Time.time;
            }
            
        }
        else
        {
            Debug.Log("Нет патронов!");
        }
    }
}
