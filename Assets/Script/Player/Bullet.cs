using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public int damage = 1;

    void Awake()
    {
        Destroy(gameObject, life);

    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Hit: " + other);  // Test hit
        
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
            
            Destroy(gameObject);

        }
        else if (other.tag == "Scene")
        {
            Destroy(gameObject);

        }
        
    }
    
}
