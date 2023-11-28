using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, IInteractable
{
    [Header("Round")]
    public GameObject enemies;
    public List<Transform> enemySpawnPoints;

    [SerializeField] private float currentTime;
    [SerializeField] private float startingTime = 0f;
    [SerializeField] private float maxTime = 5f;

    public List<GameObject> doorToOpen;

    bool roundActive;
    bool allowToSpawn;
    bool startCounting;
    bool canOpenDoor;

    void Start()
    {
        currentTime = startingTime;
        
        roundActive = false;
        allowToSpawn = true;
        startCounting = true;
        canOpenDoor = false;

    }

    void Update()
    {
        // If Round has been activated, then...
        if(roundActive)
        {
            // Open Door and return;
            if(canOpenDoor)
            {
                roundActive = false;

                // doorToOpen.GetComponent<Animator>().Play("Opening"); // Open 1 Door
                for (int d = 0; d < doorToOpen.Count; ++d)
                {
                    doorToOpen[d].GetComponent<Animator>().Play("Opening");
                    
                }

                Debug.Log("Round Over");
                return;

            }

            // Spawn Enemies if is allowTo Spawn = true
            if(allowToSpawn)
            {
                allowToSpawn = false;
                StartCoroutine(SpawnEnemies());

            }

            // Start Counting if startCounting = true && the currentTime is less than the maxTime
            if(startCounting && currentTime < maxTime)
            {
                currentTime += 1 * Time.deltaTime;
                // Debug.Log("currentTime: " + currentTime);
                
            }
            // Else stop Counting and let the door open
            else
            {
                startCounting = false;
                canOpenDoor = true;
                
            }

        }
        
    }

    IEnumerator SpawnEnemies()
    {
        int spawnIndex = Random.Range(0, enemySpawnPoints.Count);
        // Debug.Log("Number " + (supplySpawnPoints.Count - 1));
        
        // Section
        Vector3 randomPosition = new Vector3(enemySpawnPoints[spawnIndex].transform.position.x, enemySpawnPoints[spawnIndex].transform.position.y, enemySpawnPoints[spawnIndex].transform.position.z);
        GameObject enemy = Instantiate(enemies, randomPosition, Quaternion.identity);
        enemy.GetComponent<Enemy>().triggerEnemy = false;

        yield return new WaitForSeconds(2f);
        
        allowToSpawn = true;

    }

    public void Interact()
    {
        if(!roundActive && !canOpenDoor)
        {
            Round.show = true;

            roundActive = true;

        }

    }

}
