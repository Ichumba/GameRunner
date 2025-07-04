using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScreen : MonoBehaviour, IScreen
{
    List<Behaviour> _previousStates;
    
    private void Awake()
    {
        _previousStates = new List<Behaviour>();
    }

    public void Activate()
    {
        foreach (var behaviour in _previousStates)
        {
            behaviour.enabled = true;
        }
        
        _previousStates.Clear();
    }

    public void Deactivate()
    {
        foreach (var behaviour in GetComponentsInChildren<Behaviour>())
        {
            if (!behaviour.enabled) continue;
            
            _previousStates.Add(behaviour);
            
            behaviour.enabled = false;
        }
        
    }

    public void Release()
    {
        Destroy(gameObject);
    }
}
