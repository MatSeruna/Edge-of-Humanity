using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    public float offsetX = 0f;
    public float offsetY = 2f;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x + offsetX, playerTransform.position.y + offsetY, -10f);
    }
}
