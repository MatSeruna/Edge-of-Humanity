using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int levelModule;
    public Sprite[] images;
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = images[levelModule];
    }

    public void AddLevelModule()
    {
        levelModule++;
    }
}
