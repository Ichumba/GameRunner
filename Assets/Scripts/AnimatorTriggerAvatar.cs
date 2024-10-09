using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTrigger : MonoBehaviour
{
    private AnimatorAvatar _avatar;
    private void Start()
    {
        _avatar = GetComponentInParent<AnimatorAvatar>();

    }
    public void Attack(int dmg)
    {
       print ("realizo" + dmg + "daños");
        
    }
}
