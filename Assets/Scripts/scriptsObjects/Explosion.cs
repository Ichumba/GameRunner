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
            ExplotionFactory.Instance.ReturnToPool(this);
        }

    }

    public static void TurnOn(Explosion e)
    {
        e.gameObject.SetActive(true);
    }

    public static void TurnOff(Explosion e)
    {
        e.gameObject.SetActive(false);
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
