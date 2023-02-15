using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour
{
    

    public Weapons2[] weapons = { new Weapons2("Bolter", 10, 0.25f), new Weapons2("Bazooka", 10, 1f) };
    [SerializeField] private Bullet[] bullets;
    public int currentWeaponIndex = 0;
    public Transform bulletSpawner;
    private float lastShoottime = 0;
    AudioSource audioWeapon;

    public Sprite[] weaponImages;
    void Start()
    {     
        audioWeapon = GetComponent<AudioSource>();
    }

    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Alpha1))
            currentWeaponIndex= 0;
        if(Input.GetKeyDown(KeyCode.Alpha2))
            currentWeaponIndex = 1;

        if (currentWeaponIndex == 0)
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponImages[0];
        else if (currentWeaponIndex == 1)
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponImages[1];

    }

    public void Shoot()
    {
        if(weapons[currentWeaponIndex].ammoCount > 0)
        {
            if(Time.time > lastShoottime + weapons[currentWeaponIndex].fireRate)
            {
                Instantiate(bullets[currentWeaponIndex], new Vector2(bulletSpawner.position.x, bulletSpawner.position.y), bulletSpawner.rotation);               
                lastShoottime= Time.time;
                audioWeapon.Play();
                if(currentWeaponIndex>0)
                    weapons[currentWeaponIndex].ammoCount--;
            }           
        }
        else
        {
            Debug.Log("Нет патронов!");
        }
    }
    public struct Weapons2
    {
        public string name;
        public int ammoCount;
        public float fireRate;

        public Weapons2(string name, int ammoCount, float fireRate)
        {
            this.name = name;
            this.ammoCount = ammoCount;
            this.fireRate = fireRate;
        }
    }
}
