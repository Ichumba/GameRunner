using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public int healthAmount = 20;
    public float duration = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("HealthBoost recogido!");

            IBoostable player = other.GetComponent<IBoostable>();
            if (player != null)
            {
                player.ApplyBoost(BoostType.Health, healthAmount, duration);   
            }

            Destroy(gameObject);
        }
    }
}
