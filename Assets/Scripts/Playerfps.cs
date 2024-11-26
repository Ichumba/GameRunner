using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerFPS : MonoBehaviour, IDamage
{
    [SerializeField] private float _life;
    [SerializeField] private float _maxLife;
    [SerializeField] private float _shield;
    [SerializeField] private Image BarraVida;
    private Vector3 Inicio;
    public UnityEvent death;

    private void Start()
    {
        _life = Mathf.Min(_life, _maxLife);
        _shield = 0;
        Inicio = transform.position;
        UpdateHealthBar();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    public void IncreaseHealth(int amount)
    {
        _life += amount;
        _life = Mathf.Min(_life, _maxLife);
        Debug.Log("Vida actual: " + _life);

        UpdateHealthBar();
    }

    public void ApplyShield(float amount)
    {
        _shield += amount;
        Debug.Log("Escudo actual: " + _shield);
    }

    public void TakeDamage(int damage)
    {
        if (_shield > 0)
        {
            _shield -= damage;
            if (_shield < 0)
            {
                _life += _shield; 
                _shield = 0;
            }
        }
        else
        {
           
            _life -= damage;
        }

        Debug.Log("Vida actual después del daño: " + _life);
        Debug.Log("Escudo actual después del daño: " + _shield);

        
        UpdateHealthBar();

        if (_life <= 0)
        {
            death.Invoke();
            Destroy(gameObject, 0.3f);
        }
    }

    private void UpdateHealthBar()
    {
        if (BarraVida != null)
        {
            BarraVida.fillAmount = _life / _maxLife;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == Layer.OutOfBounds)
        {
            transform.position = Inicio;
            _life -= 10;
        }
    }

}
