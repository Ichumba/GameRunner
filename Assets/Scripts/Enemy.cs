using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int Life;
    [SerializeField] protected int Damage;
    [SerializeField] protected Transform player;
    protected WeaponPlayer Arma;
    protected PlayerFPS Jugador;
    protected Rigidbody rb;

    void Start()
    {
        Arma = player.GetComponent<WeaponPlayer>();
        Jugador = player.GetComponent<PlayerFPS>();
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

    protected class Layer
    {
        public const int Player = 6;
    }


}

