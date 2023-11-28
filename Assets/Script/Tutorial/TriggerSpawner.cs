using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    public int ammountOfEnemies;
    public List<Transform> enemySpawnPoints;
    public List<GameObject> enemiesType;

    public bool playerEnter;
    
    void Start()
    {
        playerEnter = false;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !playerEnter)
        {
            playerEnter = true;
            
            for(int e = 0; e < ammountOfEnemies; ++e)
            {
                int spawnIndex = Random.Range(0, enemySpawnPoints.Count);
                int enemyIndex = Random.Range(0, enemiesType.Count);
                // Debug.Log("Number " + (supplySpawnPoints.Count - 1));
                
                // Section
                Vector3 randomPosition = new Vector3(enemySpawnPoints[spawnIndex].transform.position.x, enemySpawnPoints[spawnIndex].transform.position.y, enemySpawnPoints[spawnIndex].transform.position.z);
                
                GameObject enemy = Instantiate(enemiesType[enemyIndex], randomPosition, Quaternion.identity);
                enemy.GetComponent<Enemy>().triggerEnemy = true;
                
            }
        
        }

    }

}
