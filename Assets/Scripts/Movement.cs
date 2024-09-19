using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(CapsuleCollider))]
public class Movement3D : MonoBehaviour
{
    Vector3 _direction ;
    [SerializeField] float _speed ;
    Rigidbody _rigidbody ;
    CapsuleCollider _capsule;
    [SerializeField] ForceMode _forceMode ;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();   
        _capsule = GetComponent<CapsuleCollider>();
        
    }
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float VerticalAxis = Input.GetAxis("Vertical");
        float HorinzotalAxis = Input.GetAxis("Horizontal");
        float HeightAxis = Input.GetAxis("Height");
        
        Vector3 forwardDirection = transform.forward * VerticalAxis;
        Vector3 rightDirection = transform.right * HorinzotalAxis;
        Vector3 verticalDirection = transform.up * HeightAxis;

        _direction = forwardDirection + rightDirection;
        _direction.Normalize();
        //transform.position += _direction * _speed * Time.deltaTime;
        
    
    }
    private void FixedUpdate()
    {
        // _rigidbody.MovePosition( transform.position + (_speed * _direction * Time.fixedDeltaTime ));
        //_rigidbody.AddForce(_speed * _direction, _forceMode);
        _rigidbody.velocity = _direction * _speed;

    }
}
