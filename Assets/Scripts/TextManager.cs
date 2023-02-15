using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Player player;
    public GameObject handGun;

    public Text healthText;
    public Text ammoCountText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int idWeapon = handGun.GetComponent<HandGun>().currentWeaponIndex;
        healthText.text = $"{player.health}/{player.maxHealth}";
        if (idWeapon == 0)
            ammoCountText.text = $"Патроны: бесконечные";
        else
            ammoCountText.text = $"Патроны: {handGun.GetComponent<HandGun>().weapons[idWeapon].ammoCount}";

    }
}
