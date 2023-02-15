using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boss;  
    public GameObject wall;
    public GameObject trigger;
    public GameObject healthBarBoss;
    public EnemySpawner enemySpawner;
    public Camera mainCamera;

    AudioSource audioSource;
    public AudioClip[] audioClips;
    void Start()
    {
        audioSource = mainCamera.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBossBattle()
    {
        boss.SetActive(true);
        healthBarBoss.SetActive(true);
        mainCamera.transform.position = new Vector3(159f, 2.75f, -10f);
        mainCamera.GetComponent<CameraMove>().enabled = false;
        wall.SetActive(true);
        enemySpawner.StopAllCoroutines();

        audioSource.clip = audioClips[1];
        audioSource.Play();
        Destroy(trigger);
    }
}
