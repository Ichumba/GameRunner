using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float JumpF;
    public float groundDistance = 0.5f;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    bool IsGround()
    {
        return Physics.Raycast(transform.position, Vector3.up, groundDistance);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)&& IsGround ()) 
        {
            rb.velocity = Vector3.up * JumpF;
    }

    }
}
