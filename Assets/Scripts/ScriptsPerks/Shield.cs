using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Maria Garat
    private float strength;
    private bool isActive = false;
    private float shieldDuration;
    private float shieldTimer;

     public void InitializeShield(float initialStrength, float duration)
    {
        strength = initialStrength;
        shieldDuration = duration;
        gameObject.SetActive(strength > 0);
        shieldTimer = 0f;  
    }

    public void ActivateShield(float duration)
    {
        strength = 50f; 
        gameObject.SetActive(true);
        shieldDuration = duration; 
        shieldTimer = 0f;   
        isActive = true;
    }

    public void SetStrength(float newStrength)
    {
        strength = newStrength;
        gameObject.SetActive(strength > 0); 
    }

    public void TakeDamage(float damage)
    {
        strength -= damage;
        if (strength <= 0)
        {
            Destroy(gameObject); 
        }
    }

    void Update()
    {
        if (isActive)
        {
            shieldTimer += Time.deltaTime;  
            if (shieldTimer >= shieldDuration)  
            {
                Destroy(gameObject);  
                isActive = false;
            }
        }
    }
}
