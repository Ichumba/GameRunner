using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatonAvatar : MonoBehaviour
{
    private AmimantionPlayer _Animation;
    void Start()
    {
        _Animation = GetComponent<AmimantionPlayer>();
    }

    public void OnAttack()
    {
        _Animation.OnAttack();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
