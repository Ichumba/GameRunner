using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : Enemy
{
    // Tomas Gomez
    [SerializeField] float shoot;
    [SerializeField] private Bullet bala;
    [SerializeField] private float distancia = 20;
    [SerializeField] private Transform ShootingPoint;
    AudioSource _source;
    private bool disparado = false;



    void Update()
    {
        if (disparado == false && Vector3.Distance(transform.position, player.position) <= distancia)
        {
            StartCoroutine(Disparo(shoot));
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
        Bullet Proyectile = Instantiate(bala, ShootingPoint.position, transform.rotation* Quaternion.Euler(90f, 0f, 0f));
        Proyectile.damage = Damage;
        disparado = false;
    }


}
