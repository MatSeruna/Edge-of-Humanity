using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Player player;
    public Weapon weapon;

    public Text healthText;
    public Text ammoCountText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = $"{player.health}/{player.maxHealth}";
        ammoCountText.text = $"Патроны: {weapon.ammoCount}";

    }
}
