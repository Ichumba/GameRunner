using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPS : MonoBehaviour
{
    [SerializeField] private float _life;
    [SerializeField] private float _maxLife;
    [SerializeField] private float _shield; 

    void Start()
    {
        _life = Mathf.Min(_life, _maxLife);
        _shield = 0;  
    }

    public void IncreaseHealth(int amount)
    {
        _life += amount;
        _life = Mathf.Min(_life, _maxLife);
        Debug.Log("Vida actual: " + _life);
    }

    public void ApplyShield(float amount)
    {
        _shield += amount;
        Debug.Log("Escudo actual: " + _shield);
    }
}
