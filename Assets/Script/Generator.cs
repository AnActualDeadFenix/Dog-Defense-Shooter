using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, IInteractable
{
    public List<Transform> enemySpawnPoints;
    public GameObject enemy;

    float timer;
    float cooldown = 1f;
    bool isCooldown;
    
    bool allowToSpawn;
    bool done;

    void Start()
    {
        allowToSpawn = false;
        done = false;

    }

    void Update()
    {
        if(allowToSpawn)
        {
            StartCoroutine(SpawnEnemies());

        }
        
    }

    IEnumerator SpawnEnemies()
    {
        allowToSpawn = false;

        int spawnIndex = Random.Range(0, enemySpawnPoints.Count);
        // Debug.Log("Number " + (supplySpawnPoints.Count - 1));
        
        // Section
        Vector3 randomPosition = new Vector3(enemySpawnPoints[spawnIndex].transform.position.x, enemySpawnPoints[spawnIndex].transform.position.y, enemySpawnPoints[spawnIndex].transform.position.z);
        
        Instantiate(enemy, randomPosition, Quaternion.identity);

        yield return new WaitForSeconds(1f);
        
        allowToSpawn = true;

    }

    public void Interact()
    {
        allowToSpawn = true;

    }



}
