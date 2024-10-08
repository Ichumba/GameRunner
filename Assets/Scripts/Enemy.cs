using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int Life;
    public int Damage;
    [SerializeField] protected Transform player;
    protected WeaponPlayer Arma;
    protected Rigidbody rb;

    void Start()
    {
        Arma = player.GetComponent<WeaponPlayer>();
        rb = GetComponent<Rigidbody>();
    }

    void RecieveDamage()
    {
        Life -= Arma.daño;

        if (Life <= 0)
        {
            Destroy(gameObject);
        }

    }


}

