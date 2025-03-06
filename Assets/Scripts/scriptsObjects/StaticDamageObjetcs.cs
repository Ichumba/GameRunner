using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDamageObjetcs : MonoBehaviour
{

    [SerializeField] int damage;

    private void OnTriggerEnter(Collider col)
    {
        IDamage damages = col.GetComponent<IDamage>();

        if (damages != null)
        {
            damages.TakeDamage(damage);
        }

    }
        
}
