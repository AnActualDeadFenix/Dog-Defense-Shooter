using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Points")]
    public int points;
    public Text pointsText;

    [Header("Enemy")]
    public int enemyAmount;
    public int enemyLeft;
    public List<GameObject> enemiesType;
    public List<GameObject> enemySpawnPoints;
    List<GameObject> listOfEnemies = new List<GameObject>();
    
    [Space(10)]
    public List<GameObject> supplySpawnPoints;
    public List<GameObject> obstacles;

    [Header("GameOver")]
    public GameObject gameOverScreen;
    public Text finalPointsText;

    public static bool playerDead = false;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    
    void Start()
    {
        playerDead = false;
        gameOverScreen.SetActive(false);
        
        for(int i = 0; i < supplySpawnPoints.Count; ++i)
        {
            supplySpawnPoints[i].SetActive(false);
            
        }

        Round.show = true;

        points = 0;
        pointsText.text = points.ToString();

        SpawnEnemies();
        MakeAppearSupply();

    }

    void Update()
    {
        if(playerDead)
        {
            finalPointsText.text = points.ToString();
            gameOverScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }

    }

    public void EnemyHasDied()
    {
        if(!playerDead)
        {
            --enemyLeft;
            UpdateScore(100);
    
            if(enemyLeft == 0)
            {
                Round.show = true;
                
                UpdateScore(1000);

                // Activate move camera void();

                SpawnEnemies();
                MakeAppearSupply();

            }

        }

    }
 
    public void EnemyHasAppeared()
    {
        ++enemyLeft;

    }

    public void UpdateScore(int amount)
    {
        points += amount;
        pointsText.text = points.ToString();

    }

    public void SpawnEnemies()
    {
        // Check round number
        // Depending change Enemy SpawnPoint
        
        enemyAmount += 3;
        
        
        for (int i = 0; i < enemyAmount; ++i)
        {
            int spawnIndex = Random.Range(0, enemySpawnPoints.Count);
            int enemyIndex = Random.Range(0, enemiesType.Count);
            // Debug.Log("Number " + (supplySpawnPoints.Count - 1));
            
            // Section
            Vector3 randomPosition = new Vector3(enemySpawnPoints[spawnIndex].transform.position.x, 1.5f, enemySpawnPoints[spawnIndex].transform.position.z);
            
            Instantiate(enemiesType[enemyIndex], randomPosition, Quaternion.identity);

        }

    }

    public void MakeAppearSupply()
    {
        for (int i = 0; i < 1; ++i)
        {
            int c = Random.Range (0, supplySpawnPoints.Count);

            supplySpawnPoints[c].SetActive(true);

        }

    }

}
