using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMov : MonoBehaviour
{
    //Ignacio Chumba
    [SerializeField] float rotationSens;
    float angle;
    [SerializeField] float minVerRotation;
    [SerializeField] float maxVerRotation;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }


    public void MovCamera(float vertical)
    {
        angle -= Input.GetAxis("Mouse Y") * rotationSens;
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
        angle = Mathf.Clamp(angle, minVerRotation, maxVerRotation);
    }
}
