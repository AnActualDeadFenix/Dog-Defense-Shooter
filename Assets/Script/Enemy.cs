using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("Zombie Variables")]
    public NavMeshAgent agent;
    public float health = 1;
    public int movementSpeed;
    [Space(5)]

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    
    [Space(5)]
    public Transform enemyBody;
    public Transform playerTrans;
    public Transform targetTrans;
    // bool tutorialBrain;

    [Space(5)]
    public LayerMask whatIsGround, PLAYER;
    [Space(5)]

    public bool allowToChange;
    public bool focusOnPlayer;
    public bool triggerEnemy;   // Only active for triggers in the tutorial

    GameManager gameManager;
    Scene currentScene;

    bool playGrowl;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    void Start()
    {
        // Check that the scene is not the tutorial level
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Level01")
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.EnemyHasAppeared();

        }

        playGrowl = true;
        SetZombieVariables();

    }

    void Update()
    {
        if(playGrowl)
        {
            playGrowl = false;
            StartCoroutine("ZombieSound", 0.01f);

        }
        
        enemyBody.LookAt(playerTrans);
        
        if(focusOnPlayer)
            ChasingPlayer();
        else
            MovingToTarget();   // Generator or Truck

    }

    void ChasingPlayer()
    {
        agent.SetDestination(playerTrans.position);

    }
    void MovingToTarget()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, PLAYER);

        if(playerInSightRange && allowToChange)
        {
            allowToChange = false;
            focusOnPlayer = true;

        }
        else
        {
            agent.SetDestination(targetTrans.position);

        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if(currentScene.name == "Level01")
                gameManager.EnemyHasDied();
            
            Invoke(nameof(DestroyEnemy), 0.01f);
            
        }

    }

    void SetZombieVariables()
    {
        // Set unique enemy speed
        int setSpeed = Random.Range(movementSpeed - 1, movementSpeed + 2);
        agent.speed = setSpeed;

        // Find respective things
        playerTrans = GameObject.Find("Player").transform;

        if(triggerEnemy)
        {
            Debug.Log("Trigger Enemy");
            this.focusOnPlayer = true;       // Only focus on the player
            this.allowToChange = false;

        }
        else
        {
            if(Round.inTutorial)
            {
                Debug.Log("Going to Generator" + Round.roundNum);
                targetTrans = GameObject.Find("Generator" + Round.roundNum).transform;

            }
            else
            {
                Debug.Log("Going to Truck");
                targetTrans = GameObject.Find("Truck").transform;

            }
            
            // Enemy Brain
            int index = Random.Range(1, 4); // 1 o 2 o 3
            
            switch(index)
            {
                case 1:
                    Debug.Log("Focus on the player");
                    this.focusOnPlayer = true;       // Only focus on the player
                    this.allowToChange = false;
                    break;

                case 2:
                    Debug.Log("Focus on the object");
                    this.focusOnPlayer = false;      // Only focus on the object
                    this.allowToChange = false;
                    break;

                case 3:
                    Debug.Log("Allow To Change");
                    this.focusOnPlayer = false;      // Focus on the object
                    this.allowToChange = true;       // but can change to player
                    break;

            }

        }

    }

    private IEnumerator ZombieSound()
    {
        FindObjectOfType<AudioManager>().Play("EnemyGrowl");

        yield return new WaitForSeconds(3f);
        playGrowl = true;

    }

    void DestroyEnemy()
    {
        Destroy(gameObject);

    }

}
