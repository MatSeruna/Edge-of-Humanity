using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public string nameWeapon;
    [SerializeField] public int ammoCount;
    [SerializeField] public float fireRate;

    [SerializeField] public GameObject bullet;
}
