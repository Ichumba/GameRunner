using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePj : MonoBehaviour
{
    
    [SerializeField]
    public float _speed = 5f;
    bool _isGround = false;
    [SerializeField] private float _JumpForce = 5f;
    [SerializeField] CameraMov _cameraMov;
    Vector3 _direction;

    Transform _cameraTransform;
    Rigidbody _rigidbody;
    CapsuleCollider _capsuleCollider;
    [SerializeField]
    ForceMode _forceMode;
    bool _CanJump;

    [SerializeField] LayerMask _groudCheckLayer;

    [Header("")]
    [SerializeField] Transform _feet;
    [SerializeField] float _groundDetecRadius = 0.1f;

    public Vector3 _rotate;
    public float sensitivity = .5f;

    Vector3 _cameraForward2D;
    private bool _isBoosting = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    private void Start()
    {
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _JumpForce, ForceMode.Impulse);
    }

    void Update()
    {
        CameraRot();
        float VerticalAxis = Input.GetAxis("Vertical");
        float HorizontalAxis = Input.GetAxis("Horizontal");
        _cameraForward2D = _cameraTransform.forward;
        _cameraForward2D.y = 0;
        _cameraForward2D.Normalize();

        Vector3 forwardDirection = _cameraForward2D * VerticalAxis;
        Vector3 rightDirection = transform.right * HorizontalAxis;

        _direction = forwardDirection + rightDirection;
        _direction.Normalize();

        if (!_CanJump)
        {
            _CanJump = Input.GetKeyDown(KeyCode.Space);
        }
    }

    void CameraRot()
    {
        _rotate.x += Input.GetAxisRaw("Mouse X") * sensitivity;
        _rotate.y = Input.GetAxisRaw("Mouse Y");

        if (Mathf.Abs(_rotate.x) >= 360)
        {
            _rotate.x -= 360 * Mathf.Sign(_rotate.x);
        }
        transform.localRotation = Quaternion.Euler(0, _rotate.x, 0);
        _cameraMov.MovCamera(_rotate.y);
    }

    private void FixedUpdate()
    {
        Collider[] foundColliders = Physics.OverlapSphere(_feet.position, _groundDetecRadius, _groudCheckLayer);
        _isGround = foundColliders.Length > 0;
        if (_CanJump && _isGround)
        {
            Jump();
            _CanJump = false;
        }

        Vector3 movement = _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _isGround ? Color.green : Color.red;
        if (_feet)
            Gizmos.DrawSphere(_feet.position, _groundDetecRadius);
    }
}
