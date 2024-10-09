using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    private float delay;
    [SerializeField] float shoot;
    private Bullet bala;


    private void Start()
    {
        delay = shoot;
    }

    void Update()
    {
        delay -= Time.deltaTime;

        if (delay <= 0)
        {
            disparo();
        }

    }

    private void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    void disparo()
    {
        Bullet bullet =Instantiate(bala, transform.position, transform.rotation);
        bala.damage = Damage;
        delay = shoot;
    }


}
