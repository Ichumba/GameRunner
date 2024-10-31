using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Player : Entity
{
    //[Tooltip("Vida al jugador")]
    public float jumpForce;
    public float speed;
    private Transform Yo;
    private Rigidbody _PlayerRB;
    ControlManager _controls;
    MovementPlayer _movementPlayer;
    
    char[] caracteres;
    private void Start()
    {
        
       
        Yo = GetComponent<Transform>();
        _PlayerRB = GetComponent<Rigidbody>();
        _movementPlayer = new MovementPlayer(Yo, speed);
        _controls = new ControlManager(_movementPlayer,GetComponent<AmimantionPlayer>());
    
    }
   protected override void Update()
    {
        GetComponent<AmimantionPlayer>().UpdatePlayerVelocity(_movementPlayer.GetPlayerVelocity());
        
        _controls.ArtificialUpdate();
    } 
   






}
