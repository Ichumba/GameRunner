using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ControlManager 
{

    MovementPlayer _movement;
    AmimantionPlayer _animationPlayer;
    public ControlManager(MovementPlayer movement, AmimantionPlayer animation)
    {
        _animationPlayer = animation;
        _movement = movement;
    }

   public void ArtificialUpdate()
    {
        var Vertical = Input.GetAxis("Vertical");
        var Horizontal = Input.GetAxis("Horizontal");

        
        _movement.Move(Vertical, Horizontal);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            Debug.Log("salto");
            _movement.Jump();
            
        }
        

       
    }
    public void Attack(int dmg)
    {

    }
   
}
