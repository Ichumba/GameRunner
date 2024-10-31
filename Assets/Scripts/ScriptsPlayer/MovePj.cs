using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePj : MonoBehaviour
{

    private CharacterController controller;
    public float speed = 5;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public Transform ground;
    public float groundDis = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGround;
    bool isMov;

    private Vector3 lastPos = new Vector3(0, 0, 0);   
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        isGround = Physics.CheckSphere(ground.position, groundDis, groundMask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 Mov = transform.right * x + transform.forward * y;
        controller.Move(speed * Time.deltaTime * Mov);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if (lastPos != gameObject.transform.position && isGround == true)
        {
           isMov = true;
        }
        else
        {
            isMov = false;
        }
        lastPos = gameObject.transform.position;
    }
}
