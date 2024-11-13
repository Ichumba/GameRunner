using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Chaser : Enemy
{
    [SerializeField] private float speed;
    public Animator _animator;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("Run", true);
    }

    private void Update()
    {
        if (player == null)
        {
            Destroy(this);
        }
    }

    void FixedUpdate()
    {

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle+90f, Vector3.up);

        Quaternion rotation = Quaternion.Euler(0f, rb.rotation.y, 0f);
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * (Vector3)(rotation * transform.forward));
       
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.layer == Layer.Player)
        {
            print("toco");

            Jugador.TakeDamage(Damage);
        }

    }


}
