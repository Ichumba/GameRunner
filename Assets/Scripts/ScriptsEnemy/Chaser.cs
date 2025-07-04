using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chaser : Enemy
{

    [SerializeField] private float speed;
    [SerializeField] private float distancia = 20;
    private bool cerca = false;
    private bool daño;
    public Animator _animator;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("Run", true);
        
    }

    private void Update()
    {


        if (Vector3.Distance(transform.position, player.position) <= _data.Range)
        {
            cerca = true;
        }
    }

    void FixedUpdate()
    {

        


        if (cerca== true) 
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(-angle + 90f, Vector3.up);

            Quaternion rotation = Quaternion.Euler(0f, rb.rotation.y, 0f);
            rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * (Vector3)(rotation * transform.forward));
        }
       
       
    }

    private IEnumerator Hit()
    {
        daño = false;
        Jugador.TakeDamage(_data.Damage);
        yield return new WaitForSeconds(1);

        daño = true;

    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.layer == Layer.Player && daño == true)
        {
            StartCoroutine(Hit());
            
        }

    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == Layer.Player && daño == true)
        {
            StartCoroutine(Hit());

        }
    }


}
