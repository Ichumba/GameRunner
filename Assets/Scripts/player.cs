using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class player : MonoBehaviour
{
    Vector3 _direction;
    [SerializeField] float _speed;
    Rigidbody _rigidbody;
    CapsuleCollider _capsuCollider;
    [SerializeField] ForceMode _forceMode;
    [SerializeField] float _jumpForce;
    private bool _wantsToJump;

    Transform _cameraTransform; 
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuCollider = GetComponent<CapsuleCollider>();
        _cameraTransform = GetComponentInChildren<Camera>().transform;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float VerticalAxis = Input.GetAxis("Vertical");
        float HorinzotalAxis = Input.GetAxis("Horizontal");
        

        Vector3 forwardDirection = transform.forward * VerticalAxis;
        Vector3 rightDirection = transform.right * HorinzotalAxis;
        

        _direction = forwardDirection + rightDirection ;
        _direction.Normalize();

        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }


    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;

       
        if (!_wantsToJump)
        {
            jump();
            _wantsToJump = false;
        }

    }
    void jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }
    
}
