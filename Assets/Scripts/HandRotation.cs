using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandRotation : MonoBehaviour
{
    [SerializeField] private float offset;

    Vector3 mousePos = new Vector3();
    float rotateZ;
    private Camera cam;
    
    private void Start()
    {  
        cam = Camera.main; 
    }

    private void Update()
    {
        LookMouse();
    }

    private void LookMouse()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotateZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateZ + offset);
    }
}
