using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 5f;
    public float duration = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IBoostable player = other.GetComponent<IBoostable>();
            if (player != null)
            {
                player.ApplyBoost(BoostType.Speed, boostAmount, duration);
            }
            Destroy(gameObject);
        }
    }
}
