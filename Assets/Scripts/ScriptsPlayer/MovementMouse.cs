using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementMouse : MonoBehaviour
{
    public float MouseSen = 100f;
    float _xRotate = 0f;
    float _yRotate = 0f;
    void Start()
    {
        //  Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSen * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSen * Time.deltaTime;

        _xRotate -= mouseY;
        _xRotate = Mathf.Clamp(_xRotate, -90f, 90f);
        _yRotate += mouseX;

        transform.localRotation = Quaternion.Euler(_xRotate, _yRotate, 0);
        
        
    }
}
