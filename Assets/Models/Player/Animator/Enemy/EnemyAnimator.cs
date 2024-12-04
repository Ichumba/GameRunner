using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    //[SerializeField] public float _movSpeed = 5f;
    private bool run;
    AudioSource _source;
    Rigidbody _rb;
    private Animator _anim;
    [SerializeField] private AudioClip[] _stepClips;
    private AudioClip _selectClip;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _anim = GetComponentInChildren<Animator>();
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Run(bool run)
    {
        _anim.SetBool("run", run);
        _source.Play();
       
    }
    
  

}
