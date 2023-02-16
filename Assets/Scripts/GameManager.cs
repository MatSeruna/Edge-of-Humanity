using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boss;  
    public GameObject wall;
    public GameObject trigger;
    public GameObject healthBarBoss;
    public EnemySpawner enemySpawner;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject player;

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
        if(boss!= null)
        {
            if (boss.GetComponent<BossTaran>().health <= 0)
            {
                               
                player.GetComponent<Animator>().enabled = false;
                enemySpawner.StopAllCoroutines();
                winPanel.SetActive(true);
            }
        }
        
        if(player != null)
        {
            if (player.GetComponent<Player>().health <= 0)
            {
                
                player.GetComponent<Animator>().enabled = false;
                enemySpawner.StopAllCoroutines();
                losePanel.SetActive(true);
            }
        }
        
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
