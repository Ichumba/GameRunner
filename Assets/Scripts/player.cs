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
    public Rigidbody _PlayerRB;
    ControlManager _controls;
    MovementPlayer _movementPlayer;

    char[] caracteres;
    private void Start()
    {
        _PlayerRB = GetComponent<Rigidbody>();
        _movementPlayer = new MovementPlayer(transform, speed);
        _controls = new ControlManager(_movementPlayer,GetComponent<AmimantionPlayer>());
    
    }
   protected override void Update()
    {
        GetComponent<AmimantionPlayer>().UpdatePlayerVelocity(_movementPlayer.GetPlayerVelocity());
        
        _controls.ArtificialUpdate();
    } 
   






}
