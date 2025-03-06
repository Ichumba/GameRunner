using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float delay;
    public int damage;

 
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        IDamage damages = col.GetComponent<IDamage>();

        if (damages != null)
        {
            damages.TakeDamage(damage);
        }

    }

}
