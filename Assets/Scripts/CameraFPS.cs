using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFPS : MonoBehaviour
{
    public Vector2 _rotate;
    public float sensitivity = .5f;
    float _MaxCamConeView = 30;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        _rotate.x += Input.GetAxisRaw("Mouse X")* sensitivity ;
        _rotate.y += Input.GetAxisRaw("Mouse Y") * sensitivity ;

        if (Mathf.Abs(_rotate.x) >= 360)
        {
            _rotate.x -= 360 * Mathf.Sign(_rotate.x);
        }
        
        //_rotate.y = Mathf.Clamp(_rotate.y, _MaxCamConeView, _MaxCamConeView);

        transform.localRotation = Quaternion.Euler (-_rotate.y , _rotate.x , 0);
    }
}
