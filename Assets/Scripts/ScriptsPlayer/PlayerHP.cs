using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float _life;
    [SerializeField] private float _maxLife;
    [SerializeField] private Image BarraVida;

    private void Update()
    {
        //BarraVida.fillAmount = _life / 100;
    }

    public void TakeDamage(int damage)
    {
        _life -= damage;
        if (_life < 0)
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
