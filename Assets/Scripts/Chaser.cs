using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chaser : Enemy
{
    [SerializeField] private float speed;

    // Update is called once per framea
    void FixedUpdate()
    {

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        Quaternion rotation = Quaternion.Euler(0f, rb.rotation.y, 0f);
        //transform.up = direction;
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * (Vector3)(rotation * direction));
    }
}
