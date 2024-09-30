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
            Debug.Log("Power-Up recogido!");
            Movement3D player = other.GetComponent<Movement3D>();
            if (player != null)
            {
                ApplyEffect(player);
            }
        }
    }

    public void ApplyEffect(Movement3D player)
    {
        player.speed += boostAmount; 
        StartCoroutine(RemoveEffect(player));
    }

    private IEnumerator RemoveEffect(Movement3D player)
    {
        yield return new WaitForSeconds(duration); 
        player.speed -= boostAmount; 
        Destroy(gameObject); 
    }
}
