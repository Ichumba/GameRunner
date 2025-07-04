using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
    public const int Player = 6;
    public const int Floor = 7;
    public const int Pared = 8;
    public const int OutOfBounds = 9;
}
public abstract class Enemy : MonoBehaviour, IDamage
{

    [SerializeField] protected Transform player;
    protected PlayerFPS Jugador;
    protected Rigidbody rb;


    [SerializeField] protected int Life;
    [SerializeField] protected FlyWeight _data;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = PlayerFPS._me;
        Jugador = player.GetComponent<PlayerFPS>();
        PlayerFPS.death += destroy;
    }

    public void TakeDamage(int damage)
    {
        Life -= damage;

        if (Life <= 0)
        {
            destroy();
        }
    }

    void destroy()
    {
        Destroy(gameObject);
    }

    


}

