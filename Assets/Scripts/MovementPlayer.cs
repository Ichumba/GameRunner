
using System.Collections;
using System.Collections.Generic;

using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class MovementPlayer
{
    
    private Vector3 playerVelocity ;
    private bool _groundPlayer;
    public float JumpForce;
    public float groundDistance = 0.5f;
    private Player _player;
    private Rigidbody _rigidbody;
    Transform _transform;
    float _speed;
    public MovementPlayer(Transform t, float speed)
    {
        _transform = t;
        _speed = speed;  
    }

    
    public void Move(float Vertical, float Horizontal )
    {
       playerVelocity = new Vector3(Horizontal, 0 , Vertical);
        var dir = _transform.forward * Vertical;
        dir += _transform.right * Horizontal; 
        _transform.position += _speed * Time.deltaTime * dir.normalized;
      
    }
   
    public Vector3 GetPlayerVelocity()
    {
        return playerVelocity;      
    }
   
    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        
        return;
    }
    public virtual void FixedUpdate()
    {
      
    }

}
