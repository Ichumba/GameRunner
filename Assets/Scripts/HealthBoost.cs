using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public int healthAmount = 20;  

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("HealthBoost recogido!");

            PlayerFPS playerHealth = other.GetComponent<PlayerFPS>();
            if (playerHealth != null)
            {
                ApplyEffect(playerHealth);  
            }

            Destroy(gameObject);   
        }
    }

    public void ApplyEffect(PlayerFPS playerHealth)
    {
        playerHealth.IncreaseHealth(healthAmount);   
    }
}
