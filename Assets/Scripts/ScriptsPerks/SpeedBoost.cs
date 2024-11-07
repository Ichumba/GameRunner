using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 5f;  
    public float duration = 5f;    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("SpeedBoost recogido!");

            MovePj player = other.GetComponent<MovePj>();
            if (player != null)
            {
                ApplyEffect(player);
            }
        }
    }

    public void ApplyEffect(MovePj player)
    {
        player._speed += boostAmount; 
        StartCoroutine(RemoveEffect(player));  
    }

    private IEnumerator RemoveEffect(MovePj player)
    {
        yield return new WaitForSeconds(duration);   
        player._speed -= boostAmount;  
        Destroy(gameObject);  
    }
}
