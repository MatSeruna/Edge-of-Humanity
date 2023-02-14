using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpenPanel : MonoBehaviour
{
    public void CloseOpen()
    {
        if(gameObject.activeSelf)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
