using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAttackPlayer : MonoBehaviour
{
    //Ignacio Chumba
    private Animator animator;
    [SerializeField] private string _OnAttack = "OnAttack";
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger(_OnAttack);
        }
    }
    public void Attack(int dmg)
    {
        print(gameObject.name);
        print("realizo" + dmg + "daño");
    }
}
