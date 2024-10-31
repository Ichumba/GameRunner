using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
{

    //[SerializeField] private float _movSpeed;
    public Rigidbody _rb;
     private float _zAxis;
    private float _xAxis;
    //Transform _cameraTransform;
    private Vector3 _dir;

    
    [SerializeField] private float _speed;
    private void Awake()
    {
      //  _cameraTransform = GetComponentInChildren<Camera>().transform;
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");

        Vector3 FowardDirection = transform.forward * _xAxis;
        Vector3 rightDirection =  transform.right * _zAxis;


        if (_zAxis != 0 || _xAxis != 0)
        {
            Movement(_dir);
        
        }
        
    }
    private void Movement(Vector3 dir)
    {
        transform.position += dir * _speed* Time.deltaTime;
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position+= _dir * _speed * Time.fixedDeltaTime);
        
    }

}
