using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    [SerializeField] float shoot;
    [SerializeField] private Bullet bala;

    private bool disparado = false;



    void Update()
    {
        if (disparado == false )
        {
            StartCoroutine(Disparo(shoot));
        }


        if (player == null)
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle+90, Vector3.up);
    }

    IEnumerator Disparo(float Shot)
    {
        disparado = true;
        yield return new WaitForSeconds(Shot);
        Bullet Proyectile = Instantiate(bala, transform.position, transform.rotation* Quaternion.Euler(90f, 0f, 0f));
        Proyectile.damage = Damage;
        Proyectile.PJ = Jugador;
        disparado = false;
    }


}
