using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMov : MonoBehaviour
{
    [SerializeField] float rotationSens;
    float angle;
    [SerializeField] float minVerRotation;
    [SerializeField] float maxVerRotation;

    
    
    
    public void MovCamera(float vertical)
    {
        angle -= Input.GetAxis("Mouse Y") * rotationSens;
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
        angle = Mathf.Clamp(angle, minVerRotation, maxVerRotation);
    }
}
