using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmimantionPlayer : MonoBehaviour
{
    [SerializeField] private float _movSpeed;
    private bool isJump;
    private Rigidbody _rb;
    private Animator _animator;
    [SerializeField] private string _xAxisName = "xAxis";
    [SerializeField] private string _zAxisName = "zAxis";
    [SerializeField] private string _OnAttack = "OnAttack";
    
    private MovementPlayer _movementPlayer;
    public void UpdatePlayerVelocity(Vector3 Velocity)
    {
        _animator.SetFloat(_xAxisName, Velocity.x);
        _animator.SetFloat(_zAxisName, Velocity.z);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {   
           
            _animator.SetTrigger(_OnAttack);

        }
        
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _animator = GetComponentInChildren<Animator>();
    }
    public void OnAttack()
    {

    }
    
    /*private void Movement(float xAxis, float zAxis)
    {
        Vector3 dir = (transform.right * xAxis + transform.forward * zAxis).normalized;
        _rb.MovePosition(transform.position += dir * _movSpeed * Time.fixedDeltaTime);
    }
    */
}
