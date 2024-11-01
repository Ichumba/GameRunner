using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAvatar : MonoBehaviour
{
    private AnimationPlayer playerAvatar;
    void Start()
    {
        playerAvatar = GetComponentInParent<AnimationPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAvatar.OnAttack();
    }
    
}
