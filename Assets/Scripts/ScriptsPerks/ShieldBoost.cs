using UnityEngine;

public class ShieldBoost : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float duration = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ShieldBoost recogido!");

            IBoostable player = other.GetComponent<IBoostable>();
            if (player != null)
            {
                player.ApplyBoost(BoostType.Shield, 50f, duration);   
            }

            Destroy(gameObject);
        }
    }
}
