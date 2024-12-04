using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePj : MonoBehaviour
{
    [SerializeField] public float _speed = 5f;
    private float _health = 100f;
    bool _isGround = false;
    [SerializeField] private float _JumpForce = 5f;
    [SerializeField] CameraMov _cameraMov;
    Vector3 _direction;

    Transform _cameraTransform;
    Rigidbody _rigidbody;
    CapsuleCollider _capsuleCollider;
    [SerializeField] ForceMode _forceMode;
    bool _CanJump;

    [SerializeField] LayerMask _groudCheckLayer;

    [Header("")]
    [SerializeField] Transform _feet;
    [SerializeField] float _groundDetecRadius = 0.1f;

    public Vector3 _rotate;
    public float sensitivity = .5f;
    Vector3 _cameraForward2D;
    private bool _isBoosting = false;

    public float coyoteTime = 0.2f;
    [SerializeField]private float coyoteTimeCounter;
    public LayerMask Ground;
    public float groundRayLength = 0.3f;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    private void Start() { }

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

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundRayLength, Ground))
        {
            _isGround = true;
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            _isGround = false;
            coyoteTimeCounter -= Time.deltaTime;
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
       
        if (_CanJump && _isGround && coyoteTimeCounter > 0f)
        {
            
            Jump();
            _CanJump = false;
            coyoteTime= 0f;
            
            
        }
        

        Vector3 movement = _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
       
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _isGround ? Color.green : Color.red;
        
        if (_feet)
            Gizmos.DrawSphere(_feet.position, _groundDetecRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRayLength);
    }

    public void ApplyBoost(BoostType boostType, float value, float duration)
    {
        switch (boostType)
        {
            case BoostType.Speed:
                ApplySpeedBoost(value, duration);
                break;
            case BoostType.Shield:
                ApplyShield(value, duration);
                break;
            case BoostType.Health:
                IncreaseHealth((int)value);
                break;
        }
    }

    private void ApplySpeedBoost(float amount, float duration)
    {
        _speed += amount;
        StartCoroutine(RemoveSpeedBoost(amount, duration));
    }

    private IEnumerator RemoveSpeedBoost(float amount, float duration)
    {
        yield return new WaitForSeconds(duration);
        _speed -= amount;
    }

    private void ApplyShield(float strength, float duration)
    {
         
        Debug.Log($"Shield applied with strength {strength} for {duration} seconds.");
    }

    private void IncreaseHealth(int amount)
    {
        _health += amount;
        Debug.Log($"Health increased by {amount}. Current health: {_health}");
    }
}
