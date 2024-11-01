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

            AnimationPlayer player = other.GetComponent<AnimationPlayer>();
            if (player != null)
            {
                ApplyEffect(player);
            }
        }
    }

    public void ApplyEffect(AnimationPlayer player)
    {
        player._movSpeed += boostAmount; 
        StartCoroutine(RemoveEffect(player));  
    }

    private IEnumerator RemoveEffect(AnimationPlayer player)
    {
        yield return new WaitForSeconds(duration);   
        player._movSpeed -= boostAmount;  
        Destroy(gameObject);  
    }
}
