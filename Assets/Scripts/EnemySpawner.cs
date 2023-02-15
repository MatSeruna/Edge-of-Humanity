using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Start()
    {
        StartCoroutine("SpawnEnemy");
    }
    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemies[0], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f, 6f));
        }      
    }
}
