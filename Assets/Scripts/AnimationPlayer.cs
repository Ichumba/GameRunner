using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    
    [SerializeField] private float _movSpeed = 5f;
    private float _xAxis, _zAxis;
    [SerializeField] private float _JumpForce = 5f;
    [SerializeField] private float _jumpRayD = .25f;
    [SerializeField] private float _movRayD = 1f;
    [Header("Animator")]
    [SerializeField] private string _xAxisName = "xAxis";
    [SerializeField] private string _zAxisName = "zAxis";
    [SerializeField] private string _OnAttack = "OnAttack";
    private Animator animator;
    private Rigidbody _rb;

    [Header("Physx")]
    [SerializeField] private LayerMask _jumpMask;
    [SerializeField] private LayerMask _movMask;
    [SerializeField] private Vector3 _rayPoffset = new Vector3(0 , 0.75f , 0);
    private Ray _jumpRay, _MovRay;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()

    {
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");
        animator.SetFloat(_xAxisName, _xAxis);
        animator.SetFloat(_zAxisName, _zAxis);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger(_OnAttack);
        }
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            Jump();
        }

        
    }
    private void Jump()
    {
        _rb.AddForce(transform.up * _JumpForce,ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
        if (_xAxis != 0 || _zAxis != 0)
        {
            Movement(_xAxis, _zAxis);
        }
    }
    void Movement(float xAxis, float zAxis)
    {
        Vector3 dir = (transform.right * xAxis + transform.forward * zAxis).normalized;

        _rb.MovePosition(transform.position += _movSpeed * Time.fixedDeltaTime * dir);
    }
    public void OnAttack()
    {
        print(gameObject.name + " Ataco");
    }
    private bool CanJump()
    {
        _jumpRay = new Ray(transform.position + _rayPoffset , -transform.up);
        return Physics.Raycast(_jumpRay, _jumpRayD, _jumpMask);
    }
    private void OnDrawGizmos()
    {
        if (CanJump()) Gizmos.color = Color.green;
        else Gizmos.color = Color.red;
        Gizmos.DrawRay(_jumpRay.origin, _jumpRay.direction * _jumpRayD);
    }
}
