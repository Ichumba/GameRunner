using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBoost : MonoBehaviour
{
    // Maria Garat
    public GameObject shieldPrefab;
    public float duration = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ShieldBoost recogido!");

            AnimationPlayer player = other.GetComponent<AnimationPlayer>();
            if (player != null)
            {
                ApplyEffect(player);
            }

            Destroy(gameObject);  
        }
    }

    public void ApplyEffect(AnimationPlayer player)
    {
        Vector3 shieldPosition = player.transform.position;
        GameObject shieldInstance = Instantiate(shieldPrefab, shieldPosition, Quaternion.identity);
        shieldInstance.transform.SetParent(player.transform);

        Shield shield = shieldInstance.GetComponent<Shield>();
        if (shield != null)
        {
            shield.SetStrength(100f);
            shield.ActivateShield(duration); 
        }

        shieldInstance.transform.localPosition = new Vector3(0, 0.5f, 0);
        shieldInstance.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}

