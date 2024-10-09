using UnityEngine;
public class Shield : MonoBehaviour
{
    private float strength;

    
    public void InitializeShield(float initialStrength)
    {
        strength = initialStrength;
        gameObject.SetActive(strength > 0);
    }

    
    public void ActivateShield()
    {
        strength = 50f; 
        gameObject.SetActive(true); 
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

     
}
