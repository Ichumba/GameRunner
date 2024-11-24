using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    
    
    [SerializeField] public float _movSpeed = 5f;
    private float _xAxis, _zAxis;

    [Header("Audio")]
    [SerializeField] private AudioClip[] _stepClips;

    [Header("Animator")]
    [SerializeField] private string _xAxisName = "xAxis";
    [SerializeField] private string _zAxisName = "zAxis";
    [SerializeField] private string _OnAttack = "OnAttack";
    private Animator animator;
    private Rigidbody _rb;
    private AudioSource _source;
    private AudioClip _selectClip;

   
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()

    {
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        animator = GetComponentInChildren<Animator>();
        _source = GetComponent<AudioSource>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }

        
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
        //print(gameObject.name + " Ataco");
    }
    public void PlaysSFX()
    {
        AudioClip newClip = _stepClips[Random.Range(0, _stepClips.Length)];
        while (newClip == _selectClip)
        {
            newClip = _stepClips[Random.Range(0, _stepClips.Length)];
        }
        _selectClip = newClip;
        _source.clip = _selectClip;
        _source.Play();

    }

}
