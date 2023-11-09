using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Truck : MonoBehaviour
{
    public float truckHealth;
    public Text healthText;
    
    void Start()
    {
        truckHealth = 100;
        healthText.text = truckHealth.ToString();
        
    }

    public void UpdateHealth(int amount)
    {
        truckHealth -= amount;
        healthText.text = truckHealth.ToString();

        // Death
        if (truckHealth <= 0)
            GameManager.playerDead = true;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            UpdateHealth(10);
            
            enemyComponent.TakeDamage(100);

        }

    }

}
