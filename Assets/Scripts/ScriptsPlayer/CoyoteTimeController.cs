using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoyoteTimeController : MonoBehaviour
{
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private bool isGrounded;
    private bool jumpInput;
    private Rigidbody2D rb;
    public LayerMask groundLayer1;
    public MovePj MovePj;
    public float groundRaycastLength = 0.2f;

    void Start()
    {
        MovePj = GetComponent<MovePj>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpInput = true;
        }
        
     //   isGrounded = Physics.OverlapSphere(transform.position, 0.1f , );   
        
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (jumpInput && coyoteTimeCounter > 0f)
        {
            
            jumpInput = false;
        }
    }
}
