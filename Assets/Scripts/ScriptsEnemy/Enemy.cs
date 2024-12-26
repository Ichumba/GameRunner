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
    // Tomas Gomez

    [SerializeField] 
    protected int Life;

    [SerializeField] 
    protected int Damage;

    [SerializeField] 
    protected Transform player;

    [SerializeField] 
    protected PlayerFPS Jugador;

    protected WeaponPlayer Arma;
    
    protected Rigidbody rb;

    

    void Start()
    {
        Arma = player.GetComponent<WeaponPlayer>();
        Jugador = player.GetComponent<PlayerFPS>();
        rb = GetComponent<Rigidbody>();
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

