using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HPbarBoss : MonoBehaviour
{
    public Image BarImage;
    public Text BarText;
    public Gradient Color;

    public BossTaran bossTaran;
    float value;
    void Start()
    {
        BarImage.color = Color.Evaluate(3);
    }

    // Update is called once per frame
    void Update()
    {
        if(bossTaran!= null)
        {
            BarText.text = bossTaran.health + "/" + bossTaran.maxHealth;
            value = ((bossTaran.health * 100f) / bossTaran.maxHealth) / 100f;
            BarImage.fillAmount = value;
            BarImage.color = Color.Evaluate(value);
        }
        
    }
}
