using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Zombie Variables")]
    public NavMeshAgent agent;
    public float health = 1;
    
    [Space(5)]
    public Transform enemyBody;
    public Transform player;

    [Space(5)]
    public LayerMask whatIsGround, PLAYER;

    GameManager gameManager;

    void Awake()
    {
        player = GameObject.Find("OutsideTruck").transform;
        agent = GetComponent<NavMeshAgent>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        gameManager.EnemyHasAppeared();
        
    }

    void Update()
    {
        Chasing();

    }

    void Chasing()
    {
        enemyBody.LookAt(player);
        agent.SetDestination(player.position);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gameManager.EnemyHasDied();
            
            Invoke(nameof(DestroyEnemy), .01f);
            
        }

    }

    void DestroyEnemy()
    {
        Destroy(gameObject);

    }

}
