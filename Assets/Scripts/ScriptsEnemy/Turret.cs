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
        transform.forward = direction.normalized;
    }

    IEnumerator Disparo(float Shot)
    {
        
        disparado = true;
        yield return new WaitForSeconds(Shot);
        var bullet = BulletFactory.Instance.GetFromPool();
        bullet.transform.position = ShootingPoint.position;
        bullet.transform.rotation = ShootingPoint.rotation;
        disparado = false;
    }


}
